using Azure.Core;
using BussinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CartDAO
    {
        public static List<Cart> GetCarts()
        {
            var listCarts = new List<Cart>();
            try
            {
                using var db = new FugoodexchangeContext();
                listCarts = db.Carts.ToList();
            }
            catch (Exception e)
            {

            }
            return listCarts;
        }

        public static void CreateCart(Cart cart)
        {
            try
            {
                using var context = new FugoodexchangeContext();
                context.Carts.Add(cart);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateCart(Cart cart)
        {
            try
            {
                using var context = new FugoodexchangeContext();
                context.Entry<Cart>(cart).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteCart(Cart cart)
        {
            try
            {
                using var context = new FugoodexchangeContext();
                var a = context.Carts.SingleOrDefault(c => c.CartId == cart.CartId);
                context.Carts.Remove(a);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static Cart GetCartByUserId(int UserId)
        {
            using var db = new FugoodexchangeContext();
            return db.Carts.FirstOrDefault(c => c.UserId.Equals(UserId));
        }
    }
}
