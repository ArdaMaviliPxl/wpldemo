namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
@" #####  #       ####### #######  #####  
#     # #       #     #    #    #     # 
#       #       #     #    #    #       
 #####  #       #     #    #     #####  
      # #       #     #    #          # 
#     # #       #     #    #    #     # 
 #####  ####### #######    #     #####");

            Console.WriteLine("\n\nMet hoeveel credits wil je spelen?");
            Console.Write("Credits: ");

            decimal totalCredits = AskCredits();
            int roundCounter = 1;
            Random random = new Random();

            while (totalCredits > 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\nRound {roundCounter}, place your bets!");
                Console.ResetColor();
                Console.Write("Inzet: ");

                string userInput = Console.ReadLine();

                if (userInput.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Bedankt voor het spelen!");
                    return;

                }

                if (decimal.TryParse(userInput, out decimal betAmount))
                {
                    totalCredits = ExecuteRound(random, totalCredits, betAmount);
                    roundCounter++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ongeldige inzet. Voer een getal in.");
                    Console.ResetColor();
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nGame over! Geen credits meer.");
            Console.ResetColor();
        }

        static decimal AskCredits()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal result) && result > 0)
                    return result;

                Console.Write("Credits: ");
            }
        }

        static decimal ExecuteRound(Random random, decimal credits, decimal bet)
        {
            if (bet > credits || bet <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Onvoldoende credits.");
                Console.ResetColor();
                return credits;
            }

            credits -= bet;
            Console.WriteLine($"Inzet: € {bet:F2}");

            char[] reels = { Spin(random), Spin(random), Spin(random) };

            Console.WriteLine("+---+---+---+");
            Console.WriteLine($"| {reels[0]} | {reels[1]} | {reels[2]} |");
            Console.WriteLine("+---+---+---+");

            decimal multiplier = CalculateMultiplier(reels);
            decimal winnings = bet * multiplier;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Payout: € {winnings:F2}");
            Console.ResetColor();

            credits += winnings;
            Console.WriteLine($"Credits: € {credits:F2}");

            return credits;
        }

        static char Spin(Random rnd)
        {
            return rnd.Next(100) switch
            {
                < 50 => 'A',
                < 85 => 'B',
                _ => 'C'
            };
        }

        static decimal CalculateMultiplier(char[] r)
        {
            if (r[0] == r[1] && r[1] == r[2])
                return r[0] switch { 'A' => 10, 'B' => 20, 'C' => 50, _ => 0 };

            if (r[0] == r[1] || r[1] == r[2])
                return 2;

            return 0;
        }
    }

}
    

