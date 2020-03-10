using System;
using MyBookLibrary;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList p = new MyList();
            int choice;
            do
            {
                Console.WriteLine("----------Menu----------");
                Console.WriteLine("1. Add a new item ");
                Console.WriteLine("2. Update the price of a item");
                Console.WriteLine("3. Delete a item");
                Console.WriteLine("4. Search for a item by the item's code");
                Console.WriteLine("5. Display items in ascending order of price");
                Console.WriteLine("6. Quit");
                Console.WriteLine("------------------------");
                Console.Write("Your choice: ");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");
                switch (choice)
                {
                    case 1:
                        p.InputItems();
                        Console.WriteLine("\n");
                        break;
                    case 2:
                        p.UpdatePrice();
                        Console.WriteLine("\n");
                        break;
                    case 3:
                        p.DeleteItem();
                        Console.WriteLine("\n");
                        break;
                    case 4:
                        p.Search();
                        Console.WriteLine("\n");
                        break;
                    case 5:
                        p.OutList();
                        Console.WriteLine("\n");
                        break;
                    case 6:
                        Console.WriteLine("Thank You !!!");
                        break;
                }
            } while (choice > 0 && choice <= 5);
        }
    }
}
