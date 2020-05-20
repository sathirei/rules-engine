using FluentAssertions;
using RulesEngine.Core;
using RulesEngine.Core.Domain;
using RulesEngine.Rules.Rules;
using Xunit;

namespace RulesEngine.Rules.Test.Rules
{
    public class EmailRuleTest
    {
        [Fact]
        public void IsApplication_Should_Return_True_For_Upgrade_Product()
        {
            var rule = new EmailRule();
            var product = new Product { Type = ProductType.Upgrade };

            rule.IsApplicable(product).Should().BeTrue();
            rule.Apply().Should().Be("Sending email to the owner for activation/upgrade");

        }

        [Fact]
        public void IsApplication_Should_Return_True_For_Membership_Product()
        {
            var rule = new EmailRule();
            var product = new Product { Type = ProductType.Membership };

            rule.IsApplicable(product).Should().BeTrue();
            rule.Apply().Should().Be("Sending email to the owner for activation/upgrade");

        }

        [Fact]
        public void IsApplication_Should_Return_False_For_Other_Product()
        {
            var rule = new UpgradeProductRule();
            var product = new Product { Type = ProductType.Video };

            rule.IsApplicable(product).Should().BeFalse();
        }
    }
}
