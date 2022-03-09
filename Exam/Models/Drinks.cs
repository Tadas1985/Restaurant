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
            Amount = amount;
        }
        public Drinks(){}
        public Drinks(string rawData)
        {
            string[] data = rawData.Split(',');
            this.ID = int.Parse(data[0]);
            this.Name = data[1];
            this.Amount = int.Parse(data[2]);
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public int Amount { get; }

        public static List<Drinks> listOfAllDrinks;

        public static void ReadDrinksFromCSVFile(string fileName)
        {
            listOfAllDrinks = new List<Drinks>();
            string[] drinksCSVLines = File.ReadAllLines(fileName);
            for (int i = 1; i < listOfAllDrinks.Count; i++)
            {
                var d = new Drinks(drinksCSVLines[i]);


                listOfAllDrinks.Add(d);
            }
        }
        public static void PrintDrinksMenu()
        {
            for (int i = 0; i < listOfAllDrinks.Count; i++)
            {
                Console.WriteLine(listOfAllDrinks[i].Name + " [" + i + "]");

            }
            //Console.WriteLine($"Back to main menu [{listOfAllDrinks.Count}]");

        }
    }
}
