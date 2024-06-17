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
            return _productRepository.GetAllProduct();
            }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            _productRepository.GetProductById(id);
        }

        public async Task<int> CreateProductAsync(Product product)
        {
            _productRepository.AddProduct(product);
            }

        public async Task<string> UpdateProductAsync(Product product)
        {
            _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(int id)
            {
            _productRepository.DeleteProduct(id);
        }
    }
}
