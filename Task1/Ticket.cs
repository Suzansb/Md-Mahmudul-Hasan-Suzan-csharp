using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public struct Ticket
    {
        public int TicketNumber { get; }
        public int Price { get; }

        public Ticket(int ticketNumber, int price)
        {
            TicketNumber = ticketNumber;
            Price = price;
        }
    }
}
