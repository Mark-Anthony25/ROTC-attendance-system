using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
namespace TimeTracker
{
    public partial class UserControl2 : UserControl
    {
        private MySqlConnection connection;
        //private const string connectionString = "Server=localhost;Database=timetracker;Uid=root;Pwd=;";
        private const string connectionString = "Server=192.168.254.105;Database=timetracker;Uid=time;Pwd=admin;";
        public UserControl2()
        {
            InitializeComponent();
            InitializeDatabaseConnection();
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

        private void UserControl2_Load(object sender, EventArgs e)
        {

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
            string idNumber = adminNumberTextBox.Text;
            string password = passwordTextBox.Text;

            if (string.IsNullOrWhiteSpace(idNumber) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT IDNumber, UserType FROM Users WHERE IDNumber = @IDNumber AND Password = @Password", connection);
                cmd.Parameters.AddWithValue("@IDNumber", idNumber);
                cmd.Parameters.AddWithValue("@Password", password);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        UserControl4 userControl4 = new UserControl4();
                        this.Controls.Clear();
                        this.Controls.Add(userControl4);
                        string userType = reader["UserType"].ToString();


                    }
                    else
                    {
                        MessageBox.Show("Invalid ID Number or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during login: {ex.Message}", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
