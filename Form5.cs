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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Data.SqlTypes;

namespace catering
{

    public partial class Form5 : Form
    {
        int catering_id = Form2.catering_id;
        int hizmet_id = Form3.hizmet_id;
        int mutfak_id = Form4.mutfak_id;
        int musteri_id=Form1.musteri_id;
        public static string adres;
        DateTime tarih;
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-3VH6LQ4\SQLEXPRESS;Initial Catalog=catering;Integrated Security=True;TrustServerCertificate=True");
        public static int davetli;
        int AnaYemek_toplam = AnaYemek.AnaYemek_toplam;
        public Form5()
        {
            InitializeComponent();
        }
       

       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label4.Visible = true;
                textBox3.Visible = true;
            }
            else
            {
                label4.Visible = false;
                textBox3.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

       
            
            
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Bütün Alanları Doldurunuz");
                
                   
            }
            else if (textBox3.Visible == true && comboBox1.SelectedIndex == 0 && textBox3.Text == "")
            {
                if(label4.Visible == true) { 
                MessageBox.Show("Bütün Alanları Doldurunuz");
                }
            }
            
            else 
            {
                davetli = Convert.ToInt32(textBox1.Text);
                adres=textBox2.Text;
                baglanti.Open();

                string sorgu = "insert into Siparis_Ozeti(Musteri_ID,Catering_ID,Hizmet_ID,Mutfak_ID,Miktar,Tarih)values(@musteri_id,@catering_id,@hizmet_id,@mutfak_id,@miktar,@tarih) ";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@musteri_id", musteri_id);
                komut.Parameters.AddWithValue("@catering_id", catering_id);
                komut.Parameters.AddWithValue("@hizmet_id", hizmet_id);
                komut.Parameters.AddWithValue("@mutfak_id", mutfak_id);
                komut.Parameters.AddWithValue("@miktar", davetli);
                komut.Parameters.AddWithValue("@tarih", tarih);


                komut.ExecuteNonQuery();
                baglanti.Close();
                baglanti.Open();
                string sorgum = "insert into AdresBilgileri(Musteri_ID,Adres) values(@musteri_id,@adres)";
                SqlCommand komutum = new SqlCommand(sorgum, baglanti);
                komutum.Parameters.AddWithValue("@musteri_id", musteri_id);
                komutum.Parameters.AddWithValue("@adres", adres);
                komutum.ExecuteNonQuery();
                baglanti.Close();


                this.Hide();
                Form6 fr6 = new Form6();
                fr6.ShowDialog();
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            Menu fr6 = new Menu();
            fr6.ShowDialog();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar)&&e.KeyChar!=8)
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox1.Focus();
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBox1.Focus();
                e.Handled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";

            tarih = dateTimePicker1.Value;

        }
    }
}
