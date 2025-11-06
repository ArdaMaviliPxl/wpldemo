using System.Diagnostics;

namespace wpldemo
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    internal class Program
    {
        private static object console;

        static void Main(string[] args)
        {
            
            Console.WriteLine("Welkom bij de Slot Machine!");
            Console.WriteLine();

            // Vraag startcredits
            decimal credits = 0;
            while (credits <= 0)
            {
                Console.Write("Met hoeveel credits wil je spelen? ");
                string input = Console.ReadLine();

                if (decimal.TryParse(input, out credits) && credits > 0)
                {
                    break;
                }
                Console.WriteLine("Voer een geldig bedrag in (groter dan 0)");
                credits = 0;
            }
            int roundNumber = 1;
            Random rng = new Random();

            // Hoofdspel loop
            while (true) ;

            {
                Console.WriteLine();
                Console.WriteLine($"Round {roundNumber}, place your bets!");
                Console.WriteLine($"Huidige credits: {credits:F2}");

                // Vraag inzet
                decimal stake = 0;
                bool validInput = false;

                while (!validInput)
                {
                    Console.Write("Inzet (of 'Q' om te stoppen): ");
                    string input = Console.ReadLine();
                }
            }
        }
    }
}
        
   