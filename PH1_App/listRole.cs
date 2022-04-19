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
    public partial class listRole : Form
    {
        private static string id = null;
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public listRole()
        {
            InitializeComponent();
        }

        private void clickAdd(object sender, EventArgs e)
        {
            role newRole = new role();
            newRole.Show();
        }

        private void listRole_Load(object sender, EventArgs e)
        {
            string querry = "Select * from dba_roles";

            OracleCommand cmd = new OracleCommand(querry, con);
            cmd.CommandType = CommandType.Text;
            OracleDataAdapter adapter = new OracleDataAdapter(querry, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns();
            dataGridView1.AutoResizeRows();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            id = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            label4.Text = id;
            role roleedit = new role();
            roleedit.Show();
        }
        static public string getid()
        {
            return id;
        }
    }
}
