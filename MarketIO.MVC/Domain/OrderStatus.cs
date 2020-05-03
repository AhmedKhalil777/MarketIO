namespace MarketIO.MVC.Domain
{
    public enum OrderStatus
    {
        // If the Market accept to make the quote 
        Accepted = 0,
        // Explain if their are some issues 
        Issue = 1,
        // Explain if the order is recieved to customer
        Recieved = 2,
        // Explain if the Order is out from the store and shipped to the customer
        Shipped =4 
    }
}
