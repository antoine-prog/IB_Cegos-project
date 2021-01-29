using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiFilRougeIB.Utils
{
    public class ConnectionSql
    {

        private static string server = "localhost";
        private static string user = "root";
        private static string password = "root";
        private static string db = "ibFilRouge";
        private static string port = "3306";

        private ConnectionSql() { }
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(GetConnStr());
        }

        private static string GetConnStr()
        {
            StringBuilder connStr = new StringBuilder();
            connStr.Append($"server={server};");
            connStr.Append($"user={user};");
            connStr.Append($"database={db};");
            connStr.Append($"port={port};");
            connStr.Append($"password={password}");
            return connStr.ToString();
        }


    }
}