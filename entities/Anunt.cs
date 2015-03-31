using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace entities
{
    public class Anunt
    {
        String titlu;
        String descriere;
        String poza;
        //byte[] poza;

        public Anunt(String titlu, String descriere, String poza)
        {
            this.titlu = titlu;
            this.descriere = descriere;
            this.poza = poza;
        }

        public String getTitlu()
        {
            return titlu;
        }

        public String getDescriere()
        {
            return descriere;
        }

        public String getPoza()
        {
            return poza;
        }
    }
}
