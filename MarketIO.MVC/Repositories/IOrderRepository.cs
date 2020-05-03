using MarketIO.DAL.Domain;


namespace MarketIO.MVC.Repositories
{
    public interface IOrderRepository
    {
        void CreateOrder(Orders order);
    }
}