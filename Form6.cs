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
    public partial class Form6 : Form
    {
         int catering_id = Form2.catering_id;
        int hizmet_id = Form3.hizmet_id;
        int mutfak_id = Form4.mutfak_id;
        int davetli = Form5.davetli;
        int AnaYemek_toplam = AnaYemek.AnaYemek_toplam;
        int Anayemektoplam;
        int Icecekler_toplam = Icecekler.Icecekler_toplam;
        int Iceceklertoplam;
        int Tatli_toplam = Tatli.Tatli_toplam;
        int Tatlitoplam;
        int Baslangic_toplam = Baslangic.Baslangic_toplam;
        int Baslangictoplam;
        public static int Total;
        int musteri_id = Form1.musteri_id;


        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-3VH6LQ4\SQLEXPRESS;Initial Catalog=catering;Integrated Security=True;TrustServerCertificate=True");

        public Form6()
        {
            InitializeComponent();
        }
        

           
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 fr8 = new Form8();
            fr8.ShowDialog();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            
            string sorgu = "SELECT Catering_Turleri.Catering_Adi FROM Catering_Turleri " +
                       "INNER JOIN Siparis_Ozeti ON Catering_Turleri.Catering_ID = Siparis_Ozeti.Catering_ID " +
                       "WHERE Catering_Turleri.Catering_ID = @catering_id";

            SqlCommand komut = new SqlCommand(sorgu, baglanti);

            komut.Parameters.AddWithValue("@catering_id", catering_id);

            baglanti.Open();

            using (SqlDataReader reader = komut.ExecuteReader())
            {
                if (reader.Read())
                {
                    label8.Text = reader["Catering_Adi"].ToString();
                }
                else
                {
                    label8.Text = "Veri bulunamadı veya okuma hatası";
                }
            }

            baglanti.Close();
            string sorgu1 = "SELECT Hizmet_Cesitleri.Hizmet_Adi FROM Hizmet_Cesitleri " +
                       "INNER JOIN Siparis_Ozeti ON Hizmet_Cesitleri.Hizmet_ID = Siparis_Ozeti.Hizmet_ID " +
                       "WHERE Hizmet_Cesitleri.Hizmet_ID = @hizmet_id";

            SqlCommand komut1 = new SqlCommand(sorgu1, baglanti);

            komut1.Parameters.AddWithValue("@hizmet_id", hizmet_id);

            baglanti.Open();

            using (SqlDataReader reader = komut1.ExecuteReader())
            {
                if (reader.Read())
                {
                    label9.Text = reader["Hizmet_Adi"].ToString();
                }
                else
                {
                    label9.Text = "Veri bulunamadı veya okuma hatası";
                }
            }

            baglanti.Close();
            string sorgu2 = "SELECT Ascilar.Mutfak FROM Ascilar " +
                       "INNER JOIN Siparis_Ozeti ON Ascilar.Mutfak_ID = Siparis_Ozeti.Mutfak_ID " +
                       "WHERE Ascilar.Mutfak_ID = @mutfak_id";

            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);

            komut2.Parameters.AddWithValue("@mutfak_id", mutfak_id);

            baglanti.Open();

            using (SqlDataReader reader = komut2.ExecuteReader())
            {
                if (reader.Read())
                {
                    label10.Text = reader["Mutfak"].ToString();
                }
                else
                {
                    label10.Text = "Veri bulunamadı veya okuma hatası";
                }
            }

            baglanti.Close();
            label11.Text = davetli.ToString();
            Anayemektoplam = AnaYemek_toplam * davetli;
            Baslangictoplam = Baslangic_toplam * davetli;
            Tatlitoplam = Tatli_toplam * davetli;
            Iceceklertoplam = Icecekler_toplam * davetli;
            Total = Anayemektoplam + Baslangictoplam + Tatlitoplam + Iceceklertoplam;
            label21.Text = Total.ToString();
            label17.Text = Baslangictoplam.ToString();
            label18.Text = Anayemektoplam.ToString();
            label19.Text = Iceceklertoplam.ToString();
            label20.Text = Tatlitoplam.ToString();
            string quary = "update Siparis_Ozeti set Total=@total where Musteri_ID= @musteri_id ";
            SqlCommand quary1 = new SqlCommand(quary, baglanti);
            quary1.Parameters.AddWithValue("@total", Total);
            quary1.Parameters.AddWithValue("@musteri_id", musteri_id);
            baglanti.Open();
            quary1.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 fr5 = new Form5();
            fr5.ShowDialog();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
