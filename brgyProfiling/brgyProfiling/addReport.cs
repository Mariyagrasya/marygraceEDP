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
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    // Call the stored function with exact parameter names
                    using (MySqlCommand command = new MySqlCommand("AddReport", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters exactly as defined in the stored function
                        command.Parameters.AddWithValue("@newReportID", reportId);
                        command.Parameters.AddWithValue("@newReportName", reportName);
                        command.Parameters.AddWithValue("@newDescription",
                            string.IsNullOrEmpty(description) ? DBNull.Value : (object)description);
                        command.Parameters.AddWithValue("@newDate",
                            string.IsNullOrEmpty(reportDate) ? DateTime.Now : DateTime.Parse(reportDate));
                        command.Parameters.AddWithValue("@newStaffID", staffId);

                        // Execute the stored procedure
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Report {reportId} created successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the reports view
                            reportsForm reportsForm = new reportsForm();
                            reportsForm.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No records were affected. The report may already exist.",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (MySqlException mysqlEx) when (mysqlEx.Number == 1062)
            {
                MessageBox.Show($"Report ID {reportId} already exists in the system.",
                    "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid date format. Please use YYYY-MM-DD format.",
                    "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cancelBtn_Click_1(object sender, EventArgs e)
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
