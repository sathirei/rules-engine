using RulesEngine.Core;
using RulesEngine.Core.Domain;

namespace RulesEngine.Rules.Rules
{
    public class VideoProductRule : IRule
    {
        public string Apply()
        {
            return "Adding a free \"First Aid\" video to the packing slip (the result of a court decision in 1997)";
        }

        public bool IsApplicable(Product product)
        {
            return product.Type == ProductType.Video && product.Name == "Learning to Ski";
        }
    }
}
