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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TimeTracker
{
    public partial class UserControl1 : UserControl
    {
        private MySqlConnection connection;
        //private const string connectionString = "Server=localhost;Database=timetracker;Uid=root;Pwd=;";
        private const string connectionString = "Server=192.168.254.105;Database=timetracker;Uid=time;Pwd=admin;";
        
        //192.168.186.39
        public UserControl1()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
        }
        private MySqlConnection InitializeDatabaseConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error connecting to the database: {ex.Message}", "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            return connection;
        }
        

        private void UserControl1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label3.Text = DateTime.Now.ToLongTimeString();
            label4.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
        private Dictionary<string, bool> userClockStatus = new Dictionary<string, bool>();
        private void button1_Click(object sender, EventArgs e) // Time In button
        {

            string idNumber = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(idNumber))
            {
                MessageBox.Show("Please enter the ID number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection connection = InitializeDatabaseConnection())
            {
                MySqlCommand cmdCheckID = new MySqlCommand("SELECT COUNT(*) FROM users WHERE IDNumber = @IDNumber", connection);
                cmdCheckID.Parameters.AddWithValue("@IDNumber", idNumber);
                object idResult = cmdCheckID.ExecuteScalar();
                if (idResult == null || Convert.ToInt32(idResult) == 0)
                {
                    MessageBox.Show("The ID number is not registered. Please enter a valid ID number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string logDate = DateTime.Now.ToString("yyyy-MM-dd");

                // Check if the user has already clocked in today
                MySqlCommand cmdCheckTimeIn = new MySqlCommand("SELECT COUNT(*) FROM student_attendance WHERE IDNumber = @IDNumber AND LogDate = @LogDate", connection);
                cmdCheckTimeIn.Parameters.AddWithValue("@IDNumber", idNumber);
                cmdCheckTimeIn.Parameters.AddWithValue("@LogDate", logDate);
                object result = cmdCheckTimeIn.ExecuteScalar();
                if (result != null && Convert.ToInt32(result) > 0)
                {
                    MessageBox.Show("You have already clocked in today. Please try again tomorrow.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string timeIn = DateTime.Now.ToString("hh:mm:ss tt"); // Use 12-hour format
                string inStatus = "Time In";

                MySqlCommand cmdInsertTimeIn = new MySqlCommand("INSERT INTO student_attendance (IDNumber, LogDate, TimeIn, In_Status) VALUES (@IDNumber, @LogDate, @TimeIn, @In_Status)", connection);
                cmdInsertTimeIn.Parameters.AddWithValue("@IDNumber", idNumber);
                cmdInsertTimeIn.Parameters.AddWithValue("@LogDate", logDate);
                cmdInsertTimeIn.Parameters.AddWithValue("@TimeIn", timeIn);
                cmdInsertTimeIn.Parameters.AddWithValue("@In_Status", inStatus);

                try
                {
                    int rowsInserted = cmdInsertTimeIn.ExecuteNonQuery();
                    if (rowsInserted > 0)
                    {
                        // Fetch the student's name from the database using the provided ID
                        MySqlCommand cmdFetchName = new MySqlCommand("SELECT Name FROM users WHERE IDNumber = @IDNumber", connection);
                        cmdFetchName.Parameters.AddWithValue("@IDNumber", idNumber);
                        object resultName = cmdFetchName.ExecuteScalar();
                        string studentName = resultName != null ? resultName.ToString() : "Unknown";

                        MessageBox.Show($"Time In recorded successfully for {studentName}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error recording Time In. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox1.Text = "";
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            string idNumber = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(idNumber))
            {
                MessageBox.Show("Please enter the ID number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check clock-in status directly from the database if not found in userClockStatus
            if (!userClockStatus.ContainsKey(idNumber) || !userClockStatus[idNumber])
            {
                using (MySqlConnection connection = InitializeDatabaseConnection())
                {
                    MySqlCommand cmdCheckID = new MySqlCommand("SELECT COUNT(*) FROM users WHERE IDNumber = @IDNumber", connection);
                    cmdCheckID.Parameters.AddWithValue("@IDNumber", idNumber);
                    object idResult = cmdCheckID.ExecuteScalar();
                    if (idResult == null || Convert.ToInt32(idResult) == 0)
                    {
                        MessageBox.Show("The ID number is not registered. Please enter a valid ID number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string logDate = DateTime.Now.ToString("yyyy-MM-dd");
                    MySqlCommand cmdCheckTimeIn = new MySqlCommand("SELECT COUNT(*) FROM student_attendance WHERE IDNumber = @IDNumber AND LogDate = @LogDate AND In_Status = 'Time In'", connection);
                    cmdCheckTimeIn.Parameters.AddWithValue("@IDNumber", idNumber);
                    cmdCheckTimeIn.Parameters.AddWithValue("@LogDate", logDate);
                    object result = cmdCheckTimeIn.ExecuteScalar();
                    if (result == null || Convert.ToInt32(result) == 0)
                    {
                        MessageBox.Show("You are not clocked in. Clock in first before clocking out.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            using (MySqlConnection connection = InitializeDatabaseConnection())
            {
                string logDate = DateTime.Now.ToString("yyyy-MM-dd");
                string timeOut = DateTime.Now.ToString("hh:mm:ss tt"); // Use 12-hour format
                string outStatus = "Time Out";

                MySqlCommand cmdUpdateTimeOut = new MySqlCommand("UPDATE student_attendance SET Timeout = @TimeOut, Out_Status = @Out_Status WHERE IDNumber = @IDNumber AND LogDate = @LogDate AND In_Status = 'Time In'", connection);
                cmdUpdateTimeOut.Parameters.AddWithValue("@IDNumber", idNumber);
                cmdUpdateTimeOut.Parameters.AddWithValue("@LogDate", logDate);
                cmdUpdateTimeOut.Parameters.AddWithValue("@TimeOut", timeOut);
                cmdUpdateTimeOut.Parameters.AddWithValue("@Out_Status", outStatus);

                try
                {
                    int rowsAffected = cmdUpdateTimeOut.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Fetch the student's name from the database using the provided ID
                        MySqlCommand cmdFetchName = new MySqlCommand("SELECT Name FROM users WHERE IDNumber = @IDNumber", connection);
                        cmdFetchName.Parameters.AddWithValue("@IDNumber", idNumber);
                        object result = cmdFetchName.ExecuteScalar();
                        string studentName = result != null ? result.ToString() : "Unknown";

                        MessageBox.Show($"Time Out recorded successfully for {studentName}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        userClockStatus[idNumber] = false; // Update clock-in status for user
                    }
                    else
                    {
                        MessageBox.Show("Error recording Time Out. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox1.Text = "";
            }
        }
        

        private void labelUserName_Click(object sender, EventArgs e)
        {

        }
    }
}
    
