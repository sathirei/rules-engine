using RulesEngine.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RulesEngine.Rules
{
    public class BusinessRuleEngine : IBussinessRuleEngine
    {
        public HashSet<IRule> Rules { get; } = new HashSet<IRule>();

        List<string> IBussinessRuleEngine.Process(Order order)
        {
            var result = new List<string>();
            foreach (var line in order.OrderLines)
            {
                Console.WriteLine($"Processing for OrderLineId {line.Id}");
                Rules.Where(x => x.IsApplicable(line.Product)).ToList().ForEach(x => result.Add(x.Apply()));
                Console.WriteLine("Processing Completed!");
            }

            return result;
        }

        IBussinessRuleEngine IBussinessRuleEngine.AddRule(IRule rule)
        {
            this.Rules.Add(rule);
            return this;
        }

        IBussinessRuleEngine IBussinessRuleEngine.RemoveRule(IRule rule)
        {
            this.Rules.Remove(rule);
            return this;
        }
    }
}
