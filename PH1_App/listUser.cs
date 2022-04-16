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
    public partial class listUser : Form
    {
        OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString + "User Id = system; Password=250317HoangLuc");

        public listUser()
        {
            InitializeComponent();
        }

        private void clickAdd(object sender, EventArgs e)
        {
            userInfo user = new userInfo();
            user.Show();
        }

        private void listUser_Load(object sender, EventArgs e)
        {
            con.Open();

        }
    }
}
