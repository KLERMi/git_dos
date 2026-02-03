using System;

namespace IdealBank
{
    class Program
    {
        static void Main(string[] args)
        {
            // My Welcome page
            Console.Title = "Ideal Bank - v1.0";
         

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("       WELCOME TO THE DIGITAL BANK          ");
            Console.WriteLine("------------------------------------------");
         

            // 2. CAPTURING STRING INPUT
            Console.Write("\nPlease enter your name to log in: ");
            string accountHolder = Console.ReadLine();

            Console.WriteLine($"\nHello {accountHolder}, your current balance is $58,000,000.");
           

            // 3. CAPTURING AND CONVERTING NUMERIC INPUT
            Console.Write("\nHow much would you like to withdraw today? $");
            string input = Console.ReadLine();

            // We convert the text input into a double (decimal number) for the math
            double withdrawalAmount = Convert.ToDouble(input);

            // 4. Try withdrawal
            double newBalance = 58000000 - withdrawalAmount;

            // 5. FINAL OUTPUT
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("TRANSACTION SUCCESSFUL");
            Console.WriteLine($"New Balance for {accountHolder}: ${newBalance}");
            Console.WriteLine("------------------------------------------");

            // Prevents the console from closing until user presses Enter
            Console.WriteLine("\nPress [Enter] to exit the bank system...");
            Console.ReadLine();
        }
    }
}