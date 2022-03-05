using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public struct OrderItem
    {
        public int Id;
       
        public int Amount;

        public OrderItem(int id, int amount)
        {
            this.Id = id;
          
            this.Amount = amount;
        }
    }






    public class Order
    {
        public int TableId;

        List<OrderItem> foodList; 
        public Order(int tableID= 1)
        {
            TableId = tableID;  
            foodList = new List<OrderItem>();
        }

        public void AddFood(int foodID, int amount)
        {
            foodList.Add(new OrderItem(foodID, amount));
        }

        public void Print()
        {
            string receipt = $"\n\n\n           Your receipt: \nTable ID {TableId}\n {DateTime.Now} \n";
            
            decimal totalOrderPrice = 0;
            foreach (OrderItem item in foodList)
            {
                var foodItem = Food.listOfAllFoods[item.Id];
                decimal totalItemPrice = item.Amount * foodItem.Price;
                receipt += $"{foodItem.Name}, {item.Amount} X {foodItem.Price} Eur.        {totalItemPrice} Eur.\n";

                totalOrderPrice += totalItemPrice;

            }
            receipt += $"Total Price: {totalOrderPrice} Eur. \n";
            Console.WriteLine(receipt);

            WriteRestaurantReceiptToFile(receipt);
            Console.WriteLine("Would you like to get a receipt?\nYes [1] \nNo [2]");
            var answer = Restaurant.readInt();
            if (answer == 1)
            {
                WriteCustomerReceiptToFile(receipt);
            }
            Console.WriteLine("Please enter you email if you want to receive (leave blank if not)");
            var email = Console.ReadLine();
            if (email != "")
            {
                
                SendCustomerReceiptToEmail(receipt, email);
            }
        }
        public void WriteRestaurantReceiptToFile( string receipt)
        {

            File.AppendAllText(Restaurant.filesDir + "RestaurantReceipt.txt", receipt);
        }
        public void WriteCustomerReceiptToFile( string receipt)
        {
            File.AppendAllText(Restaurant.filesDir + "CustomerReceipt.txt", receipt);
        }
        public void SendCustomerReceiptToEmail( string receipt, string email)
        {
            Console.WriteLine($"Sending email to {email}");
        }
    }
}
