using System;

namespace QuickMartProfit
{
    /*
        STRUCTURE OVERVIEW:

        1. TradeEntry
           - Represents one sales invoice.
           - Stores purchase, selling, and profit/loss details.

        2. TradeProcessor
           - Handles user input.
           - Computes profit/loss.
           - Stores only ONE transaction using static members.
           - Displays and recalculates values when required.

    */

    // Entity class for sales data
    public class TradeEntry
    {
        public string? InvoiceId;
        public string? BuyerName;
        public string? ProductName;
        public int Units;

        public decimal CostTotal;
        public decimal SaleTotal;

        public string? ResultType;
        public decimal ResultAmount;
        public decimal ResultPercent;
    }

    // Service class for transaction handling
    public class TradeProcessor
    {
        public static TradeEntry CachedTrade;
        public static bool HasTrade = false;

        // Accepts input and saves transaction
        public void CaptureTransaction()
        {
            TradeEntry entry = new TradeEntry();

            Console.Write("Enter Invoice No: ");
            entry.InvoiceId = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(entry.InvoiceId))
            {
                Console.WriteLine("Invoice No cannot be empty.");
                return;
            }

            Console.Write("Enter Customer Name: ");
            entry.BuyerName = Console.ReadLine();

            Console.Write("Enter Item Name: ");
            entry.ProductName = Console.ReadLine();

            Console.Write("Enter Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out entry.Units) || entry.Units <= 0)
            {
                Console.WriteLine("Quantity must be greater than 0.");
                return;
            }

            Console.Write("Enter Purchase Amount (total): ");
            if (!decimal.TryParse(Console.ReadLine(), out entry.CostTotal) || entry.CostTotal <= 0)
            {
                Console.WriteLine("Purchase amount must be greater than 0.");
                return;
            }

            Console.Write("Enter Selling Amount (total): ");
            if (!decimal.TryParse(Console.ReadLine(), out entry.SaleTotal) || entry.SaleTotal < 0)
            {
                Console.WriteLine("Selling amount must be zero or greater.");
                return;
            }

            Evaluate(entry);

            CachedTrade = entry;
            HasTrade = true;

            Console.WriteLine("\nTransaction saved successfully.");
            PrintResult(entry);
        }

        // Calculates profit or loss
        private void Evaluate(TradeEntry t)
        {
            if (t.SaleTotal > t.CostTotal)
            {
                t.ResultType = "PROFIT";
                t.ResultAmount = t.SaleTotal - t.CostTotal;
            }
            else if (t.SaleTotal < t.CostTotal)
            {
                t.ResultType = "LOSS";
                t.ResultAmount = t.CostTotal - t.SaleTotal;
            }
            else
            {
                t.ResultType = "BREAK-EVEN";
                t.ResultAmount = 0;
            }

            t.ResultPercent = (t.ResultAmount / t.CostTotal) * 100;
        }

        // Displays last transaction
        public void ShowTransaction()
        {
            if (!HasTrade)
            {
                Console.WriteLine("No transaction available. Please create a new transaction first.");
                return;
            }

            TradeEntry t = CachedTrade;

            Console.WriteLine("\n-------------- Last Transaction --------------");
            Console.WriteLine("InvoiceNo: " + t.InvoiceId);
            Console.WriteLine("Customer: " + t.BuyerName);
            Console.WriteLine("Item: " + t.ProductName);
            Console.WriteLine("Quantity: " + t.Units);
            Console.WriteLine("Purchase Amount: " + t.CostTotal.ToString("F2"));
            Console.WriteLine("Selling Amount: " + t.SaleTotal.ToString("F2"));
            Console.WriteLine("Status: " + t.ResultType);
            Console.WriteLine("Profit/Loss Amount: " + t.ResultAmount.ToString("F2"));
            Console.WriteLine("Profit Margin (%): " + t.ResultPercent.ToString("F2"));
            Console.WriteLine("--------------------------------------------");
        }

        // Recomputes profit/loss
        public void Reprocess()
        {
            if (!HasTrade)
            {
                Console.WriteLine("No transaction available. Please create a new transaction first.");
                return;
            }

            Evaluate(CachedTrade);
            PrintResult(CachedTrade);
        }

        // Prints calculation summary
        private void PrintResult(TradeEntry t)
        {
            Console.WriteLine("Status: " + t.ResultType);
            Console.WriteLine("Profit/Loss Amount: " + t.ResultAmount.ToString("F2"));
            Console.WriteLine("Profit Margin (%): " + t.ResultPercent.ToString("F2"));
            Console.WriteLine("------------------------------------------------------");
        }
    }
}
