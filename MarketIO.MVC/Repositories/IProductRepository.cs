using MarketIO.DAL.Domain;
using MarketIO.MVC.ResourceParameters;
using System.Collections.Generic;

namespace MarketIO.MVC.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Products> AllProducts { get; }
        IEnumerable<Products> GetProducts(ProductResourceParameters productResourceParameters);
        Products GetProductById(int id);
        IEnumerable<Products> ProductsOfTheWeek { get; }
        Products DeleteProduct(int productId);
        void CreateProduct(Products product);
        void UpdateProduct(Products product);
    }
}