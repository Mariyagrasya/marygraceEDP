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
    public partial class householdForm : Form
    {
        public householdForm()
        {
            InitializeComponent();
            LoadHouseholdData();
        }
        private void LoadHouseholdData()
        {
            try
            {
                // SQL query to fetch all data from the household table
                string query = "SELECT * FROM household";

                // Use the conn class to establish a connection
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open(); // Ensure the connection is open

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable householdData = new DataTable();
                            adapter.Fill(householdData); // Fill the DataTable with the query result

                            // Bind the data to the DataGridView
                            householdTableview.DataSource = householdData;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong
                MessageBox.Show("Error loading household data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void blotterBtn_Click_1(object sender, EventArgs e)
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

        private void officialsTableview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
           
            addHousehold addHouseholdForm = new addHousehold();
            addHouseholdForm.Show();
            this.Hide(); 
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
                worksheet.Name = "Household Data"; // Changed from "Residents Data"

                // 3. Write column headers (using householdTableview instead of residentTableview)
                for (int i = 1; i <= householdTableview.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = householdTableview.Columns[i - 1].HeaderText;
                }

                // 4. Export data (with proper formatting)
                for (int i = 0; i < householdTableview.Rows.Count; i++)
                {
                    for (int j = 0; j < householdTableview.Columns.Count; j++)
                    {
                        var cellValue = householdTableview.Rows[i].Cells[j].Value;

                        // Format dates (adjust column name as needed)
                        if (householdTableview.Columns[j].Name.ToLower().Contains("date") && cellValue is DateTime)
                        {
                            worksheet.Cells[i + 2, j + 1] = ((DateTime)cellValue).ToString("dd/MM/yyyy");
                            worksheet.Cells[i + 2, j + 1].NumberFormat = "dd/MM/yyyy";
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1] = cellValue?.ToString() ?? string.Empty;
                        }
                    }
                }

                // 5. Enable Excel filtering
                worksheet.Rows[1].AutoFilter(); // Adds dropdown filters to headers

                // 6. Auto-fit columns for better readability
                worksheet.Columns.AutoFit();

                // 7. Save the file
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                string filePath = Path.Combine(reportsDir, $"HouseholdData-{timestamp}.xlsx"); // Updated filename

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                workbook.SaveAs(filePath);
                MessageBox.Show($"Household data exported successfully to: {filePath}", "Export Successful",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting household data: {ex.Message}", "Export Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 8. Proper cleanup
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
