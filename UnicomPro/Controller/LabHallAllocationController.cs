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
    internal class LabHallAllocationController
    {
        public List<LabHallAllocation> GetAll()
        {
            var list = new List<LabHallAllocation>();
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("SELECT * FROM LabHallAllocations", conn);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var item = new LabHallAllocation
                        {
                            AllocationID = Convert.ToInt32(reader["AllocationID"]),
                            CourseID = Convert.ToInt32(reader["CourseID"]),
                            LocationType = reader["LocationType"].ToString(),
                            LocationName = reader["LocationName"].ToString(),
                            Day = reader["Day"].ToString(),
                            StartTime = reader["StartTime"].ToString(),
                            EndTime = reader["EndTime"].ToString()
                        };
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading allocations: " + ex.Message);
            }

            return list;
        }

        public void Add(LabHallAllocation allocation)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SQLiteCommand(@"
                        INSERT INTO LabHallAllocations 
                        (CourseID, LocationType, LocationName, Day, StartTime, EndTime) 
                        VALUES (@courseId, @type, @name, @day, @start, @end)", conn);
                    cmd.Parameters.AddWithValue("@courseId", allocation.CourseID);
                    cmd.Parameters.AddWithValue("@type", allocation.LocationType);
                    cmd.Parameters.AddWithValue("@name", allocation.LocationName);
                    cmd.Parameters.AddWithValue("@day", allocation.Day);
                    cmd.Parameters.AddWithValue("@start", allocation.StartTime);
                    cmd.Parameters.AddWithValue("@end", allocation.EndTime);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding allocation: " + ex.Message);
            }
        }

        public void Update(LabHallAllocation allocation)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SQLiteCommand(@"
                        UPDATE LabHallAllocations 
                        SET CourseID = @courseId, 
                            LocationType = @type, 
                            LocationName = @name, 
                            Day = @day, 
                            StartTime = @start, 
                            EndTime = @end 
                        WHERE AllocationID = @id", conn);
                    cmd.Parameters.AddWithValue("@courseId", allocation.CourseID);
                    cmd.Parameters.AddWithValue("@type", allocation.LocationType);
                    cmd.Parameters.AddWithValue("@name", allocation.LocationName);
                    cmd.Parameters.AddWithValue("@day", allocation.Day);
                    cmd.Parameters.AddWithValue("@start", allocation.StartTime);
                    cmd.Parameters.AddWithValue("@end", allocation.EndTime);
                    cmd.Parameters.AddWithValue("@id", allocation.AllocationID);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating allocation: " + ex.Message);
            }
        }

        public void Delete(int allocationId)
        {
            try
            {
                using (var conn = Connection.GetConnection())
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("DELETE FROM LabHallAllocations WHERE AllocationID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", allocationId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting allocation: " + ex.Message);
            }
        }

        public int GetCourseIdByName(string courseName)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving course ID: " + ex.Message);
                return -1;
            }
        }
    }
}
