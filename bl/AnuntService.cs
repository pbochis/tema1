using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dal;
using entities;

namespace bl
{
    public class AnuntService
    {
        AnunturiDAL andal;

        public AnuntService()
        {
            andal = new AnunturiDAL();
        }

        public void creareAnunt(String titlu, String descriere, String poza)
        {
            int id = andal.getNextId();
            if (id != 1)
            {
                andal.creareAnunt(id, titlu, descriere, poza);
            }
            else
            {
                MessageBox.Show("Error counting Users rows!");
            }
            
        }

        public Anunt citesteAnunt(String titlu)
        {
            return andal.getAnunt(titlu);
        }

        public void updateAnunt(String titlu, String descriere)
        {
            andal.modificaDescriere(titlu, descriere);
        }

        public void stergeAnunt(String titlu)
        {
            andal.deleteAnunt(titlu);
        }
    }
}
