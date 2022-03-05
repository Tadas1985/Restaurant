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
            // Get raw CSV data
            
            //string[] drinksCSVLines = File.ReadAllLines(csvDir + "Drinks.csv");
            //string[] tablesCSVLines = File.ReadAllLines(csvDir + "Tables.csv");

          
         

            Food.ReadFromCSV(Models.Restaurant.filesDir + "Food.csv");


            // Put data in to the food object list
  
     

            // Put data in to the drinks object list
            //var drinks = new List<Drinks>();
            //for (int i = 1; i < drinksCSVLines.Length; i++)
            //{
            //    Drinks d = new Drinks(drinksCSVLines[i]);
            //    drinks.Add(d);                
            //}

            //// Put data in to the tables object list
            //var tables = new List<Tables>();
            //for (int i = 1; i < tablesCSVLines.Length; i++)
            //{
            //    Tables t = new Tables(tablesCSVLines[i]) ;
            //    tables.Add(t);
            //}           


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
