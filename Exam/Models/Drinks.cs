using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Drinks
    {
        public Drinks(int iD, string name, int amount)
        {
            ID = iD;
            Name = name;
            Price = amount;
        }
        public Drinks(){}
        public Drinks(string rawData)
        {
            string[] data = rawData.Split(',');
            this.ID = int.Parse(data[0]);
            this.Name = data[1];
            this.Price = int.Parse(data[2]);
        }

      

        public static List<Drinks> ListOfAllDrinks;
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; }
        public static void ReadFromCSV(string fileName)
        {
            ListOfAllDrinks = new List<Drinks>();
            string[] drinksCSVLines = File.ReadAllLines(fileName);

            for (int i = 1; i < drinksCSVLines.Length; i++)
            {
                var d = new Drinks(drinksCSVLines[i]);


                ListOfAllDrinks.Add(d);
            }
        }

        public static void PrintDrinksMenu()
        {
            for (int i = 0; i < ListOfAllDrinks.Count; i++)
            {
                Console.WriteLine(ListOfAllDrinks[i].Name + " [" + i + "]");

            }
            Console.WriteLine($"Back to main menu [{ListOfAllDrinks.Count}]");
        }
    }
}
