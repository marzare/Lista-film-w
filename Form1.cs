using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filmy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DodawanieDanych(string tytul, string rezyser, string data, string aktor)
        {
            ListViewItem item = new ListViewItem(new string[] {tytul, rezyser, data, aktor});
            listView1.Items.Add(item);
        }

        private void DodawanieDanych(string[] dane)
        {
            ListViewItem item = new ListViewItem(dane);
            listView1.Items.Add(item);
        }

        private void UsuwanieDanych()
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                listView1.Items.Remove(item);
            }
        }

        private string[] WierszeDoPliku()
        {
            string[] linie = new string[listView1.Items.Count];
            int i = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                linie[i] = "";
                for (int k = 0; k < item.SubItems.Count; k++)
                    linie[i] += item.SubItems[k].Text + "*";

                i++;

            }
            return linie;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] linie = WierszeDoPliku();
            File.WriteAllLines("filmy.txt", linie);
        }

        private void OdczytZPliku()
        {
            if (!File.Exists("filmy.txt"))
            {
                return;
            }
            string[] linie = File.ReadAllLines("filmy.txt");
            foreach( string linia in linie)
            {
                string[] temp = linia.Split('*');
                DodawanieDanych(temp);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string tytul = textBox3.Text;
            string rezyser = textBox4.Text;
            string data = dateTimePicker1.Text;
            string aktor = textBox7.Text;
            if (tytul.Length != 0 && rezyser.Length != 0 && data.Length != 0 && aktor.Length != 0)
            {
                DodawanieDanych(tytul, rezyser, data, aktor);
                textBox3.Text = "";
                textBox4.Text = "";
                textBox7.Text = "";
                dateTimePicker1.Text = "";
            }
            else
            {
                string message = "Sprawdź czy wprowadziłeś wszystkie dane!";
                MessageBox.Show(message);
            }
        }

        private void usunWybraneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuwanieDanych();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OdczytZPliku();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {



        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            UsuwanieDanych();
        }

        private void contextMenuStrip1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            UsuwanieDanych();
        }
    }
}
