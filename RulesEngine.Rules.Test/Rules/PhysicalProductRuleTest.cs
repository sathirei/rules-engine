using FluentAssertions;
using RulesEngine.Core;
using RulesEngine.Core.Domain;
using Xunit;

namespace RulesEngine.Rules.Test.Rules
{
    public class PhysicalProductRuleTest
    {
        [Fact]
        public void IsApplication_Should_Return_True_For_Physical_Product()
        {
            var rule = new PhysicalProductRule();
            var product = new Product { Attribute = ProductAttribute.PHYSICAL };

            rule.IsApplicable(product).Should().BeTrue();
            rule.Apply().Should().Be("Generating a packing slip for shipping.");

        }

        [Fact]
        public void IsApplication_Should_Return_False_For_NonPhysical_Product()
        {
            var rule = new PhysicalProductRule();
            var product = new Product { Attribute = ProductAttribute.NONPHYSICAL };

            rule.IsApplicable(product).Should().BeFalse();
        }
    }
}
