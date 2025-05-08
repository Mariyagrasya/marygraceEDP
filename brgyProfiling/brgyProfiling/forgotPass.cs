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
    public partial class forgotPass : Form
    {
        public forgotPass()
        {
            InitializeComponent();
        }

        private void frgtPass_TextChanged(object sender, EventArgs e)
        {
            //for textbox named frgtPass
        }
        private void frgtLgnBtn_Click(object sender, EventArgs e)
        {
            string enteredUsername = username.Text.Trim();
            string enteredAnswer = forgot.Text.Trim();

            // Validate input fields
            if (string.IsNullOrEmpty(enteredUsername) || string.IsNullOrEmpty(enteredAnswer))
            {
                MessageBox.Show("Please fill in both the username and security answer.",
                               "Missing Information",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Open connection explicitly (important!)
                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    // Query to check username and security answer match
                    string query = "SELECT COUNT(*) FROM admin WHERE admin_username = @username AND fav_fruit = @answer";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Secure parameterized query
                        command.Parameters.AddWithValue("@username", enteredUsername);
                        command.Parameters.AddWithValue("@answer", enteredAnswer);

                        // Execute and check match
                        int matchCount = Convert.ToInt32(command.ExecuteScalar());

                        if (matchCount > 0)
                        {
                            // SUCCESS - Open ChangePassword form
                            MessageBox.Show("Verification successful!",
                                           "Success",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);

                            ChangePassword changePasswordForm = new ChangePassword();
                            changePasswordForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            // FAILURE - Show error
                            MessageBox.Show("Invalid username or security answer.",
                                           "Verification Failed",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException dbEx)
            {
                MessageBox.Show($"Database error: {dbEx.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            // for username txtbox named username
        }
    }
}
