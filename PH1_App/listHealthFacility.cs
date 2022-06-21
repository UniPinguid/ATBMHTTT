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
    public partial class listHealthFacility : Form
    {
        public listHealthFacility()
        {
            InitializeComponent();
        }

        // Start of 
        // Transitioning

        private void clickHomepage(object sender, EventArgs e)
        {
            homepage homepageForm = new homepage();
            homepageForm.Show();
            this.Close();
        }
        private void clickDashboard(object sender, EventArgs e)
        {
            dashboard dashboardForm = new dashboard();
            dashboardForm.Show();
            this.Close();
        }

        private void clickListMedRec(object sender, EventArgs e)
        {
            listMedicalRecord listMecRed = new listMedicalRecord();
            listMecRed.Show();
            this.Close();
        }
        private void clickToggleSidebar(object sender, EventArgs e)
        {

        }
        private void clickPatient(object sender, EventArgs e)
        {
            listPatient patient = new listPatient();
            patient.Show();
            this.Close();
        }

        private void clickAddHF(object sender, EventArgs e)
        {
            infoHealthFacility addHF = new infoHealthFacility();
            infoHealthFacility.is_add_form = true;
            addHF.Show();
            this.Close();
        }

        // End of
        // Transitioning
    }
}
