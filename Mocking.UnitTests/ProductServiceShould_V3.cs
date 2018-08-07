using AutoFixture;
using AutoFixture.AutoMoq;
using Mocking.Domain.Entities;
using Mocking.Domain.Interfaces;
using Mocking.Domain.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Mocking.UnitTests
{
    public class ProductServiceShould_V3
    {
        [Fact]
        public void ListAllProductsUnderPrice()
        {
            // Arrange
            const decimal price = 0.50M;

            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var productList = fixture.Create<List<Product>>();

            var productRepositoryMock = fixture.Freeze<Mock<IRepository<Product>>>();
            productRepositoryMock.Setup(repo => repo.ListAll()).Returns(productList);

            var productService = fixture.Create<ProductService>();

            // Act
            var results = productService.ListAllProductsUnderPrice(price);

            // Assert
            Assert.All(results, product => Assert.True(product.Price < price));
        }

        [Fact]
        public void CreateAProduct()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var product = fixture.Create<Product>();

            var productRepositoryMock = fixture.Freeze<Mock<IRepository<Product>>>();

            var productService = fixture.Create<ProductService>();

            // Act
            productService.CreateProduct(product);

            // Assert
            productRepositoryMock.Verify(repo => repo.Add(It.Is<Product>(p => p.Equals(product))));
        }
    }
}
