using RulesEngine.Core;
using System.Collections.Generic;

namespace RulesEngine.Rules
{
    public interface IBussinessRuleEngine
    {
        public HashSet<IRule> Rules { get; }
        public IBussinessRuleEngine AddRule(IRule rule);

        public IBussinessRuleEngine RemoveRule(IRule rule);
        List<string> Process(Order order);
    }
}