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
    public partial class voterRegistrationForm : Form
    {
        public voterRegistrationForm()
        {
            InitializeComponent();
            LoadVotersRegistrationData();
        }
        private void LoadVotersRegistrationData()
        {
            try
            {
                // SQL query to fetch business permits data
                string query = "SELECT * FROM voterregistrationinfo";

                // Use the conn class to establish a connection
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable votersRegistrationData = new DataTable();
                            adapter.Fill(votersRegistrationData);

                            // Bind the data to the DataGridView
                            votersTableview.DataSource = votersRegistrationData;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message,
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void addBtn_Click(object sender, EventArgs e)
        {
            addVoter addVoterForm = new addVoter();
            addVoterForm.Show();
            this.Hide();
        }

        private void votersTableview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                // 1. Ensure output directory exists
                string reportsDir = Path.Combine(Application.StartupPath, "generatedreports");
                if (!Directory.Exists(reportsDir))
                {
                    Directory.CreateDirectory(reportsDir);
                }

                // 2. Initialize Excel
                excelApp = new Excel.Application();
                workbook = excelApp.Workbooks.Add(Type.Missing);
                worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "Voter Registration";

                // 3. Format header row
                for (int i = 1; i <= votersTableview.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = votersTableview.Columns[i - 1].HeaderText;
                    worksheet.Cells[1, i].Font.Bold = true;
                    worksheet.Cells[1, i].Interior.Color = Excel.XlRgbColor.rgbLightBlue;
                    worksheet.Cells[1, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }

                // 4. Export data with special formatting
                for (int i = 0; i < votersTableview.Rows.Count; i++)
                {
                    for (int j = 0; j < votersTableview.Columns.Count; j++)
                    {
                        var cellValue = votersTableview.Rows[i].Cells[j].Value;

                        // Format dates (assuming columns with "date" in name)
                        if (votersTableview.Columns[j].Name.ToLower().Contains("date") && cellValue is DateTime)
                        {
                            worksheet.Cells[i + 2, j + 1] = ((DateTime)cellValue).ToString("MM/dd/yyyy");
                            worksheet.Cells[i + 2, j + 1].NumberFormat = "MM/dd/yyyy";
                        }
                        // Highlight active voters
                        else if (votersTableview.Columns[j].Name.ToLower().Contains("status") &&
                                cellValue?.ToString().ToLower() == "active")
                        {
                            worksheet.Cells[i + 2, j + 1] = cellValue;
                            worksheet.Cells[i + 2, j + 1].Interior.Color = Excel.XlRgbColor.rgbLightGreen;
                        }
                        // Format voter IDs
                        else if (votersTableview.Columns[j].Name.ToLower().Contains("id"))
                        {
                            worksheet.Cells[i + 2, j + 1] = "'" + cellValue?.ToString(); // Prevents Excel from converting to scientific notation
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1] = cellValue?.ToString() ?? string.Empty;
                        }
                    }
                }

                // 5. Enable Excel features
                worksheet.Rows[1].AutoFilter();  // Enable filters
                worksheet.Columns.AutoFit();      // Auto-fit columns
                worksheet.Columns[1].ColumnWidth = 15; // Set specific width for first column

                // 6. Add summary information
                int lastRow = votersTableview.Rows.Count + 2;
                worksheet.Cells[lastRow, 1] = "Total Voters:";
                worksheet.Cells[lastRow, 2] = votersTableview.Rows.Count;
                worksheet.Range[$"A{lastRow}:B{lastRow}"].Font.Bold = true;

                // 7. Save the file
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                string filePath = Path.Combine(reportsDir, $"VoterRegistration-{timestamp}.xlsx");

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                workbook.SaveAs(filePath);
                MessageBox.Show($"Voter registration data exported to:\n{filePath}", "Export Successful",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting voter data:\n{ex.Message}", "Export Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 8. Cleanup COM objects
                if (worksheet != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
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
            }
        }
    }
}
