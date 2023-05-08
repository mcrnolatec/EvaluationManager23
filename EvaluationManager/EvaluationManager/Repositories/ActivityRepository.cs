using DBLayer;
using EvaluationManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationManager.Repositories {
    public static class ActivityRepository {
        public static Activity GetStudent(int id) {

            Activity aktvnost = null;
            string sql = $"SELECT * FROM Students WHERE Id = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows) {
                reader.Read();
                aktvnost = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
                return aktvnost;
            }
            public static List<Activity> GetActivity() {
                List<Activity> aktivnosti = new List<Activity>();
                string sql = "SELECT * FROM Activities";
                DB.OpenConnection();
                var reader = DB.GetDataReader(sql);
                while (reader.Read()) {
                    Activity aktivnost = CreateObject(reader);
                    aktivnosti.Add(aktivnost);
                }
                reader.Close();
                DB.CloseConnection();
                return aktivnosti;
            }
            private static Activity CreateObject(SqlDataReader reader) {
                int id = int.Parse(reader["Id"].ToString());
                string name = reader["Name"].ToString();
                string description = reader["Description"].ToString();
                int.TryParse(reader["MaxPoints"].ToString(), out int maxPoints);
                int.TryParse(reader["MinPointsForGrade"].ToString(), out int minPointsForGrade);
                int.TryParse(reader["MinPointsForSignature"].ToString(), out int minPointsForSignature);
                var aktivnost = new Activity {
                    Id = id,
                    Name = name,
                    Description = description,
                    MaxPoints = maxPoints,
                    MinPointsForSignature = minPointsForSignature,
                    MinPointsForGrade = minPointsForGrade,
                };
                return aktivnost;
            }
        }
}
