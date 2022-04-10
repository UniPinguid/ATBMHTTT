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
    public partial class listRole : Form
    {
        public listRole()
        {
            InitializeComponent();
        }

        private void clickAdd(object sender, EventArgs e)
        {
            role newRole = new role();
            newRole.Show();
        }
    }
}
