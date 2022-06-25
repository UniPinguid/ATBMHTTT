using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace PH1_App
{
    public partial class login : Form
    {
        public static string connectionString = "Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)" +
            "(HOST = localhost)(PORT = 1521))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = XE)));";
            
        public login()
        {
            InitializeComponent();
        }

        private void clickRegister(object sender, LinkLabelLinkClickedEventArgs e)
        {
            register registerForm = new register();
            registerForm.ShowDialog();
        }

        private void clickLogin(object sender, EventArgs e)
        {
            connectionString += "User ID = " + usernameInput.Text + "; Password = " + passwordInput.Text + ";";
            OracleConnection con = new OracleConnection(connectionString);

            string querry = "SELECT USER FROM DUAL";
            OracleCommand cmd = new OracleCommand(querry, con);

            if (usernameInput.Text == "")
            {
                MessageBox.Show("Xin vui lòng nhập tên đăng nhập", "Thông báo");
            }
            else if (passwordInput.Text == "")
            {
                MessageBox.Show("Xin vui lòng nhập mật khẩu", "Thông báo");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();

                    this.Hide();
                    homepage homepageForm = new homepage();
                    homepageForm.Show();
                }
                catch
                {
                    MessageBox.Show("Xin vui lòng kiểm tra lại tên đăng nhập hoặc mật khẩu", "Đăng nhập không thành công");
                }
            }
        }

        private void CheckEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                clickLogin(sender, e);
        }
    }
}
