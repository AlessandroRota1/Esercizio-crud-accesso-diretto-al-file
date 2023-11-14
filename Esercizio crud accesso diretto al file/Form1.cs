using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Esercizio_crud_accesso_diretto_al_file
{
    public partial class Form1 : Form
    {
        public struct Prezzoprodotto //Inizializzazione della struct
        {
            public string prodotto;
            public double prezzo;
        }

        public Prezzoprodotto[] p = new Prezzoprodotto[100]; //Dichiarazione array di struct
        public int dim = 0;
        public string filePath = "file.txt"; //Dichiarazione variabile necessaria per richiamare il percorso del file
        public int riempi = 64; //Dichiarazione lunghezza dei vari record
        public int quantitàglobale; //Dichiarazione variabile necessaria per mantenere la quantità anche dopo il recupera
        public Form1()
        {
            InitializeComponent();
        }

        public void Aggiunta(string nome, double prezzo, string filePath) //Implementazione funzione necessaria per aggiungere prodotti nel file
        {
            string[] lines = File.ReadAllLines(filePath);  //Dichiarazione array delle varie righe nel file
            bool prodottoTrovato = false; //Dichiarazione booleana

            for (int i = 0; i < lines.Length; i++) //Ciclo di scorrimento per controllare se il prodotto nella textbox sia già presente nel file 
            {
                string[] oggetti = lines[i].Split(';'); //Dichiarazione array dei vari campi presenti nel file

                if (oggetti[0] == nome && double.TryParse(oggetti[1], out double existingPrezzo)) //Condizione verificata qualora il prodotto nella textbox è uguale ad uno nel file
                {
                    if (prezzo == existingPrezzo) //Controllo valore numerico
                    {
                        int quantita; //Inizializzazione variabile per la quantità
                        if (int.TryParse(oggetti[2], out quantita)) //Controllo valore numerico
                        {
                            quantita++; //Incremento dellla quantità
                            lines[i] = $"{nome};{prezzo};{quantita};0;".PadRight(riempi - 4) + "##"; //Cambiamento della riga
                            prodottoTrovato = true; //Cambiamento della booleana necessario per non entrare nel ciclo della stampa del prodotto sul file
                            quantitàglobale = quantita; //Assegnazione della quantità alla variabile che verrà mantenuta all'interno del recupera
                            break;
                        }
                    }
                }
            }

            if (!prodottoTrovato) //Condizione nella quale il prodotto non è già presente all'interno del file
            {
                var apertura = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read); //Apertura del file
                StreamWriter write = new StreamWriter(apertura); //Apertura dello streamwriter necessario per scrivere sul file
                write.WriteLine($"{nome};{prezzo};1;0;".PadRight(riempi - 4) + "##"); //Scrittura della riga sul file
                write.Close(); //Chiusura dello streamwriter
            }
            else
            {
                File.WriteAllLines(filePath, lines); //Comando necessario per riscrivere la riga del file qualora fosse stato aggiunto un prodotto già presente
            }
        }

        public int ricercaindice(string nome) //Implementazione funzione necessaria per trovare l'indice del prodotto
        {
            int riga = 0; //Dichiarazione della variabile che verrà ritornata qualora verrà trovato l'indice del prodotto 
            using (StreamReader sr = File.OpenText(filePath)) //Apertura del file
            {
                string line;
                while ((line = sr.ReadLine()) != null) //Ciclo di scorrimento sino alla fine del file
                {
                    string[] dati = line.Split(';'); //Divisione della riga nei vari campi
                    if (dati[3] == "0" && dati[0] == nome) //Condizioni necessarie per la ricerca dell'indice (il prodotto non deve esser stato cancellato ed il nome deve essere uguale a quello inserito dall'utente)
                    {
                        sr.Close(); //Chiusura del file
                        return riga; //Viene ritornato l'indice della riga in questione
                    }
                    riga++;
                }
            }
            return -1; //Viene ritornato -1 qualora il prodotto da cercare non è presente nel file
        }

        public string[] ricercaprod(string nome) //Implementazione funzione necessaria per ritornare il prodotto stesso qualora viene trovato (funzione analoga alla precedente, al posto che ritornare la riga, viene ritornato il nome del prodotto se viene trovato)
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



        public int Ricerca(string nome, string filePath) //Implementazione funzione ricerca
        {
            int riga = 0;
            using (StreamReader sr = File.OpenText(filePath)) //Apertura del file
            {
                string s;
                while ((s = sr.ReadLine()) != null) //Ciclo di scorrimento sino alla fine del file
                {
                    string[] dati = s.Split(';'); //Divisione della riga nei vari campi
                    if (dati[3] == "0" && dati[0] == nome) //Condizioni necessarie per la ricerca dell'indice (il prodotto non deve esser stato cancellato ed il nome deve essere uguale a quello inserito dall'utente)
                    {
                        sr.Close(); //Chiusura del file
                        return riga; //Viene ritornato l'indice della riga in questione
                    }
                    riga++;
                }
                sr.Close();
            }
            return -1; //Viene ritornato -1 qualora il prodotto da cercare non è presente nel file
        }

        public string[] ricercaproddarecu(string nome) //Funzione analoga a ricercaprod, solamente il valore nel quarto campo (dati[3]) deve essere pari ad 1, quindi cancellato logicamente
        {
            int riga = 0;
            using (StreamReader sr = File.OpenText(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dati = line.Split(';');
                    if (dati[3] == "1" && dati[0] == nome)
                    {
                        sr.Close();
                        return dati;
                    }
                    riga++;
                }
            }
            return null;
        }
        public int ricercaindicedarecu(string nome) //Funzione analoga a ricercaindice, solamente il valore nel quarto campo (dati[3]) deve essere pari ad 1, quindi cancellato logicamente
        {
            int riga = 0;
            using (StreamReader sr = File.OpenText(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dati = line.Split(';');
                    if (dati[3] == "1" && dati[0] == nome)
                    {
                        sr.Close();
                        return riga;
                    }
                    riga++;
                }
            }
            return -1;
        }
        private void C(object sender, EventArgs e)
        {
            double prezzo;
            if (Prodotto.Text == String.Empty) //Controllo textbox del prodotto vuota
            {
                MessageBox.Show("Inserisci un prodotto all'interno della textbox");
            }
            else
            {
                if (double.TryParse(Prezzo.Text, out prezzo)) //Controllo sul valore numerico
                {
                    if (Prodotto.Text != "") //Controllo textbox del prezzo vuota
                    {
                        p[dim].prodotto = Prodotto.Text;
                        p[dim].prezzo = prezzo;
                        Aggiunta(p[dim].prodotto, p[dim].prezzo, filePath);
                        Prodotto.Clear();
                        Prezzo.Clear();
                        dim++;
                        MessageBox.Show("Aggiunta avvenuta con successo");
                    }
                }
                else
                {
                    MessageBox.Show("Il carattere inserito nel prezzo non è un numero");
                }
            }
        }

        private void R(object sender, EventArgs e)
        {
            string a = Ricercato.Text;
            int trovato = Ricerca(a, filePath);
            if (trovato == -1) //Condizione nella quale il prodotto non è presente nel file
            {
                MessageBox.Show("Il prodotto non è stato trovato, assicurati che sia presente all'interno del file");
                Ricercato.Clear();
            }
            else //Condizione nella quale il prodotto è presente nel file
            {
                MessageBox.Show("Il prodotto si trova nella riga " + trovato);
                Ricercato.Clear();
            }
        }

        private void Modif(object sender, EventArgs e)
        {
            if (Prodvecchio.Text == String.Empty) //Condizione nella quale la textbox del prodotto da modificare è vuota
            {
                MessageBox.Show("Inserisci un prodotto da modificare");
            }
            else
            {
                if (ricercaindice(Prodvecchio.Text) == -1) //Condizione nella quale il prodotto da modificare non è stato trovato
                {
                    MessageBox.Show("Il prodotto non è stato trovato, assicurati che sia presente all'interno del file");
                    Prodvecchio.Clear();
                    Prezzonuovo.Clear();
                }
                else
                {
                    double prezzo;
                    if (double.TryParse(Prezzonuovo.Text, out prezzo)) //Condizione nella quale il nuovo prezzo sia un valore numerico
                    {
                        int indice = ricercaindice(Prodvecchio.Text); //Inizializzazione dell'indice del prodotto da modificare
                        string line;
                        var file = new FileStream(filePath, FileMode.Open, FileAccess.Write); //Apertura del file
                        BinaryWriter writer = new BinaryWriter(file); //Apertura del file in scrittura binaria
                        file.Seek(riempi * indice, SeekOrigin.Begin); //Ricerca della riga per mezzo del comando seek moltiplicando l'indice per il numero di caratteri per ogni riga
                        line = $"{Prodnuovo.Text};{Prezzonuovo.Text};1;0;".PadRight(riempi - 4) + "##"; //Modifica della riga
                        byte[] bytes = Encoding.UTF8.GetBytes(line); //Creazione della riga divisa nei vari bytes
                        writer.Write(bytes, 0, bytes.Length); //Scrittura della riga stessa
                        writer.Close(); //Chiusura del BinaryWriter
                        file.Close(); //Chiusura del file
                        Prodvecchio.Clear();
                        Prezzonuovo.Clear();
                        MessageBox.Show("Modifica avvenuta con successo");
                    }
                    else
                    {
                        MessageBox.Show("I caratteri inseriti nel prezzo non sono numeri");
                        Prezzonuovo.Clear();
                    }
                }
            }
        }

        private void D(object sender, EventArgs e)
        {
            if(Proddacanc.Text==String.Empty) //Condizione nella quale la textbox del prodotto da cancellare è vuota
            {
                MessageBox.Show("Inserisci un prodotto da cancellare");
            }
            else if (ricercaindice(Proddacanc.Text) == -1) //Condizione nella quale il prodotto da cancellare non è stato trovato
            {
                MessageBox.Show("Il prodotto non è stato trovato, assicurati che sia all'interno del file");
                Proddacanc.Clear();
            }
            else 
            {
                int indice = ricercaindice(Proddacanc.Text); //Inizializzazione dell'indice del prodotto da cancellare
                string[] prodotto = ricercaprod(Proddacanc.Text); //Inizializzazione dell'array dei vari campi del prodotto da cancellare
                string line;
                var file = new FileStream(filePath, FileMode.Open, FileAccess.Write); //Apertura del file
                BinaryWriter writer = new BinaryWriter(file); //Apertura del file in scrittura binaria
                file.Seek(riempi * indice, SeekOrigin.Begin); //Ricerca della riga per mezzo del comando seek moltiplicando l'indice per il numero di caratteri per ogni riga
                line = $"{prodotto[0]};{prodotto[1]};{quantitàglobale};1;".PadRight(riempi - 4) + "##"; //Creazione della riga cancellata logicamente
                byte[] bytes = Encoding.UTF8.GetBytes(line); //Scrittura della riga stessa
                writer.Write(bytes, 0, bytes.Length); //Scrittura della riga stessa
                writer.Close(); //Chiusura del BinaryWriter
                writer.Close();
                file.Close(); //Chiusura del file
                Proddacanc.Clear();
                MessageBox.Show("Cancellazione logica avvenuta con successo");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Cancellfisica_Click(object sender, EventArgs e)
        {
                if (Prodcancfis.Text == string.Empty) //Condizione nella quale la textbox del prodotto da cancellare è vuota
                {
                    MessageBox.Show("Inserisci un elemento da cancellare");
                }
                else if (ricercaindice(Prodcancfis.Text) == -1) //Condizione nella quale il prodotto da cancellare non è stato trovato
                {
                    MessageBox.Show("L'elemento non è stato trovato");
                    Prodcancfis.Clear();
                }
                else
                {
                    int indice = ricercaindice(Prodcancfis.Text); //Inizializzazione dell'indice del prodotto da cancellare
                    string[] linea = File.ReadAllLines(filePath); //Inizializzazione array di righe del file
                    for (int i = indice; i < linea.Length - 1; i++) //Scorrimento delle varie righe di una posizione indietro in seguito all'elemento da cancellare
                    {
                        linea[i] = linea[i + 1];
                    }

                    var file = new FileStream(filePath, FileMode.Truncate, FileAccess.Write, FileShare.Read); //Apertura del file
                    StreamWriter sw = new StreamWriter(file); //Apertura del file in scrittura
                    sw.Write(string.Empty); 
                    sw.Close();

                    var files = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read); //Apertura del file
                    StreamWriter sws = new StreamWriter(files); //Apertura del file in scrittura
                    for (int i = 0; i < linea.Length - 1; i++) //Ciclo di scorrimento del file
                    {
                        sws.WriteLine(linea[i]); //Scrittura di ogni linea
                    }
                    sws.Close(); //Chiusura del file
                    Prodcancfis.Clear();
                    MessageBox.Show("Cancellazione fisica avvenuta con successo");
                }

        }

        private void Reset_Click(object sender, EventArgs e)
        {
            var file = new FileStream(filePath, FileMode.Truncate, FileAccess.Write, FileShare.Read); //Apertura del file
            StreamWriter sw = new StreamWriter(file); //Apertura del file in scrittura
            sw.Write(string.Empty); //Cancellazione di tutto ciò che è scritto sul file
            sw.Close(); //Chiusura del file
            MessageBox.Show("File ripristinato correttamente");
        }

        private void Apri_Click(object sender, EventArgs e)
        {
            string percorso = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath); //Dichiarazione percorso (variabile necessaria per il processo di apertura del file)
            Process.Start(percorso); //Avvio del processo "percorso"
        }

        private void Recupera_Click(object sender, EventArgs e)
        {
            if (ricercaindicedarecu(proddarecu.Text) == -1) //Condizione nella quale il prodotto da recuperare non è stato trovato 
            {
                MessageBox.Show("Il prodotto non è stato trovato, assicurati che sia presente all'interno del file");
                proddarecu.Clear();
            }
            else
            {
                int indice = (ricercaindicedarecu(proddarecu.Text)); //Inizializzazione dell'indice del prodotto da recuperare
                string[] prodotto = ricercaproddarecu(proddarecu.Text); //Inizializzazione dell'array dei vari campi del prodotto da recuperare
                string line;
                var file = new FileStream(filePath, FileMode.Open, FileAccess.Write); //Apertura del file
                BinaryWriter writer = new BinaryWriter(file); //Apertura del file in scrittura binaria
                file.Seek(riempi * indice, SeekOrigin.Begin); //Ricerca della riga per mezzo del comando seek moltiplicando l'indice per il numero di caratteri per ogni riga
                line = $"{prodotto[0]};{prodotto[1]};{quantitàglobale};0;".PadRight(riempi - 4) + "##"; //Creazione della riga recuperata
                byte[] bytes = Encoding.UTF8.GetBytes(line); //Scrittura della riga stessa
                writer.Write(bytes, 0, bytes.Length); //Chiusura del BinaryWriter
                writer.Close();
                file.Close(); //Chiusura del file
                proddarecu.Clear();
                MessageBox.Show("Recupero avvenuto con successo");
            }
        }
    }
}


