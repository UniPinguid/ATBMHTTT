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
    public partial class listUser : Form
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString + "User Id = system; Password=250317HoangLuc");

        public static string username, userID;

        public static DateTime dateCreated;

        public listUser()
        {
            InitializeComponent();
        }

        private void clickAdd(object sender, EventArgs e)
        {
            createUser user = new createUser();
            user.ShowDialog();
        }

        private void listUser_Load(object sender, EventArgs e)
        {
            string querry = "Select * from all_users";

            OracleCommand cmd = new OracleCommand(querry, con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter adapter = new OracleDataAdapter(querry, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRows();
        }

        private void SearchClick(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            con.Open();
            string querry = "Select * from all_users where USERNAME like '%" + username + "%'";

            OracleCommand cmd = new OracleCommand(querry, con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter adapter = new OracleDataAdapter(querry, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRows();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            userInfo info = new userInfo();
            info.Show();
        }

        private void clickDelete(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc là xóa người dùng này hay không?", "Xóa tài khoản", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string set_script = "alter session set \"_ORACLE_SCRIPT\" = true";
                string querry = "drop user \"" + username + "\"";

                OracleCommand set_script_cmd = new OracleCommand(set_script, con);
                OracleCommand cmd = new OracleCommand(querry, con);
                cmd.CommandType = CommandType.Text;
                try
                {
                    con.Open();
                    set_script_cmd.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa tài khoản thành công!");

                    listUser_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa tài khoản!");
                }

                con.Close();
            }
        }

        private void getUserInfo_click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                username = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                userID = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                dateCreated = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            }
        }
    }
}
