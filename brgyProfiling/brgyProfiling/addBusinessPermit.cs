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
    public partial class addBusinessPermit : Form
    {
        public addBusinessPermit()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            // Collect data from input fields
            string permitId = permitID.Text.Trim();
            string businessName = name.Text.Trim();
            string residentId = resID.Text.Trim();
            string registrationDate = reg.Text.Trim();
            string expiryDate = expiry.Text.Trim();

            // Validate required fields
            if (string.IsNullOrEmpty(permitId) ||
                string.IsNullOrEmpty(businessName) ||
                string.IsNullOrEmpty(residentId))
            {
                MessageBox.Show("Please fill in all required fields (Permit ID, Business Name, and Resident ID).",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // SQL query to insert new business permit
                string query = @"INSERT INTO businesspermits 
                        (permitID, businessName, resID, registrationDate, expiryDate) 
                        VALUES 
                        (@permitID, @businessName, @resID, @registrationDate, @expiryDate)";

                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@permitID", permitId);
                        command.Parameters.AddWithValue("@businessName", businessName);
                        command.Parameters.AddWithValue("@resID", residentId);
                        command.Parameters.AddWithValue("@registrationDate", registrationDate);
                        command.Parameters.AddWithValue("@expiryDate", expiryDate);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Business permit added successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh or redirect

                            businessPermitsForm permitsForm = new businessPermitsForm();
                            permitsForm.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add business permit.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                if (mysqlEx.Number == 1062) // Duplicate entry error
                {
                    MessageBox.Show("Permit ID already exists in the system.", "Error",
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


                businessPermitsForm permitsForm = new businessPermitsForm();
                permitsForm.Show();
                this.Close();
            }
        }
    }
}
