using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ModelClass;

namespace DataAccessLayer
{
    public class StudentDAL
    {
        public static void SaveStudent(StudentModel student)
        {
            SqlConnection conn = DBHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SaveStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
            cmd.Parameters.AddWithValue("@Age", student.Age);
            cmd.Parameters.AddWithValue("@Gender", student.Gender);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@EnrollmentDate", student.EnrollmentDate);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        // Update student record
        public static void UpdateStudent(StudentModel student)
        {
            SqlConnection conn = DBHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("UpdateStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StudentID", student.StudentID);
            cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
            cmd.Parameters.AddWithValue("@Age", student.Age);
            cmd.Parameters.AddWithValue("@Gender", student.Gender);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@EnrollmentDate", student.EnrollmentDate);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        // Delete student record
        public static void DeleteStudent(int studentID)
        {
            SqlConnection conn = DBHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DeleteStudent", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StudentID", studentID);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static List<StudentModel> GetAllStudents()
        {
            List<StudentModel> students = new List<StudentModel>();

            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Students", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new StudentModel
                    {
                        StudentID = reader.GetInt32(reader.GetOrdinal("StudentID")),
                        StudentName = reader.GetString(reader.GetOrdinal("StudentName")),
                        Age = reader.GetInt32(reader.GetOrdinal("Age")),
                        Gender = reader.GetString(reader.GetOrdinal("Gender")),
                        Email = reader.GetString(reader.GetOrdinal("Email")),
                        EnrollmentDate = reader.GetDateTime(reader.GetOrdinal("EnrollmentDate"))
                    });
                }
            }

            return students;
        }
    }
}
