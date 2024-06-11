using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BussinessObject.Model;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        private readonly FugoodExchangeContext _context;
        private readonly ILogger<ProductDAO> _logger;

        public ProductDAO(FugoodExchangeContext context, ILogger<ProductDAO> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Create
        public async Task AddProductAsync(Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding product");
                throw;
            }
        }

        // Read
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            try
            {
                return await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching product by ID");
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            try
            {
                return await _context.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all products");
                throw;
            }
        }

        // Update
        public async Task UpdateProductAsync(Product product)
        {
            try
            {
                var existingProduct = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == product.ProductId);
                if (existingProduct != null)
                {
                    existingProduct.Description = product.Description;
                    existingProduct.Price = product.Price;
                    existingProduct.Quantity = product.Quantity;
                    existingProduct.CategoryId = product.CategoryId;
                    existingProduct.DatePosted = product.DatePosted;
                    existingProduct.Status = product.Status;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating product");
                throw;
            }
        }

        // Delete
        public async Task DeleteProductAsync(int id)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting product");
                throw;
            }
        }
    }
}
