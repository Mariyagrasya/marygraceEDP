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
using System.Xml.Linq;

namespace brgyProfiling
{
    public partial class addBlotterRecords : Form
    {
        public addBlotterRecords()
        {
            InitializeComponent();
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            // Collect data from input fields
            string blotterId = blotterID.Text.Trim();
            string residentId = resident.Text.Trim();
            string staffId = staff.Text.Trim();
            string reportDate = reportdate.Text.Trim();
            string description = des.Text.Trim();
            string status = statusBlotter.Text.Trim();
            string resolveDate = resolveddate.Text.Trim();

            // Validate required fields
            if (string.IsNullOrEmpty(blotterId) ||
                string.IsNullOrEmpty(residentId) ||
                string.IsNullOrEmpty(staffId) ||
                string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Please fill in all required fields (Blotter ID, Resident ID, Staff ID, and Description).",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // SQL query to insert a new blotter record
                string query = @"INSERT INTO blotterrecords 
                        (blotterID, resID, staffID, reportDate, description, status, resolveDate) 
                        VALUES 
                        (@blotterID, @resID, @staffID, @reportDate, @description, @status, @resolveDate)";

                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@blotterID", blotterId);
                        command.Parameters.AddWithValue("@resID", residentId);
                        command.Parameters.AddWithValue("@staffID", staffId);
                        command.Parameters.AddWithValue("@reportDate", reportDate);
                        command.Parameters.AddWithValue("@description", description);
                        command.Parameters.AddWithValue("@status", status);
                        command.Parameters.AddWithValue("@resolveDate", resolveDate);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Blotter record added successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Optionally redirect back to the blotter management form
                            blotterRecordsForm blotter = new blotterRecordsForm();
                            blotter.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add blotter record.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                if (mysqlEx.Number == 1062) // Duplicate entry error
                {
                    MessageBox.Show("Blotter ID already exists.", "Error",
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
            DialogResult result = MessageBox.Show("Are you sure you want to cancel adding a new blotter records?",
                                                "Confirm Cancel",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                // Optionally redirect back to the blotter management form
                blotterRecordsForm blotter = new blotterRecordsForm();
                blotter.Show();
                this.Close();
            }
        }

        private void blotterID_TextChanged(object sender, EventArgs e)
        {

        }

        private void resident_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
