using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomPro.View;

namespace UnicomPro.Controller
{
    public class MainDashboardController
    {
        private readonly string _userRole;

        public MainDashboardController(string role)
        {


        //    _userRole = role;
        //}

        //// Method to open a form based on button clicked
        //public void Navigate(string target, Form currentForm)
        //{
        //    Form nextForm = null;

        //    switch (target)
        //    {
        //        case "Students":
        //            if (_userRole == "Admin") nextForm = new StudentForm();
        //            break;

        //        case "Courses":
        //            if (_userRole == "Admin") nextForm = new CourseForm();
        //            break;

        //        //case "Subjects":
        //        //    if (_userRole == "Admin") nextForm = new SubjectForm();
        //        //    break;

        //        case "Exams":
        //            if (_userRole == "Admin") nextForm = new ExamForm();
        //            break;

        //        case "Marks":
        //            if (_userRole == "Admin") nextForm = new MarkForm();
        //            break;

        //        case "Timetable":
        //            if (_userRole == "Admin") nextForm = new TimetableForm();
        //            break;

        //        case "Attendance":
        //            if (_userRole == "Lecturer") nextForm = new AttendanceLecturerForm();
        //            else if (_userRole == "Student") nextForm = new AttendanceStudentForm(); // optional
        //            else if (_userRole == "Admin") nextForm = new AttendanceAdminForm(); // optional
        //            break;

        //        case "Logout":
        //            currentForm.Close(); // Or redirect to login
        //            return;

        //        default:
        //            MessageBox.Show("Unauthorized or Unknown module.");
        //            return;
        //    }

        //    if (nextForm != null)
        //    {
        //        nextForm.Show();
        //        currentForm.Hide();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Access denied for this module.");
        //    }
        //}

        //// Optional: restrict access to buttons in MainForm
        //public void ApplyRoleRestrictions(MainForm form)
        //{
        //    switch (_userRole)
        //    {
        //        case "Admin":
        //            // All enabled
        //            break;

        //        case "Lecturer":
        //            form.btnStudents.Enabled = false;
        //            form.btnCourses.Enabled = false;
        //            form.btnSubjects.Enabled = false;
        //            form.btnExams.Enabled = false;
        //            form.btnMarks.Enabled = false;
        //            form.btnTimetable.Enabled = false;
        //            form.btnAttendance.Enabled = true;
        //            break;

        //        case "Student":
        //            form.btnStudents.Enabled = false;
        //            form.btnCourses.Enabled = false;
        //            form.btnSubjects.Enabled = false;
        //            form.btnExams.Enabled = false;
        //            form.btnMarks.Enabled = false;
        //            form.btnTimetable.Enabled = false;
        //            form.btnAttendance.Enabled = true;
        //            break;

        //        default:
        //            MessageBox.Show("Unknown role.");
        //            break;
        //    }
        }
        
    }
}
