using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mcd_menu
{
    internal class Program
    {
        // Her gemmes bestillingerene, så de kan kaldes til senere
        public static string[] Bestilling = new string[3];
        public static int[] Total = new int[3];
        static void Main(string[] args)
        {
            menu();
        }
        // Hovedmenu
        static public void menu()
        {
            Console.WriteLine("Velkommen til McD hvad kunne du tænke dig?");
            Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
            Console.WriteLine("1 mad");
            Console.WriteLine("2 drikkevarer");
            Console.WriteLine("3 diverse");
            Console.WriteLine("4 kurv/betaling");

            // Læser hvilket input brugeren vælger
            int valg = Convert.ToInt32(Console.ReadLine());
            if (valg == 1)
            {
                Mad();
            }
            else if (valg == 2)
            {
                Drikkevare();
            }
            else if (valg == 3)
            {
                Diverse();
            }
            else if (valg == 4)
            {
                betaling();
            }
            else
            {
                Console.Clear();
                Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                Console.WriteLine("Du har ikke valgt nogle af mulighederne din spasser så ingen mad til dig næste kunde tak!!!!.");
                Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                menu();
            }
        }
        // Mad menu
        static public void Mad()
        {
            Console.WriteLine("\n") ;
            Console.WriteLine("1. McChicken 50 kr");
            Console.WriteLine("2. BigMac 30kr");
            Console.WriteLine("3. Tasty Cheese 15kr");
            Console.WriteLine("4. McBacon 25kr");
            Console.WriteLine("5. Tilbage");

            // Gemmer prisen og bestillingen i arrays
            string[] Menu = { "McChicken", "BigMac", "Tasty Cheese", "McBacon" };
            int[] priser = { 50, 30, 15, 25 };
            int valg = Convert.ToInt32(Console.ReadLine());
            if (valg == 5)
            {
                menu();
            }
            // Indsætter den valgte menu i array
            string[] retur = new string[2];
            Bestilling[0] = Menu[valg - 1];
            Total[0] = priser[valg - 1];

            Drikkevare();

        }
        // Drikkevare Menu
        static public void Drikkevare()
        {
            Console.WriteLine("\n");
            Console.WriteLine("1. Coca Cola 25kr");
            Console.WriteLine("2. Sprite 25kr");
            Console.WriteLine("3. fanta orange 25kr");
            Console.WriteLine("4. æble juice 15kr");
            Console.WriteLine("5. Tilbage");

            // Gemmer prisen og bestillingen i arrays
            string[] drikkevare = { "Coca Cola", "Sprite", "fanta orange", "æble juice" };
            int[] priser = { 25, 25, 25, 15 };
            int valg = Convert.ToInt32(Console.ReadLine());
            if (valg == 5)
            {
                Mad();
            }
            // Indsætter den valgte menu i array
            string[] retur = new string[2];
            Bestilling[1] = drikkevare[valg - 1];
            Total[1] = priser[valg - 1];

            Diverse();

        }
        // Diverse menu
        static public void Diverse()
        {
            Console.WriteLine("\n");
            Console.WriteLine("1. mcflurry smarties 45kr");
            Console.WriteLine("2. mcflurry daim 45kr");
            Console.WriteLine("3. pomfritter 25 kr");
            Console.WriteLine("4. Linux OS installation 800kr");
            Console.WriteLine("5. Tilbage");
            // Gemmer prisen og bestillingen i arrays
            string[] diverse = { "mcflurry smarties", "mcflurry daim", "pomfritter", "Linux OS installation" };
            int[] priser = { 45, 45, 25, 800 };
            int valg = Convert.ToInt32(Console.ReadLine());
            if (valg == 5)
            {
                Drikkevare();
            }
            // Indsætter den valgte menu i array
            string[] retur = new string[2];
            Bestilling[2] = diverse[valg - 1];
            Total[2] = priser[valg - 1];

            betaling();
        }
        // Betaling Menu
        static public void betaling()
        {
            Console.WriteLine("\n");
            // Udskriver menuen fra array
            Console.WriteLine($"Prisen er: {Total[0] + Total[1] + Total[2]:c}");
            Console.WriteLine($"din menu er: {Bestilling[0]}, {Bestilling[1]}, {Bestilling[2]}");
            Console.WriteLine("1. betal");
            Console.WriteLine("2. Køb videre? ");
            Console.WriteLine("3. Tilbage");
            int valg = Convert.ToInt32(Console.ReadLine());
            if (valg == 1)
            {
                // Udskriver random nummer for bestilling
                Console.WriteLine("\n");
                Random random = new Random();
                int odrenummer = random.Next(100);
                Console.WriteLine($"dit nummer er {odrenummer}");
                OdreNummer(odrenummer);
                menu();
            }
            else if (valg == 2)
            {
                Console.WriteLine("\n");
                menu();
            }
            else if (valg == 3)
            {
                Diverse();
            }
        }
        // outputer nummer, og fortæller når odren er færdig
        static public void OdreNummer(int odrenummer)
        {
            MenuEvent menuEvent = new MenuEvent();
            menuEvent.Nummer += async (s, args) =>
            {
                // Venter og udskriver når menu er done
                await Task.Delay(100);
                Thread.Sleep(odrenummer * 1000);
                Console.WriteLine($"Nr.{odrenummer} er færdig");
            };
            menuEvent.MadDone();
        }
        // fortæller eventet er færdigt
        public class MenuEvent
        {
            public event EventHandler Nummer;
            public void MadDone()
            {
                EventHandler handler = Nummer;
                handler.Invoke(this, EventArgs.Empty);
            }
        }
    }
}