namespace BehiveDataImporter
{
    partial class UserLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.login = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.authFailed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.login.Location = new System.Drawing.Point(319, 100);
            this.login.Name = "button1";
            this.login.Size = new System.Drawing.Size(94, 29);
            this.login.TabIndex = 0;
            this.login.Text = "Login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.loginClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Name:";
            // 
            // textBox1
            // 
            this.username.Location = new System.Drawing.Point(109, 14);
            this.username.Name = "textBox1";
            this.username.Size = new System.Drawing.Size(214, 27);
            this.username.TabIndex = 2;
            this.username.Text = "SYSTEM";
            this.username.Enabled = false;
            // 
            // textBox2
            // 
            this.password.Location = new System.Drawing.Point(109, 47);
            this.password.Name = "textBox2";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(214, 27);
            this.password.TabIndex = 3;
            this.password.Text = "Pass12!@";
            this.password.Enabled = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.authFailed.AutoSize = true;
            this.authFailed.ForeColor = System.Drawing.Color.Red;
            this.authFailed.Location = new System.Drawing.Point(18, 104);
            this.authFailed.Name = "label3";
            this.authFailed.Size = new System.Drawing.Size(182, 20);
            this.authFailed.TabIndex = 5;
            this.authFailed.Text = "User authentication failed.";
            this.authFailed.Hide();
            // 
            // UserLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 141);
            this.Controls.Add(this.authFailed);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.login);
            this.Name = "UserLogin";
            this.Text = "UserLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label authFailed;
    }
}