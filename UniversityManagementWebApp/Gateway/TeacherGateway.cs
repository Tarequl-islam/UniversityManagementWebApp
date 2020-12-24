using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class TeacherGateway
    {
        
        private string connectionString;
        private SqlConnection connection;
        private SqlDataReader reader;

        public TeacherGateway()
        {
            connectionString = WebConfigurationManager.
                    ConnectionStrings["UniversityDBconString"].
                    ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        public int Save(Teacher teacher)
        {
            string query = "INSERT INTO Teacher(Name, Address, Email, ContactNo, DesignationId, DepartmentId, Credit, RemainingCradit, Flag) VALUES(@Name, @Address, @Email, @ContactNo, @DesignationId, @DepartmentId, @Credit, @RemaningCredit, @Flag)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", teacher.Name);
            command.Parameters.AddWithValue("@Address", teacher.Address);
            command.Parameters.AddWithValue("@Email", teacher.Email);
            command.Parameters.AddWithValue("@ContactNo", teacher.ContactNo);
            command.Parameters.AddWithValue("@DesignationId", teacher.DesignationId);
            command.Parameters.AddWithValue("@DepartmentId", teacher.DepartmentId);
            command.Parameters.AddWithValue("@Credit", teacher.Credit);
            command.Parameters.AddWithValue("@RemaningCredit", teacher.RemaningCradit);
            command.Parameters.AddWithValue("@Flag", teacher.Flag);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsTeacherExist(string name)
        {
            string query = "SELECT * FROM Teacher WHERE Name = @name";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", name);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();
            return isExist;
        }

        public List<Designation> GetAllDesignations()
        {
            string query = "SELECT * FROM Designation";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Designation> designationList = new List<Designation>();
            while (reader.Read())
            {
                Designation designation = new Designation();
                designation.Id = Convert.ToInt32(reader["Id"]);
                designation.Name = reader["Name"].ToString();
                designationList.Add(designation);

            }
            connection.Close();
            return designationList;
        }
    }
}