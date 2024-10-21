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


namespace catering
{
    public partial class Baslangic : Form
    {
        public List<string> baslangicBilgileri = new List<string>();
        public static int Baslangic_toplam;
        public static List<int> BalangicFiyatlari = new List<int>();
        public static int mutfak_id = Form4.mutfak_id;
        private readonly List<object> previousSelections = new List<object>();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-3VH6LQ4\SQLEXPRESS;Initial Catalog=catering;Integrated Security=True;TrustServerCertificate=True");
        int musteri_id = Form1.musteri_id;
        private List<int> baslangicIdList = new List<int>();


        public Baslangic()
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
            BalangicFiyatlari.Clear();
            foreach (var item in listBox1.Items)
            {
                string[] parts = item.ToString().Split('-');
                if (parts.Length == 2)
                {
                    try
                    {
                        if (int.TryParse(parts[1].Trim(), out int fiyat))
                        {
                            BalangicFiyatlari.Add(fiyat); 

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

                Baslangic_toplam = BalangicFiyatlari.Sum();

                
            }
            



            List<string> baslangicBilgileri = new List<string>();
            foreach (var item in listBox1.Items)
            {
                baslangicBilgileri.Add(item.ToString());
            }

            List<string> baslangicAdiListesi = new List<string>();
            foreach (var item in listBox1.Items)
            {
                string[] parts = item.ToString().Split('-');
                if (parts.Length >= 1)
                {
                    baslangicAdiListesi.Add(parts[0].Trim()); 
                }
                else
                {
                    Console.WriteLine($"Geçersiz öğe formatı: {item}");
                }
            }
            List<int> baslangicIDListesi = new List<int>();
            baglanti.Open();

            foreach (string baslangicAdi in baslangicAdiListesi)
            {
                string sqlSorgu = "select Baslangic_ID FROM Baslangiclar where Baslangic_Adi = @BaslangicAdi";

                using (SqlCommand command = new SqlCommand(sqlSorgu, baglanti))
                {
                    command.Parameters.AddWithValue("@BaslangicAdi", baslangicAdi);

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        baslangicIDListesi.Add(Convert.ToInt32(result)); 
                    }
                }
            }
            baglanti.Close();
            EkleBaslangiclarSiparis(baslangicIDListesi, musteri_id);
            


            Baslangic fr1 = new Baslangic();
            Close();


        }
        private void EkleBaslangiclarSiparis(List<int> baslangicIdListesi, int musteriId)
        {

            baglanti.Open();

            foreach (int baslangicId in baslangicIdListesi)
            {
                string sqlSorgu = "insert into BaslangiclarSiparis (Musteri_ID, Baslangic_ID) VALUES (@MusteriID, @BaslangicID) ";

                using (SqlCommand command = new SqlCommand(sqlSorgu, baglanti))
                {
                    command.Parameters.AddWithValue("@MusteriID", musteri_id);
                    command.Parameters.AddWithValue("@BaslangicID", baslangicId);

                    command.ExecuteNonQuery();
                    


                }
            }
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            string sorgu1 = "select Baslangic_Adi,Baslangic_Fiyat from Baslangiclar where mutfak_ID=1";
            string sorgu2 = "select Baslangic_Adi,Baslangic_Fiyat from Baslangiclar where mutfak_ID=2";
            string sorgu3 = "select Baslangic_Adi,Baslangic_Fiyat from Baslangiclar where mutfak_ID=3";
            string sorgu4 = "select Baslangic_Adi,Baslangic_Fiyat from Baslangiclar where mutfak_ID=4";
            string sorgu5 = "select Baslangic_Adi,Baslangic_Fiyat from Baslangiclar where mutfak_ID=5";
            SqlCommand komut1 = new SqlCommand(sorgu1, baglanti);
            SqlCommand komut2 = new SqlCommand(sorgu2, baglanti);
            SqlCommand komut3 = new SqlCommand(sorgu3, baglanti);
            SqlCommand komut4 = new SqlCommand(sorgu4, baglanti);
            SqlCommand komut5 = new SqlCommand(sorgu5, baglanti);


            if (mutfak_id==1)
            {
                
               
                baglanti.Open();
                SqlDataReader reader = komut1.ExecuteReader();
              
                while (reader.Read())
                {

                    string baslangicAdi = reader["Baslangic_adi"].ToString();
                    int baslangicFiyati = Convert.ToInt32(reader["Baslangic_fiyat"]);
                    checkedListBox1.Items.Add($"{baslangicAdi}  -  {baslangicFiyati} ");

                }
                
                baglanti.Close();

            }
            else if(mutfak_id==2)
            {
                baglanti.Open();
                SqlDataReader reader = komut2.ExecuteReader();

                while (reader.Read())
                {
                    string baslangicAdi = reader["Baslangic_adi"].ToString();
                    int baslangicFiyati = Convert.ToInt32(reader["Baslangic_fiyat"]);
                    checkedListBox1.Items.Add($"{baslangicAdi}  -  {baslangicFiyati} ");

                }

                baglanti.Close();
            }
            else if (mutfak_id == 3)
            {
                baglanti.Open();
                SqlDataReader reader = komut3.ExecuteReader();

                while (reader.Read())
                {
                    string baslangicAdi = reader["Baslangic_adi"].ToString();
                    int baslangicFiyati = Convert.ToInt32(reader["Baslangic_fiyat"]);
                    checkedListBox1.Items.Add($"{baslangicAdi}  -  {baslangicFiyati} ");

                }

                baglanti.Close();
            }
            else if (mutfak_id == 4)
            {
                baglanti.Open();
                SqlDataReader reader = komut4.ExecuteReader();

                while (reader.Read())
                {
                    string baslangicAdi = reader["Baslangic_adi"].ToString();
                    int baslangicFiyati = Convert.ToInt32(reader["Baslangic_fiyat"]);
                    checkedListBox1.Items.Add($"{baslangicAdi}  -  {baslangicFiyati} ");

                }

                baglanti.Close();
            }
            else if (mutfak_id == 5)
            {
                baglanti.Open();
                SqlDataReader reader = komut5.ExecuteReader();

                while (reader.Read())
                {
                    string baslangicAdi = reader["Baslangic_adi"].ToString();
                    int baslangicFiyati = Convert.ToInt32(reader["Baslangic_fiyat"]);
                    checkedListBox1.Items.Add($"{baslangicAdi}  -  {baslangicFiyati} ");

                }

                baglanti.Close();
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
