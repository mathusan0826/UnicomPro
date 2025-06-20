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
    public partial class ExamForm : Form
    {
        private readonly ExamController _examController = new ExamController();
        public ExamForm()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddExam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtExamName.Text))
            {
                MessageBox.Show("Please enter exam name.");
                return;
            }

            var exam = new Exam
            {
                ExamName = txtExamName.Text.Trim()
            };

            _examController.AddExam(exam);
            LoadExams();
            txtExamName.Clear();
        }

        private void btnUpdateExam_Click(object sender, EventArgs e)
        {
            if (dataGridViewExams.CurrentRow == null)
            {
                MessageBox.Show("Please select an exam to update.");
                return;
            }

            var selected = (Exam)dataGridViewExams.CurrentRow.DataBoundItem;
            selected.ExamName = txtExamName.Text.Trim();

            _examController.UpdateExam(selected);
            LoadExams();
            txtExamName.Clear();
        }

        private void btnDeleteExam_Click(object sender, EventArgs e)
        {
            if (dataGridViewExams.CurrentRow == null)
            {
                MessageBox.Show("Please select an exam to delete.");
                return;
            }

            var selected = (Exam)dataGridViewExams.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show($"Delete exam '{selected.ExamName}'?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _examController.DeleteExam(selected.ExamID);
                LoadExams();
                txtExamName.Clear();
            }
        }

        private void dataGridViewExams_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridViewExams.CurrentRow != null)
            {
                var selected = (Exam)dataGridViewExams.CurrentRow.DataBoundItem;
                txtExamName.Text = selected.ExamName;
            }
        }
        private void LoadExams()
        {
            dataGridViewExams.DataSource = null;
            dataGridViewExams.DataSource = _examController.GetAllExams();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }   
}
