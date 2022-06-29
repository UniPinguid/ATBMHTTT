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
    public partial class infoEmployee : Form
    {
        public static bool is_add_form = false;

        public infoEmployee()
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
            toggleEditableTextbox(textBox_queQuan, true);
            toggleEditableTextbox(textBox_sdt, true);
            toggleEditableTextbox(textBox_csyt, true);
            toggleEditableTextbox(textBox_vaiTro, true);
            toggleEditableTextbox(textBox_chuyenKhoa, true);

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
            toggleEditableTextbox(textBox_queQuan, false);
            toggleEditableTextbox(textBox_sdt, false);
            toggleEditableTextbox(textBox_csyt, false);
            toggleEditableTextbox(textBox_vaiTro, false);
            toggleEditableTextbox(textBox_chuyenKhoa, false);
        }

        private void clickSeeHF(object sender, EventArgs e)
        {
            infoHealthFacility infoHF = new infoHealthFacility();
            infoHF.Show();
            this.Close();
        }

        private void infoEmployee_Load(object sender, EventArgs e)
        {
            if (is_add_form == true)
            {
                textBox_maCSYT.Text = "";
                textBox_hoTen.Text = "Nguyễn Văn A";
                textBox_cmnd.Text = "";
                textBox_ngaySinh.Text = "";
                textBox_queQuan.Text = "";
                textBox_sdt.Text = "";
                textBox_csyt.Text = "";
                textBox_vaiTro.Text = "";
                textBox_chuyenKhoa.Text = "";

                clickEdit(sender, e);
            }
        }
    }
}
