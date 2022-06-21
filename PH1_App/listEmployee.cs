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
    public partial class listEmployee : Form
    {
        public listEmployee()
        {
            InitializeComponent();
        }

        // Start of 
        // Transitioning

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
        private void clickListMedRec(object sender, EventArgs e)
        {
            listMedicalRecord listMecRed = new listMedicalRecord();
            listMecRed.Show();
            this.Close();
        }
        private void clickListHF(object sender, EventArgs e)
        {
            listHealthFacility listHFForm = new listHealthFacility();
            listHFForm.Show();
            this.Close();
        }
        private void clickListPatient(object sender, EventArgs e)
        {
            listPatient listPatientForm = new listPatient();
            listPatientForm.Show();
            this.Close();
        }
        private void clickListEmployee(object sender, EventArgs e)
        {
            listEmployee listEmployeeForm = new listEmployee();
            listEmployeeForm.Show();
            this.Close();
        }
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


        // End of
        // Transitioning

        private void clickAddEmployee(object sender, EventArgs e)
        {
            infoEmployee employeeAdd = new infoEmployee();
            infoEmployee.is_add_form = true;
            employeeAdd.Show();
            this.Close();
        }
    }
}
