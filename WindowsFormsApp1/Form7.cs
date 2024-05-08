using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            this.Text = "Login";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool loginExists = DBConnect.FindLogin(textBox1.Text, textBox2.Text);
            if (loginExists)
            {
                MessageBox.Show("Login successful!", "Sucess");
                Form2 f2 = new Form2();
                f2.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login credentials do not exist.", "Warning");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
