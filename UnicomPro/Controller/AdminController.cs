using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomPro.Database;
using UnicomPro.Models;

namespace UnicomPro.Controller
{
    public class AdminController
    { 
        //Add Admin
        public void AddAdmin(Admin admin)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        INSERT INTO Users (Username, Password, Role)
                        VALUES (@username, @password, 'Admin')";
                    cmd.Parameters.AddWithValue("@username", admin.Username);
                    cmd.Parameters.AddWithValue("@password", admin.Password);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding admin: " + ex.Message);
            }
        }

        // Delete Admin
        public void DeleteAdmin(int adminId)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM Users WHERE UserID = @id AND Role = 'Admin'";
                    cmd.Parameters.AddWithValue("@id", adminId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting admin: " + ex.Message);
            }
        }

        // Update Admin
        public void UpdateAdmin(Admin admin)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        UPDATE Users
                        SET Username = @username, Password = @password
                        WHERE UserID = @id AND Role = 'Admin'";
                    cmd.Parameters.AddWithValue("@username", admin.Username);
                    cmd.Parameters.AddWithValue("@password", admin.Password);
                    cmd.Parameters.AddWithValue("@id", admin.UserID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating admin: " + ex.Message);
            }
        }

        // Get All Admins
        public List<Admin> GetAllAdmins()
        {
            var admins = new List<Admin>();

            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Users WHERE Role = 'Admin'";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            admins.Add(new Admin
                            {
                                UserID = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Role = reader.GetString(3)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading admin list: " + ex.Message);
            }

            return admins;
        }
    }
}
