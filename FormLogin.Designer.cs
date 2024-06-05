namespace CodeGenerator
{
    partial class FormLogin
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
            button1 = new Button();
            label1 = new Label();
            textBox_Server_IP = new TextBox();
            textBox_Server_User = new TextBox();
            label2 = new Label();
            textBox_Server_PWD = new TextBox();
            label3 = new Label();
            comboBox_Server_DBName = new ComboBox();
            label4 = new Label();
            button_Login = new Button();
            comboBox_ServerType = new ComboBox();
            label5 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(253, 278);
            button1.Margin = new Padding(4, 4, 4, 4);
            button1.Name = "button1";
            button1.Size = new Size(88, 33);
            button1.TabIndex = 0;
            button1.Text = "获取数据库列表";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 28);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(67, 17);
            label1.TabIndex = 1;
            label1.Text = "数据库IP：";
            // 
            // textBox_Server_IP
            // 
            textBox_Server_IP.Location = new Point(14, 51);
            textBox_Server_IP.Margin = new Padding(4, 4, 4, 4);
            textBox_Server_IP.Name = "textBox_Server_IP";
            textBox_Server_IP.Size = new Size(326, 23);
            textBox_Server_IP.TabIndex = 2;
            // 
            // textBox_Server_User
            // 
            textBox_Server_User.Location = new Point(14, 109);
            textBox_Server_User.Margin = new Padding(4, 4, 4, 4);
            textBox_Server_User.Name = "textBox_Server_User";
            textBox_Server_User.Size = new Size(326, 23);
            textBox_Server_User.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 86);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(56, 17);
            label2.TabIndex = 3;
            label2.Text = "用户名：";
            // 
            // textBox_Server_PWD
            // 
            textBox_Server_PWD.Location = new Point(14, 167);
            textBox_Server_PWD.Margin = new Padding(4, 4, 4, 4);
            textBox_Server_PWD.Name = "textBox_Server_PWD";
            textBox_Server_PWD.Size = new Size(326, 23);
            textBox_Server_PWD.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 144);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(44, 17);
            label3.TabIndex = 5;
            label3.Text = "密码：";
            // 
            // comboBox_Server_DBName
            // 
            comboBox_Server_DBName.FormattingEnabled = true;
            comboBox_Server_DBName.Location = new Point(14, 282);
            comboBox_Server_DBName.Margin = new Padding(4, 4, 4, 4);
            comboBox_Server_DBName.Name = "comboBox_Server_DBName";
            comboBox_Server_DBName.Size = new Size(231, 25);
            comboBox_Server_DBName.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 259);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(56, 17);
            label4.TabIndex = 8;
            label4.Text = "数据库：";
            // 
            // button_Login
            // 
            button_Login.Location = new Point(86, 337);
            button_Login.Margin = new Padding(4, 4, 4, 4);
            button_Login.Name = "button_Login";
            button_Login.Size = new Size(88, 33);
            button_Login.TabIndex = 9;
            button_Login.Text = "登录";
            button_Login.UseVisualStyleBackColor = true;
            button_Login.Click += button_Login_Click;
            // 
            // comboBox_ServerType
            // 
            comboBox_ServerType.FormattingEnabled = true;
            comboBox_ServerType.Location = new Point(14, 225);
            comboBox_ServerType.Margin = new Padding(4, 4, 4, 4);
            comboBox_ServerType.Name = "comboBox_ServerType";
            comboBox_ServerType.Size = new Size(231, 25);
            comboBox_ServerType.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 203);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(44, 17);
            label5.TabIndex = 11;
            label5.Text = "类型：";
            // 
            // button2
            // 
            button2.Location = new Point(181, 337);
            button2.Margin = new Padding(4, 4, 4, 4);
            button2.Name = "button2";
            button2.Size = new Size(88, 33);
            button2.TabIndex = 12;
            button2.Text = "取消";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(355, 409);
            Controls.Add(button2);
            Controls.Add(label5);
            Controls.Add(comboBox_ServerType);
            Controls.Add(button_Login);
            Controls.Add(label4);
            Controls.Add(comboBox_Server_DBName);
            Controls.Add(textBox_Server_PWD);
            Controls.Add(label3);
            Controls.Add(textBox_Server_User);
            Controls.Add(label2);
            Controls.Add(textBox_Server_IP);
            Controls.Add(label1);
            Controls.Add(button1);
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "数据库登录";
            FormClosed += FormLogin_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Server_IP;
        private System.Windows.Forms.TextBox textBox_Server_User;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Server_PWD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Server_DBName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.ComboBox comboBox_ServerType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
    }
}
