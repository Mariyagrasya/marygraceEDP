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
    public partial class brgyOfficialsForm : Form
    {
        public brgyOfficialsForm()
        {
            InitializeComponent();
            LoadStaffData();
        }
        private void LoadStaffData()
        {
            try
            {
                // SQL query to fetch all data from the staff table
                string query = "SELECT * FROM staffinfo";

                // Use the conn class to establish a connection
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open(); // Ensure the connection is open

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable staffData = new DataTable();
                            adapter.Fill(staffData); // Fill the DataTable with the query result

                            // Bind the data to the DataGridView
                            officialsTableview.DataSource = staffData;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show("Error loading staff data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void brgyOfficialsForm_Load(object sender, EventArgs e)
        {

        }

        private void officialsBtn_Click(object sender, EventArgs e)
        {

            brgyOfficialsForm brgyOfficialsForm = new brgyOfficialsForm();
            brgyOfficialsForm.Show();
            this.Hide();
        }

        private void residentsBtn_Click(object sender, EventArgs e)
        {
            residentsForm resForm = new residentsForm();
            resForm.Show();
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

        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected
                if (officialsTableview.SelectedRows.Count > 0)
                {
                    // Get the selected resident's ID (assuming the primary key is in the first column)
                    string selectedStaffId = officialsTableview.SelectedRows[0].Cells[0].Value.ToString();

                    // Pass the selected resident's ID to the updateresidents form
                    updateOfficials updateForm = new updateOfficials(selectedStaffId);
                    updateForm.ShowDialog();

                    // Refresh the DataGridView after editing
                    LoadStaffData();
                }
                else
                {
                    MessageBox.Show("Please select a staff to edit.", "No Selection",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show("Error editing staff: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void officialsTableview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
