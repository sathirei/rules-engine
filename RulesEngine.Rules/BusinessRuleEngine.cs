using RulesEngine.Core;
using System.Collections.Generic;
using System.Linq;

namespace RulesEngine.Rules
{
    public class BusinessRuleEngine : IBussinessRuleEngine
    {
        public HashSet<IRule> Rules { get; } = new HashSet<IRule>();

        void IBussinessRuleEngine.Process(Order order)
        {
            foreach (var line in order.OrderLines)
            {
                Rules.Where(x => x.IsApplicable(line.Product)).ToList().ForEach(x => x.Apply());
            }
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
