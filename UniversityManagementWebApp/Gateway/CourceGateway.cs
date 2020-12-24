using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class CourceGateway
    {
        
        private string connectionString;
        private SqlConnection connection;
        private SqlDataReader reader;

        public CourceGateway()
        {
            connectionString = WebConfigurationManager.
                    ConnectionStrings["UniversityDBconString"].
                    ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        public int Save(Cource cource)
        {
            string query = "INSERT INTO Cource(Name, Code, Cradit, DepartmentId, SemisterId, Description, Flag) VALUES(@Name, @Code, @Cradit, @DepartmentId, @SemisterId, @Description, @Flag)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", cource.Name);
            command.Parameters.AddWithValue("@Code", cource.Code);
            command.Parameters.AddWithValue("@Cradit", cource.Cradit);
            command.Parameters.AddWithValue("@DepartmentId", cource.DepartmentId);
            command.Parameters.AddWithValue("@SemisterId", cource.SemisterId);
            command.Parameters.AddWithValue("@Description", cource.Description);
            command.Parameters.AddWithValue("@Flag", cource.Flag);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsCourceExist(string name, string code)
        {
            string query = "SELECT * FROM Cource WHERE Name = @name AND Code = @code";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@code", code);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();
            return isExist;
        }

        public List<Semister> GetAllSemister()
        {
            string query = "SELECT * FROM Semister";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Semister> semisterList = new List<Semister>();
            while (reader.Read())
            {
                Semister semister = new Semister();
                semister.Id = Convert.ToInt32(reader["Id"]);
                semister.Name = reader["Name"].ToString();
                semisterList.Add(semister);

            }
            connection.Close();
            return semisterList;
        }
    }
}