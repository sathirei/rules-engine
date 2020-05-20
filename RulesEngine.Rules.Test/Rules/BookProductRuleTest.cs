using FluentAssertions;
using RulesEngine.Core;
using RulesEngine.Core.Domain;
using Xunit;

namespace RulesEngine.Rules.Test.Rules
{
    public class BookProductRuleTest
    {
        [Fact]
        public void IsApplication_Should_Return_True_For_Book_Product()
        {
            var rule = new BookProductRule();
            var product = new Product { Type = ProductType.Book };

            rule.IsApplicable(product).Should().BeTrue();
            rule.Apply().Should().Be("Creating a duplicate packing slip for the royalty department");

        }

        [Fact]
        public void IsApplication_Should_Return_False_For_Other_Product()
        {
            var rule = new BookProductRule();
            var product = new Product { Type = ProductType.Membership };

            rule.IsApplicable(product).Should().BeFalse();
        }
    }
}
