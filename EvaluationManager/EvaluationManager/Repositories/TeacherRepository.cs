using DBLayer;
using EvaluationManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EvaluationManager.Repositories {
    public static class TeacherRepository {
        public static Teacher GetTeacher(string username) {
            string sql = $"SELECT * FROM Teachers WHERE Username = '{username}'";
            return FetchTeacher(sql);
        }
        public static Teacher GetTeacher(int id) {
            string sql = $"SELECT * FROM Teachers WHERE Id = '{id}'";
            return FetchTeacher(sql);
        }
        private static Teacher FetchTeacher(string sql) {
            DB.OpenConnection();
            SqlDataReader reader = DB.GetDataReader(sql);
            Teacher teacher = null;
            if (reader.HasRows) {
                reader.Read();
                teacher = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return teacher;
        }
        private static Teacher CreateObject(SqlDataReader reader) {
            int id = int.Parse(reader["Id"].ToString());
            string firstName = reader["FirstName"].ToString();
            string lastName = reader["LastName"].ToString();
            string username = reader["Username"].ToString();
            string password = reader["Password"].ToString();
            var teacher = new Teacher {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                Password = password,
            };
            return teacher;
        }
    }
}
