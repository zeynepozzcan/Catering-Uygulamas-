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
    public partial class Form8 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-3VH6LQ4\SQLEXPRESS;Initial Catalog=catering;Integrated Security=True;TrustServerCertificate=True");
        int musteri_id = Form1.musteri_id;
        SqlCommand komut,komut1,komut2,komut3;
        SqlDataAdapter sorgu,sorgu1,sorgu2,sorgu3;
        int Total = Form6.Total;


        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            label21.Text = Total.ToString();
            baglanti.Open();
            komut = new SqlCommand("SELECT Baslangiclar.Baslangic_Adi FROM Baslangiclar " +
                       "INNER JOIN BaslangiclarSiparis ON BaslangiclarSiparis.Baslangic_ID = Baslangiclar.Baslangic_ID " +
                       "WHERE BaslangiclarSiparis.Musteri_ID = @musteri_id",baglanti);
            komut.Parameters.AddWithValue("@musteri_id", musteri_id);
            sorgu = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            sorgu.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
            baglanti.Open();
            komut1 = new SqlCommand("SELECT AnaYemek.AnaYemek_Adi FROM AnaYemek " +
                       "INNER JOIN AnaYemekSiparis ON AnaYemekSiparis.AnaYemek_ID = AnaYemek.AnaYemek_ID " +
                       "WHERE AnaYemekSiparis.Musteri_ID = @musteri_id", baglanti);
            komut1.Parameters.AddWithValue("@musteri_id", musteri_id);
            sorgu1 = new SqlDataAdapter(komut1);
            DataTable tablo1 = new DataTable();
            sorgu1.Fill(tablo1);
            dataGridView2.DataSource = tablo1;
            baglanti.Close();
            baglanti.Open();
            komut2 = new SqlCommand("SELECT Icecekler.Icecek_Adi FROM Icecekler " +
                       "INNER JOIN IceceklerSiparis ON IceceklerSiparis.Icecek_ID = Icecekler.Icecek_ID " +
                       "WHERE IceceklerSiparis.Musteri_ID = @musteri_id", baglanti);
            komut2.Parameters.AddWithValue("@musteri_id", musteri_id);
            sorgu2 = new SqlDataAdapter(komut2);
            DataTable tablo2 = new DataTable();
            sorgu2.Fill(tablo2);
            dataGridView3.DataSource = tablo2;
            baglanti.Close();
            baglanti.Open();
            komut3 = new SqlCommand("SELECT Tatlilar.Tatli_Adi FROM Tatlilar " +
                       "INNER JOIN TatlilarSiparis ON TatlilarSiparis.Tatli_ID = Tatlilar.Tatli_ID " +
                       "WHERE TatlilarSiparis.Musteri_ID = @musteri_id", baglanti);
            komut3.Parameters.AddWithValue("@musteri_id", musteri_id);
            sorgu3 = new SqlDataAdapter(komut3);
            DataTable tablo3 = new DataTable();
            sorgu3.Fill(tablo3);
            dataGridView4.DataSource = tablo3;
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 fr7 = new Form7();
            fr7.ShowDialog();
        }
    }
}
