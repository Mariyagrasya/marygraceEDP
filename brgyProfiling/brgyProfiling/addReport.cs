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
    public partial class addReport : Form
    {
        public addReport()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            // Collect data from input fields
            string reportId = reportID.Text.Trim();
            string reportName = name.Text.Trim();
            string description = des.Text.Trim();
            string reportDate = created.Text.Trim();
            string staffId = staff.Text.Trim();

            // Validate required fields
            if (string.IsNullOrEmpty(reportId) ||
                string.IsNullOrEmpty(reportName) ||
                string.IsNullOrEmpty(staffId))
            {
                MessageBox.Show("Please fill in all required fields (Report ID, Report Name, and Staff ID).",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // SQL query to insert new report
                string query = @"INSERT INTO reports 
                        (reportID, reportName, description, date, staffID) 
                        VALUES 
                        (@reportID, @reportName, @description, @date, @staffID)";

                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@reportID", reportId);
                        command.Parameters.AddWithValue("@reportName", reportName);
                        command.Parameters.AddWithValue("@description", description);
                        command.Parameters.AddWithValue("@date", reportDate);
                        command.Parameters.AddWithValue("@staffID", staffId);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Report added successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh or redirect

                            // Correct instantiation and navigation
                            reportsForm ReportsForm = new reportsForm();  // Proper class name (PascalCase)
                            ReportsForm.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add report.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                if (mysqlEx.Number == 1062) // Duplicate entry error
                {
                    MessageBox.Show("Report ID already exists in the system.", "Error",
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

                // Correct instantiation and navigation
                reportsForm ReportsForm = new reportsForm();  // Proper class name (PascalCase)
                ReportsForm.Show();
                this.Close();
            }
        }
    }
}
