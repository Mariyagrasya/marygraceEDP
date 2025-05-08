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
    public partial class addresidents : Form
    {
        public addresidents()
        {
            InitializeComponent();
        }

        private void addresidents_Load(object sender, EventArgs e)
        {

        }

        private void resID_TextChanged(object sender, EventArgs e)
        {

        }

        private void fname_TextChanged(object sender, EventArgs e)
        {

        }

        private void mname_TextChanged(object sender, EventArgs e)
        {

        }

        private void lname_TextChanged(object sender, EventArgs e)
        {

        }

        private void suffix_TextChanged(object sender, EventArgs e)
        {

        }

        private void gender_TextChanged(object sender, EventArgs e)
        {

        }

        private void age_TextChanged(object sender, EventArgs e)
        {

        }

        private void bday_TextChanged(object sender, EventArgs e)
        {

        }

        private void status_TextChanged(object sender, EventArgs e)
        {

        }

        private void occupation_TextChanged(object sender, EventArgs e)
        {

        }

        private void contactNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void householdID_TextChanged(object sender, EventArgs e)
        {

        }

        private void dis_TextChanged(object sender, EventArgs e)
        {

        }

        private void emailAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void citizenship_TextChanged(object sender, EventArgs e)
        {

        }

        private void purok_TextChanged(object sender, EventArgs e)
        {

        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            // Collect data from input fields
            string residentID = resID.Text.Trim();
            string firstName = fname.Text.Trim();
            string middleName = mname.Text.Trim();
            string lastName = lname.Text.Trim();
            string suffixValue = suffix.Text.Trim();
            string genderValue = gender.Text.Trim();
            string ageValue = age.Text.Trim();
            string birthDate = bday.Text.Trim();
            string citizenshipValue = citizenship.Text.Trim();
            string civilStatus = status.Text.Trim();
            string occupationValue = occupation.Text.Trim();
            string emailAddress = emailAdd.Text.Trim();
            string contactNumber = contactNum.Text.Trim();
            string householdIDValue = householdID.Text.Trim();
            string disabilityValue = dis.Text.Trim();
            string purokValue = purok.Text.Trim();
            // Validate required fields
            if (string.IsNullOrEmpty(residentID) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Please fill in all required fields (Resident ID, First Name, and Last Name).",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // SQL query to insert a new resident
                string query = @"INSERT INTO residents 
                                (resID, name, Mname, Lname, suffix, gender, age, bday, citizenship, 
                                 civilStatus, occupation, emailAdd, contactNum, householdID, Disability, purok) 
                                VALUES 
                                (@resID, @fname, @mname, @lname, @suffix, @gender, @age, @bday, @citizenship, 
                                 @status, @occupation, @emailAdd, @contactNum, @householdID, @disability, @purok)";

                using (MySqlConnection connection = Conn.GetConnection())
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@resID", residentID);
                        command.Parameters.AddWithValue("@fname", firstName);
                        command.Parameters.AddWithValue("@mname", middleName);
                        command.Parameters.AddWithValue("@lname", lastName);
                        command.Parameters.AddWithValue("@suffix", suffixValue);
                        command.Parameters.AddWithValue("@gender", genderValue);
                        command.Parameters.AddWithValue("@age", ageValue);
                        command.Parameters.AddWithValue("@bday", birthDate);
                        command.Parameters.AddWithValue("@citizenship", citizenshipValue);
                        command.Parameters.AddWithValue("@status", civilStatus);
                        command.Parameters.AddWithValue("@occupation", occupationValue);
                        command.Parameters.AddWithValue("@emailAdd", emailAddress);
                        command.Parameters.AddWithValue("@contactNum", contactNumber);
                        command.Parameters.AddWithValue("@householdID", householdIDValue);
                        command.Parameters.AddWithValue("@disability", disabilityValue);
                        command.Parameters.AddWithValue("@purok", purokValue);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Resident added successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Redirect back to the residentsForm
                            residentsForm residents = new residentsForm();
                            residents.Show();
                            this.Close(); // Close the addresidents form
                        }
                        else
                        {
                            MessageBox.Show("Failed to add resident.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                MessageBox.Show("Database error: " + mysqlEx.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // Ask for confirmation before canceling
            DialogResult result = MessageBox.Show("Are you sure you want to cancel adding a new resident?",
                                                "Confirm Cancel",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
               
                // Option 2: Close this form and open the residents form
                residentsForm residents = new residentsForm();
                residents.Show();
                this.Close();
            }
        }
    }
}
