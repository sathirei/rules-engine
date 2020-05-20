using FluentAssertions;
using RulesEngine.Core;
using RulesEngine.Core.Domain;
using RulesEngine.Rules.Rules;
using Xunit;

namespace RulesEngine.Rules.Test.Rules
{
    public class CommisionRuleTest
    {
        [Fact]
        public void IsApplication_Should_Return_True_For_Video_Product_Learning_to_Ski()
        {
            var rule = new CommissionRule();
            var product = new Product { Attribute = ProductAttribute.PHYSICAL };

            rule.IsApplicable(product).Should().BeTrue();
            rule.Apply().Should().Be("Generating commision payment to the agent");

        }

        [Fact]
        public void IsApplication_Should_Return_False_For_Other_Product()
        {
            var rule = new VideoProductRule();
            var product = new Product { Attribute = ProductAttribute.NONPHYSICAL };

            rule.IsApplicable(product).Should().BeFalse();
        }
    }
}
