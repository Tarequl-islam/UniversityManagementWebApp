using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class CourceAssignGateway
    {
        private string connectionString;
        private SqlConnection connection;
        private SqlDataReader reader;

        public CourceAssignGateway()
        {
            connectionString = WebConfigurationManager.
                    ConnectionStrings["UniversityDBconString"].
                    ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        public int Save(CourceAssign courceAssign)
        {
            string query = "INSERT INTO CourceAssign(DepartmentId, TeacherId, CourceId, Flag) VALUES(@DepartmentId, @TeacherId, @CourceId, @Flag)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DepartmentId", courceAssign.DepartmentId);
            command.Parameters.AddWithValue("@TeacherId", courceAssign.TeacherId);
            command.Parameters.AddWithValue("@CourceId", courceAssign.CourceId);
            command.Parameters.AddWithValue("@Flag", courceAssign.Flag);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
        public int UpdateCredit(CourceAssign courceAssign)
        {
            string query = "UPDATE Teacher SET RemainingCradit=RemainingCradit-@courceCredit WHERE Id=@teacherId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@courceCredit", courceAssign.CourceCredit);
            command.Parameters.AddWithValue("@teacherId", courceAssign.TeacherId);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsCourceAssignExist(int departmentId, int teacherId, int courceId)
        {
            string query = "SELECT * FROM CourceAssign WHERE DepartmentId = @departmentId AND TeacherId = @teacherId AND CourceId = @courceId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@departmentId", departmentId);
            command.Parameters.AddWithValue("@teacherId", teacherId);
            command.Parameters.AddWithValue("@courceId", courceId);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();
            return isExist;
        }

        public List<CourceAssign> GetSelectedTeacher (int departmentId)
        {
            string query = "SELECT * FROM Teacher WHERE DepartmentId = @departmentId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@departmentId", departmentId);
            connection.Open();
            reader = command.ExecuteReader();
            List<CourceAssign> teacherList = new List<CourceAssign>();
            while (reader.Read())
            {
                CourceAssign teacher = new CourceAssign();
                teacher.TeacherId = Convert.ToInt32(reader["Id"]);
                teacher.TeacherName = reader["Name"].ToString();
                teacher.Credit = Convert.ToDouble(reader["Credit"]);
                teacher.RemaningCredit = Convert.ToDouble(reader["RemainingCradit"]);

                teacherList.Add(teacher);
            }
            connection.Close();
            return teacherList;
        }
        public List<CourceAssign> GetSelectedCource(int departmentId)
        {
            string query = "SELECT * FROM Cource WHERE DepartmentId = @departmentId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@departmentId", departmentId);
            connection.Open();
            reader = command.ExecuteReader();
            List<CourceAssign> courceList = new List<CourceAssign>();
            while (reader.Read())
            {
                CourceAssign cource = new CourceAssign();
                cource.CourceId = Convert.ToInt32(reader["Id"]);
                cource.CourceName = reader["Name"].ToString();
                cource.CourceCredit = Convert.ToDouble(reader["Cradit"]);
                cource.CourceCode = reader["Code"].ToString();

                courceList.Add(cource);
            }
            connection.Close();
            return courceList;
        }

        public CourceAssign GetTeacherDetails(int teacherId)
        {
            string query = "SELECT * FROM Teacher WHERE Id = @teacherId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@teacherId", teacherId);
            connection.Open();
            reader = command.ExecuteReader();
            CourceAssign teacher = new CourceAssign();
            while (reader.Read())
            {
                teacher.TeacherId = Convert.ToInt32(reader["Id"]);
                teacher.TeacherName = reader["Name"].ToString();
                teacher.Credit = Convert.ToDouble(reader["Credit"]);
                teacher.RemaningCredit = Convert.ToDouble(reader["RemainingCradit"]);
            }
            connection.Close();
            return teacher;
        }
        public CourceAssign GetCourceDetails(int courceId)
        {
            string query = "SELECT * FROM Cource WHERE Id = @courceId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@courceId", courceId);
            connection.Open();
            reader = command.ExecuteReader();
            CourceAssign cource = new CourceAssign();
            while (reader.Read())
            {
                cource.CourceId = Convert.ToInt32(reader["Id"]);
                cource.CourceName = reader["Name"].ToString();
                cource.CourceCredit = Convert.ToDouble(reader["Cradit"]);
                cource.CourceCode = reader["Code"].ToString();
            }
            connection.Close();
            return cource;
        }
    }
}