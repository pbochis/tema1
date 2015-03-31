using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using entities;

namespace dal
{
    public class AnunturiDAL
    {
        private String connectionString = "";
        MySqlConnection conn = null;

        public AnunturiDAL()
        {
            connectionString = String.Format("server={0};user id={1}; password={2}; database={3}; pooling=false", "localhost", "root", "", "anunturidb");
            conn = new MySqlConnection(connectionString);            
        }

        public void creareAnunt(int id, String titlu, String descriere, String poza)
        {
            String sql = "INSERT INTO Anunturi VALUES ('" + id + "', '" + titlu + "', '" + descriere + "', '" + poza + "')";
            String sql2 = "UPDATE Anunturi SET poza='" + poza + "' WHERE titlu='" + titlu + "'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                cmd2.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
            }
        }

        public Anunt getAnunt(String titlu)
        {
            Anunt an = null;
            String sql = "SELECT * FROM Anunturi WHERE titlu='" + titlu + "'";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    an = new Anunt(reader["titlu"].ToString(), reader["descriere"].ToString(), reader["poza"].ToString());
                }
                else
                {
                    an = null;
                }
                conn.Close();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                conn.Close();
                return null;
            }
            return an;
        }

        public void modificaDescriere(String titlu,String newdesc)
        {
            String sql = "UPDATE Anunturi SET descriere='" + newdesc + "' WHERE titlu='" + titlu + "'";
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

        public void deleteAnunt(String titlu)
        {
            String sql = "DELETE FROM Anunturi WHERE titlu='" + titlu + "'";
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
            String sql = "SELECT COUNT(*) FROM Anunturi";
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
