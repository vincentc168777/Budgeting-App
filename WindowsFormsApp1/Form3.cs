using System;

using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Add Item";
        }
        //this button saves transaction info into database
        private void button1_Click(object sender, EventArgs e)
        {
            float i;
            bool isNum = float.TryParse(textBox2.Text, out i);
            Item item = new Item();
            if (!string.IsNullOrEmpty(textBox1.Text) && isNum && i >= 0)
            {
                item.ItemName = textBox1.Text;
                item.Cost = i;
                item.Description = textBox3.Text;
                DBConnect.SaveItem(item);
                
                DialogResult resultEntry = MessageBox.Show("Transaction entry saved. Would you like to add another entry?", "Success", MessageBoxButtons.YesNo);
                if (resultEntry == DialogResult.No)
                {
                    this.Close();
                    
                    
                }
                
                Program.mainDisplay.LoadData();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();  



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
            else
            {
                MessageBox.Show("Invalid or missing values.", "Warning");
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
