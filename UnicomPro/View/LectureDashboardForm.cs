using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnicomPro.View
{
    public partial class LectureDashboardForm : Form
    {
        public LectureDashboardForm()
        {
            InitializeComponent();
        }
        private void LoadFormIntoPanel(Form formToLoad)
        {
            panel3.Controls.Clear(); // Ensure you have a panel named panelContainer
            formToLoad.TopLevel = false;
            formToLoad.FormBorderStyle = FormBorderStyle.None;
            formToLoad.Dock = DockStyle.Fill;
            panel3.Controls.Add(formToLoad);
            formToLoad.Show();
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //LoadFormIntoPanel(new ExamForm());
            //btnAddExam.visible=false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new MarkForm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
           
          
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new TimetableForm());
        }
    }
}
