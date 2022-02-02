
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login 
{
    public class UserProvider : DataBase
    {

        public bool LoginUser(String Username, String Password,String Email)
        {
            bool result = false;
            using (var connection = GetConnection())
            {
                var command = new MySqlCommand("SELECT * FROM login where UserName='" + Username + "' AND Password='" + Password + "'");
                command.Connection = connection;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = true;
                    }
                }
                connection.Close();
                if (result == false)
                {
                    var command1 = new MySqlCommand("SELECT * FROM login where Email='" + Email + "' AND Password='" + Password + "'");
                    command1.Connection = connection;
                    connection.Open();
                    using (var reader = command1.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = true;
                        }
                    }
                    connection.Close();
                }
            }
            return result;
        }
        public bool LoginUser(String Username, String Email)
        {
            bool result = false;
            using (var connection = GetConnection())
            {
                var command = new MySqlCommand("SELECT * FROM login where UserName='" + Username + "'");
                command.Connection = connection;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = true;
                    }
                }
                connection.Close();
                if (result == false)
                {
                    var command1 = new MySqlCommand("SELECT * FROM login where Email='" + Email + "'");
                    command1.Connection = connection;
                    connection.Open();
                    using (var reader = command1.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = true;
                        }
                    }
                    connection.Close();
                }
            }
            return result;
        }

    }
}
