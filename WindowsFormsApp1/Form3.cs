﻿using System;
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
            float i = 0;
            bool isNum = float.TryParse(textBox2.Text, out i);
            Item item = new Item();
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && isNum)
            {
                item.ItemName = textBox1.Text;
                item.Cost = i;
                DBConnect.SaveItem(item);
                
                DialogResult resultEntry = MessageBox.Show("Transaction entry saved. Would you like to add another entry?", "Success", MessageBoxButtons.YesNo);
                if (resultEntry == DialogResult.No)
                {
                    this.Close();
                    
                    
                }
                
                Program.mainDisplay.LoadData();
                textBox1.Clear();
                textBox2.Clear();

                

                if (DBConnect.displayBudget() < (DBConnect.displayTotal()))
                {
                    DialogResult resultBudget = MessageBox.Show("Total spending exceeds budget, would you like to update your budget?.", "Warning", MessageBoxButtons.YesNo);
                    if (resultBudget == DialogResult.Yes)
                    {
                        Form4 f4 = new Form4();
                        f4.Show();
                    }
                }
                
                    
                

                
            }
            else
            {
                MessageBox.Show("Invalid or missing values.", "Warning");
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
