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
    public class TimetableController
    {

        public List<Timetable> GetAll()
        {
            var list = new List<Timetable>();

            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Timetable", conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var t = new Timetable
                    {
                        TimetableID = Convert.ToInt32(reader["TimetableID"]),
                        CourseID = Convert.ToInt32(reader["CourseID"]),
                        Subject = reader["Subject"].ToString(),
                        Day = reader["Day"].ToString(),
                        StartTime = reader["StartTime"].ToString(),
                        EndTime = reader["EndTime"].ToString()
                    };
                    list.Add(t);
                }
            }

            return list;
        }

        public void Add(Timetable t)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                var cmd = new SQLiteCommand("INSERT INTO Timetable (CourseID, Subject, Day, StartTime, EndTime) VALUES (@courseId, @subject, @day, @start, @end)", conn);
                cmd.Parameters.AddWithValue("@courseId", t.CourseID);
                cmd.Parameters.AddWithValue("@subject", t.Subject);
                cmd.Parameters.AddWithValue("@day", t.Day);
                cmd.Parameters.AddWithValue("@start", t.StartTime);
                cmd.Parameters.AddWithValue("@end", t.EndTime);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Timetable t)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                var cmd = new SQLiteCommand("UPDATE Timetable SET CourseID = @courseId, Subject = @subject, Day = @day, StartTime = @start, EndTime = @end WHERE TimetableID = @id", conn);
                cmd.Parameters.AddWithValue("@courseId", t.CourseID);
                cmd.Parameters.AddWithValue("@subject", t.Subject);
                cmd.Parameters.AddWithValue("@day", t.Day);
                cmd.Parameters.AddWithValue("@start", t.StartTime);
                cmd.Parameters.AddWithValue("@end", t.EndTime);
                cmd.Parameters.AddWithValue("@id", t.TimetableID);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int timetableId)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                var cmd = new SQLiteCommand("DELETE FROM Timetables WHERE TimetableID = @id", conn);
                cmd.Parameters.AddWithValue("@id", timetableId);
                cmd.ExecuteNonQuery();
            }
        }

        public int GetCourseIdByName(string courseName)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                var cmd = new SQLiteCommand("SELECT CourseID FROM Courses WHERE CourseName = @name", conn);
                cmd.Parameters.AddWithValue("@name", courseName);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }
    }
}

