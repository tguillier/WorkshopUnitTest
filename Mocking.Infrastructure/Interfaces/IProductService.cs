using Mocking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mocking.Domain.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> ListAllProductsUnderPrice(decimal price);
        Product CreateProduct(Product product);
    }
}
