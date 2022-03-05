using System;
using System.Collections.Generic;
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
    }
}
