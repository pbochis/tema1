using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using bl;
using entities;

namespace ui
{
    public partial class FormUser : Form
    {
        AnuntService anser;
        UserService usrser;
        String name;

        public FormUser(String name)
        {
            InitializeComponent();
            this.name = name;
            label1.Text = "Welcome: " + name;
            anser = new AnuntService();
            usrser = new UserService();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String t1 = textBox1.Text, t2 = textBox2.Text, t3 = textBox3.Text;
            String t = "";
            if (t1 != "" && t2 != "" && t3 != "")
            {
                //int prim = 0;
                for (int i = 0; i < t3.Length; i++)
                {
                    if (t3[i] == '\\')
                    {
                        t = t + t3[i] + "\\";
                    }
                    else
                    {
                        t = t + t3[i];
                    }
                }
                //MessageBox.Show(t);
                anser.creareAnunt(t1,t2,t);
                usrser.incAdNr(name);
                MessageBox.Show("Anunt introdus!");
            }
            else
            {
                MessageBox.Show("Completati toate campurile: Titlu, Descriere, Poza!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String t1 = textBox1.Text;
            if (t1 != "")
            {
                Anunt an = anser.citesteAnunt(t1);
                
                pictureBox1.Image = Image.FromFile(@an.getPoza());
                textBox2.Text = an.getDescriere();
                textBox3.Text = an.getPoza();
            }
            else
            {
                MessageBox.Show("Completati campul: Titlu!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String t1 = textBox1.Text;
            if (t1 != "")
            {
                anser.stergeAnunt(t1);
                MessageBox.Show("Anunt sters!");
            }
            else
            {
                MessageBox.Show("Completati campul: Titlu!");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String t1 = textBox1.Text, t2 = textBox2.Text;
            if (t1 != "" && t2 != "")
            {
                anser.updateAnunt(t1, t2);
                MessageBox.Show("Anunt modificat!");
            }
            else
            {
                MessageBox.Show("Completati campurile: Titlu, Descriere!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Open file";
            openFileDialog1.InitialDirectory = @"d:\";
            openFileDialog1.Filter = "Image Files (*.bmp, *.jpg)|*.bmp;*.jpg";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = openFileDialog1.FileName;
            }
        }
    }
}
