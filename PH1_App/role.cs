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
    public partial class role : Form
    {
        private static string rid = null;
        OracleConnection connection;
        string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString + "User Id = system; Password=1");

        public role()
        {
            InitializeComponent();
        }

        private void S1_check(object sender, EventArgs e)
        {
            col_privilege col = new col_privilege();
            col.Show();
        }

        private void Role_Load(object sender, EventArgs e)
        {
            //code sth here....
            rid = listRole.getid();

            name_textBox.Text = rid;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
                string com = "GRANT " + comboBox1.Text + " ON TABLE " + label11.Text + " TO " + name_textBox.Text;
                com += checkBox2.Checked ? "WITH GRANT OPTION;" : ";";
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch(OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode  + "\n" +
                           "Message: " + ex.Message;

                System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
                log.Source = "Quan ly benh nhan";
                log.WriteEntry(errorMessage);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
                string com = "GRANT " + comboBox2.Text + " ON TABLE " + label12.Text + " TO " + name_textBox.Text;
                com += checkBox3.Checked ? "WITH GRANT OPTION;" : ";";
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
                log.Source = "Quan ly benh nhan";
                log.WriteEntry(errorMessage);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
                string com = "GRANT " + comboBox3.Text + " ON TABLE " + label13.Text + " TO " + name_textBox.Text;
                com += checkBox4.Checked ? "WITH GRANT OPTION;" : ";";
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
                log.Source = "Quan ly benh nhan";
                log.WriteEntry(errorMessage);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
                string com = "GRANT " + comboBox4.Text + " ON TABLE " + label14.Text + " TO " + name_textBox.Text;
                com += checkBox5.Checked ? "WITH GRANT OPTION;" : ";";
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
                log.Source = "Quan ly benh nhan";
                log.WriteEntry(errorMessage);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
                string com = "GRANT " + comboBox5.Text + " ON TABLE " + label2.Text + " TO " + name_textBox.Text;
                com += checkBox1.Checked ? "WITH GRANT OPTION;" : ";";
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
                log.Source = "Quan ly benh nhan";
                log.WriteEntry(errorMessage);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
                string com = "REVOKE " + comboBox5.Text + " ON TABLE " + label2.Text + " FROM " + name_textBox.Text + ";";
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
                log.Source = "Quan ly benh nhan";
                log.WriteEntry(errorMessage);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
                string com = "REVOKE " + comboBox5.Text + " ON TABLE " + label2.Text + " FROM " + name_textBox.Text + ";";
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
                log.Source = "Quan ly benh nhan";
                log.WriteEntry(errorMessage);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
                string com = "REVOKE " + comboBox5.Text + " ON TABLE " + label2.Text + " FROM " + name_textBox.Text + ";";
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
                log.Source = "Quan ly benh nhan";
                log.WriteEntry(errorMessage);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
                string com = "REVOKE " + comboBox5.Text + " ON TABLE " + label2.Text + " FROM " + name_textBox.Text + ";";
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
                log.Source = "Quan ly benh nhan";
                log.WriteEntry(errorMessage);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
                string com = "REVOKE " + comboBox5.Text + " ON TABLE " + label2.Text + " FROM " + name_textBox.Text + ";";
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
                log.Source = "Quan ly benh nhan";
                log.WriteEntry(errorMessage);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        { rid = listRole.getid();
            string querry = "alter session set \"_ORACLE_SCRIPT\" = true";

            OracleCommand cmd = new OracleCommand(querry, con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter adapter = new OracleDataAdapter(querry, con);
            DataTable dt = new DataTable();
            using (OracleConnection connection = con)
            using (OracleCommand command = new OracleCommand("dropRole", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("role_name", OracleDbType.Varchar2).Value = rid;
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
