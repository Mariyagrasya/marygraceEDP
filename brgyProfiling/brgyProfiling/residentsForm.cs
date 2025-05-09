using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;


namespace brgyProfiling
{
    public partial class residentsForm : Form
    {
        public residentsForm()
        {
           InitializeComponent();
            LoadResidentsData();

        }

        private void LoadResidentsData()
        {
            try
            {
                // SQL query to fetch all data from the residents table
                string query = "SELECT * FROM residents";

                // Use the conn class to establish a connection
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open(); // Ensure the connection is open

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable residentsData = new DataTable();
                            adapter.Fill(residentsData); // Fill the DataTable with the query result

                            // Bind the data to the DataGridView
                            residentTableview.DataSource = residentsData;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show("Error loading residents data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void residentsPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            // Redirect to the AddResidents form
            addresidents addResidentsForm = new addresidents();
            addResidentsForm.Show();
            this.Hide(); // Hide the current residentsForm
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected
                if (residentTableview.SelectedRows.Count > 0)
                {
                    // Get the selected resident's ID (assuming the primary key is in the first column)
                    string selectedResidentId = residentTableview.SelectedRows[0].Cells[0].Value.ToString();

                    // Confirm deletion
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this resident?",
                                                          "Delete Confirmation",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // SQL query to delete the resident
                        string query = "DELETE FROM residents WHERE resID = @resID";

                        using (MySqlConnection connection = Conn.GetConnection())
                        {
                            connection.Open();

                            using (MySqlCommand command = new MySqlCommand(query, connection))
                            {
                                // Add parameter to prevent SQL injection
                                command.Parameters.AddWithValue("@resID", selectedResidentId);

                                // Execute the query
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Resident deleted successfully!", "Success",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Refresh the DataGridView
                                    LoadResidentsData();
                                }
                                else
                                {
                                    MessageBox.Show("Failed to delete the resident.", "Error",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a resident to delete.", "No Selection",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show("Error deleting resident: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void residentTableview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void search_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void editBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected
                if (residentTableview.SelectedRows.Count > 0)
                {
                    // Get the selected resident's ID (assuming the primary key is in the first column)
                    string selectedResidentId = residentTableview.SelectedRows[0].Cells[0].Value.ToString();

                    // Pass the selected resident's ID to the updateresidents form
                    updateresidents updateForm = new updateresidents(selectedResidentId);
                    updateForm.ShowDialog();

                    // Refresh the DataGridView after editing
                    LoadResidentsData();
                }
                else
                {
                    MessageBox.Show("Please select a resident to edit.", "No Selection",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show("Error editing resident: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                // 1. Ensure the output directory exists
                string reportsDir = Path.Combine(Application.StartupPath, "generatedreports");
                if (!Directory.Exists(reportsDir))
                {
                    Directory.CreateDirectory(reportsDir);
                }

                // 2. Initialize Excel
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add(Type.Missing);
                worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "Residents Data";

                // 3. Write column headers
                for (int i = 1; i <= residentTableview.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = residentTableview.Columns[i - 1].HeaderText;
                }

                // 4. Export data (with proper date formatting)
                for (int i = 0; i < residentTableview.Rows.Count; i++)
                {
                    for (int j = 0; j < residentTableview.Columns.Count; j++)
                    {
                        var cellValue = residentTableview.Rows[i].Cells[j].Value;

                        // Check if the column contains dates (e.g., "Birthday")
                        if (residentTableview.Columns[j].Name == "Birthday" && cellValue is DateTime)
                        {
                            // Format date to show only "dd/MM/yyyy" (no time)
                            worksheet.Cells[i + 2, j + 1] = ((DateTime)cellValue).ToString("dd/MM/yyyy");
                            worksheet.Cells[i + 2, j + 1].NumberFormat = "dd/MM/yyyy"; 
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1] = cellValue?.ToString() ?? string.Empty;
                        }
                    }
                }

                // 5. Save the file
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                string filePath = Path.Combine(reportsDir, $"ResidentsData-{timestamp}.xlsx");

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                workbook.SaveAs(filePath);
                MessageBox.Show($"Data exported successfully to: {filePath}", "Export Successful",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting data: {ex.Message}", "Export Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 6. Proper cleanup (avoid memory leaks)
                if (workbook != null)
                {
                    workbook.Close(false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                }

                if (excelApp != null)
                {
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }

                if (worksheet != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                }
            }
        }

    }
}
