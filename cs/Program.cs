using System;
using System.Threading;

namespace AssetManager {
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Asset Manager ---");
            Inventory inventory = new Inventory();
            inventory.Run();
            Thread.Sleep(2000);
            string answer = "";
            while (answer != "5") {
                Console.Clear();
                Console.WriteLine(" --- Home Screen --- ");
                Console.WriteLine();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Search by asset tag");
                Console.WriteLine("2. Search by owner");
                Console.WriteLine("3. Create new asset");
                Console.WriteLine("4. Import assets from CSV");
                Console.WriteLine("5. Close application");
                Console.Write("Select a number from the menu: ");
                answer = Console.ReadLine() ?? "";

                if (answer == "1")
                {
                    Console.WriteLine("Implementing!");
                }
                else if (answer == "2")
                {
                    Console.WriteLine("Gotta search by user");
                }
                else if (answer == "3")
                {
                    Console.WriteLine("Creating dawg");
                }
                else if (answer == "4")
                {
                    Console.WriteLine("Import!");
                }
                else if (answer == "5")
                {
                    Console.Clear();
                    Console.WriteLine("Thanks for using the asset manager!");
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid selection.");
                    Thread.Sleep(2000);
                }
            }
        }
    }
}