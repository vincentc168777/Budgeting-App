using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
        }
        //this button saves transaction info into database
        private void button1_Click(object sender, EventArgs e)
        {
            
            Item item = new Item();
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                item.ItemName = textBox1.Text;
                float i = 0;
                bool isNum = float.TryParse(textBox2.Text, out i);
                if (isNum)
                {
                    item.Cost = i;

                    DBConnect.SaveItem(item);
                    MessageBox.Show("Transaction Entry Saved");
                    this.Close();
                    Program.mainDisplay.LoadData();
                    if (DBConnect.displayBudget() < (DBConnect.displayTotal()))
                    {
                        MessageBox.Show("Total spending exceeds budget.", "Warning");
                    }
                }

                
            }
            

          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
