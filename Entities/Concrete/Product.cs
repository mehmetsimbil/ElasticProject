using Core.Entities;


namespace Entities.Concrete
{
    public class Product : Entity<int>
    {
        public string ProductName { get; set; }
        public string ErpCode { get; set; }
        public Brand? Brand { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
    }
}
