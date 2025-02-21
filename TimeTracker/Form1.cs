using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker
{

    public partial class Form1 : Form
    {
        NavigationControl navigationControl;
        public Form1()
        {
            InitializeComponent();
            InitializeNavigationControl();
        }

        private void InitializeNavigationControl()
        {
            List<UserControl> userControls = new List<UserControl>() // Your UserControl list
            { new UserControl1(), new UserControl2(), new UserControl3()};

            navigationControl = new NavigationControl(userControls, panel2); // create an instance of NavigationControl class
            navigationControl.Display(0); // display UserControl1 as default
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            navigationControl.Display(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);*/
           /* float widthRatio = Screen.PrimaryScreen.Bounds.Width / 1280;
            float heightRatio = Screen.PrimaryScreen.Bounds.Height / 800f;
            SizeF scale = new SizeF(widthRatio, heightRatio);
            this.Scale(scale);
            foreach (Control control in this.Controls)
            {
                control.Font = new Font("Verdana", control.Font.SizeInPoints * heightRatio * widthRatio);
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            navigationControl.Display(2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            navigationControl.Display(1);
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This system was developed by students from BSCS 3A-BA:\n" +
                    "Leader: Mark Anthony T. Reyes\n" +
                    "Members: \n" +
                    "Gilmore Delacruz\n" +
                    "Angelo Jake Reyes\n" +
                    "William Salinas\n" +
                    "Ivhie Biankha Sibayan",
                    "System Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }
    }
}
