using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
        public int riga = 64;
        public Form1()
        {
            InitializeComponent();
        }

        public void Aggiunta(string nome, double prezzo, string filePath)
        {
            var apertura = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter write = new StreamWriter(apertura);
            write.WriteLine($"{nome};{prezzo};1;0".PadRight(riga - 4) + "##");
            write.Close();

        }

        private void C(object sender, EventArgs e)
        {
            p[dim].prodotto = Prodotto.Text;
            p[dim].prezzo = double.Parse(Prezzo.Text);
            Aggiunta(p[dim].prodotto, p[dim].prezzo, filePath);
            dim++;
        }
    }
}
