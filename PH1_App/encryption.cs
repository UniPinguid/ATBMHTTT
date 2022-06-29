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
    public partial class encryption : Form
    {
        string connectionString = login.connectionString;

        public encryption()
        {
            InitializeComponent();
        }

        // Start of
        // Transitioning
        
        private void clickKey(object sender, EventArgs e)
        {
            keyManagement keyForm = new keyManagement();
            keyForm.Show();
            this.Close();
        }
        
        // End of
        // Transitioning

        private void encryption_Load(object sender, EventArgs e)
        {
            string querry = "SELECT * FROM DBA_ENCRYPTED_COLUMNS";
            OracleConnection con = new OracleConnection(connectionString);

            OracleCommand cmd = new OracleCommand(querry, con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter adapter = new OracleDataAdapter(querry, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();

            dgv_encryption.DataSource = dt;
            dgv_encryption.AutoResizeColumns();
            dgv_encryption.AutoResizeRows();
        }

        private void clickSearch(object sender, EventArgs e)
        {
            string querry = "SELECT * DBA_ENCRYPTED_COLUMNS " +
                            "WHERE OWNER like '%" + textBox_search.Text + "%' " +
                            "OR TABLE_NAME like '%" + textBox_search.Text + "%' " +
                            "OR COLUMN_NAME like '%" + textBox_search.Text + "%'";
            OracleConnection con = new OracleConnection(connectionString);

            OracleCommand cmd = new OracleCommand(querry, con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter adapter = new OracleDataAdapter(querry, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();

            dgv_encryption.DataSource = dt;
            dgv_encryption.AutoResizeColumns();
            dgv_encryption.AutoResizeRows();
        }
    }
}
