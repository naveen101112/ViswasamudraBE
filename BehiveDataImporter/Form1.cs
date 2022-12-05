using BehiveDataImporter.Helper;
using BehiveDataImporter.IOModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
            this.loginError.Hide();
            UserLoginModel model = new UserLoginModel();
            UserLogin userLogin = new UserLogin(model);
            userLogin.ShowDialog();
            if (string.IsNullOrEmpty(model.UserName))
            {
                this.loginError.Show();
                return;
            }
            this.label1.Text = "Loading Employee details..";
            Console.WriteLine("Hello World!");
            string baseAddress = "https://api.beehivehcm.com";
            string acessToken = string.Empty;
            CommonHelper.LoginBehive(baseAddress);
            string Dt = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
            var query = HttpUtility.ParseQueryString(string.Empty);
            Console.WriteLine(this.dateTimePicker1.Value);
            query["from"] = this.dateTimePicker1.Text;
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
                if (con.State == ConnectionState.Closed) con.Open();
                //SqlTransaction tran = con.BeginTransaction();
                SqlCommand cmdTrn = new SqlCommand(@$"TRUNCATE TABLE EMP_TEMP", con);
                cmdTrn.ExecuteNonQuery();
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
                    //tran.Commit();
                    con.Close();
                    this.label1.Text = "Success";
                }catch(Exception ex)
                {
                    //tran.Rollback();
                    con.Close();
                    Console.WriteLine("Error inserting data into DB: "+ex.ToString());
                    this.label1.Text = "Error inserting data into DB";
                }
            }
            Console.WriteLine(a);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.loginError.Hide();
            UserLoginModel model = new UserLoginModel();
            UserLogin userLogin = new UserLogin(model);
            userLogin.ShowDialog();
            if (string.IsNullOrEmpty(model.UserName))
            {
                this.loginError.Show();
                return;
            }
            this.label1.Text = "Loading Master Data..";
            string baseAddress = "https://api.beehivehcm.com";
            string acessToken = string.Empty;
            CommonHelper.LoginBehive(baseAddress);
            string Dt = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["from"] = this.dateTimePicker1.Text;
            string queryString = query.ToString();

            string a = CommonHelper.GetRequest(baseAddress, "/api/masterdata/allnew", queryString);
            Console.WriteLine(a);
            if (a.Contains("fail~"))
            {
                this.label1.Text = "Error fetching data";
            }
            else
            {
                var lst = JsonConvert.
                    DeserializeObject<MasterDataResponseModel>(a);

                var typ = typeof(MasterDataResponseModel);

                var bindingFlags = System.Reflection.BindingFlags.Instance |
                            System.Reflection.BindingFlags.NonPublic |
                            System.Reflection.BindingFlags.Public;

                List<string> listNames = lst.GetType().GetFields(bindingFlags).Select(field => field.Name.Replace(">k__BackingField", "").Replace("<", "")).Where(value => value != null).ToList();
                SqlConnection con = new SqlConnection(_connection);
                if (con.State == ConnectionState.Closed) con.Open();
                SqlCommand cmdTrn = new SqlCommand(@$"TRUNCATE TABLE MIGRATION_TEMP", con);
                cmdTrn.ExecuteNonQuery();
                //SqlTransaction tran = con.BeginTransaction();

                SqlConnection con2 = new SqlConnection(_connection);
                if (con2.State == ConnectionState.Closed) con2.Open();


                try
                {
                    foreach (string name in listNames)
                    {
                        Console.WriteLine(name);
                        try
                        {
                            SqlCommand cmdTrn2 = new SqlCommand(@$"TRUNCATE TABLE MIGRATION_TEMP", con2);
                            cmdTrn2.ExecuteNonQuery();

                            SqlCommand cmd = new SqlCommand(@$"INSERT INTO MIGRATION_TEMP(DATA) VALUES(@data)", con);//, tran);
                            SqlCommand cmd1 = new SqlCommand(@$"{name}_Migration", con);//, tran);
                            foreach (object o in ((List<object>)typ.GetProperty(name).GetValue(lst)))
                            {
                                cmd.Parameters.Clear();
                                string data = o.ToString();
                                cmd.CommandType = System.Data.CommandType.Text;
                                cmd.Parameters.AddWithValue("@data", data);
                                var result = cmd.ExecuteNonQuery();
                            }
                            cmd1.Parameters.Clear();
                            cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd1.Parameters.AddWithValue("@User", model.UserName);
                            var result1 = cmd1.ExecuteNonQuery();
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine("Ignored");
                            Console.WriteLine("Error inserting data into DB: " + exc.ToString());
                            this.label1.Text = "Error inserting data into DB";
                        }
                    }
                }catch(Exception exFor)
                {
                  //  tran.Rollback();
                    con.Close();
                }
                //tran.Commit();

                /*if (con.State == ConnectionState.Closed) con.Open();
                tran = con.BeginTransaction();
                foreach (string name in listNames)
                {
                    Console.WriteLine("Calling Procedure for:"+name);
                    try
                    {
                        SqlCommand cmd = new SqlCommand(@$"EXEC Master_Data_Migration @Name=@data, @User=@uid", con, tran);
                        foreach (object o in ((List<object>)typ.GetProperty(name).GetValue(lst)))
                        {
                            cmd.Parameters.Clear();
                            string data = o.ToString();
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.Parameters.AddWithValue("@data", name);
                            cmd.Parameters.AddWithValue("@uid", uid);
                            var result = cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine("Ignored");
                        tran.Rollback();
                        con.Close();
                        Console.WriteLine("Error inserting data into DB: " + exc.ToString());
                        this.label1.Text = "Error inserting data into DB";
                    }
                }*/
                con.Close();

                this.label1.Text = "Success";
            }
            Console.WriteLine(a);
        }
    }
}
