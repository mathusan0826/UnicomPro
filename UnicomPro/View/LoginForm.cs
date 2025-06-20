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
                MessageBox.Show("Login Sucess");
                MainDashboardForm mainDashboardForm = new MainDashboardForm();
                mainDashboardForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Error","info",MessageBoxButtons.OK);

            

             


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
