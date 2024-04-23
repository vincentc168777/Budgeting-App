using System;

using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
           
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label7.Text = Convert.ToString(DBConnect.displayBudget());
        }

        //ui of saving budget info
        private void button1_Click(object sender, EventArgs e)
        {
            float i = 0;
            bool isNum = float.TryParse(textBox1.Text, out i);

            if (textBox1.Text != null && isNum) {
                
                float output = (float)Convert.ToDouble(textBox1.Text);
                this.Close();
                DBConnect.saveBudget(output);
                MessageBox.Show("Budget Updated!");
                Program.mainDisplay.LoadData();
    
            }
            else
            {
                MessageBox.Show("Invalid value.", "Warning");
            }
             

        }
    }
}
