using AutoFixture.Xunit2;
using Mocking.Domain.Entities;
using Mocking.Domain.Interfaces;
using Mocking.Domain.Services;
using Mocking.UnitTests.Attributes;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Mocking.UnitTests
{
    public class ProductServiceShould_V4
    {
        [Theory]
        [AutoMoqData]
        public void ListAllProductsUnderPrice(
            IEnumerable<Product> productList,
            [Frozen]Mock<IRepository<Product>> productRepositoryMock,
            ProductService productService)
        {
            // Arrange
            const decimal price = 0.50M;            
            productRepositoryMock.Setup(repo => repo.ListAll()).Returns(productList);

            // Act
            var results = productService.ListAllProductsUnderPrice(price);

            // Assert
            Assert.All(results, product => Assert.True(product.Price < price));
        }

        [Theory]
        [AutoMoqData]
        public void CreateAProduct(
            Product product,
            [Frozen]Mock<IRepository<Product>> productRepositoryMock,
            ProductService productService)
        {
            // Act
            productService.CreateProduct(product);

            // Assert
            productRepositoryMock.Verify(repo => repo.Add(It.Is<Product>(p => p.Equals(product))));
        }
    }
}
