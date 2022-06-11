using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PH1_App
{
    public partial class homepage : Form
    {
        public static bool toggle_sidebar = true;

        public homepage()
        {
            InitializeComponent();
        }

        private void clickToggleSidebar(object sender, EventArgs e)
        {
            if (toggle_sidebar == true)
            {
                sidebar.Hide();
                toggleSidebarBtn.Show();
                toggleSidebarBtn.BringToFront();
                toggleSidebarBtn.Location = new Point(toggleSidebarBtn.Location.X - 230, toggleSidebarBtn.Location.Y);
                toggleSidebarBtn.Text = "❯";
                toggle_sidebar = false;

            }
            else
            {
                sidebar.Show();
                toggleSidebarBtn.Location = new Point(toggleSidebarBtn.Location.X + 230, toggleSidebarBtn.Location.Y);
                toggleSidebarBtn.Text = "❮";
                toggle_sidebar = true;
            }
        }
        private void clickDashboard(object sender, EventArgs e)
        {
            this.Hide();
            dashboard dashboardForm = new dashboard();
            dashboardForm.Show();
        }
        private void clickListMecRed(object sender, EventArgs e)
        {
            listMedicalRecord listMecRed = new listMedicalRecord();
            listMecRed.Show();
            this.Hide();
        }
    }
}
