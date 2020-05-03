using MarketIO.MVC.Domain;

namespace MarketIO.MVC.Repositories
{
    public interface IOrderRepository
    {
        void CreateOrder(Orders order);
    }
}