using Microsoft.EntityFrameworkCore;
using Mocking.Domain.Entities;
using Mocking.Domain.Services;
using Mocking.Infrastructure.Data;
using System.Linq;
using Xunit;

namespace Mocking.UnitTests
{
    public class ProductServiceShould
    {
        private ProductContext productContext;
        private EfRepository<Product> productRepository;
        private ProductService productService;

        public ProductServiceShould()
        {
            var dbOptions = new DbContextOptionsBuilder<ProductContext>()
                .UseInMemoryDatabase("Catalog")
                .Options;

            productContext = new ProductContext(dbOptions);
            productRepository = new EfRepository<Product>(productContext);
            productService = new ProductService(productRepository);
        }

        [Fact]
        public void ListAllProductsUnderPrice()
        {
            // Arrange
            const decimal price = 0.50M;
            productService.CreateProduct(new Product { Price = 0.30M, Description = "Produit 1" });
            productService.CreateProduct(new Product { Price = 0.40M, Description = "Produit 1" });

            // Act
            var results = productService.ListAllProductsUnderPrice(price);

            // Assert
            Assert.Equal(2, results.Count());
        }

        [Fact]
        public void CreateAProduct()
        {
            // Arrange
            Product product = new Product { Price = 0.30M, Description = "Test produit ajouté" };

            // Act
            var newProduct = productService.CreateProduct(product);

            // Assert
            Assert.True(newProduct.Id != 0);
            Assert.Equal(product.Price, newProduct.Price);
            Assert.Equal(product.Description, newProduct.Description);
        }
    }
}
