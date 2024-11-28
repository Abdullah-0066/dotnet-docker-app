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
    public class CityDAL
    {
        public static void SaveCity(CityModel mc) 
        {
            SqlConnection conn = DBHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SaveCity", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@citycode", mc.CityCode);
            cmd.Parameters.AddWithValue("@cityname", mc.CityName);
            cmd.Parameters.AddWithValue("@is_active", mc.IsActive);                 
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void UpdateCity(CityModel mc)
        {

        }
        public static void DeleteCity(CityModel mc)
        {
            SqlConnection conn = DBHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DeleteCity", conn);

        }
        public static void GetCity()
        {

        }
    }
}
