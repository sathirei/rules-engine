using System;

namespace RulesEngine.Core
{
    public class OrderLine
    {
        private Guid id = Guid.NewGuid();

        public Guid Id { get { return id; } }
        public OrderLine(Product product, int quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
        }

        public int Quantity { get; private set; }

        public void AddQuantity(int quantity)
        {
            this.Quantity += quantity;
        }
        public Product Product { get; private set; }
    }
}
