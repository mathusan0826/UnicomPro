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
    public partial class MarkForm : Form
    {
        private readonly MarksController _marksController = new MarksController();
        private readonly StudentController _studentController = new StudentController();
        private readonly ExamController _examController = new ExamController();

        private List<Student> _students;
        private List<Exam> _exams;
        public MarkForm()
        {
            InitializeComponent();
            LoadStudents();
            LoadExams();
            LoadMarks();


        }
        private void MarkForm_Load(object sender, EventArgs e)
        {
           
        }


        private void LoadStudents()
        {
            _students = _studentController.GetAllStudents();
            comboBoxStudent.DataSource = _students;
            comboBoxStudent.DisplayMember = "StudentName";
            comboBoxStudent.ValueMember = "StudentID";
        }
        private void LoadExams()
        {
            _exams = _examController.GetAllExams();
            comboBoxExam.DataSource = _exams;
            comboBoxExam.DisplayMember = "ExamName";
            comboBoxExam.ValueMember = "ExamID";
        }
        private void LoadMarks()
        {
            dataGridView1.DataSource = null;
            var c= _marksController.GetAllMarks();
            dataGridView1.DataSource = c;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var selected = (Mark)dataGridView1.CurrentRow.DataBoundItem;
                comboBoxStudent.SelectedValue = selected.StudentID;
                comboBoxExam.SelectedValue = selected.ExamID;
                txtScore.Text = selected.Score.ToString();
            }

        }

        private void btnAddMark_Click(object sender, EventArgs e)
        {
            if (comboBoxStudent.SelectedIndex == -1 || comboBoxExam.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtScore.Text))
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            if (!float.TryParse(txtScore.Text, out float score))
            {
                MessageBox.Show("Invalid score.");
                return;
            }

            var mark = new Mark
            {
                StudentID = (int)comboBoxStudent.SelectedValue,
                ExamID = (int)comboBoxExam.SelectedValue,
                Score = score
            };

            _marksController.AddMark(mark);
            LoadMarks();
            ClearInputs();
        }

        private void btnUpdateMark_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a mark to update.");
                return;
            }

            var selected = (Mark)dataGridView1.CurrentRow.DataBoundItem;

            if (!float.TryParse(txtScore.Text, out float score))
            {
                MessageBox.Show("Invalid score.");
                return;
            }

            selected.StudentID = (int)comboBoxStudent.SelectedValue;
            selected.ExamID = (int)comboBoxExam.SelectedValue;
            selected.Score = score;

            _marksController.UpdateMark(selected);
            LoadMarks();
            ClearInputs();
        }

        private void btnDeleteMark_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a mark to delete.");
                return;
            }

            var selected = (Mark)dataGridView1.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show("Delete selected mark?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _marksController.DeleteMark(selected.MarkID);
                LoadMarks();
                ClearInputs();
            }
        }
        private void ClearInputs()
        {
            txtScore.Clear();
            comboBoxStudent.SelectedIndex = 0;
            comboBoxExam.SelectedIndex = 0;
        }

        private void MarkForm_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
    }

