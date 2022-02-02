using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class EmpleyeeProvider:DataBase
    {
        DataTable data;
        MySqlDataAdapter baglayici;
        public DataTable getEmployee()
        {
            MySqlConnection connection = GetConnection();


            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM login";
            data = new DataTable();
            baglayici = new MySqlDataAdapter();
            baglayici.SelectCommand = cmd;
            baglayici.Fill(data);
            cmd.ExecuteNonQuery();
            connection.Close();
            return data;
        }
        public DataTable getEmployee(string UsernameorEmail)
        {
            bool result = false;
            MySqlConnection connection = GetConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM login Where UserName='" + UsernameorEmail + "'";
            data = new DataTable();
            baglayici = new MySqlDataAdapter();
            baglayici.SelectCommand = cmd;
            baglayici.Fill(data);
            cmd.ExecuteNonQuery();
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    result = true;
                  
                }
            }
            connection.Close();
            if (result == false) {
                connection.Open();
                MySqlCommand cmd1 = connection.CreateCommand();
                cmd1.CommandText = "SELECT * FROM login Where Email='" + UsernameorEmail + "'";
                data = new DataTable();
                baglayici = new MySqlDataAdapter();
                baglayici.SelectCommand = cmd1;
                baglayici.Fill(data);
                cmd1.ExecuteNonQuery();
                using (var reader = cmd1.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = true;
                       
                    }
                }
            } 
        
            connection.Close();
            return data;
        }
        public DataTable removeEmployee(String Id )
        {
            MySqlConnection connection = GetConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            string sql = "DELETE FROM login WHERE Id='" + Id + "'";
            cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            return getEmployee();

        }
        public DataTable updateEmployee(String Id, String SWorkingHours,String EWorkingHours )
        {

            MySqlConnection connection = GetConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "UPDATE login SET SWorkingHours= '" + SWorkingHours+ "',EWorkingHours='" + EWorkingHours + "'where Id=" + Id + "";

            cmd.ExecuteNonQuery();
            connection.Close();
            return getEmployee();

        }
        public DataTable updateEmployee(String Id, String Name, String Surname,String Username,String Password,String Email )
        {

            MySqlConnection connection = GetConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "UPDATE login SET Name= '" + Name + "',Surname='" + Surname + "',UserName='" +Username+ "',Password='" + Password + "',Email='" + Email + "'where Id=" + Id + "";

            cmd.ExecuteNonQuery();
            connection.Close();
            return getEmployee(Username);

        }


        public bool ContainsEmployee(string Id)
        {
            bool result = false;
            using (var connection = GetConnection())
            {
                var command = new MySqlCommand("SELECT *FROM login WHERE Id='" + Id + "'");
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

        public bool InsertEmployee(string Id, string Name, string Surname, String UserName, String Password, String Email, String SWorkingHours, String EWorkingHours)
        {
            bool result = false;

            if (!ContainsEmployee(Id))
            {
                using (var connection = GetConnection())
                {
                    var command = new MySqlCommand("INSERT INTO login(Id,Name,Surname,UserName,Password,Email,SWorkingHours,EWorkingHours) VALUES('" + Id + "','" + Name + "','" + Surname + "','" + UserName + "','" + Password + "','" + Email + "','" + SWorkingHours + "','" + EWorkingHours + "')");
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
