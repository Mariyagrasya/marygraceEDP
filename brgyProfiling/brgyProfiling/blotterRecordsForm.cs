using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace brgyProfiling
{
    public partial class blotterRecordsForm : Form
    {
        public blotterRecordsForm()
        {
            InitializeComponent();
        }

        private void residentsBtn_Click(object sender, EventArgs e)
        {
            residentsForm resForm = new residentsForm();
            resForm.Show();
            this.Hide();
        }

        private void officialsBtn_Click(object sender, EventArgs e)
        {

            brgyOfficialsForm brgyOfficialsForm = new brgyOfficialsForm();
            brgyOfficialsForm.Show();
            this.Hide();
        }

        private void householdBtn_Click(object sender, EventArgs e)
        {

            householdForm houseForm = new householdForm();
            houseForm.Show();
            this.Hide();
        }

        private void blotterBtn_Click(object sender, EventArgs e)
        {
            blotterRecordsForm blotterRecordsForm = new blotterRecordsForm();
            blotterRecordsForm.Show();
            this.Hide();
        }

        private void votersBtn_Click(object sender, EventArgs e)
        {

            voterRegistrationForm votersForm = new voterRegistrationForm();
            votersForm.Show();
            this.Hide();
        }

        private void permitsBtn_Click(object sender, EventArgs e)
        {
            businessPermitsForm permitsForm = new businessPermitsForm();
            permitsForm.Show();
            this.Hide();
        }

        private void reportsBtn_Click(object sender, EventArgs e)
        {
            reportsForm reportsForm = new reportsForm();
            reportsForm.Show();
            this.Hide();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                loginForm loginForm = new loginForm();
                loginForm.Show();
                this.Hide();
            }
        }
    }
}
