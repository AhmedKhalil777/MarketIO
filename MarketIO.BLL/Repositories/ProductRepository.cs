﻿using MarketIO.DAL.Data;
using MarketIO.DAL.Domain;
using MarketIO.DAL.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarketIO.BLL.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly MarketIODbContext _db;
        

        public ProductRepository(MarketIODbContext db)
        {
            _db = db;
        }

        public IEnumerable<Products> AllProducts => _db.Products;
        public IEnumerable<Products> ProductsOfTheWeek => _db.Products.Include(c => c.Brand)
                        .Include(c => c.Category).Where(p => p.IsProductOfTheWeek && p.InStock);


        public IEnumerable<Products> GetProducts(string Category, string Brand, string SearchQuery)
        {
            if (Category == null && Brand ==null && SearchQuery == null )
            {
                throw new ArgumentNullException("Resouce Parmater Error");
            }
            var collection = _db.Products as IQueryable<Products>;
            if (!string.IsNullOrWhiteSpace(Category))
            {
                var mainCategory = Category.Trim();
                collection = collection.Where(a => a.Category.Cat_Name == mainCategory);
            }
            if (!string.IsNullOrWhiteSpace(Brand))
            {
                var mainBrand =Brand.Trim();
                collection = collection.Where(a => a.Brand.Brand_Name == mainBrand);
            }
            if (!string.IsNullOrWhiteSpace(SearchQuery))
            {
                var searchQuery = SearchQuery.Trim();
                collection = collection.Where(c => c.Category.Cat_Name.ToLower().Contains(searchQuery.ToLower())
                || c.Brand.Brand_Name.ToLower().Contains(searchQuery.ToLower())
                || c.P_Name.ToLower().Contains(searchQuery.ToLower()));
            }
            return collection.ToList();
        }


        public void UpdateProduct(Products product)
        {
            var oldProduct = _db.Products.Attach(product);
            oldProduct.State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void CreateProduct(Products product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public Products GetProductById(int productId)
        {
            return _db.Products.FirstOrDefault(p => p.Product_Id == productId);
        }

        public Products DeleteProduct(int productId , string path)
        {
            var deletedProduct = _db.Products.FirstOrDefault(p => p.Product_Id == productId);
            if (deletedProduct.Image!=null)
            {
                string uploadsFolder = Path.Combine(path, "images");
                string filePath = Path.Combine(uploadsFolder, deletedProduct.Image);
                File.Delete(filePath);
            }
            _db.Products.Remove(deletedProduct);
            _db.SaveChanges();
            return deletedProduct;
        }
    }
}
