using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomPro.Database;
using UnicomPro.Models;

namespace UnicomPro.Controller
{
    public class LectureController
    {

        public List<Lecture> GetAllLectures()
        {
            var list = new List<Lecture>();
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
            return list;
        }
        public void AddLecture(Lecture lecture)
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

        public void DeleteLecture(int lectureId)
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

        public void UpdateLecture(Lecture lecture)
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

        public int GetCourseIdByName(string courseName)
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
    }
}
