using Mocking.Domain.Entities;
using Mocking.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Mocking.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> ListAllProductsUnderPrice(decimal price)
        {
            return productRepository.ListAll().Where(product => product.Price < price);
        }

        public Product CreateProduct(Product product)
        {
            // Some business logic...

            return productRepository.Add(product);
        }
    }
}
