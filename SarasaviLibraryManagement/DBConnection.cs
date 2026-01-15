using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SarasaviLibraryManagement
{
    public static class DBConnection
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = @"Data Source=.;Initial Catalog=librarydb;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }
        public static SqlConnection OpenConnection()
        {
            SqlConnection con = GetConnection(); 
            con.Open(); 
            return con;
        }
    }
}
