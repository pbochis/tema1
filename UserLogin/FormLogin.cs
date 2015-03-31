using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using entities;
using bl;

namespace ui
{
    public partial class Form1 : Form
    {
        UserService usrsrv = new UserService();
        //FormUser fu = new FormUser();
        //FormAdmin fa = new FormAdmin();
        public Form1()
        {
            InitializeComponent();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            String n = textBox1.Text;
            String pas = textBox2.Text;

            User usr = usrsrv.login(n, pas);
            //MessageBox.Show("User: " + usr.getName() + "Pass: " + usr.getPassword());
            if (usr == null)
            {
                MessageBox.Show("Utilizator invalid");
                reset_pass.Visible = true;
            }
            else
            {

                if (usr.getType() == "admin")
                {
                    FormAdmin fa = new FormAdmin(usr.getName());
                    //fa.label1.Text("Welcome Admin: " + usr.getName);
                    fa.Show();
                }
                else
                {
                    FormUser fu = new FormUser(usr.getName());
                    fu.Show();
                }
            }
        }

        private void reset_pass_Click(object sender, EventArgs e)
        {
            String newpass = usrsrv.changePassword(textBox1.Text);
            if (newpass != "")
            {
                MessageBox.Show("Noua parola este: " + newpass);
            }
        }

        private void user_label_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void user_text_box_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
