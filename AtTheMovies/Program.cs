using System;

namespace MovieTheaterTicketSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Welcome message
            Console.WriteLine("=================================");
            Console.WriteLine("   WELCOME TO CINEMA PARADISE    ");
            Console.WriteLine("=================================");

            // ============ AGE INPUT WITH VALIDATION ============
            int age;
            Console.Write("Please enter your age: ");
            string ageInput = Console.ReadLine();

            // Validate age input
            if (!int.TryParse(ageInput, out age) || age < 0 || age > 120)
            {
                Console.WriteLine("Invalid age entered. Please restart and enter a valid age.");
                return; // Exit program
            }

            // ============ MOVIE MENU SELECTION ============
            Console.WriteLine("--- NOW SHOWING ---");
            Console.WriteLine("1. Action - Fast & Furious 12 (PG-13)");
            Console.WriteLine("2. Horror - The Haunting III (R)");
            Console.WriteLine("3. Comedy - Laugh Out Loud (PG)");
            Console.WriteLine("4. Kids - Panda Adventures (G)");
            Console.Write("Select a movie (1-4): ");

            string movieChoice = Console.ReadLine();
            string movieTitle;
            string rating;
            int minAge;

            // Switch statement for movie selection
            switch (movieChoice)
            {
                case "1":
                    movieTitle = "Fast & Furious 12";
                    rating = "PG-13";
                    minAge = 13;
                    break;
                case "2":
                    movieTitle = "The Haunting III";
                    rating = "R";
                    minAge = 17;
                    break;
                case "3":
                    movieTitle = "Laugh Out Loud";
                    rating = "PG";
                    minAge = 0;
                    break;
                case "4":
                    movieTitle = "Panda Adventures";
                    rating = "G";
                    minAge = 0;
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please restart and choose 1-4.");
                    return; // Exit program
            }

            // ============ AGE RESTRICTION CHECK (Logical Operators) ============
            bool canWatch = true;
            bool needsParent = false;

            // Check if age meets requirement OR if they need parental guidance
            if (age < minAge && rating == "R")
            {
                // R-rated: Must be 17+ with no exceptions
                canWatch = false;
            }
            else if (age < minAge && (rating == "PG-13" || rating == "PG"))
            {
                // PG-13 or PG: Under age but can watch with parent
                needsParent = true;
            }

            // ============ TICKET PRICING (if/else if/else) ============
            double ticketPrice;
            string ticketType;

            if (age < 12)
            {
                ticketPrice = 800.00;
                ticketType = "Child";
            }
            else if (age >= 12 && age < 65)
            {
                ticketPrice = 1500.00;
                ticketType = "Adult";
            }
            else // age >= 65
            {
                ticketPrice = 1000.00;
                ticketType = "Senior";
            }

            // ============ SPECIAL DISCOUNTS (Logical Operators) ============
            bool hasDiscount = false;
            string discountReason = "";

            // Tuesday discount OR kids watching G-rated movies
            if (age <= 12 && rating == "G")
            {
                ticketPrice -= 2.00;
                hasDiscount = true;
                discountReason = "Kids Special on G-rated films";
            }
            else if (age >= 65 && (rating == "PG" || rating == "G"))
            {
                ticketPrice -= 1.50;
                hasDiscount = true;
                discountReason = "Senior Matinee Discount";
            }

            // ============ DISPLAY RESULTS ============
            Console.WriteLine("=================================");
            Console.WriteLine("        YOUR TICKET SUMMARY      ");
            Console.WriteLine("=================================");

            if (!canWatch)
            {
                Console.WriteLine($"Sorry! You must be {minAge}+ to watch '{movieTitle}' (Rated {rating}).");
                Console.WriteLine("Please select a different movie.");
            }
            else
            {
                Console.WriteLine($"Movie: {movieTitle}");
                Console.WriteLine($"Rating: {rating}");
                Console.WriteLine($"Your Age: {age}");
                Console.WriteLine($"Ticket Type: {ticketType}");

                if (needsParent)
                {
                    Console.WriteLine("Parental guidance required for this film.");
                }

                if (hasDiscount)
                {
                    Console.WriteLine($"Discount Applied: {discountReason}");
                }

                Console.WriteLine($"💰 Total Price: N{ticketPrice:F2}");
                Console.WriteLine("Enjoy your movie!");
            }

            Console.WriteLine("=================================");
        }
    }
}