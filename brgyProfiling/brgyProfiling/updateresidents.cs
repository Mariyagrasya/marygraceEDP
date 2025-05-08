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
    public partial class updateresidents : Form
    {
        private string residentId;

        public updateresidents(string residentId)
        {
            InitializeComponent();
            this.residentId = residentId;
            LoadResidentData();
        }

        private void LoadResidentData()
        {
            try
            {
                string query = "SELECT * FROM residents WHERE resID = @residentId";

                using (MySqlConnection connection = Conn.GetConnection())
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@residentId", residentId);
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate form fields with resident data
                            resID.Text = reader["resID"].ToString();
                            fname.Text = reader["name"].ToString();  // Changed from firstName to name
                            mname.Text = reader["Mname"].ToString();
                            lname.Text = reader["Lname"].ToString();
                            suffix.Text = reader["suffix"].ToString();
                            gender.Text = reader["gender"].ToString();
                            age.Text = reader["age"].ToString();
                            bday.Text = Convert.ToDateTime(reader["bday"]).ToString("yyyy-MM-dd");
                            citizenship.Text = reader["citizenship"].ToString();
                            status.Text = reader["civilStatus"].ToString();
                            occupation.Text = reader["occupation"].ToString();
                            emailAdd.Text = reader["emailAdd"].ToString();
                            contactNum.Text = reader["contactNum"].ToString();
                            householdID.Text = reader["householdID"].ToString();
                            dis.Text = reader["Disability"].ToString();
                            purok.Text = reader["purok"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading resident data: " + ex.Message, "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fname.Text) || string.IsNullOrEmpty(lname.Text))
            {
                MessageBox.Show("Name fields are required.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string query = @"UPDATE residents SET 
                               name = @name,
                               Mname = @Mname,
                               Lname = @Lname,
                               suffix = @suffix,
                               gender = @gender,
                               age = @age,
                               bday = @bday,
                               citizenship = @citizenship,
                               civilStatus = @civilStatus,
                               occupation = @occupation,
                               emailAdd = @emailAdd,
                               contactNum = @contactNum,
                               householdID = @householdID,
                               Disability = @Disability,
                               purok = @purok
                               WHERE resID = @resID";

                using (MySqlConnection connection = Conn.GetConnection())
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@name", fname.Text.Trim());
                    command.Parameters.AddWithValue("@Mname", mname.Text.Trim());
                    command.Parameters.AddWithValue("@Lname", lname.Text.Trim());
                    command.Parameters.AddWithValue("@suffix", suffix.Text.Trim());
                    command.Parameters.AddWithValue("@gender", gender.Text.Trim());
                    command.Parameters.AddWithValue("@age", int.Parse(age.Text));
                    command.Parameters.AddWithValue("@bday", bday.Text);
                    command.Parameters.AddWithValue("@citizenship", citizenship.Text.Trim());
                    command.Parameters.AddWithValue("@civilStatus", status.Text.Trim());
                    command.Parameters.AddWithValue("@occupation", occupation.Text.Trim());
                    command.Parameters.AddWithValue("@emailAdd", emailAdd.Text.Trim());
                    command.Parameters.AddWithValue("@contactNum", contactNum.Text.Trim());
                    command.Parameters.AddWithValue("@householdID", householdID.Text.Trim());
                    command.Parameters.AddWithValue("@Disability", dis.Text.Trim());
                    command.Parameters.AddWithValue("@purok", purok.Text.Trim());
                    command.Parameters.AddWithValue("@resID", residentId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Resident updated successfully!", "Success",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid values for numeric fields.", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            // Ask for confirmation before canceling
            DialogResult result = MessageBox.Show("Are you sure you want to cancel?",
                                                "Confirm Cancel",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                // Optionally redirect back to the blotter management form
                residentsForm res = new residentsForm();
                res.Show();
                this.Close();
            }
        }

        // TextChanged events remain empty if no special logic needed
        private void resID_TextChanged(object sender, EventArgs e) { }
        private void fname_TextChanged(object sender, EventArgs e) { }
        private void mname_TextChanged(object sender, EventArgs e) { }
        private void lname_TextChanged(object sender, EventArgs e) { }
        private void suffix_TextChanged(object sender, EventArgs e) { }
        private void gender_TextChanged(object sender, EventArgs e) { }
        private void age_TextChanged(object sender, EventArgs e) { }
        private void bday_TextChanged(object sender, EventArgs e) { }
        private void citizenship_TextChanged(object sender, EventArgs e) { }
        private void status_TextChanged(object sender, EventArgs e) { }
        private void occupation_TextChanged(object sender, EventArgs e) { }
        private void emailAdd_TextChanged(object sender, EventArgs e) { }
        private void contactNum_TextChanged(object sender, EventArgs e) { }
        private void householdID_TextChanged(object sender, EventArgs e) { }
        private void dis_TextChanged(object sender, EventArgs e) { }
        private void purok_TextChanged(object sender, EventArgs e) { }
    }
}