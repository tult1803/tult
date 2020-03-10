﻿using System;
using System.Collections;

namespace Lab1
{
    class Program
    {
        ArrayList arrCode = new ArrayList(), arrName = new ArrayList(), arrPrice = new ArrayList(), demo_arrPrice = new ArrayList(),  sort_price = new ArrayList(), arr = new ArrayList();
        Items item = new Items();

        public void InputItems()
        {
            Boolean check;
            string code;
            do
            {
                Console.Write("Code: ");
                code = Console.ReadLine();
                check = CheckCode(code);
            } while (check == true);
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Price: ");
            float price = float.Parse(Console.ReadLine());
            AddItems(code, name, price);
            Console.WriteLine("Successed !!!");
        }
        public void AddItems(string code, string name, float price)
        {
            arrCode.Add(code);
            arrName.Add(name);
            arrPrice.Add(price);
            demo_arrPrice.Add(price);
        }

        public void UpdatePrice()
        {
            Boolean check = false;
            Console.Write("Code: ");
            string code = Console.ReadLine();
            for(int i = 0; i < arrCode.Count; i++)
            {
                if (arrCode[i].Equals(code))
                {
                    Console.WriteLine("Old-Price: " + arrPrice[i]);
                    Console.Write("New-Price: ");
                    float new_price = float.Parse(Console.ReadLine());
                    try
                    {
                        arrPrice[i] = new_price;
                        arr.Add(i);
                        check = true;
                    }catch (Exception e)
                    {   
                        Console.WriteLine("Try Again !!!");
                    }
                }
               
            }
            if(check == true)
            {
                Console.WriteLine("Successed !!!");
            }
            else
            {
                Console.WriteLine("Cann't find this code: " + code);
            }
        }

        public void DeleteItem()
        {
            Boolean check = false;
            Console.Write("Code: ");
            string code = Console.ReadLine();
            for (int i = 0; i < arrCode.Count; i++)
            {
                if (arrCode[i].Equals(code))
                {
                    arrCode.RemoveAt(i);
                    arrName.RemoveAt(i);
                    arrPrice.RemoveAt(i);
                    check = true;
                }

            }
            if (check == true)
            {
                Console.WriteLine("Successed !!!");
            }
            else
            {
                Console.WriteLine("Cann't find this code: " + code);
            }
        }

        public void Search()
        {
            Boolean check = false;
            Console.Write("Code: ");
            string code = Console.ReadLine();
            for (int i = 0; i < arrCode.Count; i++)
            {
                if (arrCode[i].Equals(code))
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Code: " + arrCode[i]);
                    Console.WriteLine("Name: " + arrName[i]);
                    Console.WriteLine("Price: " + arrPrice[i]);
                    Console.WriteLine("-----------------------");
                    check = true;
                }

            }
            if (check == true)
            {
                Console.WriteLine("Successed !!!");
            }
            else
            {
                Console.WriteLine("Cann't find this code: " + code);
            }
        }
        public void OutList()
        {
            if(arrCode.Count == 0)
            {
                Console.WriteLine("List is empty !!!");
            }
            else 
            {
                SortArr();
                for(int i = 0; i < arr.Count; i++)
                {
                    int j = (int)arr[i];
                    Console.WriteLine(arrCode[j] + " - " + arrName[j]  + " - " + arrPrice[j]);
                }
                arr.Clear();
            }
            
        }

        public void SortArr()
        {
            sort_price = demo_arrPrice;
            sort_price.Sort();
            for (int i = 0; i < sort_price.Count; i++)
            {
                for (int j = 0; j < arrPrice.Count; j++)
                {
                    if (sort_price[i].Equals(arrPrice[j]))
                    {
                        arr.Add(j);
                    }
                }
            }
        }
        public Boolean CheckCode(string code)
        {
            if (arrCode.Contains(code))
            {
                Console.WriteLine("Code is exist !!!");
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
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