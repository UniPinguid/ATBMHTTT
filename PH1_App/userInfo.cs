﻿using System;
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
    public partial class userInfo : Form
    {
        public userInfo()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void S1_click(object sender, EventArgs e)
        {
            if (S1.Checked)
            { 
                col_privilege col = new col_privilege();
                col.Show();
            }
        }
    }
}