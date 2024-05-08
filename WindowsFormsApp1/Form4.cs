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
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
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
            float i;
            bool isNum = float.TryParse(textBox1.Text, out i);

            if (isNum && i >=0 ) {
                
                this.Close();
                DBConnect.saveBudget(i);
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
            //loads diff image depending on ur budget amount
            string picPath = Path.Combine(Environment.CurrentDirectory, "pictures") ;
            float bud = DBConnect.displayBudget();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            if (bud == 0)
            {
                pictureBox1.Image = Image.FromFile(picPath + @"\empty.png");
            }
            else 
            {
                pictureBox1.Image = Image.FromFile(picPath + @"\filled.png");
            }
            

        }
    }
}
