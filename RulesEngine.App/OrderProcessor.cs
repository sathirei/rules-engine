using RulesEngine.Rules;
using System;
using System.Collections.Generic;

namespace RulesEngine.Core
{
    public class OrderProcessor
    {
        private IBussinessRuleEngine bussinessRuleEngine;

        public OrderProcessor(IBussinessRuleEngine bussinessRuleEngine, Agent agent)
        {            
            this.Order = new Order(Guid.NewGuid(), agent);
            this.bussinessRuleEngine = bussinessRuleEngine;

        }
        public Order Order { get; private set; }
        public OrderProcessor Add(OrderLine orderLine)
        {
            this.Order.Add(orderLine);
            return this;
        }

        public List<string> Process()
        {
            Console.WriteLine($"Order processing for Agent {this.Order.Agent.Name}");
            return this.bussinessRuleEngine.Process(this.Order);
        }
    }
}
