namespace RulesEngine.Core
{
    public class OrderLine
    {
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
