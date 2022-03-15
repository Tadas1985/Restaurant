using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
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
        //public void AddDrinks(int foodID, int amount)
        //{
        //    drinkList.Add(new OrderItem(foodID, amount));
        //}

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

                SendEmail(receipt, email);
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
        public void SendEmail(string receipt, string email)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("rasa@nauckunas.lt");
                mail.To.Add(email);
                mail.Subject = "Receipt";
                //mail.Attachments(receipt);
                mail.Body = "<h1>Your receipt</h1>";
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(@"C:\Users\tadas.valutis\Desktop\CodeAcademy\C# Advanced exam\CSVfiles\CustomerReceipt.txt");
                mail.Attachments.Add(attachment);

                
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new System.Net.NetworkCredential("rasa@nauckunas.lt", "morka?ryza14");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    //testc.testing123@gmail.com
                }
            }
        }
    }
}
