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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textUser.Text;
            String password = textPass.Text;
            if (username =="admin" && password =="admin")
            {
                MessageBox.Show("Admin Login Sucess");
                MainDashboardForm mainDashboardForm = new MainDashboardForm();
                mainDashboardForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Admin Login Error","info",MessageBoxButtons.OK);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String username = textUser.Text;
            String password = textPass.Text;
            if (username == "staff" && password == "staff")
            {
                MessageBox.Show("Staff Login Sucess");
                //MainDashboardForm mainDashboardForm = new MainDashboardForm();
                //mainDashboardForm.Show();
                //this.Hide();
                MessageBox.Show("Lecture Login Sucess");
                StaffDashboardForm staffDashboardForm = new StaffDashboardForm();
                staffDashboardForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(" Staff Login Error", "info", MessageBoxButtons.OK);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String username = textUser.Text;
            String password = textPass.Text;
            if (username == "lec" && password == "lec")
            {
                LectureDashboardForm lectureDashboardForm = new LectureDashboardForm();
                lectureDashboardForm.Show();
                this.Hide();
                //MainDashboardForm mainDashboardForm = new MainDashboardForm();
                //mainDashboardForm.Show();
                //this.Hide();
            }
            else
            {
                MessageBox.Show(" Lecture Login Error", "info", MessageBoxButtons.OK);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String username = textUser.Text;
            String password = textPass.Text;
            if (username == "student" && password == "student")
            {
                MessageBox.Show(" Student  Login Sucess");
                StudentDashboardForm studentDashboardForm = new StudentDashboardForm();
                studentDashboardForm.Show();
                this.Hide();
                //MainDashboardForm mainDashboardForm = new MainDashboardForm();
                //mainDashboardForm.Show();
                //this.Hide();
            }
            else
            {
                MessageBox.Show(" Student Login Error", "info", MessageBoxButtons.OK);

            }

        }

        private void textPass_TextChanged(object sender, EventArgs e)
        {
//
        }
    }
}
