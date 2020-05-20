using RulesEngine.Core;
using System;

namespace RulesEngine.Rules.Rules
{
    public class CommissionRule : IRule
    {
        public string Apply()
        {
            Console.WriteLine($"Applying {nameof(CommissionRule)}");
            return "Generating commision payment to the agent";
        }

        public bool IsApplicable(Product product)
        {
            return product.Attribute == Core.Domain.ProductAttribute.PHYSICAL;
        }
    }
}
