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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace brgyProfiling
{
    public partial class addHousehold : Form
    {
        public addHousehold()
        {
            InitializeComponent();
        }

        private void householdID_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void purok_TextChanged(object sender, EventArgs e)
        {

        }

        private void rescount_TextChanged(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            // Collect data from input fields
            string householdIDValue = householdID.Text.Trim();
            string householdName = name.Text.Trim();
            string purokValue = purok.Text.Trim();
            string residentsCount = rescount.Text.Trim();

            // Validate required fields
            if (string.IsNullOrEmpty(householdIDValue) ||
                string.IsNullOrEmpty(householdName) ||
                string.IsNullOrEmpty(purokValue))
            {
                MessageBox.Show("Please fill in all required fields (Household ID, Name, and Purok).",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate residents count is a number
            if (!int.TryParse(residentsCount, out int count) || count < 0)
            {
                MessageBox.Show("Please enter a valid number for residents count.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // SQL query to insert a new household
                string query = @"INSERT INTO household 
                                (householdID, householdName, purok, residents_count) 
                                VALUES 
                                (@householdID, @householdName, @purok, @residentsCount)";

                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@householdID", householdIDValue);
                        command.Parameters.AddWithValue("@householdName", householdName);
                        command.Parameters.AddWithValue("@purok", purokValue);
                        command.Parameters.AddWithValue("@residentsCount", count);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Household added successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            householdForm household = new householdForm();
                            household.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add household.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                if (mysqlEx.Number == 1062) // Duplicate entry error
                {
                    MessageBox.Show("Household ID already exists.", "Error",
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

                
                householdForm household = new householdForm();
                household.Show();
                this.Close();
            }
        }
    }
}
