using BehiveDataImporter.Helper;
using BehiveDataImporter.IOModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace BehiveDataImporter
{
    public partial class Form1 : Form
    {
        public string _connection { get; set; }
        public Form1()
        {
            InitializeComponent();
            _connection = "Server=14.97.10.154;Database=VS_EMPLOYEE;User ID=administrator;Password=admin@123$;";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label1.Text = "Loading Employee details..";
            Console.WriteLine("Hello World!");
            string baseAddress = "https://api.beehivehcm.com";
            string acessToken = string.Empty;
            CommonHelper.LoginBehive(baseAddress);
            string Dt = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["from"] = "01-Aug-2020 10:00:00 AM";
            string queryString = query.ToString();

            string a = CommonHelper.GetRequest(baseAddress, "/api/employee/allnew", queryString);
            Console.WriteLine(a);
            if (a.Contains("fail~"))
            {
                this.label1.Text = "Error fetching data";
            }
            else
            {
                SqlConnection con = new SqlConnection(_connection);
                SqlCommand cmd = new SqlCommand(@"INSERT INTO EMP_TEMP(DATA) VALUES(@data)", con);
                SqlTransaction tran = con.BeginTransaction();
                if (con.State == ConnectionState.Closed) con.Open();
                try
                {
                    var lst = JsonConvert.
                    DeserializeObject<List<Object>>(a);
                    for (int i = 0; i < lst.Count; i++)
                    {
                        cmd.Parameters.Clear();
                        string data = lst[i].ToString();
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@data", data);
                        var result = cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                    con.Close();
                    this.label1.Text = "Success";
                }catch(Exception ex)
                {
                    tran.Rollback();
                    con.Close();
                    Console.WriteLine("Error inserting data into DB: "+ex.ToString());
                    this.label1.Text = "Error inserting data into DB";
                }
            }
            Console.WriteLine(a);
        }
    }
}
