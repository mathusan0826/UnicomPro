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
    public class LectureController
    {

        public List<Lecture> GetAllLectures()
        {
            var list = new List<Lecture>();
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Lectures";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Lecture
                            {
                                LectureID = reader.GetInt32(0),
                                LectureName = reader.GetString(1),
                                CourseId = reader.GetInt32(2)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading lectures: " + ex.Message);
            }

            return list;
        }

        public void AddLecture(Lecture lecture)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        INSERT INTO Lectures (LectureName, CourseId)
                        VALUES (@name, @courseId)";
                    cmd.Parameters.AddWithValue("@name", lecture.LectureName);
                    cmd.Parameters.AddWithValue("@courseId", lecture.CourseId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding lecture: " + ex.Message);
            }
        }

        public void DeleteLecture(int lectureId)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM Lectures WHERE LectureID = @id";
                    cmd.Parameters.AddWithValue("@id", lectureId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting lecture: " + ex.Message);
            }
        }

        public void UpdateLecture(Lecture lecture)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        UPDATE Lectures
                        SET LectureName = @name, CourseId = @courseId
                        WHERE LectureID = @id";
                    cmd.Parameters.AddWithValue("@name", lecture.LectureName);
                    cmd.Parameters.AddWithValue("@courseId", lecture.CourseId);
                    cmd.Parameters.AddWithValue("@id", lecture.LectureID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating lecture: " + ex.Message);
            }
        }

        public int GetCourseIdByName(string courseName)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT CourseID FROM Courses WHERE CourseName = @name";
                    cmd.Parameters.AddWithValue("@name", courseName);

                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving course ID: " + ex.Message);
                return -1;
            }
        }
    }
}
