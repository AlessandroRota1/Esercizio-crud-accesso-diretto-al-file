namespace Esercizio_crud_accesso_diretto_al_file
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.Prodotto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Prezzo = new System.Windows.Forms.TextBox();
            this.Create = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Ricercato = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Prodvecchio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Prezzonuovo = new System.Windows.Forms.TextBox();
            this.Prodnuovo = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.Proddacanc = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.Cancellfisica = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.Prodcancfis = new System.Windows.Forms.TextBox();
            this.Reset = new System.Windows.Forms.Button();
            this.Apri = new System.Windows.Forms.Button();
            this.Recupera = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.proddarecu = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Prodotto
            // 
            this.Prodotto.Location = new System.Drawing.Point(70, 57);
            this.Prodotto.Name = "Prodotto";
            this.Prodotto.Size = new System.Drawing.Size(100, 20);
            this.Prodotto.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inserisci il nome del prodotto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Inserisci il prezzo del prodotto:";
            // 
            // Prezzo
            // 
            this.Prezzo.Location = new System.Drawing.Point(70, 110);
            this.Prezzo.Name = "Prezzo";
            this.Prezzo.Size = new System.Drawing.Size(100, 20);
            this.Prezzo.TabIndex = 3;
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(229, 41);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(109, 36);
            this.Create.TabIndex = 4;
            this.Create.Text = "Aggiungi prodotto alla lista:";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.C);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(229, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "Ricerca prodotto:";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.R);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Inserisci il prodotto da ricercare:";
            // 
            // Ricercato
            // 
            this.Ricercato.Location = new System.Drawing.Point(70, 204);
            this.Ricercato.Name = "Ricercato";
            this.Ricercato.Size = new System.Drawing.Size(100, 20);
            this.Ricercato.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Inserisci prodotto da modificare:";
            // 
            // Prodvecchio
            // 
            this.Prodvecchio.Location = new System.Drawing.Point(70, 294);
            this.Prodvecchio.Name = "Prodvecchio";
            this.Prodvecchio.Size = new System.Drawing.Size(100, 20);
            this.Prodvecchio.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 317);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Inserisci nuovo nome del prodotto:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 357);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Inserisci nuovo prezzo:";
            // 
            // Prezzonuovo
            // 
            this.Prezzonuovo.Location = new System.Drawing.Point(70, 373);
            this.Prezzonuovo.Name = "Prezzonuovo";
            this.Prezzonuovo.Size = new System.Drawing.Size(100, 20);
            this.Prezzonuovo.TabIndex = 12;
            // 
            // Prodnuovo
            // 
            this.Prodnuovo.Location = new System.Drawing.Point(70, 333);
            this.Prodnuovo.Name = "Prodnuovo";
            this.Prodnuovo.Size = new System.Drawing.Size(100, 20);
            this.Prodnuovo.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(229, 278);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 36);
            this.button2.TabIndex = 14;
            this.button2.Text = "Modifica prodotto:";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Modif);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(444, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Inserisci il nome del prodotto:";
            // 
            // Proddacanc
            // 
            this.Proddacanc.Location = new System.Drawing.Point(447, 57);
            this.Proddacanc.Name = "Proddacanc";
            this.Proddacanc.Size = new System.Drawing.Size(100, 20);
            this.Proddacanc.TabIndex = 16;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(593, 41);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(157, 37);
            this.button3.TabIndex = 17;
            this.button3.Text = "Cancella prodotto logicamente (recuperabile):";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.D);
            // 
            // Cancellfisica
            // 
            this.Cancellfisica.Location = new System.Drawing.Point(593, 172);
            this.Cancellfisica.Name = "Cancellfisica";
            this.Cancellfisica.Size = new System.Drawing.Size(157, 37);
            this.Cancellfisica.TabIndex = 18;
            this.Cancellfisica.Text = "Cancella prodotto fisicamente:";
            this.Cancellfisica.UseVisualStyleBackColor = true;
            this.Cancellfisica.Click += new System.EventHandler(this.Cancellfisica_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(444, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Inserisci il nome del prodotto:";
            // 
            // Prodcancfis
            // 
            this.Prodcancfis.Location = new System.Drawing.Point(447, 188);
            this.Prodcancfis.Name = "Prodcancfis";
            this.Prodcancfis.Size = new System.Drawing.Size(100, 20);
            this.Prodcancfis.TabIndex = 20;
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(577, 314);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(116, 98);
            this.Reset.TabIndex = 21;
            this.Reset.Text = "Ripristina il file:";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Apri
            // 
            this.Apri.Location = new System.Drawing.Point(447, 317);
            this.Apri.Name = "Apri";
            this.Apri.Size = new System.Drawing.Size(116, 98);
            this.Apri.TabIndex = 22;
            this.Apri.Text = "Apri il file:";
            this.Apri.UseVisualStyleBackColor = true;
            this.Apri.Click += new System.EventHandler(this.Apri_Click);
            // 
            // Recupera
            // 
            this.Recupera.Location = new System.Drawing.Point(593, 101);
            this.Recupera.Name = "Recupera";
            this.Recupera.Size = new System.Drawing.Size(157, 37);
            this.Recupera.TabIndex = 23;
            this.Recupera.Text = "Recupera prodotto cancellato:";
            this.Recupera.UseVisualStyleBackColor = true;
            this.Recupera.Click += new System.EventHandler(this.Recupera_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(444, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Inserisci il nome del prodotto:";
            // 
            // proddarecu
            // 
            this.proddarecu.Location = new System.Drawing.Point(447, 110);
            this.proddarecu.Name = "proddarecu";
            this.proddarecu.Size = new System.Drawing.Size(100, 20);
            this.proddarecu.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.proddarecu);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Recupera);
            this.Controls.Add(this.Apri);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.Prodcancfis);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Cancellfisica);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Proddacanc);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Prodnuovo);
            this.Controls.Add(this.Prezzonuovo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Prodvecchio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Ricercato);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.Prezzo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Prodotto);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Prodotto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Prezzo;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Ricercato;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Prodvecchio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Prezzonuovo;
        private System.Windows.Forms.TextBox Prodnuovo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Proddacanc;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Cancellfisica;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Prodcancfis;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Apri;
        private System.Windows.Forms.Button Recupera;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox proddarecu;
    }
}

