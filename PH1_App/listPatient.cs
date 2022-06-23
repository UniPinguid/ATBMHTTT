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
    public partial class listPatient : Form
    {
        public listPatient()
        {
            InitializeComponent();
        }

        private void clickHomepage(object sender, EventArgs e)
        {
            homepage homepageForm = new homepage();
            homepageForm.Show();
            this.Close();
        }
        private void clickToggleSidebar(object sender, EventArgs e)
        {
            if (homepage.toggle_sidebar == true)
            {
                sidebar.Hide();
                toggleSidebarBtn.Show();
                toggleSidebarBtn.BringToFront();
                toggleSidebarBtn.Location = new Point(toggleSidebarBtn.Location.X - 230, toggleSidebarBtn.Location.Y);
                toggleSidebarBtn.Text = "❯";
                homepage.toggle_sidebar = false;

            }
            else
            {
                sidebar.Show();
                toggleSidebarBtn.Location = new Point(toggleSidebarBtn.Location.X + 230, toggleSidebarBtn.Location.Y);
                toggleSidebarBtn.Text = "❮";
                homepage.toggle_sidebar = true;
            }
        }
        private void clickDashboard(object sender, EventArgs e)
        {
            this.Hide();
            dashboard dashboardForm = new dashboard();
            dashboardForm.Show();
        }
        private void clickMedRec(object sender, EventArgs e)
        {
            listMedicalRecord mecRed = new listMedicalRecord();
            mecRed.Show();
            this.Close();
        }

        private void clickAddPatient(object sender, EventArgs e)
        {
            infoPatient patientAdd = new infoPatient();
            infoPatient.is_add_form = true;
            patientAdd.Show();
            this.Close();
        }
    }
}