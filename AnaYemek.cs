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
    public partial class AnaYemek : Form
    {
        public readonly List<object> previousSelections = new List<object>();
        public static int AnaYemek_toplam;
        public  static List<int> AnaYemekFiyatlari  = new List<int>(); 
        public static int mutfak_id = Form4.mutfak_id;
        int musteri_id = Form1.musteri_id;

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-3VH6LQ4\SQLEXPRESS;Initial Catalog=catering;Integrated Security=True;TrustServerCertificate=True");

        public AnaYemek()
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
            AnaYemekFiyatlari.Clear();
            foreach (var item in listBox1.Items)
            {
                string[] parts = item.ToString().Split('-');
                if (parts.Length == 2)
                {
                    try
                    {
                        if (int.TryParse(parts[1].Trim(), out int fiyat))
                        {
                            AnaYemekFiyatlari.Add(fiyat); 

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

                AnaYemek_toplam = AnaYemekFiyatlari.Sum();


                
            }
            List<string> AnaYemekBilgileri = new List<string>();
            foreach (var item in listBox1.Items)
            {
                AnaYemekBilgileri.Add(item.ToString());
            }

            List<string> AnaYemekAdiListesi = new List<string>();
            foreach (var item in listBox1.Items)
            {
                string[] parts = item.ToString().Split('-');
                if (parts.Length >= 1)
                {
                    AnaYemekAdiListesi.Add(parts[0].Trim()); 
                }
                else
                {
                    Console.WriteLine($"Geçersiz öğe formatı: {item}");
                }
            }
            List<int> AnaYemekIDListesi = new List<int>();
            baglanti.Open();

            foreach (string AnaYemekAdi in AnaYemekAdiListesi)
            {
                string sqlSorgu = "select AnaYemek_ID FROM AnaYemek where AnaYemek_Adi = @AnaYemekAdi";

                using (SqlCommand command = new SqlCommand(sqlSorgu, baglanti))
                {
                    command.Parameters.AddWithValue("@AnaYemekAdi", AnaYemekAdi);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        AnaYemekIDListesi.Add(Convert.ToInt32(result)); 
                    }
                }
            }
            baglanti.Close();
            EkleAnaYemekSiparis(AnaYemekIDListesi, musteri_id);
            AnaYemek fr1 = new AnaYemek();
            Close();

        }
        private void EkleAnaYemekSiparis(List<int> AnaYemekIdListesi, int musteriId)
        {

            baglanti.Open();

            foreach (int AnaYemekId in AnaYemekIdListesi)
            {
                string sqlSorgu = "insert into AnaYemekSiparis (Musteri_ID, AnaYemek_ID) VALUES (@MusteriID, @AnaYemekID) ";

                using (SqlCommand command = new SqlCommand(sqlSorgu, baglanti))
                {
                    command.Parameters.AddWithValue("@MusteriID", musteri_id);
                    command.Parameters.AddWithValue("@AnaYemekID", AnaYemekId);

                    command.ExecuteNonQuery();
                   


                }
            }
            baglanti.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            string sorgu = $"select AnaYemek_Adi,AnaYemek_Fiyat from AnaYemek where mutfak_ID={mutfak_id}";
            
            SqlCommand komut = new SqlCommand(sorgu, baglanti);

            baglanti.Open();
            SqlDataReader reader = komut.ExecuteReader();

            while (reader.Read())
            {
                string AnaYemekAdi = reader["AnaYemek_adi"].ToString();
                int AnaYemekFiyati = Convert.ToInt32(reader["AnaYemek_fiyat"]);
                checkedListBox1.Items.Add($"{AnaYemekAdi}  -  {AnaYemekFiyati} ");
            }

            baglanti.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}