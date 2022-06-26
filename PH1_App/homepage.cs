using Oracle.ManagedDataAccess.Client;
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

        string connectionString = login.connectionString;
        int i = 0;

        public homepage()
        {
            InitializeComponent();

            btnSubmit.Hide();
            iconSubmit.Hide();

            if (login.is_NhanVien)
            {
                panel_NV.Show();
                panel_BN.Hide();
            }
            else if (login.is_BenhNhan)
            {
                panel_BN.Show();
                panel_NV.Hide();

                panel_BN.Location = new Point(29, 165);
            }
        }

        // Start of
        // Transitioning

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

        private void clickListMecRed(object sender, EventArgs e)
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
        private void clickPatient(object sender, EventArgs e)
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

            toggleEditableTextbox(textBox_maCSYTBN, true);
            toggleEditableTextbox(textBox_hoTenBN, true);
            toggleEditableTextbox(textBox_cmndBN, true);
            toggleEditableTextbox(textBox_ngaySinhBN, true);
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
            toggleEditableTextbox(textBox_queQuan, false);
            toggleEditableTextbox(textBox_sdt, false);
            toggleEditableTextbox(textBox_csyt, false);
            toggleEditableTextbox(textBox_vaiTro, false);
            toggleEditableTextbox(textBox_chuyenKhoa, false);

            toggleEditableTextbox(textBox_maCSYTBN, false);
            toggleEditableTextbox(textBox_hoTenBN, false);
            toggleEditableTextbox(textBox_cmndBN, false);
            toggleEditableTextbox(textBox_ngaySinhBN, false);
            toggleEditableTextbox(textBox_soNha, false);
            toggleEditableTextbox(textBox_tenDuong, false);
            toggleEditableTextbox(textBox_quanHuyen, false);
            toggleEditableTextbox(textBox_tinhThanh, false);
            toggleEditableTextbox(textBox_tiensu, false);
            toggleEditableTextbox(textBox_tiensuGD, false);
            toggleEditableTextbox(textBox_diUng, false);
        }

        private void homepage_Load(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(connectionString);
            con.Open();

            string querry = "Select * from \"900001\".THONGBAO ORDER BY NGAYGIO DESC";

            OracleCommand cmd = new OracleCommand(querry, con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter adapter1 = new OracleDataAdapter(querry, con);
            DataTable dt = new DataTable();
            adapter1.Fill(dt);

            dataThongBao.DataSource = dt;

            ThoiGianDiaDiem.Text = dataThongBao.Rows[i].Cells[2].Value.ToString() + ", " + dataThongBao.Rows[i].Cells[3].Value.ToString();
            noidungTB.Text = dataThongBao.Rows[i].Cells[1].Value.ToString();
        }

        private void clickTBCu(object sender, EventArgs e)
        {
            if (i >= dataThongBao.RowCount - 2)
                return;
            else
            {
                i++;
                homepage_Load(sender, e);
            }
        }

        private void clickTBMoi(object sender, EventArgs e)
        {
            if (i <= 0)
                return;
            else
            {
                i--;
                homepage_Load(sender, e);
            }
        }
    }
}
