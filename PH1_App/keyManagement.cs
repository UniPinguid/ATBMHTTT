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
    public partial class keyManagement : Form
    {
        public keyManagement()
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
        private void clickEncryption(object sender, EventArgs e)
        {
            encryption encryptionForm = new encryption();
            encryptionForm.Show();
            this.Close();
        }
        private void clickAudit(object sender, EventArgs e)
        {
            audit auditForm = new audit();
            auditForm.Show();
            this.Close();
        }

        private void clickKey(object sender, EventArgs e)
        {
            keyManagement keyForm = new keyManagement();
            keyForm.Show();
            this.Close();
        }




        // End of
        // Transitioning
    }
}
