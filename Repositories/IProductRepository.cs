using BussinessObject.Model;

namespace Repositories
{
    public interface IProductRepository
    {
        Product GetProductById(int id);
        List<Product> GetAllProduct();
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}