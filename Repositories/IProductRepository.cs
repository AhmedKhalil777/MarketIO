using MarketIO.MVC.Domain;
using System.Collections.Generic;

namespace MarketIO.MVC.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Products> AllProducts { get; }
        //IEnumerable<Products> ProductsOfTheWeek { get; }
        Products GetPieById(int productId);
        void CreatePie(Products product);
        void UpdatePie(Products product);
    }
}