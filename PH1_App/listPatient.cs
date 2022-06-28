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
    public partial class listPatient : Form
    {
        public listPatient()
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

        private void clickAddPatient(object sender, EventArgs e)
        {
            infoPatient patientAdd = new infoPatient();
            infoPatient.is_add_form = true;
            patientAdd.Show();
            this.Close();
        }
    }
}
