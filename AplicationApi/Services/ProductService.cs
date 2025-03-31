using AplicationApi.Models;

namespace AplicationApi.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new();

        public IEnumerable<Product> GetAll() => _products;

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public Product Create(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
            return product;
        }

        public bool Update(int id, Product updatedData)
        {
            var existing = _products.FirstOrDefault(p => p.Id == id);
            if (existing == null) return false;

            existing.NameProduct = updatedData.NameProduct;
            existing.DescriptionProduct = updatedData.DescriptionProduct;
            existing.PriceProduct  = updatedData.PriceProduct;
            existing.StockProduct = updatedData.StockProduct;
            return true;
        }

        public bool Delete(int id)
        {
            var product = GetById(id);
            if (product == null) return false;

            _products.Remove(product);
            return true;
        }
    }
}
