using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace brgyProfiling
{
    public partial class reportsForm : Form
    {
        public reportsForm()
        {
            InitializeComponent();
            LoadReportsData();
        }
        private void LoadReportsData()
        {
            try
            {
                // SQL query to fetch business permits data
                string query = "SELECT * FROM reports";

                // Use the conn class to establish a connection
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable reportsData = new DataTable();
                            adapter.Fill(reportsData);

                            // Bind the data to the DataGridView
                            reportsTableview.DataSource = reportsData;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message,
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            addReport addReportForm = new addReport();
            addReportForm.Show();
            this.Hide(); 
        }
    }
}
