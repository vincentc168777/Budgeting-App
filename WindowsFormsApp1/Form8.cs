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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            this.Text = "Sign Up";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool loginExists = DBConnect.FindLogin(textBox1.Text, textBox2.Text);
            if (!loginExists) {
                DBConnect.SaveLogin(textBox1.Text, textBox2.Text);
                MessageBox.Show("Sign up successful!", "Success");
                this.Close();
            }
            else
            {
                MessageBox.Show("Username already exists, please try another one.", "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
