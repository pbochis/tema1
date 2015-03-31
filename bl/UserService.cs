using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dal;
using entities;
using System.Security.Cryptography;


namespace bl
{
    public class UserService
    {
        UsersDAL usrdal;

        public UserService()
        {
            usrdal = new UsersDAL();
        }

        public User login(String user, String pass)
        {
            String p = getMd5Hash(pass);
            User usr = usrdal.getUser(user, p);
            return usr;
        }

        private string getMd5Hash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public String changePassword(String user)
        {
            if (usrdal.existsUser(user)!=1)
            {
                String newpass = generatePassword();
                usrdal.resetPassword(user, getMd5Hash(newpass));
                return newpass;
            }
            else
            {
                MessageBox.Show("User doesn't exist in database!");
            }
            return "";

        }

        private string generatePassword()
        {
            String s = DateTime.Now.ToString("h:mm:ss");

            return "parola"+s[2]+s[5]+s[3]+s[6];
        }

        public void creareCont(String name, String pass, String type)
        {
            int id = usrdal.getNextId();
            String p = getMd5Hash(pass);
            if (id != 1)
            {
                usrdal.insertNewAccount(id, name, p, type,0);
            }
            else
            {
                MessageBox.Show("Error counting Users rows!");
            }
        }

        public int getAdNr(String name)
        {
            return usrdal.getAdNr(name);
        }

        public void incAdNr(String name)
        {
            usrdal.incAdNr(name);
        }
    }
}
