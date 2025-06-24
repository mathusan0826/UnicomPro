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
    public partial class CourseForm : Form
    {
      
        
        private readonly CourseController _courseController = new CourseController();
        public CourseForm()
        {
            InitializeComponent();
            LoadCourses();

        }
       


        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageBox.Show("Please enter a course name.");
                return;
            }

            var newCourse = new Course { CourseName = txtCourseName.Text.Trim() };
            _courseController.AddCourse(newCourse);
            LoadCourses();
            txtCourseName.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridViewCourses.CurrentRow == null)
            {
                MessageBox.Show("Please select a course to delete.");
                return;
            }

            var selectedCourse = (Course)dataGridViewCourses.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show($"Are you sure to delete '{selectedCourse.CourseName}'?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _courseController.DeleteCourse(selectedCourse.CourseID);
                LoadCourses();
                txtCourseName.Clear();
            }
            dataGridViewCourses.Columns["CourseID"].HeaderText = "Course ID";
            dataGridViewCourses.Columns["CourseID"].Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewCourses.CurrentRow == null || string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageBox.Show("Please select a course and enter a new name.");
                return;
            }

            var selectedCourse = (Course)dataGridViewCourses.CurrentRow.DataBoundItem;
            selectedCourse.CourseName = txtCourseName.Text.Trim();

            _courseController.UpdateCourse(selectedCourse);
            LoadCourses();
            txtCourseName.Clear();
        }

        private void dataGridViewCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCourses.CurrentRow == null || string.IsNullOrWhiteSpace(txtCourseName.Text))
            {
                MessageBox.Show("Please select a course and enter a new name.");
                return;
            }

            var selectedCourse = (Course)dataGridViewCourses.CurrentRow.DataBoundItem;
            selectedCourse.CourseName = txtCourseName.Text.Trim();

            _courseController.UpdateCourse(selectedCourse);
            LoadCourses();
            txtCourseName.Clear();
        }
        private void LoadCourses()
        {
            var courses = _courseController.GetAllCourses();
            dataGridViewCourses.DataSource = null;
            dataGridViewCourses.DataSource = courses;
        }

        private void dataGridViewCourse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCourses.CurrentRow != null)
            {
                var selectedCourse = (Course)dataGridViewCourses.CurrentRow.DataBoundItem;
                txtCourseName.Text = selectedCourse.CourseName;
            }
        }

        private void CourseForm_Load(object sender, EventArgs e)
        {

        }
        public void MakeReadOnly()
        {
            button1.Enabled = false; // Add
            button2.Enabled = false; // Delete
            button3.Enabled = false; // Update
           // txtCourseName.Enabled = false; // Optional: disable text box
        }
    }
}
