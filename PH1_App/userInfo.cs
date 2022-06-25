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
        string connectionString = login.connectionString;
        string username, userID;
        DateTime dateCreated;

        public userInfo()
        {
            InitializeComponent();

            username = listUser.username;
            usernameTextBox.Text = username;

            userID = listUser.userID;
            userIDTextBox.Text = userID;

            dateCreated = listUser.dateCreated;
            dateCreatedPicker.Value = dateCreated;
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
            connection = new OracleConnection(connectionString);
            connection.Open();
            try
            {
                string com = "GRANT " + comboBox3.Text + " ON  \"900001\". " + label1.Text + " TO " + usernameTextBox.Text;
                com += checkBox1.Checked ? "WITH GRANT OPTION" : "";
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Cap quyen thanh cong.", "Thong Bao");
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;
                MessageBox.Show(errorMessage, "Thong Bao");
            }
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection = new OracleConnection(connectionString);
            connection.Open();
            try
            {
                string com = "GRANT " + comboBox4.Text + " ON  \"900001\". " + label8.Text + " TO " + usernameTextBox.Text;
                com += checkBox1.Checked ? "WITH GRANT OPTION" : "";
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Cap quyen thanh cong.", "Thong Bao");
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                MessageBox.Show(errorMessage, "Thong Bao");
            }
            connection.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            connection = new OracleConnection(connectionString);
            connection.Open();
            try
            {
                string com = "GRANT " + comboBox5.Text + " ON  \"900001\". " + label10.Text + " TO " + usernameTextBox.Text;
                com += checkBox3.Checked ? "WITH GRANT OPTION" : "";
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Cap quyen thanh cong.", "Thong Bao");
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                MessageBox.Show(errorMessage, "Thong Bao");
            }
            connection.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            connection = new OracleConnection(connectionString);
            connection.Open();
            try
            {
                string com = "GRANT " + comboBox6.Text + " ON  \"900001\". " + label15.Text + " TO " + usernameTextBox.Text;
                com += checkBox4.Checked ? "WITH GRANT OPTION" : "";
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Cap quyen thanh cong.", "Thong Bao");
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                MessageBox.Show(errorMessage, "Thong Bao");
            }
            connection.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            connection = new OracleConnection(connectionString);
            connection.Open();
            try
            {
                string com = "GRANT " + comboBox7.Text + " ON  \"900001\". " + label17.Text + " TO " + usernameTextBox.Text;
                com += checkBox5.Checked ? "WITH GRANT OPTION" : "";
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Cap quyen thanh cong.", "Thong Bao");
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                MessageBox.Show(errorMessage, "Thong Bao");
            }
            connection.Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            connection = new OracleConnection(connectionString);
            connection.Open();
            try
            {
                string com = "REVOKE " + comboBox3.Text + " ON  \"900001\". " + label1.Text + " FROM " + usernameTextBox.Text;
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Tuoc quyen thanh cong.", "Thong Bao");
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                MessageBox.Show(errorMessage, "Thong Bao");
            }
            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            connection = new OracleConnection(connectionString);
            connection.Open();
            try
            {
                string com = "REVOKE " + comboBox4.Text + " ON  \"900001\". " + label8.Text + " FROM " + usernameTextBox.Text;
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Tuoc quyen thanh cong.", "Thong Bao");
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                MessageBox.Show(errorMessage, "Thong Bao");
            }
            connection.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            connection = new OracleConnection(connectionString);
            connection.Open();
            try
            {
                string com = "REVOKE " + comboBox5.Text + " ON  \"900001\". " + label10.Text + " FROM " + usernameTextBox.Text;
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Tuoc quyen thanh cong.", "Thong Bao");
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                MessageBox.Show(errorMessage, "Thong Bao");
            }
            connection.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            connection = new OracleConnection(connectionString);
            connection.Open();
            try
            {
                string com = "REVOKE " + comboBox6.Text + " ON  \"900001\". " + label15.Text + " FROM " + usernameTextBox.Text;
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Tuoc quyen thanh cong.", "Thong Bao");
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                MessageBox.Show(errorMessage, "Thong Bao");
            }
            connection.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            connection = new OracleConnection(connectionString);
            connection.Open();
            try
            {
                string com = "REVOKE " + comboBox7.Text + " ON  \"900001\". " + label17.Text + " FROM " + usernameTextBox.Text;
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Tuoc quyen thanh cong.", "Thong Bao");
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                MessageBox.Show(errorMessage, "Thong Bao");
            }
            connection.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            connection = new OracleConnection(connectionString);
            connection.Open();
            try
            {
                string com = "GRANT " + comboBox8.Text + " TO " + usernameTextBox.Text;
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Tuoc quyen thanh cong.", "Thong Bao");
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                MessageBox.Show(errorMessage, "Thong Bao");
            }
            connection.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            connection = new OracleConnection(connectionString);
            connection.Open();
            try
            {
                string com = "REVOKE " + comboBox8.Text + " FROM " + usernameTextBox.Text;
                OracleCommand command = new OracleCommand(com, connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Tuoc quyen thanh cong.", "Thong Bao");
            }
            catch (OracleException ex)
            {
                string errorMessage = "Code: " + ex.ErrorCode + "\n" +
                           "Message: " + ex.Message;

                MessageBox.Show(errorMessage, "Thong Bao");
            }
            connection.Close();
        }
    }
}
