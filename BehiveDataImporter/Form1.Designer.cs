namespace BehiveDataImporter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.loginError = new System.Windows.Forms.Label();
            this.dbUserName = new System.Windows.Forms.TextBox();
            this.dbPassword = new System.Windows.Forms.TextBox();
            this.dbUserNameLabel = new System.Windows.Forms.Label();
            this.dbPasswordLabel = new System.Windows.Forms.Label();
            this.progressStatusPanel = new System.Windows.Forms.Panel();
            this.completedCheckLabel = new System.Windows.Forms.Label();
            this.completedCheckImage = new System.Windows.Forms.PictureBox();
            this.dataMigrateCheckLabel = new System.Windows.Forms.Label();
            this.dataMigrateCheckImage = new System.Windows.Forms.PictureBox();
            this.tempInsertionCheckLabel = new System.Windows.Forms.Label();
            this.tempInsertionCheckImage = new System.Windows.Forms.PictureBox();
            this.apiRetriveCheckLabel = new System.Windows.Forms.Label();
            this.apiRetriveCheckImage = new System.Windows.Forms.PictureBox();
            this.userAuthenticationCheckLabel = new System.Windows.Forms.Label();
            this.userAuthenticationCheckImage = new System.Windows.Forms.PictureBox();
            this.dataVerifyCheckLabel = new System.Windows.Forms.Label();
            this.dataVerifyCheckImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dbURLLabel = new System.Windows.Forms.Label();
            this.dbURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progressStatusPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.completedCheckImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataMigrateCheckImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempInsertionCheckImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.apiRetriveCheckImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userAuthenticationCheckImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataVerifyCheckImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "Employee";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = ".";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(142, 208);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 52);
            this.button2.TabIndex = 2;
            this.button2.Text = "Master Data";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MMM-yyyy hh:mm:ss tt";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(15, 160);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(250, 27);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // loginError
            // 
            this.loginError.AutoSize = true;
            this.loginError.ForeColor = System.Drawing.Color.Red;
            this.loginError.Location = new System.Drawing.Point(15, 291);
            this.loginError.Name = "loginError";
            this.loginError.Size = new System.Drawing.Size(174, 20);
            this.loginError.TabIndex = 4;
            this.loginError.Text = "Please login to Proceed...";
            this.loginError.Visible = false;
            // 
            // dbUserName
            // 
            this.dbUserName.Location = new System.Drawing.Point(108, 82);
            this.dbUserName.Name = "dbUserName";
            this.dbUserName.Size = new System.Drawing.Size(125, 27);
            this.dbUserName.TabIndex = 5;
            this.dbUserName.Text = "administrator";
            // 
            // dbPassword
            // 
            this.dbPassword.Location = new System.Drawing.Point(108, 114);
            this.dbPassword.Name = "dbPassword";
            this.dbPassword.PasswordChar = '*';
            this.dbPassword.Size = new System.Drawing.Size(125, 27);
            this.dbPassword.TabIndex = 6;
            // 
            // dbUserNameLabel
            // 
            this.dbUserNameLabel.AutoSize = true;
            this.dbUserNameLabel.Location = new System.Drawing.Point(17, 85);
            this.dbUserNameLabel.Name = "dbUserNameLabel";
            this.dbUserNameLabel.Size = new System.Drawing.Size(85, 20);
            this.dbUserNameLabel.TabIndex = 7;
            this.dbUserNameLabel.Text = "User Name:";
            // 
            // dbPasswordLabel
            // 
            this.dbPasswordLabel.AutoSize = true;
            this.dbPasswordLabel.Location = new System.Drawing.Point(17, 121);
            this.dbPasswordLabel.Name = "dbPasswordLabel";
            this.dbPasswordLabel.Size = new System.Drawing.Size(73, 20);
            this.dbPasswordLabel.TabIndex = 8;
            this.dbPasswordLabel.Text = "Password:";
            // 
            // progressStatusPanel
            // 
            this.progressStatusPanel.Controls.Add(this.completedCheckLabel);
            this.progressStatusPanel.Controls.Add(this.completedCheckImage);
            this.progressStatusPanel.Controls.Add(this.dataMigrateCheckLabel);
            this.progressStatusPanel.Controls.Add(this.dataMigrateCheckImage);
            this.progressStatusPanel.Controls.Add(this.tempInsertionCheckLabel);
            this.progressStatusPanel.Controls.Add(this.tempInsertionCheckImage);
            this.progressStatusPanel.Controls.Add(this.apiRetriveCheckLabel);
            this.progressStatusPanel.Controls.Add(this.apiRetriveCheckImage);
            this.progressStatusPanel.Controls.Add(this.userAuthenticationCheckLabel);
            this.progressStatusPanel.Controls.Add(this.userAuthenticationCheckImage);
            this.progressStatusPanel.Controls.Add(this.dataVerifyCheckLabel);
            this.progressStatusPanel.Controls.Add(this.dataVerifyCheckImage);
            this.progressStatusPanel.Location = new System.Drawing.Point(332, 30);
            this.progressStatusPanel.Name = "progressStatusPanel";
            this.progressStatusPanel.Size = new System.Drawing.Size(307, 226);
            this.progressStatusPanel.TabIndex = 9;
            // 
            // completedCheckLabel
            // 
            this.completedCheckLabel.AutoSize = true;
            this.completedCheckLabel.ForeColor = System.Drawing.Color.Black;
            this.completedCheckLabel.Location = new System.Drawing.Point(19, 123);
            this.completedCheckLabel.Name = "completedCheckLabel";
            this.completedCheckLabel.Size = new System.Drawing.Size(86, 20);
            this.completedCheckLabel.TabIndex = 11;
            this.completedCheckLabel.Text = "Completed.";
            // 
            // completedCheckImage
            // 
            this.completedCheckImage.Image = global::BehiveDataImporter.Properties.Resources.checkbox;
            this.completedCheckImage.Location = new System.Drawing.Point(7, 127);
            this.completedCheckImage.Name = "completedCheckImage";
            this.completedCheckImage.Size = new System.Drawing.Size(13, 13);
            this.completedCheckImage.TabIndex = 10;
            this.completedCheckImage.TabStop = false;
            // 
            // dataMigrateCheckLabel
            // 
            this.dataMigrateCheckLabel.AutoSize = true;
            this.dataMigrateCheckLabel.ForeColor = System.Drawing.Color.Black;
            this.dataMigrateCheckLabel.Location = new System.Drawing.Point(19, 102);
            this.dataMigrateCheckLabel.Name = "dataMigrateCheckLabel";
            this.dataMigrateCheckLabel.Size = new System.Drawing.Size(173, 20);
            this.dataMigrateCheckLabel.TabIndex = 9;
            this.dataMigrateCheckLabel.Text = "Migrating data to tables.";
            // 
            // dataMigrateCheckImage
            // 
            this.dataMigrateCheckImage.Image = global::BehiveDataImporter.Properties.Resources.checkbox;
            this.dataMigrateCheckImage.Location = new System.Drawing.Point(7, 106);
            this.dataMigrateCheckImage.Name = "dataMigrateCheckImage";
            this.dataMigrateCheckImage.Size = new System.Drawing.Size(13, 13);
            this.dataMigrateCheckImage.TabIndex = 8;
            this.dataMigrateCheckImage.TabStop = false;
            // 
            // tempInsertionCheckLabel
            // 
            this.tempInsertionCheckLabel.AutoSize = true;
            this.tempInsertionCheckLabel.ForeColor = System.Drawing.Color.Black;
            this.tempInsertionCheckLabel.Location = new System.Drawing.Point(19, 82);
            this.tempInsertionCheckLabel.Name = "tempInsertionCheckLabel";
            this.tempInsertionCheckLabel.Size = new System.Drawing.Size(214, 20);
            this.tempInsertionCheckLabel.TabIndex = 7;
            this.tempInsertionCheckLabel.Text = "Inserting Data into Temp table.";
            // 
            // tempInsertionCheckImage
            // 
            this.tempInsertionCheckImage.Image = global::BehiveDataImporter.Properties.Resources.checkbox;
            this.tempInsertionCheckImage.Location = new System.Drawing.Point(7, 86);
            this.tempInsertionCheckImage.Name = "tempInsertionCheckImage";
            this.tempInsertionCheckImage.Size = new System.Drawing.Size(13, 13);
            this.tempInsertionCheckImage.TabIndex = 6;
            this.tempInsertionCheckImage.TabStop = false;
            // 
            // apiRetriveCheckLabel
            // 
            this.apiRetriveCheckLabel.AutoSize = true;
            this.apiRetriveCheckLabel.ForeColor = System.Drawing.Color.Black;
            this.apiRetriveCheckLabel.Location = new System.Drawing.Point(19, 58);
            this.apiRetriveCheckLabel.Name = "apiRetriveCheckLabel";
            this.apiRetriveCheckLabel.Size = new System.Drawing.Size(195, 20);
            this.apiRetriveCheckLabel.TabIndex = 5;
            this.apiRetriveCheckLabel.Text = "Retrieved Data from Behive.";
            // 
            // apiRetriveCheckImage
            // 
            this.apiRetriveCheckImage.Image = global::BehiveDataImporter.Properties.Resources.checkbox;
            this.apiRetriveCheckImage.Location = new System.Drawing.Point(7, 62);
            this.apiRetriveCheckImage.Name = "apiRetriveCheckImage";
            this.apiRetriveCheckImage.Size = new System.Drawing.Size(13, 13);
            this.apiRetriveCheckImage.TabIndex = 4;
            this.apiRetriveCheckImage.TabStop = false;
            // 
            // userAuthenticationCheckLabel
            // 
            this.userAuthenticationCheckLabel.AutoSize = true;
            this.userAuthenticationCheckLabel.ForeColor = System.Drawing.Color.Black;
            this.userAuthenticationCheckLabel.Location = new System.Drawing.Point(19, 38);
            this.userAuthenticationCheckLabel.Name = "userAuthenticationCheckLabel";
            this.userAuthenticationCheckLabel.Size = new System.Drawing.Size(138, 20);
            this.userAuthenticationCheckLabel.TabIndex = 3;
            this.userAuthenticationCheckLabel.Text = "User Authenticated.";
            // 
            // userAuthenticationCheckImage
            // 
            this.userAuthenticationCheckImage.Image = global::BehiveDataImporter.Properties.Resources.checkbox;
            this.userAuthenticationCheckImage.Location = new System.Drawing.Point(7, 42);
            this.userAuthenticationCheckImage.Name = "userAuthenticationCheckImage";
            this.userAuthenticationCheckImage.Size = new System.Drawing.Size(13, 13);
            this.userAuthenticationCheckImage.TabIndex = 2;
            this.userAuthenticationCheckImage.TabStop = false;
            // 
            // dataVerifyCheckLabel
            // 
            this.dataVerifyCheckLabel.AutoSize = true;
            this.dataVerifyCheckLabel.ForeColor = System.Drawing.Color.Black;
            this.dataVerifyCheckLabel.Location = new System.Drawing.Point(19, 15);
            this.dataVerifyCheckLabel.Name = "dataVerifyCheckLabel";
            this.dataVerifyCheckLabel.Size = new System.Drawing.Size(130, 20);
            this.dataVerifyCheckLabel.TabIndex = 1;
            this.dataVerifyCheckLabel.Text = "Verified Database.";
            // 
            // dataVerifyCheckImage
            // 
            this.dataVerifyCheckImage.Image = global::BehiveDataImporter.Properties.Resources.checkbox;
            this.dataVerifyCheckImage.Location = new System.Drawing.Point(7, 19);
            this.dataVerifyCheckImage.Name = "dataVerifyCheckImage";
            this.dataVerifyCheckImage.Size = new System.Drawing.Size(13, 13);
            this.dataVerifyCheckImage.TabIndex = 0;
            this.dataVerifyCheckImage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dbURLLabel);
            this.panel1.Controls.Add(this.dbURL);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 137);
            this.panel1.TabIndex = 10;
            // 
            // dbURLLabel
            // 
            this.dbURLLabel.AutoSize = true;
            this.dbURLLabel.Location = new System.Drawing.Point(5, 42);
            this.dbURLLabel.Name = "dbURLLabel";
            this.dbURLLabel.Size = new System.Drawing.Size(38, 20);
            this.dbURLLabel.TabIndex = 1;
            this.dbURLLabel.Text = "URL:";
            this.dbURLLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dbURL
            // 
            this.dbURL.Location = new System.Drawing.Point(96, 39);
            this.dbURL.Name = "dbURL";
            this.dbURL.Size = new System.Drawing.Size(125, 27);
            this.dbURL.TabIndex = 0;
            this.dbURL.Text = "14.97.10.154";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(0, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Database Credentials";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 365);
            this.Controls.Add(this.progressStatusPanel);
            this.Controls.Add(this.dbPasswordLabel);
            this.Controls.Add(this.dbUserNameLabel);
            this.Controls.Add(this.dbPassword);
            this.Controls.Add(this.dbUserName);
            this.Controls.Add(this.loginError);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "BehiveDataImporter";
            this.progressStatusPanel.ResumeLayout(false);
            this.progressStatusPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.completedCheckImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataMigrateCheckImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempInsertionCheckImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.apiRetriveCheckImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userAuthenticationCheckImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataVerifyCheckImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label loginError;
        private System.Windows.Forms.TextBox dbUserName;
        private System.Windows.Forms.TextBox dbPassword;
        private System.Windows.Forms.Label dbUserNameLabel;
        private System.Windows.Forms.Label dbPasswordLabel;
        private System.Windows.Forms.Panel progressStatusPanel;
        private System.Windows.Forms.Label completedCheckLabel;
        private System.Windows.Forms.PictureBox completedCheckImage;
        private System.Windows.Forms.Label dataMigrateCheckLabel;
        private System.Windows.Forms.PictureBox dataMigrateCheckImage;
        private System.Windows.Forms.Label tempInsertionCheckLabel;
        private System.Windows.Forms.PictureBox tempInsertionCheckImage;
        private System.Windows.Forms.Label apiRetriveCheckLabel;
        private System.Windows.Forms.PictureBox apiRetriveCheckImage;
        private System.Windows.Forms.Label userAuthenticationCheckLabel;
        private System.Windows.Forms.PictureBox userAuthenticationCheckImage;
        private System.Windows.Forms.Label dataVerifyCheckLabel;
        private System.Windows.Forms.PictureBox dataVerifyCheckImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label dbURLLabel;
        private System.Windows.Forms.TextBox dbURL;
        private System.Windows.Forms.Label label2;
    }
}
