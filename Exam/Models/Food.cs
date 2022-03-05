using System;
using System.Collections.Generic;
using System.IO;

namespace Models
{
    public class Food
    {
        public Food(int iD, string name, decimal price)
        {
            ID = iD;
            Name = name;
            Price = price;
        }
        public Food() { }
        public Food(string rawData)
        {
            string[] data = rawData.Split(',');
            this.ID = int.Parse(data[0]);
            this.Name = data[1];
            this.Price = int.Parse(data[2]);
            
        }
        public static List<Food> listOfAllFoods;

        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; }

        public static void ReadFromCSV( string fileName)
        {
            listOfAllFoods = new List<Food>();  
            string[] foodCSVLines = File.ReadAllLines(fileName);

            for (int i = 1; i < foodCSVLines.Length; i++)
            {
                var f = new Food(foodCSVLines[i]);


                listOfAllFoods.Add(f);
            }
        }
        public static void PrintMenu()
        {
            for (int i = 0; i < listOfAllFoods.Count; i++)
            {
                Console.WriteLine(listOfAllFoods[i].Name + " [" + i + "]");

            }
            Console.WriteLine($"Back to main menu [{listOfAllFoods.Count}]");

        }
    }
}
