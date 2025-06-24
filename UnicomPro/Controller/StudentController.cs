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
    public class StudentController
    {
        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();

            using (var conn = Connection.GetConnection())
            {
                conn.Open();

                var cmd = new SQLiteCommand(@"
                    SELECT 
                        StudentID,
                        StudentName,
                        
                        CourseId
                    FROM Students;", conn);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        StudentID = reader.GetInt32(0),
                        StudentName = reader.GetString(1),
                        
                        CourseID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2)
                    });
                }
            }

            return students;
        }

        public void AddStudent(Student student)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();

                var cmd = new SQLiteCommand(@"
                    INSERT INTO Students (StudentName, CourseId)
                    VALUES (@name, @courseId);", conn);

                cmd.Parameters.AddWithValue("@name", student.StudentName);
               
                cmd.Parameters.AddWithValue("@courseId", student.CourseID);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();

                var cmd = new SQLiteCommand(@"
                    UPDATE Students 
                    SET StudentName = @name, 
                        
                        CourseId = @courseId 
                    WHERE StudentID = @id;", conn);

                cmd.Parameters.AddWithValue("@name", student.StudentName);
               
                cmd.Parameters.AddWithValue("@courseId", student.CourseID);
                cmd.Parameters.AddWithValue("@id", student.StudentID);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(int studentId)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();

                var cmd = new SQLiteCommand("DELETE FROM Students WHERE StudentID = @id;", conn);
                cmd.Parameters.AddWithValue("@id", studentId);

                cmd.ExecuteNonQuery();
            }
        }

        public Student GetStudentById(int studentId)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();

                var cmd = new SQLiteCommand(@"
                    SELECT StudentID, StudentName, StudentAddress, CourseId 
                    FROM Students 
                    WHERE StudentID = @id;", conn);

                cmd.Parameters.AddWithValue("@id", studentId);

                var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Student
                    {
                        StudentID = reader.GetInt32(0),
                        StudentName = reader.GetString(1),

                        CourseID = reader.IsDBNull(3) ? 0 : reader.GetInt32(2)
                    };
                }
            }

            return null;
        }
    }
}

