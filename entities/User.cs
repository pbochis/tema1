using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace entities
{
    public class User
    {
        String name;
        String password;
        String type;
        int adNr;

        public User(String name, String pass, String type,int adNr)
        {
            this.name = name;
            this.password = pass;
            this.type = type;
            this.adNr = adNr;
        }

        public String getName()
        {
            return name;
        }

        public String getPassword()
        {
            return password;
        }

        public String getType()
        {
            return type;
        }

        public int getAdNr()
        {
            return adNr;
        }
    }
}
