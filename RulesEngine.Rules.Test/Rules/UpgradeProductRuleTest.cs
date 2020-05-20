using FluentAssertions;
using RulesEngine.Core;
using RulesEngine.Core.Domain;
using RulesEngine.Rules.Rules;
using Xunit;

namespace RulesEngine.Rules.Test.Rules
{
    public class UpgradeProductRuleTest
    {
        [Fact]
        public void IsApplication_Should_Return_True_For_Upgrade_Product()
        {
            var rule = new UpgradeProductRule();
            var product = new Product { Type = ProductType.Upgrade };

            rule.IsApplicable(product).Should().BeTrue();
            rule.Apply().Should().Be("Applying the upgrade");

        }

        [Fact]
        public void IsApplication_Should_Return_False_For_Other_Product()
        {
            var rule = new UpgradeProductRule();
            var product = new Product { Type = ProductType.Membership };

            rule.IsApplicable(product).Should().BeFalse();
        }
    }
}
