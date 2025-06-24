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
    public partial class LectureForm : Form
    {
        private readonly LectureController _lectureController = new LectureController();
        private readonly CourseController _courseController = new CourseController();
        private List<Course> _courses;
        public LectureForm()
        {
            InitializeComponent();
            LoadCourses();
            LoadLectures();
        }

        private void LoadCourses()
        {
            _courses = _courseController.GetAllCourses();
            comboBoxCourse.DataSource = _courses;
            comboBoxCourse.DisplayMember = "CourseName";
            comboBoxCourse.ValueMember = "CourseID";
        }

        private void LoadLectures()
        {
            dataGridViewLectures.DataSource = null;
            dataGridViewLectures.DataSource = _lectureController.GetAllLectures();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLectureName.Text) || comboBoxCourse.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter a lecture name and select a course.");
                return;
            }

            var lecture = new Lecture
            {
                LectureName = txtLectureName.Text.Trim(),
                CourseId = (int)comboBoxCourse.SelectedValue
            };

            _lectureController.AddLecture(lecture);
            MessageBox.Show("Lecture added successfully.");
            LoadLectures();
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewLectures.CurrentRow == null)
            {
                MessageBox.Show("Please select a lecture to update.");
                return;
            }

            var selectedLecture = (Lecture)dataGridViewLectures.CurrentRow.DataBoundItem;
            selectedLecture.LectureName = txtLectureName.Text.Trim();
            selectedLecture.CourseId = (int)comboBoxCourse.SelectedValue;

            _lectureController.UpdateLecture(selectedLecture);
            MessageBox.Show("Lecture updated.");
            LoadLectures();
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewLectures.CurrentRow == null)
            {
                MessageBox.Show("Please select a lecture to delete.");
                return;
            }

            var selectedLecture = (Lecture)dataGridViewLectures.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show("Are you sure to delete this lecture?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _lectureController.DeleteLecture(selectedLecture.LectureID);
                MessageBox.Show("Lecture deleted.");
                LoadLectures();
                ClearForm();
            }
        }

        private void dataGridViewLectures_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewLectures.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLectures.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            if (dataGridViewLectures.CurrentRow != null)
            {
                var selected = (Lecture)dataGridViewLectures.CurrentRow.DataBoundItem;
                txtLectureName.Text = selected.LectureName;
                comboBoxCourse.SelectedValue = selected.CourseId;
            }
        }

        private void ClearForm()
        {
            txtLectureName.Clear();
            comboBoxCourse.SelectedIndex = 0;
        }
    }
}
    

