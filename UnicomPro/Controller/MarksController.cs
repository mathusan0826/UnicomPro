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
    public class MarksController
    {
        public List<Mark> GetAllMarks()
        {
            var marksList = new List<Mark>();

            using (var conn = Connection.GetConnection())
            {
                conn.Open();

                var cmd = new SQLiteCommand(@"
                    SELECT MarkID, StudentID, ExamID, Score 
                    FROM Marks;", conn);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    marksList.Add(new Mark
                    {
                        MarkID = reader.GetInt32(0),
                        StudentID = reader.GetInt32(1),
                        ExamID = reader.GetInt32(2),
                        Score = reader.GetFloat(3)
                    });
                }
            }

            return marksList;
        }

        public void AddMark(Mark mark)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();

                var cmd = new SQLiteCommand(@"
                    INSERT INTO Marks (StudentID, ExamID, Score)
                    VALUES (@studentId, @examId, @score);", conn);

                cmd.Parameters.AddWithValue("@studentId", mark.StudentID);
                cmd.Parameters.AddWithValue("@examId", mark.ExamID);
                cmd.Parameters.AddWithValue("@score", mark.Score);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteMark(int markId)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();

                var cmd = new SQLiteCommand("DELETE FROM Marks WHERE MarkID = @id;", conn);
                cmd.Parameters.AddWithValue("@id", markId);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateMark(Mark mark)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();

                var cmd = new SQLiteCommand(@"
                    UPDATE Marks 
                    SET StudentID = @studentId, 
                        ExamID = @examId, 
                        Score = @score 
                    WHERE MarkID = @id;", conn);

                cmd.Parameters.AddWithValue("@studentId", mark.StudentID);
                cmd.Parameters.AddWithValue("@examId", mark.ExamID);
                cmd.Parameters.AddWithValue("@score", mark.Score);
                cmd.Parameters.AddWithValue("@id", mark.MarkID);

                cmd.ExecuteNonQuery();
            }
        }

        public int GetMarksIdByStudentName(string studentName)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();

                var cmd = new SQLiteCommand(@"
                    SELECT m.MarkID 
                    FROM Marks m
                    JOIN Students s ON m.StudentID = s.StudentID
                    WHERE s.StudentName = @name;", conn);

                cmd.Parameters.AddWithValue("@name", studentName);

                var result = cmd.ExecuteScalar();

                return result != null ? System.Convert.ToInt32(result) : 0;
            }
        }

        public int GetCourseIdByName(string courseName)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();

                var cmd = new SQLiteCommand(@"
                    SELECT CourseID 
                    FROM Courses 
                    WHERE CourseName = @name;", conn);

                cmd.Parameters.AddWithValue("@name", courseName);

                var result = cmd.ExecuteScalar();

                return result != null ? Convert.ToInt32(result) : 0;
            }
        }
    }
}
