using RulesEngine.Core;
using RulesEngine.Core.Domain;
using System;

namespace RulesEngine.Rules.Rules
{
    public class MembershipProductRule : IRule
    {
        public string Apply()
        {
            Console.WriteLine($"Applying {nameof(MembershipProductRule)}");
            return "Activating membership";
        }

        public bool IsApplicable(Product product)
        {
            return product.Type == ProductType.Membership;
        }
    }
}
