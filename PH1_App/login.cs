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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void clickRegister(object sender, LinkLabelLinkClickedEventArgs e)
        {
            register registerForm = new register();
            registerForm.ShowDialog();
        }

        private void clickLogin(object sender, EventArgs e)
        {
            this.Hide();
            homepage homepageForm = new homepage();
            homepageForm.Show();
        }
    }
}
