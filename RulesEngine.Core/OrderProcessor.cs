using System;

namespace RulesEngine.Core
{
    public class OrderProcessor
    {
        public OrderProcessor(Agent agent)
        {
            this.Order = new Order(Guid.NewGuid(), agent);
        }
        public Order Order { get; private set; }
        public void Add(OrderLine orderLine)
        {
            this.Order.Add(orderLine);
        }
    }
}
