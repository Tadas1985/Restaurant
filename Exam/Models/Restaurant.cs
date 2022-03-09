using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    // Testing improvements branch1
    public class Restaurant
    {
        public static string filesDir = @"C:\Users\tadas.valutis\Desktop\CodeAcademy\C# Advanced exam\CSVfiles\";
        public Restaurant() 
        {
            tables = new List<Table>() { new Table(1,2), new Table(2,4), new Table(3,6)};
        }
        public List<Table> tables;
        public static int readInt()
        {
            return int.Parse(Console.ReadLine());
        }
        public int SystemMenuOptions()
        {
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("What actions would you like to perform:");
            Console.WriteLine("Select an option:");
            Console.WriteLine("Check table availability [1] \nBook table [2] \nFree table [3] \nOrder food [4] \nOrder Drinks [5] \nPayments [6] \n\nExit menu [7]");
            

            var optionSelected = readInt();
            return optionSelected;
        }

        public void PrintTables()
        {
            foreach (var item in tables)
            {
                var availability = item.IsFree() ? "Free" : "Busy";
                Console.WriteLine($" Table Number {item.TableID}, Table seats {item.Seats}, {availability}");
            }
        }
        public void BookTable()
        {
            Console.WriteLine("Which table would you like to book?");
            var tableID = readInt();
            var table = FindTableByID(tableID); 
            table.CreateNewOrder();
        }
        public void FreeTable()
        {
            Console.WriteLine("What table would you like to free?");
            var tableID = readInt();
            var table = FindTableByID(tableID);
            table.FreeTable();
        }
        public void OrderFood()
        {
            Console.WriteLine("Which table are you serving?");
            var servingTableID = readInt();
            var servingTable = FindTableByID(servingTableID); 
            while (true) 
            {
                Food.PrintMenu();
                
                Console.WriteLine("What kind of measl would you like to order");
                var foodChoice = readInt();
                if (foodChoice == Food.listOfAllFoods.Count)
                {   
                    return;
                }
                Console.WriteLine($"How many item {Food.listOfAllFoods[foodChoice].Name} would you like to order?");
                var amountOfFoodItems = readInt();
                servingTable.order.AddFood(foodChoice, amountOfFoodItems);
            }
            
           
            
            
        }
        public void OrderDrinks()
        {
            Console.WriteLine("Which table are you serving?");
            var servingTableID = readInt();
            var servingTable = FindTableByID(servingTableID);
            while (true)
            {
                Drinks.PrintDrinksMenu();

                Console.WriteLine("What kind of drink would you like to order");
                var foodChoice = readInt();
                if (foodChoice == Drinks.listOfAllDrinks.Count)
                {
                    return;
                }
                Console.WriteLine($"How many item {Drinks.listOfAllDrinks[foodChoice].Name} would you like to order?");
                var amountOfFoodItems = readInt();
                servingTable.order.AddFood(foodChoice, amountOfFoodItems);
            }




        }
        public void Payments()
        { 
        }
        public void Exit()
        {
            System.Environment.Exit(0);
        }

        public Table FindTableByID(int id)
        {
            foreach (var table in tables)
            {
                if (table.TableID == id)
                {
                    
                    return table;   
                }
            }
            return null;
        }
    }
}
