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
    public partial class Tatli : Form
    {
        private readonly List<object> previousSelections = new List<object>();
        public static int Tatli_toplam;
        public static List<int> TatliFiyatlari = new List<int>();
        public static int mutfak_id = Form4.mutfak_id;
        int musteri_id = Form1.musteri_id;
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-3VH6LQ4\SQLEXPRESS;Initial Catalog=catering;Integrated Security=True;TrustServerCertificate=True");
        public Tatli()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Visible = true;
            button3.Visible = true;
            var yeniSecimler = checkedListBox1.CheckedItems.Cast<object>().ToArray();
            previousSelections.Clear();
            previousSelections.AddRange(listBox1.Items.Cast<object>());
            listBox1.Items.Clear();

            foreach (var item in yeniSecimler)
            {
                if (!previousSelections.Contains(item))
                {
                    listBox1.Items.Add(item);
                }
            }
            listBox1.Items.AddRange(previousSelections.ToArray());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TatliFiyatlari.Clear();
            foreach (var item in listBox1.Items)
            {
                string[] parts = item.ToString().Split('-');
                if (parts.Length == 2)
                {
                    try
                    {
                        if (int.TryParse(parts[1].Trim(), out int fiyat))
                        {
                            TatliFiyatlari.Add(fiyat); 

                        }
                        else
                        {
                            Console.WriteLine($"Fiyat dönüştürülürken hata: {parts[1].Trim()}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Hata: {ex.Message}");
                    }

                }

                Tatli_toplam = TatliFiyatlari.Sum();

                
            }
            List<string> TatliBilgileri = new List<string>();
            foreach (var item in listBox1.Items)
            {
                TatliBilgileri.Add(item.ToString());
            }

            List<string> TatliAdiListesi = new List<string>();
            foreach (var item in listBox1.Items)
            {
                string[] parts = item.ToString().Split('-');
                if (parts.Length >= 1)
                {
                    TatliAdiListesi.Add(parts[0].Trim()); 
                }
                else
                {
                    Console.WriteLine($"Geçersiz öğe formatı: {item}");
                }
            }
            List<int> TatliIDListesi = new List<int>();
            baglanti.Open();

            foreach (string TatliAdi in TatliAdiListesi)
            {
                string sqlSorgu = "select Tatli_ID FROM Tatlilar where Tatli_Adi = @TatliAdi";

                using (SqlCommand command = new SqlCommand(sqlSorgu, baglanti))
                {
                    command.Parameters.AddWithValue("@TatliAdi", TatliAdi);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        TatliIDListesi.Add(Convert.ToInt32(result)); 
                    }
                }
            }
            baglanti.Close();
            EkleTatlilarSiparis(TatliIDListesi, musteri_id);


            Tatli fr1 = new Tatli();
            Close();
        }
        private void EkleTatlilarSiparis(List<int> TatliIdListesi, int musteriId)
        {

            baglanti.Open();

            foreach (int TatliId in TatliIdListesi)
            {
                string sqlSorgu = "insert into TatlilarSiparis (Musteri_ID, Tatli_ID) VALUES (@MusteriID, @TatliID) ";

                using (SqlCommand command = new SqlCommand(sqlSorgu, baglanti))
                {
                    command.Parameters.AddWithValue("@MusteriID", musteri_id);
                    command.Parameters.AddWithValue("@TatliID", TatliId);

                    command.ExecuteNonQuery();



                }
            }
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            string sorgu1 = "select Tatli_Adi,Tatli_Fiyati from Tatlilar where mutfak_ID=1";
            string sorgu2 = "select Tatli_Adi,Tatli_Fiyati from Tatlilar where mutfak_ID=2";
            string sorgu3 = "select Tatli_Adi,Tatli_Fiyati from Tatlilar where mutfak_ID=3";
            string sorgu4 = "select Tatli_Adi,Tatli_Fiyati from Tatlilar where mutfak_ID=4";
            string sorgu5 = "select Tatli_Adi,Tatli_Fiyati from Tatlilar where mutfak_ID=5";
            SqlCommand komut1 = new SqlCommand(sorgu1, baglanti);
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
            SqlCommand komut3 = new SqlCommand(sorgu3, baglanti);
            SqlCommand komut4 = new SqlCommand(sorgu4, baglanti);
            SqlCommand komut5 = new SqlCommand(sorgu5, baglanti);

            if (mutfak_id == 1)
            {


                baglanti.Open();
                SqlDataReader reader = komut1.ExecuteReader();

                while (reader.Read())
                {
                    string TatliAdi = reader["Tatli_Adi"].ToString();
                    int TatliFiyati = Convert.ToInt32(reader["Tatli_Fiyati"]);
                    checkedListBox1.Items.Add($"{TatliAdi}  -  {TatliFiyati} ");
                }

                baglanti.Close();

            }
            else if (mutfak_id == 2)
            {
                baglanti.Open();
                SqlDataReader reader = komut2.ExecuteReader();

                while (reader.Read())
                {
                    string TatliAdi = reader["Tatli_Adi"].ToString();
                    int TatliFiyati = Convert.ToInt32(reader["Tatli_Fiyati"]);
                    checkedListBox1.Items.Add($"{TatliAdi}  -  {TatliFiyati} ");
                }

                baglanti.Close();
            }
            else if (mutfak_id == 3)
            {
                baglanti.Open();
                SqlDataReader reader = komut3.ExecuteReader();

                while (reader.Read())
                {
                    string TatliAdi = reader["Tatli_Adi"].ToString();
                    int TatliFiyati = Convert.ToInt32(reader["Tatli_Fiyati"]);
                    checkedListBox1.Items.Add($"{TatliAdi}  -  {TatliFiyati} ");
                }

                baglanti.Close();
            }
            else if (mutfak_id == 4)
            {
                baglanti.Open();
                SqlDataReader reader = komut4.ExecuteReader();

                while (reader.Read())
                {
                    string TatliAdi = reader["Tatli_Adi"].ToString();
                    int TatliFiyati = Convert.ToInt32(reader["Tatli_Fiyati"]);
                    checkedListBox1.Items.Add($"{TatliAdi}  -  {TatliFiyati} ");
                }

                baglanti.Close();
            }
            else if (mutfak_id == 5)
            {
                baglanti.Open();
                SqlDataReader reader = komut5.ExecuteReader();

                while (reader.Read())
                {
                    string TatliAdi = reader["Tatli_Adi"].ToString();
                    int TatliFiyati = Convert.ToInt32(reader["Tatli_Fiyati"]);
                    checkedListBox1.Items.Add($"{TatliAdi}  -  {TatliFiyati} ");
                }

                baglanti.Close();
            }
        }

        
    }
}
