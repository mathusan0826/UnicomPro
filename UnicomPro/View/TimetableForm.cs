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
    public partial class TimetableForm : Form
    {
          private readonly TimetableController _timetableController = new TimetableController();
        public TimetableForm()
        {
            InitializeComponent();
            LoadDays();
            LoadTimetables();
        }
        private void LoadDays()
        {
            cmbDay.Items.Clear();
            cmbDay.Items.AddRange(new string[] {
                "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
            });
            cmbDay.SelectedIndex = 0;
        }
        private void LoadTimetables()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _timetableController.GetAll();
        }

           private void ClearInputs()
        {
            txtCourseID.Clear();
            txtSubject.Clear();
            cmbDay.SelectedIndex = 0;
            txtStartTime.Clear();
            txtEndTime.Clear();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseID.Text) || string.IsNullOrWhiteSpace(txtSubject.Text))
            {
                MessageBox.Show("Please fill in Course ID and Subject.");
                return;
            }

            var timetable = new Timetable
            {
                CourseID = int.Parse(txtCourseID.Text),
                Subject = txtSubject.Text,
                Day = cmbDay.SelectedItem.ToString(),
                StartTime = txtStartTime.Text,
                EndTime = txtEndTime.Text
            };

            _timetableController.Add(timetable);
            LoadTimetables();
            ClearInputs();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a timetable to update.");
                return;
            }

            var selected = (Timetable)dataGridView1.CurrentRow.DataBoundItem;

            selected.CourseID = int.Parse(txtCourseID.Text);
            selected.Subject = txtSubject.Text;
            selected.Day = cmbDay.SelectedItem.ToString();
            selected.StartTime = txtStartTime.Text;
            selected.EndTime = txtEndTime.Text;

            _timetableController.Update(selected);
            LoadTimetables();
            ClearInputs();
            MessageBox.Show("Timetable saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a timetable to delete.");
                return;
            }

            var selected = (Timetable)dataGridView1.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show("Delete this timetable?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _timetableController.Delete(selected.TimetableID);
                LoadTimetables();
                ClearInputs();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var selected = (Timetable)dataGridView1.CurrentRow.DataBoundItem;

            txtCourseID.Text = selected.CourseID.ToString();
            txtSubject.Text = selected.Subject;
            cmbDay.SelectedItem = selected.Day;
            txtStartTime.Text = selected.StartTime;
            txtEndTime.Text = selected.EndTime;
        }

        private void cmbDay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        public void MakeReadOnly()
        {
            btnAdd.Enabled = false; // Add
            btnDelete.Enabled = false; // Delete
            btnUpdate.Enabled = false; // Update
                                     // txtCourseName.Enabled = false; // Optional: disable text box
        }

    }
}
