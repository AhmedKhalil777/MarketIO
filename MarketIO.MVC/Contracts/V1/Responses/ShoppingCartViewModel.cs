using MarketIO.BLL.Repositories;

namespace MarketIO.MVC.Contracts.V1.Responses
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }

    }
}
