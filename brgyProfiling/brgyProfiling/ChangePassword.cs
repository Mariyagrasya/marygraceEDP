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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void newpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lgnBtn_Click(object sender, EventArgs e)
        {
            string currentUsername = username.Text.Trim(); // TextBox for the current username
            string newPassword = newpassword.Text.Trim(); // TextBox for the new password

            // Validate input fields
            if (string.IsNullOrEmpty(currentUsername) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Please fill in both the username and the new password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // SQL query to update the username and password for the user
                string query = "UPDATE admin SET admin_password = @newPassword WHERE admin_username = @currentUsername";

                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open(); // Ensure the connection is explicitly opened

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@currentUsername", currentUsername);
                        command.Parameters.AddWithValue("@newPassword", newPassword);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Redirect to the residentsForm
                            residentsForm residents = new residentsForm();
                            residents.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Username not found. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
