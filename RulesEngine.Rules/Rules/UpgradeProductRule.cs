using RulesEngine.Core;
using RulesEngine.Core.Domain;

namespace RulesEngine.Rules.Rules
{
    public class UpgradeProductRule : IRule
    {
        public string Apply()
        {
            return "Applying the upgrade";
        }

        public bool IsApplicable(Product product)
        {
            return product.Type == ProductType.Upgrade;
        }
    }
}
