using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PH1_App
{
    public partial class createUser : Form
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);


        public createUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string set_script = "alter session set \"_ORACLE_SCRIPT\" = true;";
            string querry = "create user \"" + usernameInput.Text + "\" identified by \"" + passwordInput.Text + "\"";

            OracleCommand set_script_cmd = new OracleCommand(set_script, con);
            OracleCommand cmd = new OracleCommand(querry, con);
            cmd.CommandType = CommandType.Text;
            try
            {
                con.Open();
                set_script_cmd.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Tạo tài khoản thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tạo tài khoản thất bại! Vui lòng xem lại username và password.");
            }

            con.Close();

            /*using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString + "User Id = system; Password=250317HoangLuc"))
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.CommandText = "createUser";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("user_name", OracleType.VarChar).Value = usernameInput.Text;
                objCmd.Parameters.Add("user_passwd", OracleType.VarChar).Value = passwordInput.Text;
                try
                {
                    con.Open();
                    objCmd.ExecuteNonQuery();
                    MessageBox.Show("Tạo tài khoản thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tạo tài khoản thất bại! Vui lòng xem lại username và password.");
                }
                con.Close();
            }
            */
        }
    }
}
