namespace slotmachine
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
                    return; if (decimal.TryParse(userInput, out decimal betAmount))
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

        }

    }
        }
}
