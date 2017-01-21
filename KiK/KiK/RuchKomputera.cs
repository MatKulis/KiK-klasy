using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KiK
{
    public partial class MainForm
    {
        
        class RuchKomputera 

        {
                               
            private static int liczbakolejek = 0;

            public static IEnumerable<Control> Controls { get; private set; }

            public static void ruchKomputera(int liczba)//-WŁ                          
            {
				
                Button ruch = null;
                liczbakolejek=liczba;

                ruch = WygrajLubBlokuj("O");
                if (ruch == null)
                {
                    ruch = WygrajLubBlokuj("X");
                    if (ruch == null)
                    {
                        ruch = ZajmijRogi();
                        if (ruch == null)
                        {
                            ruch = wolnePole();
                        }
                    }
                }
                
                if (liczbakolejek < 9) {
                	
                	ruch.PerformClick();
                	liczbakolejek++;
                	
                }

                


            }
          //Metoda sprawdzająca które pola sa wolne
            private static Button wolnePole()//-WŁ            
            {
            	
                Button b = null;
				try{                
                foreach ( Control c in Controls)
                {
                	
                	b = c as Button;
                    if (b != null)
                    {
                        if (b.Text == "") return b;                        
                        break;
                    }
                	
                    break;                                                     
                }
}
                	catch{}                
                return null;
            }
            //Metoda sprawdzajaća który zrogów pola może zając komputer
            public static Button ZajmijRogi()//-WŁ
            {
                if (A1.Text == "O")
                {
                    if (A3.Text == "")
                        return A3;
                    if (C3.Text == "")
                        return C3;
                    if (C1.Text == "")
                        return C1;
                }

                if (A3.Text == "O")
                {
                    if (A1.Text == "")
                        return A1;
                    if (C3.Text == "")
                        return C3;
                    if (C1.Text == "")
                        return C1;
                }

                if (C3.Text == "O")
                {
                    if (A1.Text == "")
                        return A3;
                    if (A3.Text == "")
                        return A3;
                    if (C1.Text == "")
                        return C1;
                }

                if (C1.Text == "O")
                {
                    if (A1.Text == "")
                        return A3;
                    if (A3.Text == "")
                        return A3;
                    if (C3.Text == "")
                        return C3;
                }

                if (A1.Text == "")
                    return A1;
                if (A3.Text == "")
                    return A3;
                if (C1.Text == "")
                    return C1;
                if (C3.Text == "")
                    return C3;

                return null;
            }
            //Metoda sprawdzajaca zajęte pola jeżeli komputer ma mozliwośc wygranej wygra w innym przypadku zablokuje możliwośc wygranej graczowi
            public static Button WygrajLubBlokuj(string znak)//-WŁ
            {

                //Wyszukiwanie w poziomie
                if ((A1.Text == znak) && (A2.Text == znak) && (A3.Text == ""))
                    return A3;
                if ((A2.Text == znak) && (A3.Text == znak) && (A1.Text == ""))
                    return A1;
                if ((A1.Text == znak) && (A3.Text == znak) && (A2.Text == ""))
                    return A2;

                if ((B1.Text == znak) && (B2.Text == znak) && (B3.Text == ""))
                    return B3;
                if ((B2.Text == znak) && (B3.Text == znak) && (B1.Text == ""))
                    return B1;
                if ((B1.Text == znak) && (B3.Text == znak) && (B2.Text == ""))
                    return B2;

                if ((C1.Text == znak) && (C2.Text == znak) && (C3.Text == ""))
                    return C3;
                if ((C2.Text == znak) && (C3.Text == znak) && (C1.Text == ""))
                    return C1;
                if ((C1.Text == znak) && (C3.Text == znak) && (C2.Text == ""))
                    return C2;

                //Wyszukiwanie w pionie
                if ((A1.Text == znak) && (B1.Text == znak) && (C1.Text == ""))
                    return C1;
                if ((B1.Text == znak) && (C1.Text == znak) && (A1.Text == ""))
                    return A1;
                if ((A1.Text == znak) && (C1.Text == znak) && (B1.Text == ""))
                    return B1;

                if ((A2.Text == znak) && (B2.Text == znak) && (C2.Text == ""))
                    return C2;
                if ((B2.Text == znak) && (C2.Text == znak) && (A2.Text == ""))
                    return A2;
                if ((A2.Text == znak) && (C2.Text == znak) && (B2.Text == ""))
                    return B2;

                if ((A3.Text == znak) && (B3.Text == znak) && (C3.Text == ""))
                    return C3;
                if ((B3.Text == znak) && (C3.Text == znak) && (A3.Text == ""))
                    return A3;
                if ((A3.Text == znak) && (C3.Text == znak) && (B3.Text == ""))
                    return B3;

                //Wyszukiwanie na ukos
                if ((A1.Text == znak) && (B2.Text == znak) && (C3.Text == ""))
                    return C3;
                if ((B2.Text == znak) && (C3.Text == znak) && (A1.Text == ""))
                    return A1;
                if ((A1.Text == znak) && (C3.Text == znak) && (B2.Text == ""))
                    return B2;

                if ((A3.Text == znak) && (B2.Text == znak) && (C1.Text == ""))
                    return C1;
                if ((B2.Text == znak) && (C1.Text == znak) && (A3.Text == ""))
                    return A3;
                if ((A3.Text == znak) && (C1.Text == znak) && (B2.Text == ""))
                    return B2;
                liczbakolejek++;
                return null;
            }


        
        }
    }
}