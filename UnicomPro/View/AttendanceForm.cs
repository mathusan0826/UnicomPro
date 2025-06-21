using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UnicomPro.Controller;
using UnicomPro.Models;

namespace UnicomPro.View
{
    public partial class AttendanceForm : Form
    {
        private readonly AttendanceController _attendanceController = new AttendanceController();
        private readonly StudentController _studentController = new StudentController();
        private readonly CourseController _subjectController = new CourseController();

        private List<Student> _students;
        private List<Course> _subjects;

        public AttendanceForm()
        {
            InitializeComponent();
            LoadSubjects();
            datePicker.Value = DateTime.Today;
            InitializeGrid();

        }
        private void LoadSubjects()
        {
            _subjects = _subjectController.GetAllCourses();
            cmbSubject.DataSource = _subjects;
            cmbSubject.DisplayMember = "SubjectName";
            cmbSubject.ValueMember = "CourseID";
        }


        private void InitializeGrid()
        {
            dgvAttendance.Columns.Clear();
            dgvAttendance.Columns.Add("StudentIDColumn", "Student ID");
            dgvAttendance.Columns["StudentIDColumn"].ReadOnly = true;

            dgvAttendance.Columns.Add("StudentNameColumn", "Student Name");
            dgvAttendance.Columns["StudentNameColumn"].ReadOnly = true;

            var statusColumn = new DataGridViewComboBoxColumn();
            statusColumn.HeaderText = "Status";
            statusColumn.Name = "StatusColumn";
            statusColumn.Items.AddRange("Present", "Absent", "Late", "Excused");
            dgvAttendance.Columns.Add(statusColumn);
        }

        private void btnSaveAttendance_Click(object sender, EventArgs e)
        {
            if (cmbSubject.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a subject.");
                return;
            }

            int subjectId = (int)cmbSubject.SelectedValue;
            string selectedDate = datePicker.Value.ToString("yyyy-MM-dd");

            foreach (DataGridViewRow row in dgvAttendance.Rows)
            {
                if (row.IsNewRow) continue;

                int studentId = Convert.ToInt32(row.Cells["StudentIDColumn"].Value);
                string status = row.Cells["StatusColumn"].Value?.ToString() ?? "Absent";

                var attendance = new Attendance
                {
                    StudentID = studentId,
                    SubjectID = subjectId,
                    Date = selectedDate,
                    Status = status
                };

                _attendanceController.AddOrUpdate(attendance);
            }

            MessageBox.Show("Attendance saved successfully!");
        }

        private void btnLoadStudents_Click(object sender, EventArgs e)
        {
            if (cmbSubject.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a subject.");
                return;
            }

            _students = _studentController.GetAllStudents();
            dgvAttendance.Rows.Clear();

            foreach (var student in _students)
            {
                dgvAttendance.Rows.Add(student.StudentID, student.StudentName, "Present");
            }
        }

        private void dgvAttendance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AttendanceForm_Load(object sender, EventArgs e)
        {

        }
    }
    }

