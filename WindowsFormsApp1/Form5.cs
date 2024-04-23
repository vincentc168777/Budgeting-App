using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        private int id;
        public Form5(int i)
        {
            InitializeComponent();
            id = i;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox1.Text = DBConnect.getName(id);
            textBox2.Text = Convert.ToString(DBConnect.getCost(id));
            textBox3.Text = DBConnect.getDescription(id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float i = 0;
            bool isNum = float.TryParse(textBox2.Text, out i);
            Item item = new Item();
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && isNum)
            {
                item.ItemName = textBox1.Text;
                item.Cost = i;
                item.Description = textBox3.Text;
                DBConnect.EditItem(id, item.ItemName, (decimal)item.Cost, item.Description);
                Program.mainDisplay.LoadData();
                this.Close();
            }
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
    }
}
