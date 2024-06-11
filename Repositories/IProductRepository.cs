using BussinessObject.Model;

namespace Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetAllProduct();
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}