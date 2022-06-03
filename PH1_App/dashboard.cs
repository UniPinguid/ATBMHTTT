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
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void clickUser(object sender, DataGridViewCellEventArgs e)
        {
            userInfo userInfo = new userInfo();
            userInfo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userInfo userInfo = new userInfo();
            userInfo.Show();
        }

        private void clickRole(object sender, EventArgs e)
        {
            listRole role = new listRole();
            role.Show();
        }

        private void clickUser(object sender, EventArgs e)
        {
            listUser user = new listUser();
            user.Show();
        }
    }
}
