using System;

namespace QuickMartProfit
{
    class Program
    {
        static void Main()
        {
            TradeProcessor processor = new TradeProcessor();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n================== QuickMart Traders ==================");
                Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
                Console.WriteLine("2. View Last Transaction");
                Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your option: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        processor.CaptureTransaction();
                        break;

                    case "2":
                        processor.ShowTransaction();
                        break;

                    case "3":
                        processor.Reprocess();
                        break;

                    case "4":
                        Console.WriteLine("Thank you. Application closed normally.");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose between 1 to 4.");
                        break;
                }
            }
        }
    }
}
