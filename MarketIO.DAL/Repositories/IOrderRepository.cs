using MarketIO.DAL.Domain;


namespace MarketIO.DAL.Repositories
{
    public interface IOrderRepository
    {
        void CreateOrder(Orders order);
    }
}