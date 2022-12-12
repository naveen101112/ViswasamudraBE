using BehiveDataImporter.Helper;
using BehiveDataImporter.IOModels;
using BehiveDataImporter.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace BehiveDataImporter
{
    public partial class Form1 : Form
    {
        public string _connection { get; set; }
        private Color _black = System.Drawing.Color.Black;
        public Form1()
        {
            InitializeComponent();
        }

        private void resetCheckList()
        {
            this.label1.Text = "";

            Bitmap blankImage = Resources.checkbox;
            this.dataVerifyCheckImage.Image = blankImage;
            this.dataVerifyCheckLabel.ForeColor = _black;

            this.userAuthenticationCheckImage.Image = blankImage;
            this.userAuthenticationCheckLabel.ForeColor = _black;

            this.apiRetriveCheckImage.Image = blankImage;
            this.apiRetriveCheckLabel.ForeColor = _black;

            this.apiRetriveCheckImage.Image = blankImage;
            this.apiRetriveCheckLabel.ForeColor = _black;

            this.tempInsertionCheckImage.Image = blankImage;
            this.tempInsertionCheckLabel.ForeColor = _black;

            this.completedCheckImage.Image = blankImage;
            this.completedCheckLabel.ForeColor = _black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetCheckList();
            this.loginError.Hide();
            string dbUser = this.dbUserName.Text;
            string dbPassword = this.dbPassword.Text;
            string dbUrl = this.dbURL.Text;
            _connection = $"Server={dbUrl};Database=VS_EMPLOYEE;User ID={dbUser};Password={dbPassword};";
            using (SqlConnection con = new SqlConnection(_connection))
            {
                
                try
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                }
                catch (SqlException)
                {
                   this.dataVerifyCheckImage.Image = Resources.cross1;
                   this.dataVerifyCheckLabel.ForeColor = System.Drawing.Color.Red;
                   return;
                }

                this.dbPassword.ReadOnly = true;
                this.dataVerifyCheckImage.Image = Resources.check;
                this.dataVerifyCheckLabel.ForeColor = System.Drawing.Color.Green;

                UserLoginModel model = new UserLoginModel();
                UserLogin userLogin = new UserLogin(model);
                userLogin.ShowDialog();
                if (string.IsNullOrEmpty(model.UserName))
                {
                    this.userAuthenticationCheckImage.Image = Resources.cross1;
                    this.userAuthenticationCheckLabel.ForeColor = System.Drawing.Color.Red;
                    this.loginError.Show();
                    return;
                }
                this.userAuthenticationCheckImage.Image = Resources.check;
                this.userAuthenticationCheckLabel.ForeColor = System.Drawing.Color.Green;

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
                    this.apiRetriveCheckImage.Image = Resources.cross1;
                    this.apiRetriveCheckLabel.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    this.apiRetriveCheckImage.Image = Resources.check;
                    this.apiRetriveCheckLabel.ForeColor = System.Drawing.Color.Green;

                    SqlCommand cmd = new SqlCommand(@"INSERT INTO EMP_TEMP(DATA) VALUES(@data)", con);
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
                        if (lst.Count == 0)
                        {
                            this.label1.Text = "No data found.";
                        }
                        else
                        {
                            this.tempInsertionCheckImage.Image = Resources.check;
                            this.tempInsertionCheckLabel.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                    catch (Exception ex)
                    {
                        //tran.Rollback();
                        con.Close();
                        Console.WriteLine("Error inserting data into DB: " + ex.ToString());
                        this.label1.Text = "Error inserting data into DB";
                        this.tempInsertionCheckImage.Image = Resources.cross1;
                        this.tempInsertionCheckLabel.ForeColor = System.Drawing.Color.Red;
                    }
                }

                Console.WriteLine(a);
                this.completedCheckImage.Image = Resources.check;
                this.completedCheckLabel.ForeColor = System.Drawing.Color.Green;
                this.dbPassword.ReadOnly = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetCheckList();
            this.loginError.Hide();
            string dbUser = this.dbUserName.Text;
            string dbPassword = this.dbPassword.Text;
            string dbUrl = this.dbURL.Text;
            _connection = $"Server={dbUrl};Database=VS_EMPLOYEE;User ID={dbUser};Password={dbPassword};";

            using (SqlConnection con = new SqlConnection(_connection))
            {

                try
                {
                    if (con.State == ConnectionState.Closed) con.Open();
                }
                catch (SqlException)
                {
                    this.dataVerifyCheckImage.Image = Resources.cross1;
                    this.dataVerifyCheckLabel.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                this.dbPassword.ReadOnly = true;
                this.dataVerifyCheckImage.Image = Resources.check;
                this.dataVerifyCheckLabel.ForeColor = System.Drawing.Color.Green;

                UserLoginModel model = new UserLoginModel();
                UserLogin userLogin = new UserLogin(model);
                userLogin.ShowDialog();
                if (string.IsNullOrEmpty(model.UserName))
                {
                    this.userAuthenticationCheckImage.Image = Resources.cross1;
                    this.userAuthenticationCheckLabel.ForeColor = System.Drawing.Color.Red;
                    this.loginError.Show();
                    return;
                }
                this.userAuthenticationCheckImage.Image = Resources.check;
                this.userAuthenticationCheckLabel.ForeColor = System.Drawing.Color.Green;

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
                    this.apiRetriveCheckImage.Image = Resources.cross1;
                    this.apiRetriveCheckLabel.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    this.apiRetriveCheckImage.Image = Resources.check;
                    this.apiRetriveCheckLabel.ForeColor = System.Drawing.Color.Green;

                    var lst = JsonConvert.
                        DeserializeObject<MasterDataResponseModel>(a);

                    var typ = typeof(MasterDataResponseModel);

                    var bindingFlags = System.Reflection.BindingFlags.Instance |
                                System.Reflection.BindingFlags.NonPublic |
                                System.Reflection.BindingFlags.Public;

                    List<string> listNames = lst.GetType().GetFields(bindingFlags).Select(field => field.Name.Replace(">k__BackingField", "").Replace("<", "")).Where(value => value != null).ToList();
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

                                this.label1.Text = "Success";
                                this.tempInsertionCheckImage.Image = Resources.check;
                                this.tempInsertionCheckLabel.ForeColor = System.Drawing.Color.Green;
                            }
                            catch (Exception exc)
                            {
                                Console.WriteLine("Ignored");
                                Console.WriteLine("Error inserting data into DB: " + exc.ToString());
                                this.label1.Text = "Error inserting data into DB";
                                this.tempInsertionCheckImage.Image = Resources.cross1;
                                this.tempInsertionCheckLabel.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                    }
                    catch (Exception exFor)
                    {
                        //  tran.Rollback();
                        con.Close();
                        this.label1.Text = "Error inserting data into DB";
                        this.tempInsertionCheckImage.Image = Resources.cross1;
                        this.tempInsertionCheckLabel.ForeColor = System.Drawing.Color.Red;
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
                }
                Console.WriteLine(a);
                this.completedCheckImage.Image = Resources.check;
                this.completedCheckLabel.ForeColor = System.Drawing.Color.Green;
                this.dbPassword.ReadOnly = false;
            }
        }
    }
}
