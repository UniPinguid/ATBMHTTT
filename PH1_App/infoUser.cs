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
using System.Configuration;

namespace PH1_App
{
    public partial class infoUser : Form
    {
        OracleConnection connection;
        string connectionString = login.connectionString;
        string username, userID;
        DateTime dateCreated;

        public infoUser()
        {
            InitializeComponent();

            username = listUser.username;
            usernameTextBox.Text = username;

            userID = listUser.userID;
            userIDTextBox.Text = userID;

            dateCreated = listUser.dateCreated;
            dateCreatedPicker.Value = dateCreated;

            btnSubmit.Hide();
            iconSubmit.Hide();
        }

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
            toggleEditableTextbox(usernameTextBox, true);

        }
        private void clickSubmit(object sender, EventArgs e)
        {
            btnEdit.Show();
            iconEdit.Show();

            btnSubmit.Hide();
            iconSubmit.Hide();

            // Uneditable fields
            toggleEditableTextbox(usernameTextBox, false);

        }

        private void clickGrantPrivileges(object sender, EventArgs e)
        {
            connection = new OracleConnection(connectionString);
            connection.Open();
            string com = "GRANT " + comboBox_privileges.Text + " ON \"900001\"." + comboBox_table.Text + " TO \"" + usernameTextBox.Text + "\"";

            if (checkBox_withGrantOpt.Checked)
            {
                com += " WITH GRANT OPTION";
            }
            try
            {
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Phân quyền thành công.", "Thông báo");
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                MessageBox.Show(errorMessage, "Thong Bao");
            }
            userInfo_Load(sender, e);
            connection.Close();
        }
        private void clickGrantRole(object sender, EventArgs e)
        {
            connection = new OracleConnection(connectionString);
            connection.Open();
            string com = "GRANT " + comboBox_role.Text + " TO \"" + usernameTextBox.Text + "\"";

            if (checkBox_withAdminOpt.Checked)
            {
                com += " WITH ADMIN OPTION";
            }
            try
            {
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Phân quyền vai trò thành công.", "Thông báo");
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                MessageBox.Show(errorMessage, "Thong Bao");
            }

            userInfo_Load(sender, e);
            connection.Close();
        }
        private void clickRevokePrivileges(object sender, EventArgs e)
        {
            connection = new OracleConnection(connectionString);
            connection.Open();
            try
            {
                string com = "REVOKE " + comboBox_privilegesRevoke.Text + " ON TABLE \"900001\"." + comboBox_tableRevoke.Text + " FROM \"" + usernameTextBox.Text + "\"";
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Tước quyền thành công.", "Thong Bao");
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                MessageBox.Show(errorMessage, "Thong Bao");
            }

            userInfo_Load(sender, e);
            connection.Close();
        }
        private void clickRevokeRole(object sender, EventArgs e)
        {
            connection = new OracleConnection(connectionString);
            connection.Open();
            try
            {
                string com = "REVOKE " + comboBox_roleRevoke.Text + " FROM \"" + usernameTextBox.Text + "\"";
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Tước quyền thành công.", "Thong Bao");
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                MessageBox.Show(errorMessage, "Thong Bao");
            }

            userInfo_Load(sender, e);
            connection.Close();
        }

        private void userInfo_Load(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection(connectionString);
            con.Open();

            string querry1 = "Select * from DBA_TAB_PRIVS WHERE grantee = '" + usernameTextBox.Text + "'";
            string querry2 = "Select * from DBA_ROLE_PRIVS WHERE grantee = '" + usernameTextBox.Text + "'";

            OracleCommand cmd1 = new OracleCommand(querry1, con);
            cmd1.CommandType = CommandType.Text;
            OracleDataAdapter adapter1 = new OracleDataAdapter(querry1, con);
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);

            dgv_privileges.DataSource = dt1;
            dgv_privileges.AutoResizeColumns();
            dgv_privileges.AutoResizeRows();

            OracleCommand cmd2 = new OracleCommand(querry2, con);
            cmd2.CommandType = CommandType.Text;
            OracleDataAdapter adapter2 = new OracleDataAdapter(querry2, con);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);

            dgv_roles.DataSource = dt2;
            dgv_roles.AutoResizeColumns();
            dgv_roles.AutoResizeRows();

            con.Close();
        }

    }
}
