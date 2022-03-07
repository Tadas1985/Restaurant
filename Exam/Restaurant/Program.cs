using Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Restaurant
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            Models.Restaurant menu = new Models.Restaurant();
            Food.ReadFromCSV(Models.Restaurant.filesDir + "Food.csv");
            Console.WriteLine("Welcome to a restaurant management system");
           
            while (true)
            {               
                switch (menu.SystemMenuOptions())
                {
                    case 1:
                        menu.PrintTables();
                        break;
                    case 2:
                        menu.BookTable();
                        break;
                    case 3:
                        menu.FreeTable();
                        break;
                    case 4:
                        menu.OrderFood();
                        break;
                    case 5:
                        menu.Payments();
                        break;
                    case 6:
                        menu.Exit();
                        break;
                }
                
            }
        }
    }
}
