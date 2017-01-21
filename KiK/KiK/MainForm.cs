using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KiK
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        bool kolejka = true;// true = kolejka X, false = kolejka O
        static int liczba_kolejek = 0;
        bool zKomputerem = false;// false gracz przecoiwko graczowi, true gracz przeciwko komputerowi



        public MainForm()
        {

            InitializeComponent();
           	Gracz gracze = new Gracz();            
			RuchKomputera ruchK = new RuchKomputera();
        }
        
		

        void ZasadyGryToolStripMenuItemClick(object sender, EventArgs e) //-MK
        {
            MessageBox.Show("Gracze obejmują pola na przemian dążąc do objęcia trzech pól w jednej linii, przy jednoczesnym uniemożliwieniu tego samego przeciwnikowi." +
                            " Pole pole zajęte przez jednego z graczy nie może zmienić właściciela aż do ukończenia rundy.", "Zasady gry");
        }

        void AutorzyToolStripMenuItemClick(object sender, EventArgs e)//-MK
        {
            MessageBox.Show("Wiktor Łopatka" + "\nMateusz Kuliś", "Autorzy");
        }

        void WyjścieToolStripMenuItemClick(object sender, EventArgs e)//-MK
        {
            Application.Exit();
        }

        //Obsluga zdażenia nacisnięcia 
        void przycisk_klik(object sender, EventArgs e)//-WŁ
        {
            Button b = (Button)sender;

            if (kolejka)
            {

                b.Text = "X";
                kolej.Text = "Kolejka gracza " + Gracz.gracz2;//Zmiana tekstu w polu tekstowym po wykonaniu ruchu
                
            }
            else
            {
                b.Text = "O";
                kolej.Text = "Kolejka gracza " + Gracz.gracz1;
                
            }
            kolejka = !kolejka;//Zmiana kolejki
            b.Enabled = false;//Wyłączenie pola po kliknieciu
            liczba_kolejek++;//Zwiekszenie liczby kolejek o 1
            SprawdzWygrana();
            if ((!kolejka) && (zKomputerem))//jeśli kolejka=false i zKomputerem=true komputer wykonuje ruch
            {
            	RuchKomputera.ruchKomputera(liczba_kolejek);
            	
            }
			
        }
		
        //Metoda sprawdzająca czy ktoś wygral lub zremisowano
        private void SprawdzWygrana()//-MK
        {
            bool wygrana = false;

            //Rzędy
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled)) wygrana = true;

            if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled)) wygrana = true;

            if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled)) wygrana = true;

            //Kolumny
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled)) wygrana = true;

            if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled)) wygrana = true;

            if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled)) wygrana = true;

            //Na ukos
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled)) wygrana = true;

            if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled)) wygrana = true;




            if (wygrana)
            {
                WylaczPrzyciski();
                string zwyciezca = "";
                if (!kolejka)
                {
                    zwyciezca = Gracz.gracz1;
                    WygraneX.Text = (Int32.Parse(WygraneX.Text) + 1).ToString();
                }
                else
                {
                    zwyciezca = Gracz.gracz2;
                    WygraneO.Text = (Int32.Parse(WygraneO.Text) + 1).ToString();
                }
                MessageBox.Show(zwyciezca + " wygrywa!", "Gratulacje!");
                kolej.Text = "Gratulacje!";
            }
            else
            {
                if (liczba_kolejek == 9)
                {
                    MessageBox.Show("Remis.", "Koniec gry.");
                    Remis.Text = (Int32.Parse(Remis.Text) + 1).ToString();
                    kolej.Text = "Koniec gry.";
                }
            }
        }
       
        //Metoda wyłączająca pola gry po zakończeniu rozgrywki
        private void WylaczPrzyciski()//-WŁ
        {

            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
                catch { }
            }

        }
        //Zaczyna nowa gre z resetowaniem liczników
        void NowaGraToolStripMenuItemClick(object sender, EventArgs e)//-WŁ
        {
            kolejka = true;
            liczba_kolejek = 0;
           
            WygraneX.Text = "0";
            WygraneO.Text = "0";
            Remis.Text = "0";
			
            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
            }


        }
        //Obsługa zdażenia najazdu na przycisk
        void Najazd(object sender, EventArgs e)//-WŁ
        {
            Button b = (Button)sender;

            if (b.Enabled)
            {
                if (kolejka)
                {

                    b.Text = "X";


                }
                else
                {
                    b.Text = "O";


                }
            }

        }
        //Obsługa zdażenia zjazdu na przycisk
        void Zjazd(object sender, EventArgs e)//-WŁ
        {
            Button b = (Button)sender;

            if (b.Enabled) b.Text = "";



        }
        //Zaczyna nową runde bez resetowania liczników
        void NowaRundaToolStripMenuItemClick(object sender, EventArgs e)//-MK
        {

            kolejka = true;
            liczba_kolejek = 0;
            
            
            

            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
                
            }

        }
        void MainFormLoad(object sender, EventArgs e)//-WŁ
        {
            Form okno1 = new Form1();
            okno1.ShowDialog();

            //Ustawienie nazw graczy jeżeli nic nie zostało wprowadzone
            if (string.IsNullOrWhiteSpace(Gracz.gracz1)) Gracz.gracz1 = "Pierwszy";
            if (string.IsNullOrWhiteSpace(Gracz.gracz2)) Gracz.gracz2 = "Drugi";

            kolej.Text = "Kolejka gracza " + Gracz.gracz1;//Wyświetlenie w polu tekstowym który gracz wykonuje ruch
            label1.Text = Gracz.gracz1;

            //Zmiana wartości zKomputerem na true jeżeli nazwa gracza2 to Komputer
            if (Gracz.gracz2 == "Komputer") { zKomputerem = true; }
            label3.Text = Gracz.gracz2;
            



        }
        void UruchomPonownieToolStripMenuItemClick(object sender, EventArgs e)//-MK
        {
            Application.Restart();
        }
        void ObjaśnieniaToolStripMenuItemClick(object sender, EventArgs e)//-MK
        {
            MessageBox.Show("Nowa gra - zaczyna grę odnowa zerując licznik wygranych/porażek zachowując nazwy graczy." +
                            "\n Nowa runda - zaczyna grę odnowa zachowując nazwy graczy i licznik wygranych/porażek." +
                           "\nUruchom ponownie - uruchamia ponownie grę dajac możliwośc zmiany nazw graczy lub gry z komputerem." +
                          "\nWyjście - zamyka grę.", "Objaśnienia Menu.");
        }



    }

}

