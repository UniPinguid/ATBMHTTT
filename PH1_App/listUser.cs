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
        string connectionString = login.connectionString;
        public static string username, userID;

        public static DateTime dateCreated;

        public listUser()
        {
            InitializeComponent();
        }


        // Start of
        // Transitioning 

        private void clickToggleSidebar(object sender, EventArgs e)
        {
            if (homepage.toggle_sidebar == true)
            {
                sidebar.Hide();
                toggleSidebarBtn.Show();
                toggleSidebarBtn.BringToFront();
                toggleSidebarBtn.Location = new Point(toggleSidebarBtn.Location.X - 230, toggleSidebarBtn.Location.Y);
                toggleSidebarBtn.Text = "❯";

                homepage.toggle_sidebar = false;
            }
            else
            {
                sidebar.Show();
                toggleSidebarBtn.Location = new Point(toggleSidebarBtn.Location.X + 230, toggleSidebarBtn.Location.Y);
                toggleSidebarBtn.Text = "❮";
                homepage.toggle_sidebar = true;
            }
        }

        private void clickHomepage(object sender, EventArgs e)
        {
            homepage homepageForm = new homepage();
            homepageForm.Show();
            this.Close();
        }
        private void clickDashboard(object sender, EventArgs e)
        {
            dashboard dashboardForm = new dashboard();
            dashboardForm.Show();
            this.Close();
        }


        private void clickUser(object sender, EventArgs e)
        {
            listUser user = new listUser();
            user.Show();
        }
        private void clickRole(object sender, EventArgs e)
        {
            listRole role = new listRole();
            role.Show();
        }
        private void clickAudit(object sender, EventArgs e)
        {
            audit auditForm = new audit();
            auditForm.Show();
            this.Close();
        }

        // End of
        // Transitioning

        private void clickAdd(object sender, EventArgs e)
        {
            createUser user = new createUser();
            user.ShowDialog();
        }

        private void listUser_Load(object sender, EventArgs e)
        {
            string querry = "Select * from all_users";
            OracleConnection con = new OracleConnection(connectionString);

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
            OracleConnection con = new OracleConnection(connectionString);
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
            infoUser info = new infoUser();
            info.Show();
        }

        private void clickDelete(object sender, EventArgs e)
        {

            OracleConnection con = new OracleConnection(connectionString); 
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
