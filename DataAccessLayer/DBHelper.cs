using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DBHelper
    {
        public static SqlConnection GetConnection () 
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-3M7NQIU;Initial Catalog=StudentDB;Integrated Security=True;");
            return conn;
        }
    }
}
