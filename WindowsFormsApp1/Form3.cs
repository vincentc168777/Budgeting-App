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
        ///SQLiteConnection conn = new SQLiteConnection("Data Source=testdb.db;");
        //SQLiteCommand command;
        public Form3()
        {
            InitializeComponent();
        }
        //this button saves transaction info into database
        private void button1_Click(object sender, EventArgs e)
        {
            //conn.Open();
            //command = new SQLiteCommand("INSERT INTO Items (ItemName, Cost) VALUES (@ItemName, @Cost)", conn);
            //command.ExecuteNonQuery();
            Item item = new Item();
            item.ItemName = textBox1.Text;
  
            item.Cost = (float) Convert.ToDouble(textBox2.Text);
            DBConnect.SavePeople(item);
            MessageBox.Show("Transaction Entry Saved");
            this.Close();
            Program.mainDisplay.LoadData();

          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
