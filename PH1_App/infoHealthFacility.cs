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
            if (login.is_DBA || login.is_GiamDocSo || login.is_GiamDocCSYT)
            {
                dashboard dashboardForm = new dashboard();
                dashboardForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bạn không đủ quyền để thực hiện tính năng này", "Thông báo");
            }
        }

        private void clickListMedRec(object sender, EventArgs e)
        {
            if (login.is_DBA || login.is_ThanhTra || login.is_NghienCuu || login.is_YBacSi || login.is_CoSoYTe)
            {
                listMedicalRecord listMecRed = new listMedicalRecord();
                listMecRed.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Bạn không đủ quyền để thực hiện tính năng này", "Thông báo");
        }
        private void clickListPatient(object sender, EventArgs e)
        {
            if (login.is_DBA || login.is_ThanhTra || login.is_YBacSi || login.is_BenhNhan)
            {
                listPatient patient = new listPatient();
                patient.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Bạn không đủ quyền để thực hiện tính năng này", "Thông báo");
        }
        private void clickListHF(object sender, EventArgs e)
        {
            if (login.is_DBA || login.is_ThanhTra)
            {
                listHealthFacility listHF = new listHealthFacility();
                listHF.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bạn không đủ quyền để thực hiện tính năng này", "Thông báo");
            }
        }
        private void clickListEmployee(object sender, EventArgs e)
        {
            if (login.is_DBA || login.is_ThanhTra || login.is_NhanVien)
            {
                listEmployee listEmpForm = new listEmployee();
                listEmpForm.Show();
                this.Hide();
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
