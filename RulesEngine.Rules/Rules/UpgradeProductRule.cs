using RulesEngine.Core;
using RulesEngine.Core.Domain;
using System;

namespace RulesEngine.Rules.Rules
{
    public class UpgradeProductRule : IRule
    {
        public string Apply()
        {
            Console.WriteLine($"Applying {nameof(UpgradeProductRule)}");
            return "Applying the upgrade";
        }

        public bool IsApplicable(Product product)
        {
            return product.Type == ProductType.Upgrade;
        }
    }
}
