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
    public partial class LapHallAllocationForm : Form
    {
        private readonly LabHallAllocationController _controller = new LabHallAllocationController();
        public LapHallAllocationForm()
        {
            InitializeComponent();
            LoadDays();
            LoadTypes();
            LoadAllocations();
        }
        private void LoadDays()
        {
            cmbDay.Items.Clear();
            cmbDay.Items.AddRange(new string[]
            {
                "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
            });
            cmbDay.SelectedIndex = 0;
        }

        private void LoadTypes()
        {
            cmbLocationType.Items.Clear();
            cmbLocationType.Items.AddRange(new string[] { "Lab", "Hall" });
            cmbLocationType.SelectedIndex = 0;
        }

        private void LoadAllocations()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _controller.GetAll();
        }

        private void ClearInputs()
        {
            txtCourseID.Clear();
            txtLocationName1.Clear();
            cmbDay.SelectedIndex = 0;
            cmbLocationType.SelectedIndex = 0;
            txtStartTime.Clear();
            txtEndTime.Clear();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCourseID.Text) || string.IsNullOrWhiteSpace(txtLocationName.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            var allocation = new LabHallAllocation
            {
                CourseID = int.Parse(txtCourseID.Text),
                LocationType = cmbLocationType.SelectedItem.ToString(),
                LocationName = txtLocationName.Text,
                Day = cmbDay.SelectedItem.ToString(),
                StartTime = txtStartTime.Text,
                EndTime = txtEndTime.Text
            };

            _controller.Add(allocation);
            LoadAllocations();
            ClearInputs();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a record to update.");
                return;
            }

            var selected = (LabHallAllocation)dataGridView1.CurrentRow.DataBoundItem;

            selected.CourseID = int.Parse(txtCourseID.Text);
            selected.LocationType = cmbLocationType.SelectedItem.ToString();
            selected.LocationName = txtLocationName.Text;
            selected.Day = cmbDay.SelectedItem.ToString();
            selected.StartTime = txtStartTime.Text;
            selected.EndTime = txtEndTime.Text;

            _controller.Update(selected);
            LoadAllocations();
            ClearInputs();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a record to delete.");
                return;
            }

            var selected = (LabHallAllocation)dataGridView1.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show("Delete this record?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _controller.Delete(selected.AllocationID);
                LoadAllocations();
                ClearInputs();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            var selected = (LabHallAllocation)dataGridView1.CurrentRow.DataBoundItem;

            txtCourseID.Text = selected.CourseID.ToString();
            cmbLocationType.SelectedItem = selected.LocationType;
            txtLocationName.Text = selected.LocationName;
            cmbDay.SelectedItem = selected.Day;
            txtStartTime.Text = selected.StartTime;
            txtEndTime.Text = selected.EndTime;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtLocationName1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
