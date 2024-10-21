using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace catering
{
    public partial class Form1 : Form
    {
        public static int musteri_id;
        public Form1()
        {
            InitializeComponent();
          
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-3VH6LQ4\SQLEXPRESS;Initial Catalog=catering;Integrated Security=True;TrustServerCertificate=True");
        
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            

            string sorgu = "insert into Musteriler(Musteri_Adi,Musteri_Soyadi,Musteri_Tel,Musteri_Sifre)values(@ad,@soyad,@tel,@sifre) ";
            string sorgu2 = "select MAX(Musteri_ID) from Musteriler where Musteri_Adi=@ad and Musteri_Soyadi=@soyad and Musteri_Tel=@tel and Musteri_Sifre=@sifre";

            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);

            komut.Parameters.AddWithValue("@ad", textBox1.Text);
            komut.Parameters.AddWithValue("@soyad", textBox2.Text);
            komut.Parameters.AddWithValue("@tel", textBox3.Text);
            komut.Parameters.AddWithValue("@sifre", textBox4.Text);

            komut2.Parameters.AddWithValue("@ad", textBox1.Text);
            komut2.Parameters.AddWithValue("@soyad", textBox2.Text);
            komut2.Parameters.AddWithValue("@tel", textBox3.Text);
            komut2.Parameters.AddWithValue("@sifre", textBox4.Text);

            baglanti.Open();
            komut.ExecuteNonQuery();
            musteri_id = Convert.ToInt32(komut2.ExecuteScalar()); 

            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox3.Text=="")
            {
                MessageBox.Show("Bütün Alanları Doldurunuz");

            }
            
            else
            {
                baglanti.Close();
                this.Hide();
                Form2 fr2 = new Form2();
                fr2.ShowDialog();
            }

          
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (textBox3.Text.Length >= 11 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox4.Focus();
                e.Handled = true;
            }

        }

        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox2.Focus();
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox3.Focus();
                e.Handled = true;
            }
        }

        
    }
}
