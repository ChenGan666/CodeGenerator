using System;
using ZNS.CodeGenerator.Utils;
using ZSN.CodeGenerator;

namespace CodeGenerator
{
    public partial class FormLogin : Form
    {
        public FormMain main;
        public FormLogin(FormMain main)
        {
            this.main = main;
            InitializeComponent();
            comboBox_ServerType.Items.AddRange(ServerType.ServerTypeList);

            if (DBServer.Current != null)
            {
                textBox_Server_IP.Text = DBServer.Current.ServerIp;
                textBox_Server_User.Text = DBServer.Current.ServerUser;
                textBox_Server_PWD.Text = DBServer.Current.ServerPwd;
                comboBox_ServerType.Text = DBServer.Current.ServerType;
                comboBox_Server_DBName.Text = DBServer.Current.ServerDbName;
            }
        }
        private void button_Login_Click(object sender, EventArgs e)
        {
            GetServerInfo();
            DialogResult = DialogResult.OK;
        }

        private void GetServerInfo()
        {
            var server = DBServer.Current;
            server.ServerIp = textBox_Server_IP.Text.Trim();
            server.ServerUser = textBox_Server_User.Text.Trim();
            server.ServerPwd = textBox_Server_PWD.Text.Trim();
            server.ServerType = comboBox_ServerType.Text.Trim();
            server.ServerDbName = comboBox_Server_DBName.Text.Trim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetServerInfo();
            var db = new DbHelper { Server = DBServer.Current };
            try
            {
                var dbNameList = db.GetAllDbName();
                comboBox_Server_DBName.Items.Clear();
                foreach (string dbName in dbNameList)
                {
                    comboBox_Server_DBName.Items.Add(dbName);
                }
                comboBox_Server_DBName.Text = dbNameList.FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}
