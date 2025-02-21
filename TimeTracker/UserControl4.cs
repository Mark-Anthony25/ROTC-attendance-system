using iText.Kernel.Pdf;
using MySql.Data.MySqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms.DataVisualization.Charting;

namespace TimeTracker
{
    public partial class UserControl4 : UserControl
    {
        private MySqlConnection connection;
        //private const string connectionString = "Server=localhost;Database=timetracker;Uid=root;Pwd=;";
        private const string connectionString = "Server=192.168.254.105;Database=timetracker;Uid=time;Pwd=admin;";
        public UserControl4()
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

        private void button2_Click(object sender, EventArgs e)
        {
            listView_record.Items.Clear(); // Assuming listView_record is your ListView control

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Name, YearLevel, Course, IDNumber FROM Users";

                using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection))
                {
                    using (MySqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["Name"].ToString());
                            item.SubItems.Add(reader["YearLevel"].ToString());
                            item.SubItems.Add(reader["Course"].ToString());
                            item.SubItems.Add(reader["IDNumber"].ToString());

                            listView_record.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            string idNumber = idNumberTextBox.Text;
            if (string.IsNullOrEmpty(idNumber))
            {
                MessageBox.Show("Please enter the ID number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = nameTextBox.Text;
            string yearLevel = yearLevelComboBox.SelectedItem?.ToString(); // Assuming you have a ComboBox for Year Level
            string course = courseComboBox.SelectedItem?.ToString(); // Assuming you have a ComboBox for Course

            using (MySqlConnection connection = new MySqlConnection(connectionString)) // Use connectionString here
            {
                connection.Open();

                string updateQuery = "UPDATE Users SET Name = @Name, YearLevel = @YearLevel, Course = @Course WHERE IDNumber = @IDNumber";

                using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@IDNumber", idNumber);
                    updateCommand.Parameters.AddWithValue("@Name", name);
                    updateCommand.Parameters.AddWithValue("@YearLevel", yearLevel);
                    updateCommand.Parameters.AddWithValue("@Course", course);

                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No record found with the provided ID number. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            nameTextBox.Text = "";
            idNumberTextBox.Text = "";
            yearLevelComboBox.SelectedIndex = -1; // Reset the Year Level ComboBox
            courseComboBox.SelectedIndex = -1; // Reset the Course ComboBox
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string idNumber = idNumberTextBox.Text;
            if (string.IsNullOrEmpty(idNumber))
            {
                MessageBox.Show("Please enter the ID number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM Users WHERE IDNumber = @IDNumber";

                using (MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@IDNumber", idNumber);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No record found with the provided ID number. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            idNumberTextBox.Text = ""; // Clear the ID Number TextBox
        }

        private void PopulateListView(string idNumberQuery)
        {
            listView_record.Items.Clear(); // Clear existing items

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT Name, YearLevel, Course, IDNumber FROM Users WHERE IDNumber LIKE @IDNumber";

                using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@IDNumber", "%" + idNumberQuery + "%");

                    using (MySqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["Name"].ToString());
                            item.SubItems.Add(reader["YearLevel"].ToString());
                            item.SubItems.Add(reader["Course"].ToString());
                            item.SubItems.Add(reader["IDNumber"].ToString());

                            listView_record.Items.Add(item);
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string idNumber = SearchtestBox.Text.Trim();
            if (string.IsNullOrEmpty(idNumber))
            {
                MessageBox.Show("Please enter the ID number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PopulateListView(idNumber);

            SearchtestBox.Text = ""; // Clear the ID Number TextBox
        }

        private void SearchtestBox_TextChanged(object sender, EventArgs e)
        {
            string idNumber = idNumberTextBox.Text.Trim();
            if (string.IsNullOrEmpty(idNumber))
            {
                return;
            }

            PopulateListView(idNumber);
        }

        private void GeneratePDF_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Get the selected start and end dates from the DateTimePicker controls
                string startDate = StartdateTimePicker.Value.ToString("yyyy-MM-dd");
                string endDate = EnddateTimePicker.Value.ToString("yyyy-MM-dd");

                // Query to get the unique log dates within the selected range and sort them
                string dateQuery = "SELECT DISTINCT sa.logdate FROM student_attendance sa WHERE sa.logdate BETWEEN @startDate AND @endDate ORDER BY sa.logdate";
                MySqlCommand dateCommand = new MySqlCommand(dateQuery, connection);
                dateCommand.Parameters.AddWithValue("@startDate", startDate);
                dateCommand.Parameters.AddWithValue("@endDate", endDate);
                MySqlDataReader dateReader = dateCommand.ExecuteReader();

                // Get the unique log dates and store them in a list
                List<string> uniqueLogDates = new List<string>();
                while (dateReader.Read())
                {
                    uniqueLogDates.Add(dateReader["logdate"].ToString());
                }
                dateReader.Close(); // Close the dateReader

                // Create a mapping of logdate to "Day X" labels
                Dictionary<string, string> dayLabels = new Dictionary<string, string>();
                for (int i = 0; i < uniqueLogDates.Count; i++)
                {
                    dayLabels[uniqueLogDates[i]] = "Day " + (i + 1);
                }

                // Query to get the attendance data within the selected range, ordered by course, YearLevel and name
                string selectQuery = "SELECT sa.IDnumber, u.name, u.course, u.YearLevel, sa.logdate, sa.timein, sa.timeout " +
                                     "FROM student_attendance sa " +
                                     "INNER JOIN users u ON sa.IDnumber = u.IDNumber " +
                                     "WHERE sa.logdate BETWEEN @startDate AND @endDate " +
                                     "ORDER BY u.course, u.YearLevel, u.name, sa.logdate";
                MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@startDate", startDate);
                selectCommand.Parameters.AddWithValue("@endDate", endDate);

                // Create a new PDF document
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string appFolderPath = Path.Combine(documentsPath, "Student Time Tracker");
                Directory.CreateDirectory(appFolderPath); // Create the directory if it doesn't exist
                string filePath = Path.Combine(appFolderPath, $"student_attendance_{timestamp}.pdf");

                // Create a new PDF document with the dynamic file path
                // Set the document to landscape orientation by swapping the width and height in the PageSize
                Document document = new Document(PageSize.A4.Rotate());
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                // Add title and table headers
                Paragraph title = new Paragraph("ROTC Attendance", FontFactory.GetFont("Arial", 20, iTextSharp.text.Font.BOLD));
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Paragraph("\n")); // Add a blank line

                PdfPTable table = new PdfPTable(3 + uniqueLogDates.Count * 2 + 1); // Columns for Name, ID, Course/Year/Section, each logdate (Time In, Time Out), and Total
                iTextSharp.text.Font cellFont = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL); // Set the font size to 10
                table.AddCell(new PdfPCell(new Phrase("Name", cellFont)));
                table.AddCell(new PdfPCell(new Phrase("ID Number", cellFont)));
                table.AddCell(new PdfPCell(new Phrase("Course/Year/Section", cellFont)));
                foreach (string logdate in uniqueLogDates)
                {
                    table.AddCell(new PdfPCell(new Phrase(dayLabels[logdate] + "\n" + logdate + " Time In", cellFont)));
                    table.AddCell(new PdfPCell(new Phrase(dayLabels[logdate] + "\n" + logdate + " Time Out", cellFont)));
                }
                table.AddCell(new PdfPCell(new Phrase("Total Days Present", cellFont)));

                // Execute the select query and populate the table with data
                using (MySqlDataReader reader = selectCommand.ExecuteReader())
                {
                    // Initialize variables to store the current user's data
                    string currentID = "";
                    string currentName = "";
                    string currentCourse = "";
                    List<string> currentTimeIn = new List<string>(new string[uniqueLogDates.Count]);
                    List<string> currentTimeOut = new List<string>(new string[uniqueLogDates.Count]);
                    int totalDaysPresent = 0;
                    int lateOrUndertimeDays = 0;

                    while (reader.Read())
                    {
                        string id = reader["IDnumber"].ToString();
                        string name = reader["name"].ToString();
                        string course = reader["course"].ToString() + " " + reader["YearLevel"].ToString();
                        string logdate = reader["logdate"].ToString();
                        string timein = reader["timein"].ToString();
                        string timeout = reader["timeout"].ToString();

                        // If the ID has changed, add the current user's data to the table and start a new row
                        if (id != currentID && currentID != "")
                        {
                            table.AddCell(new PdfPCell(new Phrase(currentName, cellFont)));
                            table.AddCell(new PdfPCell(new Phrase(currentID, cellFont)));
                            table.AddCell(new PdfPCell(new Phrase(currentCourse, cellFont)));
                            for (int i = 0; i < uniqueLogDates.Count; i++)
                            {
                                iTextSharp.text.Font timeInFont = (!string.IsNullOrEmpty(currentTimeIn[i]) && DateTime.Parse(currentTimeIn[i]) > DateTime.Parse("08:00:00")) ? FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.RED) : FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                                iTextSharp.text.Font timeOutFont = (!string.IsNullOrEmpty(currentTimeOut[i]) && DateTime.Parse(currentTimeOut[i]) < DateTime.Parse("11:00:00")) ? FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.RED) : FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                                PdfPCell timeInCell = new PdfPCell(new Phrase(currentTimeIn[i], timeInFont));
                                PdfPCell timeOutCell = new PdfPCell(new Phrase(currentTimeOut[i], timeOutFont));
                                table.AddCell(timeInCell);
                                table.AddCell(timeOutCell);
                            }
                            table.AddCell(new PdfPCell(new Phrase($"{totalDaysPresent} - {lateOrUndertimeDays} = {totalDaysPresent - lateOrUndertimeDays}", cellFont))); // Add total days present in the last column

                            // Reset the current user's data
                            currentTimeIn = new List<string>(new string[uniqueLogDates.Count]);
                            currentTimeOut = new List<string>(new string[uniqueLogDates.Count]);
                            totalDaysPresent = 0; // Reset total days present
                            lateOrUndertimeDays = 0; // Reset late or undertime days
                        }

                        // Update the current user's data
                        currentID = id;
                        currentName = name;
                        currentCourse = course;
                        int index = uniqueLogDates.IndexOf(logdate);
                        currentTimeIn[index] = timein;
                        currentTimeOut[index] = timeout;

                        // Increment the total days present if the student has a time in and time out
                        if (!string.IsNullOrEmpty(timein) && !string.IsNullOrEmpty(timeout))
                        {
                            totalDaysPresent++;
                            DateTime timeInTime = DateTime.Parse(timein);
                            DateTime timeOutTime = DateTime.Parse(timeout);
                            if (timeInTime > DateTime.Parse("08:00:00") || timeOutTime < DateTime.Parse("11:00:00"))
                            {
                                lateOrUndertimeDays++;
                            }
                        }
                    }

                    // Add the last user's data to the table
                    table.AddCell(new PdfPCell(new Phrase(currentName, cellFont)));
                    table.AddCell(new PdfPCell(new Phrase(currentID, cellFont)));
                    table.AddCell(new PdfPCell(new Phrase(currentCourse, cellFont)));
                    for (int i = 0; i < uniqueLogDates.Count; i++)
                    {
                        iTextSharp.text.Font timeInFont = (!string.IsNullOrEmpty(currentTimeIn[i]) && DateTime.Parse(currentTimeIn[i]) > DateTime.Parse("08:00:00")) ? FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.RED) : FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                        iTextSharp.text.Font timeOutFont = (!string.IsNullOrEmpty(currentTimeOut[i]) && DateTime.Parse(currentTimeOut[i]) < DateTime.Parse("11:00:00")) ? FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.RED) : FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                        PdfPCell timeInCell = new PdfPCell(new Phrase(currentTimeIn[i], timeInFont));
                        PdfPCell timeOutCell = new PdfPCell(new Phrase(currentTimeOut[i], timeOutFont));
                        table.AddCell(timeInCell);
                        table.AddCell(timeOutCell);
                    }
                    table.AddCell(new PdfPCell(new Phrase($"{totalDaysPresent} - {lateOrUndertimeDays} = {totalDaysPresent - lateOrUndertimeDays}", cellFont))); // Add total days present in the last column
                }

                // Add the table to the document and close the document
                document.Add(table);
                document.Close();

                MessageBox.Show($"PDF generated successfully at: {filePath}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void loadChart_Click(object sender, EventArgs e)
        {
            // Get the selected date for chart data
            DateTime selectedDate = dateTimePicker1.Value.Date;

            // Prepare the SQL query to get course-wise clock-in counts for the selected date
            string selectQuery = "SELECT u.course AS Course, COUNT(sa.IDnumber) AS ClockInCount " +
                                 "FROM student_attendance sa " +
                                 "INNER JOIN users u ON sa.IDnumber = u.IDNumber " +
                                 "WHERE sa.logdate = @SelectedDate AND sa.In_Status = 'Time In' " +
                                 "GROUP BY u.course";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@SelectedDate", selectedDate.ToString("yyyy-MM-dd"));

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Clear existing data from the existing chart (chart1)
                        chart1.Series.Clear();
                        chart1.ChartAreas.Clear();

                        // Add new chart area and series to the existing chart (chart1)
                        chart1.ChartAreas.Add("ChartArea");
                        chart1.Series.Add("ClockIns");
                        chart1.Series["ClockIns"].ChartType = SeriesChartType.Column;

                        // Bind chart data from the DataTable to the existing chart (chart1)
                        chart1.DataSource = dataTable;
                        chart1.Series["ClockIns"].XValueMember = "Course";
                        chart1.Series["ClockIns"].YValueMembers = "ClockInCount";
                    }
                }
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // Get the selected date for chart data
            DateTime selectedDate = dateTimePicker1.Value.Date;

            // Prepare the SQL query to get course-wise clock-in counts for the selected date
            string selectQuery = "SELECT u.course AS Course, COUNT(sa.IDnumber) AS ClockInCount " +
                                 "FROM student_attendance sa " +
                                 "INNER JOIN users u ON sa.IDnumber = u.IDNumber " +
                                 "WHERE sa.logdate = @SelectedDate AND sa.In_Status = 'Time In' " +
                                 "GROUP BY u.course";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@SelectedDate", selectedDate.ToString("yyyy-MM-dd"));

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectCommand))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Clear existing data from the existing chart (chart1)
                        chart1.Series.Clear();
                        chart1.ChartAreas.Clear();

                        // Add new chart area and series to the existing chart (chart1)
                        chart1.ChartAreas.Add("ChartArea");
                        chart1.Series.Add("ClockIns");
                        chart1.Series["ClockIns"].ChartType = SeriesChartType.Column;

                        // Bind chart data from the DataTable to the existing chart (chart1)
                        chart1.DataSource = dataTable;
                        chart1.Series["ClockIns"].XValueMember = "Course";
                        chart1.Series["ClockIns"].YValueMembers = "ClockInCount";
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            UserControl2 userControl1 = new UserControl2();
            this.Controls.Add(userControl1);
            userControl1.Dock = DockStyle.Fill;
           
        }

        private void StartdateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void EnddateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
