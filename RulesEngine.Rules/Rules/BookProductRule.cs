using RulesEngine.Core;
using RulesEngine.Core.Domain;
using System;

namespace RulesEngine.Rules
{
    public class BookProductRule : IRule
    {
        public string Apply()
        {
            return "Creating a duplicate packing slip for the royalty department";
        }

        public bool IsApplicable(Product product)
        {
            return product.Type == ProductType.Book;
        }
    }
}
