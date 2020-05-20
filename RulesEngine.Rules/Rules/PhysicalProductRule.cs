using RulesEngine.Core;
using System;

namespace RulesEngine.Rules
{
    public class PhysicalProductRule : IRule
    {

        public string Apply()
        {
            Console.WriteLine($"Applying {nameof(PhysicalProductRule)}");
            return "Generating a packing slip for shipping.";
        }

        public bool IsApplicable(Product product)
        {
            return product.Attribute == Core.Domain.ProductAttribute.PHYSICAL;
        }
    }
}
