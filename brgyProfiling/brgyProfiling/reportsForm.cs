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
    public partial class reportsForm : Form
    {
        public reportsForm()
        {
            InitializeComponent();
            LoadReportsData();
            LoadExpiringPermitsData();
        }
        private void LoadReportsData()
        {
            try
            {
                // SQL query to fetch business permits data
                string query = "SELECT * FROM reports";

                // Use the conn class to establish a connection
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable reportsData = new DataTable();
                            adapter.Fill(reportsData);

                            // Bind the data to the DataGridView
                            reportsTableview.DataSource = reportsData;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            addReport addReportForm = new addReport();
            addReportForm.Show();
            this.Hide(); 
        }

        private void expiringPermits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void LoadExpiringPermitsData()
        {
            try
            {
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    // 1. First clear the existing data source if needed
                    if (expiringPermits.DataSource != null)
                    {
                        expiringPermits.DataSource = null;
                        expiringPermits.Rows.Clear();
                    }

                    // 2. Use stored procedure call with parameters
                    using (MySqlCommand command = new MySqlCommand("ListResidentsWithExpiringBusinessPermitsInNext3Years", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameter for days threshold (e.g., 90 days)
                        command.Parameters.AddWithValue("@days_threshold", 90);

                        // 3. Use DataTable for better handling
                        DataTable dt = new DataTable();
                        dt.Load(command.ExecuteReader());

                        // 4. Configure DataGridView properly
                        expiringPermits.AutoGenerateColumns = true;
                        expiringPermits.DataSource = dt;

                        // 5. Format columns (optional)
                        if (expiringPermits.Columns.Contains("expiryDate"))
                        {
                            expiringPermits.Columns["expiryDate"].DefaultCellStyle.Format = "MM/dd/yyyy";
                        }

                        // 6. Add visual indicators for urgency
                        foreach (DataGridViewRow row in expiringPermits.Rows)
                        {
                            if (row.Cells["expiryDate"].Value != null &&
                                DateTime.TryParse(row.Cells["expiryDate"].Value.ToString(), out DateTime expiryDate))
                            {
                                if (expiryDate < DateTime.Now.AddDays(30))
                                {
                                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                                }
                                else if (expiryDate < DateTime.Now.AddDays(60))
                                {
                                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading expiring permits:\n{ex.Message}",
                              "Database Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void totalPopulation_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                // SQL query to call the MySQL function
                string query = "SELECT GetTotalPopulation() AS TotalPopulation";

                // Use the conn class to establish a connection
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Execute the query and retrieve the result
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int totalPopulation))
                        {
                            // Display the total population in the UI
                            e.Graphics.DrawString($"Total Population: {totalPopulation}",
                                                  new Font("Arial", 12, FontStyle.Bold),
                                                  Brushes.Black,
                                                  new PointF(20, 20));
                        }
                        else
                        {
                            e.Graphics.DrawString("Total Population: Data not available",
                                                  new Font("Arial", 12, FontStyle.Bold),
                                                  Brushes.Red,
                                                  new PointF(20, 20));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message in the UI if something goes wrong
                e.Graphics.DrawString($"Error: {ex.Message}",
                                      new Font("Arial", 12, FontStyle.Bold),
                                      Brushes.Red,
                                      new PointF(10, 10));
            }
        }

        private void Men_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                // SQL query to call the MySQL function
                string query = "SELECT GetTotalMales() AS TotalMales";

                // Use the conn class to establish a connection
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Execute the query and retrieve the result
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int totalMales))
                        {
                            // Display the total male population in the UI
                            e.Graphics.DrawString($"Total Males: {totalMales}",
                                                  new Font("Arial", 12, FontStyle.Bold),
                                                  Brushes.Blue,
                                                  new PointF(20, 20));
                        }
                        else
                        {
                            e.Graphics.DrawString("Total Males: Data not available",
                                                  new Font("Arial", 12, FontStyle.Bold),
                                                  Brushes.Red,
                                                  new PointF(20, 20));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message in the UI if something goes wrong
                e.Graphics.DrawString($"Error: {ex.Message}",
                                      new Font("Arial", 12, FontStyle.Bold),
                                      Brushes.Red,
                                      new PointF(10, 10));
            }
        }


        private void women_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                // SQL query to call the MySQL function
                string query = "SELECT GetTotalFemales() AS TotalFemales";

                // Use the conn class to establish a connection
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Execute the query and retrieve the result
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int totalFemales))
                        {
                            // Display the total female population in the UI
                            e.Graphics.DrawString($"Total Females: {totalFemales}",
                                                  new Font("Arial", 12, FontStyle.Bold),
                                                  Brushes.Pink,
                                                  new PointF(20, 20));
                        }
                        else
                        {
                            e.Graphics.DrawString("Total Females: Data not available",
                                                  new Font("Arial", 12, FontStyle.Bold),
                                                  Brushes.Red,
                                                  new PointF(20, 20));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message in the UI if something goes wrong
                e.Graphics.DrawString($"Error: {ex.Message}",
                                      new Font("Arial", 12, FontStyle.Bold),
                                      Brushes.Red,
                                      new PointF(10, 10));
            }
        }

        private void voters_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                // SQL query to call the MySQL function
                string query = "SELECT GetTotalRegisteredVoters() AS TotalVoters";

                // Use the conn class to establish a connection
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Execute the query and retrieve the result
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int totalVoters))
                        {
                            // Display the total registered voters in the UI
                            e.Graphics.DrawString($"Total Registered Voters: {totalVoters}",
                                                  new Font("Arial", 12, FontStyle.Bold),
                                                  Brushes.Green,
                                                  new PointF(20, 20));
                        }
                        else
                        {
                            e.Graphics.DrawString("Total Registered Voters: Data not available",
                                                  new Font("Arial", 12, FontStyle.Bold),
                                                  Brushes.Red,
                                                  new PointF(20, 20));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message in the UI if something goes wrong
                e.Graphics.DrawString($"Error: {ex.Message}",
                                      new Font("Arial", 12, FontStyle.Bold),
                                      Brushes.Red,
                                      new PointF(10, 10));
            }
        }

    }
}
