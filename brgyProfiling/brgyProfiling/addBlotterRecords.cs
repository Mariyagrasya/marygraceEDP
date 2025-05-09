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
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    // Call the stored procedure with exact parameter names
                    using (MySqlCommand command = new MySqlCommand("RegisterBlotterRecord", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters exactly as defined in the stored procedure
                        command.Parameters.AddWithValue("@blotterID", blotterId);
                        command.Parameters.AddWithValue("@reportDate",
                            string.IsNullOrEmpty(reportDate) ? DateTime.Now : DateTime.Parse(reportDate));
                        command.Parameters.AddWithValue("@incidentDesc", description);
                        command.Parameters.AddWithValue("@involvedResidentId", residentId);
                        command.Parameters.AddWithValue("@staffId", staffId);

                        // Add output parameters for status and resolve date if needed
                        if (!string.IsNullOrEmpty(status))
                        {
                            command.Parameters.AddWithValue("@status", status);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@status", "Pending"); // Default status
                        }

                        if (!string.IsNullOrEmpty(resolveDate))
                        {
                            command.Parameters.AddWithValue("@resolveDate", DateTime.Parse(resolveDate));
                        }

                        // Execute the stored procedure
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Blotter record {blotterId} registered successfully!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Return to blotter records form
                            blotterRecordsForm blotterForm = new blotterRecordsForm();
                            blotterForm.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No records were affected. The blotter ID may already exist.",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (MySqlException mysqlEx) when (mysqlEx.Number == 1062)
            {
                MessageBox.Show($"Blotter ID {blotterId} already exists in the system.",
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
