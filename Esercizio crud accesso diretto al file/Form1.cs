using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Esercizio_crud_accesso_diretto_al_file
{
    public partial class Form1 : Form
    {
        public struct Prezzoprodotto
        {
            public string prodotto;
            public double prezzo;
        }

        public Prezzoprodotto[] p = new Prezzoprodotto[100];
        public int dim = 0;
        public string filePath = "file.txt";
        public int riempi = 64;
        public Form1()
        {
            InitializeComponent();
        }

        public void Aggiunta(string nome, double prezzo, string filePath)
        {
            var apertura = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter write = new StreamWriter(apertura);
            write.WriteLine($"{nome};{prezzo};1;0;".PadRight(riempi - 4) + "##");
            write.Close();
        }

        public int ricercaindice(string nome)
        {
            int riga = 0;
            using (StreamReader sr = File.OpenText(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dati = line.Split(';');
                    if (dati[3] == "0" && dati[0] == nome)
                    {
                        sr.Close();
                        return riga;
                    }
                    riga++;
                }
            }
            return -1;
        }

        public string[] ricercaprod(string nome)
        {
            int riga = 0;
            using (StreamReader sr = File.OpenText(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dati = line.Split(';');
                    if (dati[3] == "0" && dati[0] == nome)
                    {
                        sr.Close();
                        return dati;
                    }
                    riga++;
                }
            }
            return null;
        }



        public int Ricerca(string nome, string filePath)
        {
            int riga = 0;
            using (StreamReader sr = File.OpenText(filePath))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] dati = s.Split(';');
                    if (dati[3] == "0" && dati[0] == nome)
                    {
                        sr.Close();
                        return riga;
                    }
                    riga++;
                }
                sr.Close();
            }
            return -1;
        }
        private void C(object sender, EventArgs e)
        {
            double prezzo;
            if (double.TryParse(Prezzo.Text, out prezzo)) //Inserimento del prezzo con controllo sul valore numerico
            {
                if (Prodotto.Text != "")
                {
                    p[dim].prodotto = Prodotto.Text;
                    p[dim].prezzo = prezzo;
                    Aggiunta(p[dim].prodotto, p[dim].prezzo, filePath);
                    dim++;
                }
                else
                {
                    MessageBox.Show("Inserisci un prodotto");
                }
            }
            else
            {
                MessageBox.Show("Il carattere inserito non è un numero");
            }
        }

        private void R(object sender, EventArgs e)
        {
            string a = Ricercato.Text;
            int trovato = Ricerca(a, filePath);
            if (trovato == -1)
            {
                MessageBox.Show("Il prodotto non è stato trovato");
            }
            else
            {
                MessageBox.Show("Il prodotto si trova nella riga " + trovato);
            }
        }

        private void Modif(object sender, EventArgs e)
        {
            int indice = ricercaindice(Prodvecchio.Text);
            string line;
            var file = new FileStream(filePath, FileMode.Open, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);
            file.Seek(riempi * indice, SeekOrigin.Begin);
            line = $"{Prodnuovo.Text};{Prezzonuovo.Text};1;0;".PadRight(riempi - 4) + "##";
            byte[] bytes = Encoding.UTF8.GetBytes(line);
            writer.Write(bytes, 0, bytes.Length);
            writer.Close();
            file.Close();
        }

        private void D(object sender, EventArgs e)
        {
            int indice = ricercaindice(Proddacanc.Text);
            string[] prodotto = ricercaprod(Proddacanc.Text);
            string line;
            var file = new FileStream(filePath, FileMode.Open, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(file);
            file.Seek(riempi * indice, SeekOrigin.Begin);
            line = $"{prodotto[0]};{prodotto[1]};{prodotto[3]};1;".PadRight(riempi - 4) + "##";
            byte[] bytes = Encoding.UTF8.GetBytes(line);
            writer.Write(bytes, 0, bytes.Length);
            writer.Close();
            file.Close();
        }
    }

}
