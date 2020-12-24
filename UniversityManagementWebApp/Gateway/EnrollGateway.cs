using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class EnrollGateway
    { private string connectionString;
        private SqlConnection connection;
        private SqlDataReader reader;

        public EnrollGateway()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["UniversityDBconString"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        public List<Enroll> GetAllStudents()
        {
            string query = "SELECT * FROM Student";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Enroll> enrollList = new List<Enroll>();
            while (reader.Read())
            {
                Enroll student = new Enroll();
                student.Id = Convert.ToInt32(reader["Id"]);
                student.Name = reader["Name"].ToString();
                student.RegistNo = reader["RegiNo"].ToString();
                student.Email = reader["Email"].ToString();
                student.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                enrollList.Add(student);

            }
            connection.Close();
            return enrollList;
        }
        public List<Enroll> GetAllCources()
        {
            string query = "SELECT * FROM Cource";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Enroll> enrollList = new List<Enroll>();
            while (reader.Read())
            {
                Enroll cource = new Enroll();
                cource.Id = Convert.ToInt32(reader["Id"]);
                cource.Name = reader["Code"].ToString();
                enrollList.Add(cource);

            }
            connection.Close();
            return enrollList;
        }

        public Enroll GetSelectedStudent(int stdId)
        {
            string query = "SELECT * FROM StudentView WHERE Id = @stdId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@stdId", stdId);
            connection.Open();
            reader = command.ExecuteReader();
            Enroll student = new Enroll();
            while (reader.Read())
            {
                student.Id = Convert.ToInt32(reader["Id"]);
                student.Name = reader["Name"].ToString();
                student.Email = reader["Email"].ToString();
                student.Department = reader["DepartmentName"].ToString();
                student.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
            }
            connection.Close();
            return student;
        }

        public int Save(Enroll enroll)
        {
            string query = "INSERT INTO EnrollCource(StudentId, CourceId, Date) VALUES(@StudentId, @CourceId, @Date)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentId", enroll.StudentId);
            command.Parameters.AddWithValue("@CourceId", enroll.CourceId);
            command.Parameters.AddWithValue("@Date", enroll.Date);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsCourceExist(int studentId, int courceId)
        {
            string query = "SELECT * FROM EnrollCource WHERE studentId = @StudentId AND CourceId = @courceId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@studentId", studentId);
            command.Parameters.AddWithValue("@courceId", courceId);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();
            return isExist;
        }

        public List<Result> GetAllGrades()
        {
            string query = "SELECT * FROM Grade";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Result> enrollList = new List<Result>();
            while (reader.Read())
            {
                Result cource = new Result();
                cource.GradeId = Convert.ToInt32(reader["Id"]);
                cource.GradeName = reader["Name"].ToString();
                enrollList.Add(cource);

            }
            connection.Close();
            return enrollList;
        }

        public int SaveResult(Result enroll)
        {
            string query = "INSERT INTO Result(StudentId, CourceId, GradeId) VALUES(@StudentId, @CourceId, @GradeId)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentId", enroll.StudentId);
            command.Parameters.AddWithValue("@CourceId", enroll.CourceId);
            command.Parameters.AddWithValue("@GradeId", enroll.GradeId);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
        public bool IsResultExist(int studentId, int courceId)
        {
            string query = "SELECT * FROM Result WHERE studentId = @StudentId AND CourceId = @courceId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@studentId", studentId);
            command.Parameters.AddWithValue("@courceId", courceId);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();
            return isExist;
        }

    }
}