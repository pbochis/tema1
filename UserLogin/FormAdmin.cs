using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using bl;

namespace ui
{
    public partial class FormAdmin : Form
    {
        AnuntService anser;
        UserService usrser;

        public FormAdmin(String name)
        {
            InitializeComponent();
            label1.Text  = "Welcome Admin: " + name;
            anser = new AnuntService();
            usrser = new UserService();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String t1 = textBox1.Text, t2 = textBox2.Text, t3 = textBox3.Text;
            if (t1 != "" && t2 != "" && t3 != "")
            {
                usrser.creareCont(t1, t2, t3); //VEZI ID-ul
                
            }
            else
            {
                MessageBox.Show("Completati toate campurile: Name, Password, Type!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String t1 = textBox1.Text;
            int adrez;
            if (t1 != "")
            {
                adrez = usrser.getAdNr(t1);
                if(adrez != -1)
                {
                    //textBox4.Text = "";
                    textBox4.Text = "Raport " + t1 + ": \n" + adrez.ToString();
                }
                else
                {
                    MessageBox.Show("Eroare raport angajat!");
                }
            }
            else
            {
                MessageBox.Show("Completati campul: Name");
            }
            //getAdNr
        }
    }
}
