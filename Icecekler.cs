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
    public partial class Icecekler : Form
    {
        public static int Icecekler_toplam;
        public static List<int> IcecekFiyatlari = new List<int>();
        public static int mutfak_id = Form4.mutfak_id;
        private readonly List<object> previousSelections = new List<object>();
        int musteri_id = Form1.musteri_id;

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-3VH6LQ4\SQLEXPRESS;Initial Catalog=catering;Integrated Security=True;TrustServerCertificate=True");
        public Icecekler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            string sorgu1 = "select Icecek_Adi,Icecek_Fiyati from Icecekler where mutfak_ID=1";
            string sorgu2 = "select Icecek_Adi,Icecek_Fiyati from Icecekler where mutfak_ID=2";
            string sorgu3 = "select Icecek_Adi,Icecek_Fiyati from Icecekler where mutfak_ID=3";
            string sorgu4 = "select Icecek_Adi,Icecek_Fiyati from Icecekler where mutfak_ID=4";
            string sorgu5 = "select Icecek_Adi,Icecek_Fiyati from Icecekler where mutfak_ID=5";
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
                    string IcecekAdi = reader["Icecek_Adi"].ToString();
                    int IcecekFiyati = Convert.ToInt32(reader["Icecek_Fiyati"]);
                    checkedListBox1.Items.Add($"{IcecekAdi}  -  {IcecekFiyati} ");
                }

                baglanti.Close();

            }
            else if (mutfak_id == 2)
            {
                baglanti.Open();
                SqlDataReader reader = komut2.ExecuteReader();

                while (reader.Read())
                {
                    string IcecekAdi = reader["Icecek_Adi"].ToString();
                    int IcecekFiyati = Convert.ToInt32(reader["Icecek_Fiyati"]);
                    checkedListBox1.Items.Add($"{IcecekAdi}  -  {IcecekFiyati} ");
                }

                baglanti.Close();
            }
            else if (mutfak_id == 3)
            {
                baglanti.Open();
                SqlDataReader reader = komut3.ExecuteReader();

                while (reader.Read())
                {
                    string IcecekAdi = reader["Icecek_Adi"].ToString();
                    int IcecekFiyati = Convert.ToInt32(reader["Icecek_Fiyati"]);
                    checkedListBox1.Items.Add($"{IcecekAdi}  -  {IcecekFiyati} ");
                }

                baglanti.Close();
            }
            else if (mutfak_id == 4)
            {
                baglanti.Open();
                SqlDataReader reader = komut4.ExecuteReader();

                while (reader.Read())
                {
                    string IcecekAdi = reader["Icecek_Adi"].ToString();
                    int IcecekFiyati = Convert.ToInt32(reader["Icecek_Fiyati"]);
                    checkedListBox1.Items.Add($"{IcecekAdi}  -  {IcecekFiyati} ");
                }

                baglanti.Close();
            }
            else if (mutfak_id == 5)
            {
                baglanti.Open();
                SqlDataReader reader = komut5.ExecuteReader();

                while (reader.Read())
                {
                    string IcecekAdi = reader["Icecek_Adi"].ToString();
                    int IcecekFiyati = Convert.ToInt32(reader["Icecek_Fiyati"]);
                    checkedListBox1.Items.Add($"{IcecekAdi}  -  {IcecekFiyati} ");
                }

                baglanti.Close();
            }

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
            IcecekFiyatlari.Clear();
            foreach (var item in listBox1.Items)
            {
                string[] parts = item.ToString().Split('-');
                if (parts.Length == 2)
                {
                    try
                    {
                        if (int.TryParse(parts[1].Trim(), out int fiyat))
                        {
                            IcecekFiyatlari.Add(fiyat); 

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

                Icecekler_toplam = IcecekFiyatlari.Sum();

                
            }
            List<string> IcecekBilgileri = new List<string>();
            foreach (var item in listBox1.Items)
            {
                IcecekBilgileri.Add(item.ToString());
            }

            List<string> IcecekAdiListesi = new List<string>();
            foreach (var item in listBox1.Items)
            {
                string[] parts = item.ToString().Split('-');
                if (parts.Length >= 1)
                {
                    IcecekAdiListesi.Add(parts[0].Trim()); 
                }
                else
                {
                    Console.WriteLine($"Geçersiz öğe formatı: {item}");
                }
            }
            List<int> IcecekIDListesi = new List<int>();
            baglanti.Open();

            foreach (string IcecekAdi in IcecekAdiListesi)
            {
                string sqlSorgu = "select Icecek_ID FROM Icecekler where Icecek_Adi = @IcecekAdi";

                using (SqlCommand command = new SqlCommand(sqlSorgu, baglanti))
                {
                    command.Parameters.AddWithValue("@IcecekAdi", IcecekAdi);

                   
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        IcecekIDListesi.Add(Convert.ToInt32(result)); 
                    }
                }
            }
            baglanti.Close();
            EkleIceceklerSiparis(IcecekIDListesi, musteri_id);


            Icecekler fr1 =new Icecekler();
            Close();
        }
        private void EkleIceceklerSiparis(List<int> IcecekIdListesi, int musteriId)
        {

            baglanti.Open();

            foreach (int IcecekId in IcecekIdListesi)
            {
                string sqlSorgu = "insert into IceceklerSiparis (Musteri_ID, Icecek_ID) VALUES (@MusteriID, @IcecekID) ";

                using (SqlCommand command = new SqlCommand(sqlSorgu, baglanti))
                {
                    command.Parameters.AddWithValue("@MusteriID", musteri_id);
                    command.Parameters.AddWithValue("@IcecekID", IcecekId);

                    command.ExecuteNonQuery();
                    


                }
            }
            baglanti.Close();

        }
        private void İcecekler_Load(object sender, EventArgs e)
        {
            
        }
    }
}
