using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class ProductProvider:DataBase
    {
        DataTable data ;
        MySqlDataAdapter baglayici ;
        public DataTable getStat()
        {
            MySqlConnection connection = GetConnection();


            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM statistics";
            data = new DataTable();
            baglayici = new MySqlDataAdapter();
            baglayici.SelectCommand = cmd;
            baglayici.Fill(data);
            cmd.ExecuteNonQuery();
            connection.Close();
            return data;
        }
        public DataTable removeStat(String IdName)
        {
            MySqlConnection connection = GetConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            string sql = "DELETE FROM statistics WHERE Id='" + IdName + "'";
            cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            return getProduct();

        }
        public DataTable updateStat(String Id, String Name)
        {

            MySqlConnection connection = GetConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "UPDATE statistics SET Name= '" + Name  + "'where Id=" + Id + "";

            cmd.ExecuteNonQuery();
            connection.Close();
            return getProduct();

        }
        public DataTable updateStattsale(String Id, String Tsale)
        {

            MySqlConnection connection = GetConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "UPDATE statistics SET TSales= '" + Tsale + "'where Id=" + Id + "";

            cmd.ExecuteNonQuery();
            connection.Close();
            return getStat();

        }
        public DataTable updateStatlsale(String Id, String Lsale,String Sstat )
        {

            MySqlConnection connection = GetConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "UPDATE statistics SET LSales= '" + Lsale + "',Sstat='" + Sstat+ "'where Id=" + Id + "";

            cmd.ExecuteNonQuery();
            connection.Close();
            return getStat();

        }
        public bool ContainsStat(string Id)
        {
            bool result = false;
            using (var connection = GetConnection())
            {
                var command = new MySqlCommand("SELECT *FROM statistics WHERE Id='" + Id + "'");
                command.Connection = connection;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        result = true;
                    else
                        result = false;

                }
                connection.Close();

            }
            return result;
        }
        public bool InsertStat(string Id, string Name,  string Tsale, string Lsale )
        {
            bool result = false;

            if (!ContainsStat(Id ))
            {
                using (var connection = GetConnection())
                {
                    var command = new MySqlCommand("INSERT INTO statistics(Id,Name,TSales, LSales) VALUES('" + Id + "','" + Name + "','"  + Tsale + "','" + Lsale + "')");
                    command.Connection = connection;
                    connection.Open();
                    if (command.ExecuteNonQuery() != -1)
                    {
                        result = true;
                    }
                    connection.Close();
                }
            }
            return result;
        }
        public DataTable getProduct()
        {
            MySqlConnection connection = GetConnection();


            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM product";
            data = new DataTable();
            baglayici = new MySqlDataAdapter();
            baglayici.SelectCommand = cmd;  
            baglayici.Fill(data);
            cmd.ExecuteNonQuery();
            connection.Close();
            return data;
        }
        public DataTable removeProduct(String IdName)
        {
                MySqlConnection connection = GetConnection();
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                string sql = "DELETE FROM product WHERE Id='" + IdName + "'";
                cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                return getProduct();

        }
       
        public DataTable updateProduct(String Id,String Name,String Count )
        {

                MySqlConnection connection = GetConnection();
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = "UPDATE product SET Count= '" + Count + "',Name='" + Name + "'where Id=" + Id;
           
                cmd.ExecuteNonQuery();
                connection.Close();
            return getProduct();

        }
        public DataTable updateProduct(String Id, String Count)
        {

            MySqlConnection connection = GetConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "UPDATE product SET Count= '" + Count  + "'where Id=" + Id + "";

            cmd.ExecuteNonQuery();
            connection.Close();
            return getProduct();
        }
        public bool ContainsProduct(string Id)
        {
            bool result = false;
            using (var connection = GetConnection())
            {
                var command = new MySqlCommand("SELECT *FROM product WHERE Id='" + Id + "'");
                command.Connection = connection;
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        result = true;
                    else
                        result = false;
 
                }
                connection.Close();
               
            }
            return result;
        }

        public bool InsertProduct(string Id,string Name,string Count)
        {
            bool result=false;
     
            if (!ContainsProduct(Id)) 
            {
                using (var connection = GetConnection())
                {
                    var command = new MySqlCommand("INSERT INTO product(Id,Name,Count) VALUES('" + Id + "','" + Name + "','" + Count +"')");
                    command.Connection = connection;
                    connection.Open();
                    if (command.ExecuteNonQuery() != -1)
                    {
                        result = true;
                    }
                    connection.Close();
                }
            }
            return result;
        }
       
    }
}
