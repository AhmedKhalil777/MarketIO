using MarketIO.DAL.Data;
using MarketIO.DAL.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketIO.BLL.Repositories
{
    public class ShoppingCart
    {
        private readonly MarketIODbContext _appDbContext;

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(MarketIODbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<MarketIODbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Products product, int amount = 1)
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems
                .FirstOrDefault(c => c.Product.Product_Id == product.Product_Id&& c.ShoppingCartId.ToString() == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    Product = product,
                    ShoppingCartId =Guid.Parse(ShoppingCartId),
                    Amount = amount
                };
                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Products product)
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Product.Product_Id== product.Product_Id&& s.ShoppingCartId.ToString() == ShoppingCartId);
            int localAmount = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _appDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                  (ShoppingCartItems =
                      _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId.ToString() == ShoppingCartId)
                          .Include(s => s.Product)
                          .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId.ToString() == ShoppingCartId);
            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _appDbContext.SaveChanges();
        }
        public decimal GetTotal()
        {
            var total = _appDbContext.ShoppingCartItems.Where(s => s.ShoppingCartId.ToString() == ShoppingCartId)
                            .Select(p => p.Amount * p.Product.Price).Sum();
            return total;
        }
    }
}
