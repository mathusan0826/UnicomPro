using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnicomPro.View
{
    public partial class StaffDashboardForm : Form
    {
        public StaffDashboardForm()
        {
            InitializeComponent();
        }
        private void LoadFormIntoPanel(Form formToLoad)
        {
            panel3.Controls.Clear(); // Ensure you have a panel named panelContainer
            formToLoad.TopLevel = false;
            formToLoad.FormBorderStyle = FormBorderStyle.None;
            formToLoad.Dock = DockStyle.Fill;
            panel3.Controls.Add(formToLoad);
            formToLoad.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new LectureForm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new StudentForm());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new CourseForm());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new SubjectForm());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new TimetableForm());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new LapHallAllocationForm());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new ExamForm());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
