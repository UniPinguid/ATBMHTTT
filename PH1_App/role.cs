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
using System.Configuration;

namespace PH1_App
{
    public partial class role : Form
    {
        private static string rid = null;
        OracleConnection connection;
        string connectionString = login.connectionString;

        private static bool conOpen = false; 

        public role()
        {
            InitializeComponent();
        }

        private void S1_check(object sender, EventArgs e)
        {
            col_privilege col = new col_privilege();
            col.Show();
        }

        private void Role_Load(object sender, EventArgs e)
        {
            //code sth here....
            if (listRole.getAddBtn() == true)
            {
                // button2.Text = "Thêm vai trò";
            }
            rid = listRole.getid();

            name_textBox.Text = rid;

            OracleConnection con = new OracleConnection(connectionString);
            con.Open();

            string querry = "Select * from ROLE_TAB_PRIVS WHERE ROLE = '" + name_textBox.Text + "'";

            OracleCommand cmd = new OracleCommand(querry, con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter adapter1 = new OracleDataAdapter(querry, con);
            DataTable dt = new DataTable();
            adapter1.Fill(dt);

            dgv_privileges.DataSource = dt;
            dgv_privileges.AutoResizeColumns();
            dgv_privileges.AutoResizeRows();
        }

        private void clickGrantPrivileges(object sender, EventArgs e)
        {
            connection = new OracleConnection(connectionString);
            connection.Open();
            string com = "GRANT " + comboBox_privileges.Text + " ON \"900001\"." + comboBox_table.Text + " TO \"" + name_textBox.Text + "\"";

            try
            {
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Phân quyền thành công.", "Thông báo");
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                MessageBox.Show(errorMessage, "Thong Bao");
            }
            Role_Load(sender, e);
            connection.Close();
        } 
        private void clickRevokePrivileges(object sender, EventArgs e)
        {
            connection = new OracleConnection(connectionString);
            connection.Open();
            try
            {
                string com = "REVOKE " + comboBox_privilegesRevoke.Text + " ON \"900001\"." + comboBox_tableRevoke.Text + " FROM \"" + name_textBox.Text + "\"";
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Tước quyền thành công.", "Thong Bao");
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                MessageBox.Show(errorMessage, "Thong Bao");
            }

            Role_Load(sender, e);
            connection.Close();
        }

        
        /*
        private void button2_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(connectionString);

            if (button2.Text == "Xoá vai trò")
            {
                rid = listRole.getid();

                string querry = "alter session set \"_ORACLE_SCRIPT\" = true";

                OracleCommand cmd = new OracleCommand(querry, con);
                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                using (OracleConnection connection = con)
                using (OracleCommand command = new OracleCommand("dropRole", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("role_name", OracleDbType.Varchar2).Value = rid;
                    //connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            else
            {
                string querry = "alter session set \"_ORACLE_SCRIPT\" = true";
                
                OracleCommand cmd = new OracleCommand(querry, con);
                /* if (conOpen == false)
                 {
                     con.Open();
                     conOpen = true;
                 }*/
                /*
                con.Open();
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                using (OracleConnection connection = con)
                using (OracleCommand command = new OracleCommand("addRole", connection))
                {
                    rid = name_textBox.Text;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("role_name", OracleDbType.Varchar2).Value = rid;
                    //connection.Open();
                    MessageBox.Show(command.CommandText);
                    //MessageBox.Show(rid);
                    //command.ExecuteNonQuery();
                }
            }
        }
        */
    }
}
