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
    internal class LabHallAllocationController
    {
        public List<LabHallAllocation> GetAll()
        {
            var list = new List<LabHallAllocation>();

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

            return list;
        }

        public void Add(LabHallAllocation allocation)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                var cmd = new SQLiteCommand("INSERT INTO LabHallAllocations (CourseID, LocationType, LocationName, Day, StartTime, EndTime) VALUES (@courseId, @type, @name, @day, @start, @end)", conn);
                cmd.Parameters.AddWithValue("@courseId", allocation.CourseID);
                cmd.Parameters.AddWithValue("@type", allocation.LocationType);
                cmd.Parameters.AddWithValue("@name", allocation.LocationName);
                cmd.Parameters.AddWithValue("@day", allocation.Day);
                cmd.Parameters.AddWithValue("@start", allocation.StartTime);
                cmd.Parameters.AddWithValue("@end", allocation.EndTime);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(LabHallAllocation allocation)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                var cmd = new SQLiteCommand("UPDATE LabHallAllocations SET CourseID = @courseId, LocationType = @type, LocationName = @name, Day = @day, StartTime = @start, EndTime = @end WHERE AllocationID = @id", conn);
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

        public void Delete(int allocationId)
        {
            using (var conn = Connection.GetConnection())
            {
                conn.Open();
                var cmd = new SQLiteCommand("DELETE FROM LabHallAllocations WHERE AllocationID = @id", conn);
                cmd.Parameters.AddWithValue("@id", allocationId);
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
