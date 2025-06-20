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
    public partial class AdminForm : Form
    {
        private readonly AdminController _adminController = new AdminController();
        public AdminForm()
        {
            InitializeComponent();
            LoadAdmins();
        }
        private void LoadAdmins()
        {
            dataGridViewAdmins.DataSource = null;
            dataGridViewAdmins.DataSource = _adminController.GetAllAdmins();
        }
        private void AdminForm_Load(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridViewAdmins.CurrentRow == null)
            {
                MessageBox.Show("Please select an admin to delete.");
                return;
            }

            var selectedAdmin = (Admin)dataGridViewAdmins.CurrentRow.DataBoundItem;

            var confirm = MessageBox.Show("Are you sure to delete this admin?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _adminController.DeleteAdmin(selectedAdmin.UserID);
                MessageBox.Show("Admin deleted.");
                LoadAdmins();
                ClearForm();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            var admin = new Admin
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim()
            };

            _adminController.AddAdmin(admin);
            MessageBox.Show("Admin added successfully.");
            LoadAdmins();
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewAdmins.CurrentRow == null)
            {
                MessageBox.Show("Please select an admin to update.");
                return;
            }

            var selectedAdmin = (Admin)dataGridViewAdmins.CurrentRow.DataBoundItem;
            selectedAdmin.Username = txtUsername.Text.Trim();
            selectedAdmin.Password = txtPassword.Text.Trim();

            _adminController.UpdateAdmin(selectedAdmin);
            MessageBox.Show("Admin updated.");
            LoadAdmins();
            ClearForm();
        }

        private void dataGridViewAdmins_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewAdmins.CurrentRow != null)
            {
                var selected = (Admin)dataGridViewAdmins.CurrentRow.DataBoundItem;
                txtUsername.Text = selected.Username;
                txtPassword.Text = selected.Password;
            }
        }
        private void ClearForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void AdminForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
