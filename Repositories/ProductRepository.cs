using System.Collections.Generic;
using System.Threading.Tasks;
using BussinessObject.Model;
using DataAccessLayer;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product product)
        {
            ProductDAO.CreateProduct(product);
        }

        public List<Product> GetAllProduct()
        {
            return ProductDAO.GetAllProducts();
        }

        public Product GetProductById(int productId)
        {
            return ProductDAO.GetProductById(productId);
        }

        public void UpdateProduct(Product product)
        {
            ProductDAO.UpdateProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            ProductDAO.DeleteProduct(productId);
        }
    }
}
