using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catering
{
    
    public partial class Form4 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-3VH6LQ4\SQLEXPRESS;Initial Catalog=catering;Integrated Security=True;TrustServerCertificate=True");
        public static int mutfak_id;
        public Form4()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox1.Visible = true;
            }
            else
            {
                groupBox1.Visible = false;
            }
            button2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 fr33 = new Form3();
            fr33.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            if (radioButton2.Checked)
            {
                mutfak_id = 1;
            }
            else if (radioButton3.Checked)
            {
                mutfak_id = 2;
            }
            else if (radioButton4.Checked)
            {
                mutfak_id = 3;
            }
            else if (radioButton5.Checked)
            {
                mutfak_id = 4;
            }
            else if (radioButton6.Checked)
            {
                mutfak_id = 5;
            }

            this.Hide();
            Menu fr5 = new Menu();
            fr5.ShowDialog();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
