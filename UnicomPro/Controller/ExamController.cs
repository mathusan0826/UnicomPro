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
    public class ExamController
    {
        public List<Exam> GetAllExams()
        {
            var exams = new List<Exam>();
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("SELECT ExamID, ExamName FROM Exams;", conn);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        exams.Add(new Exam
                        {
                            ExamID = reader.GetInt32(0),
                            ExamName = reader.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading exams: " + ex.Message);
            }

            return exams;
        }

        public void AddExam(Exam exam)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("INSERT INTO Exams (ExamName) VALUES (@name);", conn);
                    cmd.Parameters.AddWithValue("@name", exam.ExamName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding exam: " + ex.Message);
            }
        }

        public void DeleteExam(int examId)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("DELETE FROM Exams WHERE ExamID = @id;", conn);
                    cmd.Parameters.AddWithValue("@id", examId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting exam: " + ex.Message);
            }
        }

        public void UpdateExam(Exam exam)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("UPDATE Exams SET ExamName = @name WHERE ExamID = @id;", conn);
                    cmd.Parameters.AddWithValue("@name", exam.ExamName);
                    cmd.Parameters.AddWithValue("@id", exam.ExamID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating exam: " + ex.Message);
            }
        }

        public int GetExamIdByName(string examName)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("SELECT ExamID FROM Exams WHERE ExamName = @name;", conn);
                    cmd.Parameters.AddWithValue("@name", examName);
                    var result = cmd.ExecuteScalar();

                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving Exam ID: " + ex.Message);
                return 0;
            }
        }
    }
}
