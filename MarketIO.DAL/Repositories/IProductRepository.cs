using MarketIO.DAL.Domain;
using System.Collections.Generic;

namespace MarketIO.DAL.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Products> AllProducts { get; }
        IEnumerable<Products> GetProducts(string Catagory , string Brand , string SearchQuery);
        Products GetProductById(int id);
        IEnumerable<Products> ProductsOfTheWeek { get; }
        Products DeleteProduct(int productId , string path);
        void CreateProduct(Products product);
        void UpdateProduct(Products product);
    }
}