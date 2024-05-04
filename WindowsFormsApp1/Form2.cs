using System;
using System.Drawing;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Text = "Transactions Home";
            //DBConnect.clearData();
            //DBConnect.createBudgetTable();
            LoadData();
            textBox1.KeyUp += textBox1_KeyUp;

            
           
        }

        //displays data from database
        public void LoadData()
        {
            
            dataGridView2.DataSource = DBConnect.LoadItem();
            label3.Text = Convert.ToString(DBConnect.displayBudget());
            label5.Text = Convert.ToString(DBConnect.displayTotal());

        }

        //leads to popup that allows data to be input
            private void button1_Click(object sender, EventArgs e)
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
                Form3 f3 = new Form3();
                f3.Show();
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged_1(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView2.Columns["dataGridViewDeleteButton"].Index)
            {
                if (dataGridView2.Rows.Count > e.RowIndex) {
                    bool form6open = false;
                    FormCollection fc = Application.OpenForms;

                    foreach (Form frm in fc)
                    {
                        if (frm.Name == "Form6")
                        {
                            form6open = true;
                        }
                    }
                    if (!form6open)
                    {
                        Form6 f6 = new Form6((int)dataGridView2.Rows[e.RowIndex].Cells["ID"].Value);
                        f6.Show();
                    }

                }
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView2.Columns["dataGridViewEditButton"].Index)
            {
                if (dataGridView2.Rows.Count > e.RowIndex)
                {
                    bool form5open = false;
                    FormCollection fc = Application.OpenForms;

                    foreach (Form frm in fc)
                    {
                        if (frm.Name == "Form5")
                        {
                            form5open = true;
                        }
                    }
                    if (!form5open)
                    {
                            Form5 f5 = new Form5((int)dataGridView2.Rows[e.RowIndex].Cells["ID"].Value);
                            f5.Show();
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView2.Columns[1].HeaderText = "Name";
            dataGridView2.Columns[2].HeaderText = "Price ($)";

            dataGridView2.Columns[1].Width = 130;

            dataGridView2.Columns["description"].Width = 185;

            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.Name = "dataGridViewEditButton";
            editButton.HeaderText = "";
            editButton.Text = "Edit";
            editButton.UseColumnTextForButtonValue = true;
            this.dataGridView2.Columns.Add(editButton);
            dataGridView2.Columns["dataGridViewEditButton"].Width = 50;

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.Name = "dataGridViewDeleteButton";
            deleteButton.HeaderText = "";
            deleteButton.Text = "×";
            deleteButton.UseColumnTextForButtonValue = true;
            this.dataGridView2.Columns.Add(deleteButton);

            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            dataGridView2.Columns["Id"].Visible = false;
            dataGridView2.Columns["dataGridViewDeleteButton"].Width = 40;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool form4open = false;
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Name == "Form4")
                {
                    form4open = true;
                }
            }
            if (!form4open)
            {
                Form4 f4 = new Form4();
                f4.Show();
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
  
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView2.DataSource = DBConnect.GetItemsWithLetters(textBox1.Text);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }


    }
}
