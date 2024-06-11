
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repositories;
using BussinessObject.Model;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;

        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo ?? throw new ArgumentNullException(nameof(productRepo));
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            try
            {
                return await _productRepo.GetAllProduct();
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Failed to retrieve products: {ex.Message}", ex);
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                return await _productRepo.GetProductById(id);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Failed to retrieve product: {ex.Message}", ex);
            }
        }

        public async Task<int> CreateProductAsync(Product product)
        {
            try
            {
                await _productRepo.AddProduct(product);
                return product.ProductId; 
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Failed to create product: {ex.Message}", ex);
            }
        }

        public async Task<string> UpdateProductAsync(Product product)
        {
            try
            {
                await _productRepo.UpdateProduct(product);
                return "Product updated successfully";
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Failed to update product: {ex.Message}", ex);
            }
        }

        public async Task<string> DeleteProductAsync(int id)
        {
            try
            {
                await _productRepo.DeleteProduct(id);
                return "Product deleted successfully";
            }
            catch (Exception ex)
            {
                // Log the exception
                throw new Exception($"Failed to delete product: {ex.Message}", ex);
            }
        }
    }
}
