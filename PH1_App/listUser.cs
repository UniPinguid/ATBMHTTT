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
    public partial class listUser : Form
    {
        public listUser()
        {
            InitializeComponent();
        }

        private void clickAdd(object sender, EventArgs e)
        {
            userInfo user = new userInfo();
            user.Show();
        }
    }
}
