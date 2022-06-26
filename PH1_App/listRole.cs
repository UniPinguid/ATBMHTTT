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
        private static bool addBtnClicked = false;
        public listRole()
        {
            InitializeComponent();
        }
        static public bool getAddBtn()
        {
            return addBtnClicked;
        }
        private void clickAdd(object sender, EventArgs e)
        {
            addBtnClicked = true;
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

        static public string getid()
        {
            return id;
        }

        private void clickUser(object sender, EventArgs e)
        {
            listUser user = new listUser();
            user.Show();
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            id = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            // label4.Text = id;
            role roleedit = new role();
            roleedit.Show();
        }

        //private void clickDeleteRole(object sender, EventArgs e)
        //{
        //    OracleConnection con = new OracleConnection(connectionString);

        //    if (button2.Text == "Xoá vai trò")
        //    {
        //        rid = listRole.getid();

        //        string querry = "alter session set \"_ORACLE_SCRIPT\" = true";

        //        OracleCommand cmd = new OracleCommand(querry, con);
        //        con.Open();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.ExecuteNonQuery();
        //        using (OracleConnection connection = con)
        //        using (OracleCommand command = new OracleCommand("dropRole", connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.Add("role_name", OracleDbType.Varchar2).Value = rid;
        //            //connection.Open();
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //    else
        //    {
        //        string querry = "alter session set \"_ORACLE_SCRIPT\" = true";

        //        OracleCommand cmd = new OracleCommand(querry, con);
        //        /* if (conOpen == false)
        //         {
        //             con.Open();
        //             conOpen = true;
        //         }*/

        //        con.Open();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.ExecuteNonQuery();
        //        using (OracleConnection connection = con)
        //        using (OracleCommand command = new OracleCommand("addRole", connection))
        //        {
        //            rid = name_textBox.Text;
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.Add("role_name", OracleDbType.Varchar2).Value = rid;
        //            //connection.Open();
        //            MessageBox.Show(command.CommandText);
        //            //MessageBox.Show(rid);
        //            //command.ExecuteNonQuery();
        //        }
        //    }
        //}
    }
}
