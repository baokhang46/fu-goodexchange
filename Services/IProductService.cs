
using BussinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<int> CreateProductAsync(Product product);
        Task<string> UpdateProductAsync(Product product);
        Task<string>DeleteProductAsync(int id);
    }
}
