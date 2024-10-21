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
    public partial class Form3 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-3VH6LQ4\SQLEXPRESS;Initial Catalog=catering;Integrated Security=True;TrustServerCertificate=True");
        public static int hizmet_id;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fr22 = new Form2();
            fr22.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked)
            {
                hizmet_id = 1;
            }
            else if (radioButton3.Checked)
            {
                hizmet_id = 2;
            }
            else if (radioButton4.Checked)
            {
                hizmet_id = 3;
            }
            else if (radioButton2.Checked)
            {
                hizmet_id = 4;
            }
           
            this.Hide();
            Form4 fr4 = new Form4();
            fr4.ShowDialog();
        }
    }
}
