using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catering
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 fr44 = new Form4();
            fr44.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AnaYemek fr44 = new AnaYemek();
            fr44.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Tatli fr44 = new Tatli();
            fr44.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Baslangic fr44 = new Baslangic();
            fr44.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Icecekler fr44 = new Icecekler();
            fr44.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 fr5 = new Form5();
            fr5.ShowDialog();
        }
    }
}
