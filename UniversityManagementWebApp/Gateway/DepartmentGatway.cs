using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class DepartmentGatway
    {
         
        private string connectionString;
        private SqlConnection connection;
        private SqlDataReader reader;

        public DepartmentGatway()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["UniversityDBconString"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public int Save(Department department)
        {
            string query = "INSERT INTO Department(Name, Code, Flag) VALUES(@Name, @Code, @Flag)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", department.Name);
            command.Parameters.AddWithValue("@Code", department.Code);
            command.Parameters.AddWithValue("@Flag", department.Flag);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsDepartmentExist(string name, string code)
        {
            string query = "SELECT * FROM Department WHERE Name = @name AND Code = @code";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@code", code);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();
            return isExist;
        }
        public List<Department> GetAllDepartments()
        {
            string query = "SELECT * FROM Department";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Department> departmentList = new List<Department>();
            while (reader.Read())
            {
                Department department = new Department();
                department.Id = Convert.ToInt32(reader["Id"]);
                department.Name = reader["Name"].ToString();
                department.Code = reader["Code"].ToString();
                departmentList.Add(department);

            }
            connection.Close();
            return departmentList;
        }
    }
}