namespace Mocking.Domain.Entities
{
    public class Product : BaseEntity
    {
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}