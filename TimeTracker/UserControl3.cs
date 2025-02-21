using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class UserControl3 : UserControl
    {
        private MySqlConnection connection;
        //private const string connectionString = "Server=localhost;Database=timetracker;Uid=root;Pwd=;";
        private const string connectionString = "Server=192.168.254.105;Database=timetracker;Uid=time;Pwd=admin;";


        public UserControl3()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
            radioButtonStudent.Checked = true;
            //radioButtonStudent.Checked = true;
            label6.Visible = false;
            checkBox1.Visible = false;
            passwordTextBox.Visible = false;
        }
        private void InitializeDatabaseConnection()
        {
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to the database: {ex.Message}", "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CourseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*   
               label6.Visible = CourseComboBox.SelectedItem.ToString() == "Admin";
               textBox4.Visible = CourseComboBox.SelectedItem.ToString() == "Admin";
               */
            /* label5.Visible = UserTypeComboBox.SelectedItem.ToString() == "Student";
             CourseComboBox.Visible = UserTypeComboBox.SelectedItem.ToString() == "Student";
             */
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                passwordTextBox.UseSystemPasswordChar = false;

            }
            else
            {
                passwordTextBox.UseSystemPasswordChar = true;
            }
        }

        private void Register_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            string idNumber = idNumberTextBox.Text;
            string yearLevel = yearLevelTextBox.Text; // Assuming you have a TextBox for Year Level
            string course;
            if (CourseComboBox.Enabled)
            {
                course = CourseComboBox.SelectedItem?.ToString();
                yearLevel = yearLevelTextBox.SelectedItem?.ToString();
            }
            else
            {
                course = "";  // Default value when CourseComboBox is disabled
                yearLevel = "";
            }
            string userType;
            if (radioButtonStudent.Checked)
            {
                userType = "Student";
            }
            else if (radioButtonAdmin.Checked)
            {
                userType = "Admin";
            }
            else
            {
                MessageBox.Show("Please select a user type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string password = passwordTextBox.Text;

            // Additional validation for IDNumber
            if (!IsValidIDNumber(idNumber))
            {
                MessageBox.Show("ID Number must contain only alphanumeric values and '-'", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Users (Name, IDNumber, YearLevel, Course, UserType, Password) VALUES (@Name, @IDNumber, @YearLevel, @Course, @UserType, @Password)", connection);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@IDNumber", idNumber);
                cmd.Parameters.AddWithValue("@YearLevel", yearLevel);
                cmd.Parameters.AddWithValue("@Course", course);
                cmd.Parameters.AddWithValue("@UserType", userType);
                cmd.Parameters.AddWithValue("@Password", password);

                cmd.ExecuteNonQuery();

                MessageBox.Show("User registered successfully!", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error registering user: {ex.Message}", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            nameTextBox.Text = "";
            idNumberTextBox.Text = "";
            yearLevelTextBox.Text = ""; // Clear the Year Level TextBox
            CourseComboBox.SelectedIndex = -1;
            passwordTextBox.Text = "";
        }
        private bool IsValidIDNumber(string value)
        {
            // Allow alphanumeric characters and '-'
            return System.Text.RegularExpressions.Regex.IsMatch(value, "^[a-zA-Z0-9-]+$");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonStudent.Checked)
            {
                label5.Visible = true;
                CourseComboBox.Visible = true;
                CourseComboBox.Enabled = true;
                yearLevelTextBox.Visible = true;
                label2.Visible = true;
                passwordTextBox.Visible = false;
                label6.Visible = false;
                checkBox1.Visible = false;

            }
        }

        private void radioButtonStudent_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAdmin.Checked)
            {
                label5.Visible = false;
                CourseComboBox.Visible = false;
                CourseComboBox.Enabled = false;
                yearLevelTextBox.Visible = false;
                label2.Visible = false;
                passwordTextBox.Visible = true;
                label6.Visible = true;
                checkBox1.Visible = true;
            }
        }

        private void CourseComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void UserControl3_Load(object sender, EventArgs e)
        {

        }
    }
}
