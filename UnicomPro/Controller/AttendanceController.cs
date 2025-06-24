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
    public class AttendanceController
    {
        public List<Attendance> GetAll()
        {
            var list = new List<Attendance>();
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("SELECT * FROM Attendance", conn);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(new Attendance
                        {
                            AttendanceID = int.Parse(reader["AttendanceID"].ToString()),
                            StudentID = int.Parse(reader["StudentID"].ToString()),
                            SubjectID = int.Parse(reader["SubjectID"].ToString()),
                            Date = reader["Date"].ToString(),
                            Status = reader["Status"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance records: " + ex.Message);
            }

            return list;
        }

        public void AddOrUpdate(Attendance a)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        INSERT OR REPLACE INTO Attendance (AttendanceID, StudentID, SubjectID, Date, Status)
                        VALUES (
                            (SELECT AttendanceID FROM Attendance WHERE StudentID = @studentID AND SubjectID = @subjectID AND Date = @date),
                            @studentID, @subjectID, @date, @status);";

                    var cmd = new SQLiteCommand(query, conn);
                    cmd.Parameters.AddWithValue("@studentID", a.StudentID);
                    cmd.Parameters.AddWithValue("@subjectID", a.SubjectID);
                    cmd.Parameters.AddWithValue("@date", a.Date);
                    cmd.Parameters.AddWithValue("@status", a.Status);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving attendance: " + ex.Message);
            }
        }

        public void Delete(int attendanceID)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("DELETE FROM Attendance WHERE AttendanceID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", attendanceID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting attendance record: " + ex.Message);
            }
        }
    }
}
