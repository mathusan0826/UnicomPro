using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnicomPro.Database
{
    public static class Migration
    {
        public static void CreateTables()
        {
            using (var connection = Connection.GetConnection())
            {
                connection.Open();

                // Create Courses table
                var createCoursesTable = @"
                    CREATE TABLE IF NOT EXISTS Courses (
                        CourseID INTEGER PRIMARY KEY AUTOINCREMENT,
                        CourseName TEXT NOT NULL
                    );";

                using (var cmd = new SQLiteCommand(createCoursesTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                // Create Students table with correct foreign key reference
                var createStudentsTable = @"
                    CREATE TABLE IF NOT EXISTS Students (
                        StudentID INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentName TEXT NOT NULL,
                        CourseId INTEGER,
                        FOREIGN KEY (CourseId) REFERENCES Courses(CourseID)
                    );";

                using (var cmd = new SQLiteCommand(createStudentsTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }

               // MessageBox.Show("Tables created successfully!");



                var createExamsTable = @"
                    CREATE TABLE IF NOT EXISTS Exams (
                          ExamID INTEGER PRIMARY KEY AUTOINCREMENT,
                           ExamName TEXT NOT NULL
                 );";

                using (var cmd = new SQLiteCommand(createExamsTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                var createMarksTable = @"
                    CREATE TABLE IF NOT EXISTS Marks (
                           MarkID INTEGER PRIMARY KEY AUTOINCREMENT,
                            StudentID INTEGER,
                            ExamID INTEGER,
                            Score REAL NOT NULL,
                          FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
                          FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
    );";

                using (var cmd = new SQLiteCommand(createMarksTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }
               

                var createTimetableTable = @"
                    CREATE TABLE IF NOT EXISTS Timetable (
                        TimetableID INTEGER PRIMARY KEY AUTOINCREMENT,
                        CourseID INTEGER NOT NULL,
                        Subject TEXT NOT NULL,
                        Day TEXT NOT NULL,
                        StartTime TEXT NOT NULL,
                        EndTime TEXT NOT NULL,
                        FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
                    );";

                using (var cmd = new SQLiteCommand(createTimetableTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                

             

                // LabHallAllocations table
                var createLabHallTable = @"
                    CREATE TABLE IF NOT EXISTS LabHallAllocations (
                        AllocationID INTEGER PRIMARY KEY AUTOINCREMENT,
                        CourseID INTEGER NOT NULL,
                        LocationType TEXT NOT NULL,     -- 'Lab' or 'Hall'
                        LocationName TEXT NOT NULL,     -- e.g., 'Lab 1'
                        Day TEXT NOT NULL,
                        StartTime TEXT NOT NULL,
                        EndTime TEXT NOT NULL,
                        FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
                    );";

                using (var cmd = new SQLiteCommand(createLabHallTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }

              //  MessageBox.Show("Timetables and Lab/Hall Allocation tables created successfully!");


                string query = @"
                 CREATE TABLE IF NOT EXISTS Attendance (
                       AttendanceID INTEGER PRIMARY KEY AUTOINCREMENT,
                      StudentID INTEGER NOT NULL,
                      SubjectID INTEGER NOT NULL,
                      Date TEXT NOT NULL,
                      Status TEXT NOT NULL,
                      UNIQUE(StudentID, SubjectID, Date),
                      FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
                      FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
            );";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();
                }

              
                var createLecturesTable = @"
    CREATE TABLE IF NOT EXISTS Lectures (
        LectureID INTEGER PRIMARY KEY AUTOINCREMENT,
        LectureName TEXT NOT NULL,
        CourseId INTEGER,
        FOREIGN KEY (CourseId) REFERENCES Courses(CourseID)
    );";

                using (var cmd = new SQLiteCommand(createLecturesTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                var createSubjectsTable = @"
    CREATE TABLE IF NOT EXISTS Subjects (
        SubjectID INTEGER PRIMARY KEY AUTOINCREMENT,
        SubjectName TEXT NOT NULL,
        CourseId INTEGER,
        FOREIGN KEY (CourseId) REFERENCES Courses(CourseID)
    );";

                using (var cmd = new SQLiteCommand(createSubjectsTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                var createUsersTable = @"
    CREATE TABLE IF NOT EXISTS Users (
        UserID INTEGER PRIMARY KEY AUTOINCREMENT,
        Username TEXT NOT NULL UNIQUE,
        Password TEXT NOT NULL,
        Role TEXT NOT NULL
    );";

                using (var cmd = new SQLiteCommand(createUsersTable, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        }
           
        }
    

