using BehiveDataImporter.IOModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BehiveDataImporter
{
    public partial class UserLogin : Form
    {
        UserLoginModel _username;
        public UserLogin(UserLoginModel username)
        {
            InitializeComponent();
            _username = username;
        }

        private void loginClick(object sender, EventArgs e)
        {
            this.authFailed.Hide();
            if(this.username.Text.ToUpper() == "SYSTEM" && this.password.Text == "Pass12!@")
            {
                _username.UserName = this.username.Text;
                _username.Password = this.password.Text;
                this.Close();
            }
            else
            {
                this.authFailed.Show();
                _username.UserName = string.Empty;
            }
        }
    }
}
