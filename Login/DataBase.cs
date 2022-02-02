using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class DataBase
    {
        public static MySqlConnection GetConnection()
        {
           
            string connection;
          
                connection = @"Data Source=localhost;port=3306;Initial Catalog=mall;User Id=root;password=''";
          
     
            

            return new MySqlConnection(connection);
        }
    }
}
