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
    public partial class blotterRecordsForm : Form
    {
        public blotterRecordsForm()
        {
            InitializeComponent();
            LoadBlotterRecordsData();
        }
        private void LoadBlotterRecordsData()
        {
            try
            {
                // SQL query to fetch business permits data
                string query = "SELECT * FROM blotterreportsummary";

                // Use the conn class to establish a connection
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable blotterRecordsData = new DataTable();
                            adapter.Fill(blotterRecordsData);

                            // Bind the data to the DataGridView
                            blotterTableview.DataSource = blotterRecordsData;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading business permits data: " + ex.Message,
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

        private void blotterTableview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            addBlotterRecords addBlotterForm = new addBlotterRecords ();
            addBlotterForm.Show();
            this.Hide();
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
                worksheet.Name = "Blotter Records";

                // 3. Write column headers
                for (int i = 1; i <= blotterTableview.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = blotterTableview.Columns[i - 1].HeaderText;

                    // Format header row
                    worksheet.Cells[1, i].Font.Bold = true;
                    worksheet.Cells[1, i].Interior.Color = Excel.XlRgbColor.rgbLightGray;
                }

                // 4. Export data with special formatting
                for (int i = 0; i < blotterTableview.Rows.Count; i++)
                {
                    for (int j = 0; j < blotterTableview.Columns.Count; j++)
                    {
                        var cellValue = blotterTableview.Rows[i].Cells[j].Value;

                        // Format dates (assuming columns with "date" in name)
                        if (blotterTableview.Columns[j].Name.ToLower().Contains("date") && cellValue is DateTime)
                        {
                            worksheet.Cells[i + 2, j + 1] = ((DateTime)cellValue).ToString("MM/dd/yyyy");
                            worksheet.Cells[i + 2, j + 1].NumberFormat = "MM/dd/yyyy";
                        }
                        // Highlight "Resolved" status
                        else if (blotterTableview.Columns[j].Name.ToLower().Contains("status") && cellValue?.ToString() == "Resolved")
                        {
                            worksheet.Cells[i + 2, j + 1] = cellValue;
                            worksheet.Cells[i + 2, j + 1].Interior.Color = Excel.XlRgbColor.rgbLightGreen;
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

                // 6. Save the file
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                string filePath = Path.Combine(reportsDir, $"BlotterRecords-{timestamp}.xlsx");

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                workbook.SaveAs(filePath);
                MessageBox.Show($"Blotter records exported to:\n{filePath}", "Export Successful",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting blotter records:\n{ex.Message}", "Export Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 7. Cleanup COM objects in reverse order
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
