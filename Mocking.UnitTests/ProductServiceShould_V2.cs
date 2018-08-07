using Mocking.Domain.Entities;
using Mocking.Domain.Interfaces;
using Mocking.Domain.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Mocking.UnitTests
{
    public class ProductServiceShould_V2
    {
        [Fact]
        public void ListAllProductsUnderPrice()
        {
            // Arrange
            const decimal price = 0.50M;
            var productList = new List<Product>
            {
                new Product { Price = 0.30M },
                new Product { Price = 0.30M },
                new Product { Price = price }
            };

            var productRepositoryMock = new Mock<IRepository<Product>>();
            productRepositoryMock.Setup(repo => repo.ListAll()).Returns(productList);

            var productService = new ProductService(productRepositoryMock.Object);

            // Act
            var results = productService.ListAllProductsUnderPrice(price);

            // Assert
            Assert.Equal(productList.Count(p => p.Price < price), results.Count());
        }

        [Fact]
        public void CreateAProduct()
        {
            // Arrange
            var product = new Product { Price = 0.30M, Description = "Test produit ajouté" };

            var productRepositoryMock = new Mock<IRepository<Product>>();

            var productService = new ProductService(productRepositoryMock.Object);

            // Act
            productService.CreateProduct(product);

            // Assert
            productRepositoryMock.Verify(repo => repo.Add(It.Is<Product>(p => p.Equals(product))));
            // Assert logic here...
        }
    }
}
