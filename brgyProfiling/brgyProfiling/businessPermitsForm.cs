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
    public partial class businessPermitsForm : Form
    {
        public businessPermitsForm()
        {
            InitializeComponent();
            LoadBusinessPermitsData();
        }
        private void LoadBusinessPermitsData()
        {
            try
            {
                // SQL query to fetch business permits data
                string query = "SELECT * FROM businesspermitsinfo";

                // Use the conn class to establish a connection
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable businessPermitsData = new DataTable();
                            adapter.Fill(businessPermitsData);

                            // Bind the data to the DataGridView
                            permitsTableview.DataSource = businessPermitsData;
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

        private void sidePanel_Paint(object sender, PaintEventArgs e)
        {

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
        
            addBusinessPermit addPermitForm = new addBusinessPermit();
            addPermitForm.Show();
            this.Hide(); 
        }

        private void permitsTableview_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                worksheet.Name = "Business Permits";

                // 3. Format header row
                for (int i = 1; i <= permitsTableview.Columns.Count; i++)
                {
                    worksheet.Cells[1, i] = permitsTableview.Columns[i - 1].HeaderText;
                    worksheet.Cells[1, i].Font.Bold = true;
                    worksheet.Cells[1, i].Interior.Color = Excel.XlRgbColor.rgbLightSteelBlue;
                    worksheet.Cells[1, i].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Cells[1, i].Borders.Weight = Excel.XlBorderWeight.xlThin;
                }

                // 4. Export data with special formatting
                for (int i = 0; i < permitsTableview.Rows.Count; i++)
                {
                    for (int j = 0; j < permitsTableview.Columns.Count; j++)
                    {
                        var cellValue = permitsTableview.Rows[i].Cells[j].Value;

                        // Format dates (issuance/expiration)
                        if (permitsTableview.Columns[j].Name.ToLower().Contains("date") && cellValue is DateTime)
                        {
                            worksheet.Cells[i + 2, j + 1] = ((DateTime)cellValue).ToString("MM/dd/yyyy");
                            worksheet.Cells[i + 2, j + 1].NumberFormat = "MM/dd/yyyy";

                            // Highlight expired permits in red
                            if (permitsTableview.Columns[j].Name.ToLower().Contains("expir") &&
                                (DateTime)cellValue < DateTime.Today)
                            {
                                worksheet.Cells[i + 2, j + 1].Interior.Color = Excel.XlRgbColor.rgbLightCoral;
                            }
                        }
                        // Format permit numbers
                        else if (permitsTableview.Columns[j].Name.ToLower().Contains("permit no"))
                        {
                            worksheet.Cells[i + 2, j + 1] = "'" + cellValue?.ToString(); // Preserve leading zeros
                        }
                        // Format currency (fees)
                        else if (permitsTableview.Columns[j].Name.ToLower().Contains("fee"))
                        {
                            worksheet.Cells[i + 2, j + 1] = cellValue;
                            worksheet.Cells[i + 2, j + 1].NumberFormat = "₱#,##0.00";
                        }
                        else
                        {
                            worksheet.Cells[i + 2, j + 1] = cellValue?.ToString() ?? string.Empty;
                        }
                    }
                }

                // 5. Enable Excel features
                worksheet.Rows[1].AutoFilter();  // Enable filters
                worksheet.Columns.AutoFit();     // Auto-fit columns

                // Set specific column widths
                worksheet.Columns[1].ColumnWidth = 15; // Permit No
                worksheet.Columns[2].ColumnWidth = 25; // Business Name

                // 6. Add summary information
                int lastRow = permitsTableview.Rows.Count + 2;
                worksheet.Cells[lastRow, 1] = "Total Permits:";
                worksheet.Cells[lastRow, 2] = permitsTableview.Rows.Count;

                // Calculate total fees
                if (permitsTableview.Columns.Contains("Fee"))
                {
                    int feeColIndex = permitsTableview.Columns["Fee"].Index + 1;
                    worksheet.Cells[lastRow + 1, 1] = "Total Fees:";
                    worksheet.Cells[lastRow + 1, 2].Formula = $"=SUM(B2:B{lastRow - 1})";
                    worksheet.Cells[lastRow + 1, 2].NumberFormat = "₱#,##0.00";
                }

                // Format summary rows
                Excel.Range summaryRange = worksheet.Range[$"A{lastRow}:B{lastRow + 1}"];
                summaryRange.Font.Bold = true;
                summaryRange.Interior.Color = Excel.XlRgbColor.rgbLightGray;

                // 7. Save the file
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                string filePath = Path.Combine(reportsDir, $"BusinessPermits-{timestamp}.xlsx");

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                workbook.SaveAs(filePath);
                MessageBox.Show($"Business permits exported to:\n{filePath}", "Export Successful",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting business permits:\n{ex.Message}", "Export Error",
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
