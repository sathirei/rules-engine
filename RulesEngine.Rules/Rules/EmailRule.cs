using RulesEngine.Core;
using RulesEngine.Core.Domain;

namespace RulesEngine.Rules.Rules
{
    public class EmailRule : IRule
    {
        public string Apply()
        {
            return "Sending email to the owner for activation/upgrade";
        }

        public bool IsApplicable(Product product)
        {
            return product.Type == ProductType.Membership || product.Type == ProductType.Upgrade;
        }
    }
}
