using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomPro.Controller;

namespace UnicomPro.View
{
    public partial class MainDashboardForm : Form
    {
        private readonly MainDashboardController _controller;
        //private readonly MainDashboardModel _currentUser;

        public MainDashboardForm()
        {
            InitializeComponent();
           // _currentUser = userModel;
           // _controller = new MainDashboardController(userModel.Role);

           // lblWelcome.Text = $"Welcome, {_currentUser.FullName} ({_currentUser.Role})";
         //   _controller.ApplyRoleRestrictions(this);
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            //_controller.Navigate("Students", this);
            StudentForm studentForm = new StudentForm();
            studentForm.Show();
            this.Hide();
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            //_controller.Navigate("Courses", this);
            CourseForm CourseForm=new CourseForm();
            CourseForm.Show();
            this.Hide();
        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
           
        }

        private void btnExams_Click(object sender, EventArgs e)
        {
            //_controller.Navigate("Exams", this);
            ExamForm examForm = new ExamForm();
            examForm.Show();
            this.Hide();
        }

        private void btnMarks_Click(object sender, EventArgs e)
        {
            //    _controller.Navigate("Marks", this);
            MarkForm markForm = new MarkForm();
            markForm.Show();
            this.Hide();
        }

        private void btnTimetable_Click(object sender, EventArgs e)
        {
            //_controller.Navigate("Timetable", this);
            TimetableForm timetableForm = new TimetableForm(); 
            timetableForm.Show();
            this.Hide();
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            //_controller.Navigate("Attendance", this);
            AttendanceForm attendanceForm = new AttendanceForm();
            attendanceForm.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            //_controller.Navigate("Logout", this);
        }

        private void btnLecture_Click(object sender, EventArgs e)
        {
            LectureForm lectureForm = new LectureForm();
            lectureForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //_controller.Navigate("Subjects", this);
            SubjectForm subjectForm = new SubjectForm();
            subjectForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LapHallAllocationForm lapHallAllocationForm = new LapHallAllocationForm();
            lapHallAllocationForm.Show();
            this.Hide();
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void MainDashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
