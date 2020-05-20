using RulesEngine.Core;
using RulesEngine.Core.Domain;

namespace RulesEngine.Rules.Rules
{
    public class MembershipProductRule : IRule
    {
        public string Apply()
        {
            return "Activating membership";
        }

        public bool IsApplicable(Product product)
        {
            return product.Type == ProductType.Membership;
        }
    }
}
