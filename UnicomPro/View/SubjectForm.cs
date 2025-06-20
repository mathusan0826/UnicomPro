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
    public partial class SubjectForm : Form
    {
        private readonly SubjectController _subjectController = new SubjectController();
        private readonly CourseController _courseController = new CourseController();
        private List<Course> _courses;
        public SubjectForm()
        {
            InitializeComponent();
            LoadCourses();
            LoadSubjects();
        }
        private void LoadCourses()
        {
            _courses = _courseController.GetAllCourses();
            comboBoxCourse.DataSource = _courses;
            comboBoxCourse.DisplayMember = "CourseName";
            comboBoxCourse.ValueMember = "CourseID";
        }
        private void LoadSubjects()
        {
            dataGridViewSubjects.DataSource = null;
            dataGridViewSubjects.DataSource = _subjectController.GetAllSubjects();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSubjectName.Text) || comboBoxCourse.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter a subject name and select a course.");
                return;
            }

            var subject = new Subject
            {
                SubjectName = txtSubjectName.Text.Trim(),
                CourseId = (int)comboBoxCourse.SelectedValue
            };

            _subjectController.AddSubject(subject);
            MessageBox.Show("Subject added successfully.");
            LoadSubjects();
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (dataGridViewSubjects.CurrentRow == null)
            {
                MessageBox.Show("Please select a subject to update.");
                return;
            }

            var selectedSubject = (Subject)dataGridViewSubjects.CurrentRow.DataBoundItem;
            selectedSubject.SubjectName = txtSubjectName.Text.Trim();
            selectedSubject.CourseId = (int)comboBoxCourse.SelectedValue;

            _subjectController.UpdateSubject(selectedSubject);
            MessageBox.Show("Subject updated.");
            LoadSubjects();
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewSubjects.CurrentRow == null)
            {
                MessageBox.Show("Please select a subject to delete.");
                return;
            }

            var selectedSubject = (Subject)dataGridViewSubjects.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show("Are you sure to delete this subject?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _subjectController.DeleteSubject(selectedSubject.SubjectID);
                MessageBox.Show("Subject deleted.");
                LoadSubjects();
                ClearForm();
            }
        }

        private void dataGridViewSubjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSubjects.CurrentRow != null)
            {
                var selected = (Subject)dataGridViewSubjects.CurrentRow.DataBoundItem;
                txtSubjectName.Text = selected.SubjectName;
                comboBoxCourse.SelectedValue = selected.CourseId;
            }
        }
        private void ClearForm()
        {
            txtSubjectName.Clear();
            comboBoxCourse.SelectedIndex = 0;
        }
    }
}
