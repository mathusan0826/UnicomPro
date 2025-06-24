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
    public class SubjectController
    {
        public void AddSubject(Subject subject)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        INSERT INTO Subjects (SubjectName, CourseId)
                        VALUES (@name, @courseId)";
                    cmd.Parameters.AddWithValue("@name", subject.SubjectName);
                    cmd.Parameters.AddWithValue("@courseId", subject.CourseId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding subject: " + ex.Message);
            }
        }

        public void DeleteSubject(int subjectId)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE FROM Subjects WHERE SubjectID = @id";
                    cmd.Parameters.AddWithValue("@id", subjectId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting subject: " + ex.Message);
            }
        }

        public void UpdateSubject(Subject subject)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                        UPDATE Subjects
                        SET SubjectName = @name, CourseId = @courseId
                        WHERE SubjectID = @id";
                    cmd.Parameters.AddWithValue("@name", subject.SubjectName);
                    cmd.Parameters.AddWithValue("@courseId", subject.CourseId);
                    cmd.Parameters.AddWithValue("@id", subject.SubjectID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating subject: " + ex.Message);
            }
        }

        public List<Subject> GetAllSubjects()
        {
            var subjects = new List<Subject>();
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Subjects";

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            subjects.Add(new Subject
                            {
                                SubjectID = reader.GetInt32(0),
                                SubjectName = reader.GetString(1),
                                CourseId = reader.GetInt32(2)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading subjects: " + ex.Message);
            }
            return subjects;
        }
    }
}
