using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomPro.Database;
using UnicomPro.Models;

namespace UnicomPro.Controller
{
    public class CourseController
    {
        public List<Course> GetAllCourses()
        {
            var courses = new List<Course>();
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();

                    var cmd = new SQLiteCommand("SELECT CourseID, CourseName FROM Courses;", conn);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        courses.Add(new Course
                        {
                            CourseID = reader.GetInt32(0),
                            CourseName = reader.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
            }

            return courses;
        }

        public void AddCourse(Course course)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();

                    var cmd = new SQLiteCommand("INSERT INTO Courses (CourseName) VALUES (@name);", conn);
                    cmd.Parameters.AddWithValue("@name", course.CourseName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding course: " + ex.Message);
            }
        }

        public void DeleteCourse(int courseId)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();

                    var cmd = new SQLiteCommand("DELETE FROM Courses WHERE CourseID = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", courseId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting course: " + ex.Message);
            }
        }

        public void UpdateCourse(Course course)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();

                    var cmd = new SQLiteCommand("UPDATE Courses SET CourseName = @name WHERE CourseID = @id;", conn);
                    cmd.Parameters.AddWithValue("@name", course.CourseName);
                    cmd.Parameters.AddWithValue("@id", course.CourseID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating course: " + ex.Message);
            }
        }

        public int GetCourseIdByName(string courseName)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();

                    var cmd = new SQLiteCommand("SELECT CourseID FROM Courses WHERE CourseName = @name;", conn);
                    cmd.Parameters.AddWithValue("@name", courseName);
                    var result = cmd.ExecuteScalar();

                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving course ID: " + ex.Message);
                return 0;
            }
        }
    }
}
