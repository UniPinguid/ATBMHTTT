using System;
using System.Drawing;
using System.Windows.Forms;

namespace PH1_App
{
    public partial class infoHealthFacility : Form
    {
        public static bool is_add_form = false;

        public infoHealthFacility()
        {
            InitializeComponent();

            btnSubmit.Hide();
            iconSubmit.Hide();
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

        private void toggleEditableTextbox(TextBox infoField, bool toggle)
        {
            if (toggle == true)
            {
                infoField.BorderStyle = BorderStyle.Fixed3D;
                infoField.ReadOnly = false;
                infoField.Location = new Point(infoField.Location.X - 3, infoField.Location.Y - 3);
            }
            else
            {
                infoField.BorderStyle = BorderStyle.None;
                infoField.ReadOnly = true;
                infoField.Location = new Point(infoField.Location.X + 3, infoField.Location.Y + 3);
                infoField.BackColor = Color.White;
            }
        }
        private void clickEdit(object sender, EventArgs e)
        {
            btnEdit.Hide();
            iconEdit.Hide();

            btnSubmit.Show();
            iconSubmit.Show();
            btnSubmit.Location = new Point(btnEdit.Location.X, btnEdit.Location.Y);
            iconSubmit.Location = new Point(iconEdit.Location.X, iconEdit.Location.Y);
            iconSubmit.BringToFront();

            // Editable fields
            toggleEditableTextbox(textBox_maCSYT, true);
            toggleEditableTextbox(textBox_tenCSYT, true);
            toggleEditableTextbox(textBox_diaChi, true);
            toggleEditableTextbox(textBox_sdt, true);
            toggleEditableTextbox(textBox_SLNV, true);

        }
        private void clickSubmit(object sender, EventArgs e)
        {
            btnEdit.Show();
            iconEdit.Show();

            btnSubmit.Hide();
            iconSubmit.Hide();

            // Uneditable fields
            toggleEditableTextbox(textBox_maCSYT, false);
            toggleEditableTextbox(textBox_tenCSYT, false);
            toggleEditableTextbox(textBox_diaChi, false);
            toggleEditableTextbox(textBox_sdt, false);
            toggleEditableTextbox(textBox_SLNV, false);
        }

        private void infoHealthFacility_Load(object sender, EventArgs e)
        {
            if (is_add_form == true)
            {
                textBox_maCSYT.Text = "";
                textBox_tenCSYT.Text = "Tỉnh A";
                textBox_diaChi.Text = "";
                textBox_sdt.Text = "";
                textBox_SLNV.Text = "";

                clickEdit(sender, e);
            }
        }
    }
}
