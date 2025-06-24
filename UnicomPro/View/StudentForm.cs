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
using UnicomPro.Models;

namespace UnicomPro.View
{
    public partial class StudentForm : Form
    {
        private readonly StudentController _studentController = new StudentController();
        private readonly CourseController _courseController = new CourseController();
        private List<Course> _courses;
        public StudentForm()
        {
            InitializeComponent();
            LoadCourses();
            LoadStudents();
        }
        
       
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentName.Text) )
            {
                MessageBox.Show("Please fill all student fields.");
                return;
            }

            var student = new Student
            {
                StudentName = txtStudentName.Text.Trim(),
               
                CourseID = Convert.ToInt32(comboBoxCourses.SelectedValue)
            };

            _studentController.AddStudent(student);
            LoadStudents();
            ClearInputs();
        }

        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.CurrentRow == null)
            {
                MessageBox.Show("Please select a student to update.");
                return;
            }

            var selected = (Student)dataGridViewStudents.CurrentRow.DataBoundItem;

            selected.StudentName = txtStudentName.Text.Trim();
            
            selected.CourseID = Convert.ToInt32(comboBoxCourses.SelectedValue);

            _studentController.UpdateStudent(selected);
            LoadStudents();
            ClearInputs();
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.CurrentRow == null)
            {
                MessageBox.Show("Please select a student to delete.");
                return;
            }

            var selected = (Student)dataGridViewStudents.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show($"Delete student '{selected.StudentName}'?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _studentController.DeleteStudent(selected.StudentID);
                LoadStudents();
                ClearInputs();
            }
        }
        private void LoadCourses()
        {
            _courses = _courseController.GetAllCourses();
            comboBoxCourses.DataSource = _courses;
            comboBoxCourses.DisplayMember = "CourseName";
            comboBoxCourses.ValueMember = "CourseID";
        }
        private void LoadStudents()
        {
            dataGridViewStudents.DataSource = null;
            dataGridViewStudents.DataSource = _studentController.GetAllStudents();
        }

        private void dataGridViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewStudents.CurrentRow != null)
            {
                var selected = (Student)dataGridViewStudents.CurrentRow.DataBoundItem;
                txtStudentName.Text = selected.StudentName;
               
                comboBoxCourses.SelectedValue = selected.CourseID;
            }
        }
        private void ClearInputs()
        {
            txtStudentName.Clear();
            if (comboBoxCourses.Items.Count > 0)
                comboBoxCourses.SelectedIndex = 0;

            //  comboBoxCourses.SelectedIndex = 0;
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
    }

