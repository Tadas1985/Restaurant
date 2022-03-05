using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Table
    {
        public Order order;
        public Table(int tableID, int seats )
        {
            TableID = tableID;
         
            Seats = seats;

            order = null;
        }

       
        public int TableID { get; }
      
        public int Seats { get; set; }

        public bool IsFree()
        {
            return order == null;
        }
        public void CreateNewOrder()
        {
             order = new Order();  
        }

        public void FreeTable()
        {
            order.Print();
            order = null;
        }

    }
}
