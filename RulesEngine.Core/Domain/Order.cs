using System;
using System.Collections.Generic;

namespace RulesEngine.Core
{
    public class Order
    {
        public Order(Guid orderId, Agent agent)
        {
            this.OrderId = orderId;
            this.Agent = agent;
            this.OrderLines = new List<OrderLine>();
        }

        public Guid OrderId { get; }
        public Agent Agent { get; private set; }
        public List<OrderLine> OrderLines { get; private set; }

        internal void Add(OrderLine orderLine)
        {
            var line = this.OrderLines.Find(x => x.Product.Id == orderLine.Product.Id);

            if (line != null)
            {
                line.AddQuantity(orderLine.Quantity);
            }
            else
            {
                this.OrderLines.Add(orderLine);
            }

        }
    }
}
