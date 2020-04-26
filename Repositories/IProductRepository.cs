using MarketIO.MVC.Domain;
using System.Collections.Generic;

namespace MarketIO.MVC.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Products> AllProducts { get; }
        Products GetProductById(int id);
        IEnumerable<Products> ProductsOfTheWeek { get; }
        Products DeleteProduct(int productId);
        void CreateProduct(Products product);
        void UpdateProduct(Products product);
    }
}