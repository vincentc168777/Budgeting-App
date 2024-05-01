using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;


namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.Text = "Modify Budget";
            loadBudgetImage();
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

        private void loadBudgetImage()
        {
            string picPath = Path.Combine(Environment.CurrentDirectory, "pictures") ;
            float bud = DBConnect.displayBudget();
            if(bud == 0)
            {
                pictureBox1.BackgroundImage = Image.FromFile(picPath + @"\emptywallet.jpg");
            }
            else if(bud > 0 && bud < 100f)
            {
                pictureBox1.BackgroundImage = Image.FromFile(picPath + @"\almostempty.jpg");
            }
            else{

            }
            
        }
    }
}
