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
    public partial class audit : Form
    {
        string connectionString = login.connectionString;

        public audit()
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

                tabControl1.Location = new Point(tabControl1.Location.X + 50, tabControl1.Location.Y);
                tabControl1.Size = new Size(tabControl1.Width + 180, tabControl1.Height);
                dataGridView1.Size = new Size(dataGridView1.Width + 180, dataGridView1.Height);
            }
            else
            {
                sidebar.Show();
                toggleSidebarBtn.Location = new Point(toggleSidebarBtn.Location.X + 230, toggleSidebarBtn.Location.Y);
                toggleSidebarBtn.Text = "❮";
                homepage.toggle_sidebar = true;

                tabControl1.Location = new Point(tabControl1.Location.X - 50, tabControl1.Location.Y);
                tabControl1.Size = new Size(tabControl1.Width - 180, tabControl1.Height);
                dataGridView1.Size = new Size(dataGridView1.Width - 180, dataGridView1.Height);
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

        // End of
        // Transitioning

        private void clickSearch(object sender, EventArgs e)
        {
            if (username_textBox.Text == "Tìm kiếm người dùng...")
                username_textBox.Text = "";

            string querry = "SELECT username, action_name, obj_name, timestamp, obj_privilege, grantee, terminal " +
                            "FROM dba_audit_trail " +
                            "WHERE username like '%" + username_textBox.Text + "%' " +
                            "AND timestamp BETWEEN TO_DATE('" + fromDate.Text + "', 'dd/mm/yyyy') AND TO_DATE('" + toDate.Text + "', 'dd/mm/yyyy')";
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

            countResults.Text = "Có " + (dataGridView1.RowCount).ToString() + " dữ liệu nhật ký";
        }

        private void usernameTextBoxClick(object sender, EventArgs e)
        {
            username_textBox.Text = "";
        }

        private void clickDeleteAll(object sender, EventArgs e)
        {

        }
    }
}
