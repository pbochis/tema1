using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using entities;

namespace dal
{
    public class UsersDAL
    {
        private String connectionString = "";
        MySqlConnection conn = null;

        public UsersDAL()
        {
            connectionString = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false", "localhost", "root", "", "logindb");
            conn = new MySqlConnection(connectionString);            
        }


        public User getUser(String name, String password)
        {
            User u = null;
            String sql = "SELECT * FROM Users WHERE name='" + name + "' AND password='" + password + "'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    u = new User(reader["name"].ToString(), reader["password"].ToString(), reader["type"].ToString(),Convert.ToInt32(reader["adNr"].ToString()));
                }
                else
                {
                    u = null;
                }
                conn.Close();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
                return null;
            }
            return u;
        }

        public int getAdNr(String name)
        {
            String sql = "SELECT adNr FROM Users WHERE name='" + name + "'";
            int rez = -1;

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                rez = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            return rez;
        }

        public void resetPassword(string user, string new_password)
        {
            String sql = "UPDATE Users SET password='" + new_password + "' WHERE name='" + user + "'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
        }

        public void insertNewAccount(int id, String name, String pass, String type, int adNr)
        {
            String sql = "INSERT INTO Users VALUES ('" + id +"', '" + name + "', '" + pass + "', '" + type + "', '" + adNr+"')";

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
        }

        public int getNextId()
        {
            String sql = "SELECT COUNT(*) FROM Users";
            Int32 ret = 0;
            try
            {
                conn.Open();
                MySqlCommand cmd= new MySqlCommand(sql, conn);
                ret =Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            ret++;
            return (int)ret;
        }

        public void incAdNr(String name)
        {
            int adrez = getAdNr(name);
            adrez++;
            String sql = "UPDATE Users SET adNr='" + adrez + "' WHERE name='" + name + "'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
        }

        public int existsUser(String name)
        {
            String sql = "SELECT COUNT(*) FROM Users WHERE name='"+name + "'";
            Int32 ret = 0;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                ret = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
            ret++;
            return (int)ret;
        }
    }
}
