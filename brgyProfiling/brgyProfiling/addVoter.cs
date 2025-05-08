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
    public partial class addVoter : Form
    {
        public addVoter()
        {
            InitializeComponent();
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            // Collect data from input fields
            string voterId = voterID.Text.Trim();
            string residentId = residentID.Text.Trim();
            string registrationDate = registration.Text.Trim();
            string precinctNum = precinctnum.Text.Trim();

            // Validate required fields
            if (string.IsNullOrEmpty(voterId) ||
                string.IsNullOrEmpty(residentId) ||
                string.IsNullOrEmpty(precinctNum))
            {
                MessageBox.Show("Please fill in all required fields (Voter ID, Resident ID, and Precinct Number).",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // SQL query to insert new voter registration
                string query = @"INSERT INTO votersregistration 
                        (voterID, resID, registrationDate, precinctNum) 
                        VALUES 
                        (@voterID, @resID, @registrationDate, @precinctNum)";

                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@voterID", voterId);
                        command.Parameters.AddWithValue("@resID", residentId);
                        command.Parameters.AddWithValue("@registrationDate", registrationDate);
                        command.Parameters.AddWithValue("@precinctNum", this.precinctnum);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Voter registration added successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the data grid view or redirect

                            voterRegistrationForm voterForm = new voterRegistrationForm();
                            voterForm.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add voter registration.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                if (mysqlEx.Number == 1062) // Duplicate entry error
                {
                    MessageBox.Show("Voter ID already exists in the system.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Database error: " + mysqlEx.Message, "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // Ask for confirmation before canceling
            DialogResult result = MessageBox.Show("Are you sure you want to cancel adding a new household?",
                                                "Confirm Cancel",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {


                voterRegistrationForm voter = new voterRegistrationForm();
                voter.Show();
                this.Close();
            }
        }
    }
}
