namespace TimeTracker
{
    partial class UserControl4
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.GeneratePDF = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.listView_record = new System.Windows.Forms.ListView();
            this.Author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Thesis_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Year_Published = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Department = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ShowButton = new System.Windows.Forms.Button();
            this.SearchtestBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.idNumberTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.yearLevelComboBox = new System.Windows.Forms.ComboBox();
            this.courseComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.loadChart = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.StartdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EnddateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // GeneratePDF
            // 
            this.GeneratePDF.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.GeneratePDF.Location = new System.Drawing.Point(869, 579);
            this.GeneratePDF.Name = "GeneratePDF";
            this.GeneratePDF.Size = new System.Drawing.Size(199, 79);
            this.GeneratePDF.TabIndex = 0;
            this.GeneratePDF.Text = "Generate Report";
            this.GeneratePDF.UseVisualStyleBackColor = true;
            this.GeneratePDF.Click += new System.EventHandler(this.GeneratePDF_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.UpdateButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateButton.Location = new System.Drawing.Point(869, 357);
            this.UpdateButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(150, 60);
            this.UpdateButton.TabIndex = 24;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DeleteButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.DeleteButton.Location = new System.Drawing.Point(869, 421);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(150, 60);
            this.DeleteButton.TabIndex = 25;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // listView_record
            // 
            this.listView_record.BackColor = System.Drawing.Color.CadetBlue;
            this.listView_record.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Author,
            this.Thesis_Name,
            this.Year_Published,
            this.Department});
            this.listView_record.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_record.ForeColor = System.Drawing.Color.FloralWhite;
            this.listView_record.HideSelection = false;
            this.listView_record.Location = new System.Drawing.Point(88, 62);
            this.listView_record.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView_record.Name = "listView_record";
            this.listView_record.Size = new System.Drawing.Size(775, 730);
            this.listView_record.TabIndex = 26;
            this.listView_record.UseCompatibleStateImageBehavior = false;
            this.listView_record.View = System.Windows.Forms.View.Details;
            // 
            // Author
            // 
            this.Author.Text = "Name";
            this.Author.Width = 150;
            // 
            // Thesis_Name
            // 
            this.Thesis_Name.Text = "Year Level";
            this.Thesis_Name.Width = 150;
            // 
            // Year_Published
            // 
            this.Year_Published.Text = "Course";
            this.Year_Published.Width = 150;
            // 
            // Department
            // 
            this.Department.Text = "ID Number";
            this.Department.Width = 150;
            // 
            // ShowButton
            // 
            this.ShowButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ShowButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.ShowButton.Location = new System.Drawing.Point(1025, 357);
            this.ShowButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShowButton.Name = "ShowButton";
            this.ShowButton.Size = new System.Drawing.Size(150, 60);
            this.ShowButton.TabIndex = 27;
            this.ShowButton.Text = "Show";
            this.ShowButton.UseVisualStyleBackColor = true;
            this.ShowButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // SearchtestBox
            // 
            this.SearchtestBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchtestBox.Location = new System.Drawing.Point(88, 26);
            this.SearchtestBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SearchtestBox.Name = "SearchtestBox";
            this.SearchtestBox.Size = new System.Drawing.Size(534, 34);
            this.SearchtestBox.TabIndex = 28;
            this.SearchtestBox.Tag = "";
            this.SearchtestBox.TextChanged += new System.EventHandler(this.SearchtestBox_TextChanged);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(628, 24);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(235, 37);
            this.button3.TabIndex = 29;
            this.button3.Text = "Search ID Number";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // idNumberTextBox
            // 
            this.idNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idNumberTextBox.Location = new System.Drawing.Point(1017, 60);
            this.idNumberTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.idNumberTextBox.Name = "idNumberTextBox";
            this.idNumberTextBox.Size = new System.Drawing.Size(139, 34);
            this.idNumberTextBox.TabIndex = 30;
            this.idNumberTextBox.Tag = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(869, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 27);
            this.label4.TabIndex = 31;
            this.label4.Text = "ID number:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(873, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 27);
            this.label1.TabIndex = 32;
            this.label1.Text = "Name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(960, 146);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(228, 34);
            this.nameTextBox.TabIndex = 33;
            this.nameTextBox.Tag = "";
            // 
            // yearLevelComboBox
            // 
            this.yearLevelComboBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearLevelComboBox.FormattingEnabled = true;
            this.yearLevelComboBox.Items.AddRange(new object[] {
            "1-A",
            "1-B",
            "1-C",
            "1-D",
            "2-A",
            "2-B",
            "2-C",
            "2-D",
            "3-A",
            "3-B",
            "3-C",
            "3-D",
            "4-A",
            "4-B",
            "4-C",
            "4-D"});
            this.yearLevelComboBox.Location = new System.Drawing.Point(1135, 282);
            this.yearLevelComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.yearLevelComboBox.Name = "yearLevelComboBox";
            this.yearLevelComboBox.Size = new System.Drawing.Size(122, 39);
            this.yearLevelComboBox.TabIndex = 34;
            // 
            // courseComboBox
            // 
            this.courseComboBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.courseComboBox.FormattingEnabled = true;
            this.courseComboBox.Items.AddRange(new object[] {
            "BAPS",
            "BAT",
            "BSAIS",
            "BSBA",
            "BSCS",
            "BSCRIM",
            "BSE",
            "BSED",
            "BSEMC",
            "BSHM",
            "BSIT - CCSICT",
            "BSIT - PS",
            "BSLM",
            "BSMA",
            "BSTM"});
            this.courseComboBox.Location = new System.Drawing.Point(989, 200);
            this.courseComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.courseComboBox.Name = "courseComboBox";
            this.courseComboBox.Size = new System.Drawing.Size(156, 39);
            this.courseComboBox.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(873, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 27);
            this.label2.TabIndex = 36;
            this.label2.Text = "Course:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(873, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 27);
            this.label3.TabIndex = 37;
            this.label3.Text = "Year Level/Section:";
            // 
            // loadChart
            // 
            this.loadChart.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.loadChart.Location = new System.Drawing.Point(1468, 663);
            this.loadChart.Name = "loadChart";
            this.loadChart.Size = new System.Drawing.Size(199, 79);
            this.loadChart.TabIndex = 39;
            this.loadChart.Text = "Load Chart";
            this.loadChart.UseVisualStyleBackColor = true;
            this.loadChart.Click += new System.EventHandler(this.loadChart_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(1306, 84);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(543, 574);
            this.chart1.TabIndex = 40;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(1306, 62);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(236, 22);
            this.dateTimePicker1.TabIndex = 41;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(869, 663);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 60);
            this.button1.TabIndex = 42;
            this.button1.Text = "Logout";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StartdateTimePicker
            // 
            this.StartdateTimePicker.Location = new System.Drawing.Point(874, 551);
            this.StartdateTimePicker.Name = "StartdateTimePicker";
            this.StartdateTimePicker.Size = new System.Drawing.Size(194, 22);
            this.StartdateTimePicker.TabIndex = 43;
            this.StartdateTimePicker.ValueChanged += new System.EventHandler(this.StartdateTimePicker_ValueChanged);
            // 
            // EnddateTimePicker
            // 
            this.EnddateTimePicker.Location = new System.Drawing.Point(1100, 551);
            this.EnddateTimePicker.Name = "EnddateTimePicker";
            this.EnddateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.EnddateTimePicker.TabIndex = 45;
            this.EnddateTimePicker.ValueChanged += new System.EventHandler(this.EnddateTimePicker_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(869, 522);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 23);
            this.label5.TabIndex = 46;
            this.label5.Text = "Start Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1095, 522);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 23);
            this.label6.TabIndex = 47;
            this.label6.Text = "End Date";
            // 
            // UserControl4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.EnddateTimePicker);
            this.Controls.Add(this.StartdateTimePicker);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.loadChart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.courseComboBox);
            this.Controls.Add(this.yearLevelComboBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.idNumberTextBox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.SearchtestBox);
            this.Controls.Add(this.ShowButton);
            this.Controls.Add(this.listView_record);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.GeneratePDF);
            this.Name = "UserControl4";
            this.Size = new System.Drawing.Size(1924, 1072);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GeneratePDF;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.ListView listView_record;
        private System.Windows.Forms.ColumnHeader Author;
        private System.Windows.Forms.ColumnHeader Year_Published;
        private System.Windows.Forms.ColumnHeader Thesis_Name;
        private System.Windows.Forms.ColumnHeader Department;
        private System.Windows.Forms.Button ShowButton;
        private System.Windows.Forms.TextBox SearchtestBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox idNumberTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.ComboBox yearLevelComboBox;
        private System.Windows.Forms.ComboBox courseComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button loadChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker StartdateTimePicker;
        private System.Windows.Forms.DateTimePicker EnddateTimePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
