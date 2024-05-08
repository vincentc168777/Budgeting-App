using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using System.Drawing.Text;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form6 : Form
    {
        private int id;
        public Form6(int i)
        {
            InitializeComponent();
            this.Text = "Delete Item";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            id = i;
            label6.Text = DBConnect.getName(id);
            label7.Text = Convert.ToString(DBConnect.getCost(id));
            label8.Text = DBConnect.getDescription(id);
            loadImages();
        }
        private void loadImages()
        {
            string picPath = Path.Combine(Environment.CurrentDirectory, "pictures");
            float bud = DBConnect.displayBudget();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Image.FromFile(picPath + @"\trashcan.png");
        }
        
        private void Form6_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DBConnect.DeleteItem((int)dataGridView2.Rows[e.RowIndex].Cells["ID"].Value);
            DBConnect.DeleteItem(id);
            Program.mainDisplay.LoadData();
            this.Close();
            if (DBConnect.displayBudget() < (DBConnect.displayTotal()))
            {
                bool form3open = false;
                FormCollection fc = Application.OpenForms;

                foreach (Form frm in fc)
                {
                    if (frm.Name == "Form3")
                    {
                        form3open = true;
                    }
                }
                if (!form3open)
                {
                    DialogResult resultBudget = MessageBox.Show("Total spending exceeds budget, would you like to update your budget?.", "Warning", MessageBoxButtons.YesNo);
                    if (resultBudget == DialogResult.Yes)
                    {
                        Form4 f4 = new Form4();
                        f4.Show();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
