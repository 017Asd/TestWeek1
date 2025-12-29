using System;

namespace MediSureClinic
{
    class Program
    {
        static void Main()
        {
            ClinicController controller = new ClinicController();
            bool stop = false;

            while (!stop)
            {
                Console.WriteLine("\n================== MediSure Clinic Billing ==================");
                Console.WriteLine("1. Create New Bill (Enter Patient Details)");
                Console.WriteLine("2. View Last Bill");
                Console.WriteLine("3. Clear Last Bill");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your option: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        controller.AddBill();
                        break;

                    case "2":
                        controller.DisplayBill();
                        break;

                    case "3":
                        controller.RemoveBill();
                        break;

                    case "4":
                        Console.WriteLine("Thank you. Application closed normally.");
                        stop = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
