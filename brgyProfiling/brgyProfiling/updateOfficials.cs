using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace brgyProfiling
{
    public partial class updateOfficials : Form
    {
        private string staffId;

        public updateOfficials(string staffId)
        {
            InitializeComponent();
            this.staffId = staffId;
            LoadOfficialData();
        }

        private void LoadOfficialData()
        {
            try
            {
                string query = "SELECT * FROM staff WHERE staffID = @staffId";

                using (MySqlConnection connection = Conn.GetConnection())
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@staffId", staffId);
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate form fields with official data
                            staffID.Text = reader["staffID"].ToString();
                            name.Text = reader["staffName"].ToString();
                            role.Text = reader["roleID"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading official data: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {

            try
            {
                string query = @"UPDATE staff SET 
                                staffName = @staffName,
                                roleID = @roleID
                                WHERE staffID = @staffID";

                using (MySqlConnection connection = Conn.GetConnection())
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@staffName", name.Text.Trim());
                    command.Parameters.AddWithValue("@roleID", role.Text.Trim());
                    command.Parameters.AddWithValue("@staffID", staffId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Official updated successfully!", "Success",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void updateOfficials_Load(object sender, EventArgs e)
        {
            // Load roles into combo box
            try
            {
                string query = "SELECT roleID, roleName FROM roles";
                using (MySqlConnection connection = Conn.GetConnection())
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    DataTable dt = new DataTable();
                    dt.Load(command.ExecuteReader());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading roles: " + ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void staffID_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void roleID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}