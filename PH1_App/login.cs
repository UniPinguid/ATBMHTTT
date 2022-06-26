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

        public static bool is_DBA = false;
        public static bool is_GiamDocSo = false;
        public static bool is_GiamDocCSYT = false;
        public static bool is_ThanhTra = false;
        public static bool is_CoSoYTe = false;
        public static bool is_YBacSi = false;
        public static bool is_NghienCuu = false;
        public static bool is_NhanVien = false;
        public static bool is_BenhNhan = false;

            
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

                    checkRole(usernameInput.Text);

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

        private void checkRole(string input)
        {
            OracleConnection con = new OracleConnection(connectionString);
            con.Open();

            string querry = "Select VAITRO, CAPBAC from \"900001\".NHANVIEN WHERE MANV = '" + input + "'";

            OracleCommand cmd = new OracleCommand(querry, con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter adapter1 = new OracleDataAdapter(querry, con);
            DataTable dt = new DataTable();
            adapter1.Fill(dt);

            virtualDGV.DataSource = dt;

            if (input == "900001" || input == "900002" || input == "900003" || input == "900004")
            {
                is_DBA = true;
                return;
            }

            else if (virtualDGV.Rows[0].Cells[0].Value.ToString() == "Thanh tra")
                is_ThanhTra = true;
            else if (virtualDGV.Rows[0].Cells[0].Value.ToString() == "Nghiên cứu")
                is_NghienCuu = true;
            else if (virtualDGV.Rows[0].Cells[0].Value.ToString() == "Cơ sở y tế")
                is_CoSoYTe = true;
            else if (virtualDGV.Rows[0].Cells[0].Value.ToString() == "Y/Bác sĩ")
                is_YBacSi = true;
            
            if (virtualDGV.Rows[0].Cells[0].Value.ToString().Length > 0)
                is_NhanVien = true;
            
            if (virtualDGV.RowCount == 0)
                is_BenhNhan = true;


            if (is_BenhNhan == false)
            {
                if (virtualDGV.Rows[0].Cells[1].Value.ToString() == "Giám đốc sở")
                    is_GiamDocSo = true;
                else if (virtualDGV.Rows[0].Cells[1].Value.ToString() == "Giám đốc cơ sở y tế")
                    is_GiamDocCSYT = true;
            }
            
        }

        private void CheckEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                clickLogin(sender, e);
        }
    }
}
