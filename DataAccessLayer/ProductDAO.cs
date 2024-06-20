
using BussinessObject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        public static Product GetProductById(int productId)
        {
            try
            {
                using var db = new FugoodexchangeContext();
                return db.Products
                         .Include(p => p.Category)
                         .Include(p => p.Seller)
                         .FirstOrDefault(p => p.ProductId == productId);
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while retrieving product with ID {productId}.", e);
            }
        }


        public static List<Product> GetAllProducts()
        {
            try
            {
                using var db = new FugoodexchangeContext();
                return db.Products
                         .Include(p => p.Category)
                         .Include(p => p.Seller)
                         .ThenInclude(s => s.User)
                         .ToList();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while retrieving products.", e);
            }
        }

        public static void CreateProduct(Product product)
        {
            try
            {
                using var context = new FugoodexchangeContext();
                context.Products.Add(product);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while creating the product.", e);
            }
        }

        public static void UpdateProduct(Product product)
        {
            try
            {
                using var context = new FugoodexchangeContext();
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while updating the product.", e);
            }
        }

        public static void DeleteProduct(int productId)
        {
            try
            {
                using var context = new FugoodexchangeContext();
                var product = context.Products.SingleOrDefault(p => p.ProductId == productId);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while deleting the product.", e);
            }
        }
    }
}
