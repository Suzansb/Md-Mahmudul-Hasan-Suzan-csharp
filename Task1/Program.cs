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



