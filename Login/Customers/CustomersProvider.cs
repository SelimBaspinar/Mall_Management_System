using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class CustomersProvider:DataBase
    {
        DataTable data;
        MySqlDataAdapter baglayici;
        public DataTable getCustomers()
        {
            MySqlConnection connection = GetConnection();


            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM customers";
            data = new DataTable();
            baglayici = new MySqlDataAdapter();
            baglayici.SelectCommand = cmd;
            baglayici.Fill(data);
            cmd.ExecuteNonQuery();
            connection.Close();
            return data;
        }
        public DataTable removeCustomers(String Id)
        {
            MySqlConnection connection = GetConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            string sql = "DELETE FROM customers WHERE Id='" + Id + "'";
            cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            return getCustomers();

        }
        public DataTable updateDiscount(String Id,  String Discount)
        {

            MySqlConnection connection = GetConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "UPDATE customers SET Discount= '" + Discount +  "'where Id=" + Id + "";

            cmd.ExecuteNonQuery();
            connection.Close();
            return getCustomers();

        }
        public DataTable updateScount(String Id,String Lsdate, String Scount,String Sstat)
        {

            MySqlConnection connection = GetConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "UPDATE customers SET ShoppingCount= '" + Scount + "',Lsdate='" + Lsdate + "',Sstat='" + Sstat + "'where Id=" + Id + "";

            cmd.ExecuteNonQuery();
            connection.Close();
            return getCustomers();

        }

       

        public bool ContainsCustomers(string Id)
        {
            bool result = false;
            using (var connection = GetConnection())
            {
                var command = new MySqlCommand("SELECT *FROM customers WHERE Id='" + Id + "'");
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

        public bool InsertCustomers(string Id, string Name, string Surname,String Date,String Discount,String Lsdate,String Scount)
        {
            bool result = false;

            if (!ContainsCustomers(Id))
            {
                using (var connection = GetConnection())
                {
                    var command = new MySqlCommand("INSERT INTO customers(Id,Name,Surname,Date,Discount,Lsdate,ShoppingCount) VALUES('" + Id + "','" + Name + "','" + Surname + "','" +Date+"','" +Discount +  "','" + Lsdate+ "','" + Scount + "')");
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
