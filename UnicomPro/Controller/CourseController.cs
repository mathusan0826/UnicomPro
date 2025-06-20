using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomPro.Database;
using UnicomPro.Models;

namespace UnicomPro.Controller
{
    public class CourseController
    {
        public List<Course> GetAllCourses()
        {
            var courses = new List<Course>();

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

            return courses;
        }

        public void AddCourse(Course course)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();

                var cmd = new SQLiteCommand("INSERT INTO Courses (CourseName) VALUES (@name);", conn);
                cmd.Parameters.AddWithValue("@name", course.CourseName);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCourse(int courseId)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();

                var cmd = new SQLiteCommand("DELETE FROM Courses WHERE CourseID = @id;", conn);
                cmd.Parameters.AddWithValue("@id", courseId);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCourse(Course course)
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

        public int GetCourseIdByName(string courseName)
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
    }
}
