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
    public partial class userInfo : Form
    {
        OracleConnection connection;
        string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public userInfo()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        //private void S1_click(object sender, EventArgs e)
        //{
        //    if (S1.Checked)
        //    { 
        //        col_privilege col = new col_privilege();
        //        col.Show();
        //    }
        //}

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
                string com = "GRANT " + comboBox3.Text + " ON TABLE " + label1.Text + " TO " + name_textBox.Text;
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
                string com = "GRANT " + comboBox4.Text + " ON TABLE " + label8.Text + " TO " + name_textBox.Text;
                com += checkBox2.Checked ? "WITH GRANT OPTION;" : ";";
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
                string com = "GRANT " + comboBox5.Text + " ON TABLE " + label10.Text + " TO " + name_textBox.Text;
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

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
                string com = "GRANT " + comboBox6.Text + " ON TABLE " + label15.Text + " TO " + name_textBox.Text;
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

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
                string com = "GRANT " + comboBox7.Text + " ON TABLE " + label17.Text + " TO " + name_textBox.Text;
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

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
                string com = "REVOKE " + comboBox3.Text + " ON TABLE " + label1.Text + " FROM " + name_textBox.Text + ";";
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
                string com = "REVOKE " + comboBox4.Text + " ON TABLE " + label8.Text + " FROM " + name_textBox.Text + ";";
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
                string com = "REVOKE " + comboBox5.Text + " ON TABLE " + label10.Text + " FROM " + name_textBox.Text + ";";
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
                string com = "REVOKE " + comboBox6.Text + " ON TABLE " + label15.Text + " FROM " + name_textBox.Text + ";";
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
                string com = "REVOKE " + comboBox7.Text + " ON TABLE " + label17.Text + " FROM " + name_textBox.Text + ";";
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

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
                string com = "GRANT " + comboBox8.Text + " TO " + name_textBox.Text + ";";
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

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new OracleConnection(connectionString);
                connection.Open();
                string com = "REVOKE " + comboBox8.Text + " FROM " + name_textBox.Text + ";";
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
    }
}
