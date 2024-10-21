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
    public partial class Form2 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-3VH6LQ4\SQLEXPRESS;Initial Catalog=catering;Integrated Security=True;TrustServerCertificate=True");
        public static int catering_id;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            



            if (radioButton1.Checked)
            {
                catering_id = 1;
            }
            else if (radioButton2.Checked)
            {
                catering_id = 2;
            }
            else if (radioButton3.Checked)
            {
                catering_id = 3;
            }
            else if (radioButton4.Checked)
            {
                catering_id = 4;
            }
            
            
            switch (catering_id)
            {
                case 1:
                    MessageBox.Show("Özel Catering için öneriler:\nBaşlangıç: Aperatif tabakları veya mezeler\n- Ana Yemek: Izgara et çeşitleri\n- İçecek: Özel kokteyller veya meyve suları\n- Tatlı: Çikolatalı veya meyveli tatlılar", "Öneri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 2:
                    MessageBox.Show("Sosyal Catering için öneriler:\nBaşlangıç: Çeşitli bruschettalar\n- Ana Yemek: Farklı makarna ve tavuk yemekleri\n- İçecek: Çeşitli meyve suları\n- Tatlı: Tiramisu veya pasta çeşitleri", "Öneri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 3:
                    MessageBox.Show("Kurumsal Catering için öneriler:\n- Başlangıç: Mini sandviçler veya hafif atıştırmalıklar\n- Izgara tavuk veya somon, yanında sebzeli pilav veya çeşitli salatalar\n- İçecek: İçecek standı veya çeşitli içecekler\n- Tatlı: Kurabiye ve pasta çeşitleri", "Öneri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 4:
                    MessageBox.Show("Endüstriyel Catering için öneriler:\n- Başlangıç: Çorba çeşitleri\n- Ana Yemek: Fırın tavuk ve sebzeler\n- İçecek: Soğuk içecekler\n- Tatlı: Meyve salatası veya sütlü tatlılar", "Öneri", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    MessageBox.Show("Geçersiz catering türü seçildi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            this.Hide();
            Form3 fr3 = new Form3();
            fr3.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 fr1 = new Form1();
            fr1.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string ozelCateringBilgi = "Özel Catering, kişiselleştirilmiş etkinlikler için özel olarak tasarlanmış yiyecek ve içecek hizmetlerini ifade eder. Bu hizmet, müşterinin istekleri doğrultusunda özel bir menü, tematik dekorasyon, kişisel hizmet ve özel içecekler gibi özellikleri içerir. Genellikle düğünler, doğum günleri, iş toplantıları ve diğer özel etkinlikler için tercih edilen bir hizmettir.";

            MessageBox.Show(ozelCateringBilgi, "Özel Catering Hakkında Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sosyalCateringBilgi = "Sosyal Catering, sosyal etkinlikler ve toplantılar için tasarlanmış özel yiyecek ve içecek hizmetlerini ifade eder. Bu hizmet, çeşitli bruschettalar, tavuklu pesto makarna, meyve suyu barı gibi özel öneriler içerebilir. Sosyal catering genellikle arkadaş buluşmaları, küçük partiler veya özel kutlamalar için popülerdir.";

            MessageBox.Show(sosyalCateringBilgi, "Sosyal Catering Hakkında Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string kurumsalCateringBilgi = "Kurumsal Catering, iş toplantıları, konferanslar ve kurumsal etkinlikler için tasarlanmış özel yiyecek ve içecek hizmetlerini ifade eder. Bu hizmet, mini sandviçler, hafif atıştırmalıklar, iş toplantısı tarzı ana yemekler ve kurumsal etkinliklere uygun içecekler içerebilir.";

            MessageBox.Show(kurumsalCateringBilgi, "Kurumsal Catering Hakkında Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string endustriyelCateringBilgi = "Endüstriyel Catering, büyük organizasyonlar, fabrika etkinlikleri veya endüstriyel tesislerdeki etkinlikler için tasarlanmış özel yiyecek ve içecek hizmetlerini ifade eder. Bu hizmet, çeşitli çorba çeşitleri, fırın tavuk ve sebzeler, soğuk içecekler ve pratik tatlılar içerebilir.";

            MessageBox.Show(endustriyelCateringBilgi, "Endüstriyel Catering Hakkında Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
