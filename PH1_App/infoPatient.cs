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
    public partial class infoPatient : Form
    {
        public static bool is_add_form = false;

        public infoPatient()
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
            toggleEditableTextbox(textBox_hoTen, true);
            toggleEditableTextbox(textBox_cmnd, true);
            toggleEditableTextbox(textBox_ngaySinh, true);
            toggleEditableTextbox(textBox_soNha, true);
            toggleEditableTextbox(textBox_tenDuong, true);
            toggleEditableTextbox(textBox_quanHuyen, true);
            toggleEditableTextbox(textBox_tinhThanh, true);
            toggleEditableTextbox(textBox_tiensu, true);
            toggleEditableTextbox(textBox_tiensuGD, true);
            toggleEditableTextbox(textBox_diUng, true);

        }
        private void clickSubmit(object sender, EventArgs e)
        {
            btnEdit.Show();
            iconEdit.Show();

            btnSubmit.Hide();
            iconSubmit.Hide();

            // Uneditable fields
            toggleEditableTextbox(textBox_maCSYT, false);
            toggleEditableTextbox(textBox_hoTen, false);
            toggleEditableTextbox(textBox_cmnd, false);
            toggleEditableTextbox(textBox_ngaySinh, false);
            toggleEditableTextbox(textBox_soNha, false);
            toggleEditableTextbox(textBox_tenDuong, false);
            toggleEditableTextbox(textBox_quanHuyen, false);
            toggleEditableTextbox(textBox_tinhThanh, false);
            toggleEditableTextbox(textBox_tiensu, false);
            toggleEditableTextbox(textBox_tiensuGD, false);
            toggleEditableTextbox(textBox_diUng, false);
        }

        private void infoPatient_Load(object sender, EventArgs e)
        {
            if (is_add_form == true)
            {
                textBox_maCSYT.Text = "";
                textBox_hoTen.Text = "Nguyễn Văn A";
                textBox_cmnd.Text = "";
                textBox_ngaySinh.Text = "";
                textBox_soNha.Text = "";
                textBox_tenDuong.Text = "";
                textBox_quanHuyen.Text = "";
                textBox_tinhThanh.Text = "";
                textBox_tiensu.Text = "";
                textBox_tiensuGD.Text = "";
                textBox_diUng.Text = "";

                clickEdit(sender, e);
            }
        }
    }
}
