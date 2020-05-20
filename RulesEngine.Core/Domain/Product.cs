using RulesEngine.Core.Domain;

namespace RulesEngine.Core
{
    public class Product
    {
        public int Id { get; set; }
        public ProductAttribute Attribute { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Type { get; set; }

    }
}