using RulesEngine.Core;
using System;

namespace RulesEngine.Rules
{
    public interface IRule
    {
        public string Apply();

        public Boolean IsApplicable(Product product);
    }
}
