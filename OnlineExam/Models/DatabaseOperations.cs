using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTest.Models
{
    public static class DatabaseOperations
    {
        private static string CONNECTION_STRING = @"Data Source=PCA171\SQL2017;Initial Catalog=OnlineTest;Integrated Security=True";

        public static  string GetConnectionString()
        {
            return CONNECTION_STRING;
        }
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(CONNECTION_STRING);
        } 
    }
}
