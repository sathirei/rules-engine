using FluentAssertions;
using RulesEngine.Core;
using RulesEngine.Core.Domain;
using RulesEngine.Rules.Rules;
using Xunit;

namespace RulesEngine.Rules.Test.Rules
{
    public class VideoProductRuleTest
    {
        [Fact]
        public void IsApplication_Should_Return_True_For_Video_Product_Learning_to_Ski()
        {
            var rule = new VideoProductRule();
            var product = new Product { Type = ProductType.Video, Name = "Learning to Ski" };

            rule.IsApplicable(product).Should().BeTrue();
            rule.Apply().Should().Be("Adding a free \"First Aid\" video to the packing slip (the result of a court decision in 1997)");

        }

        [Fact]
        public void IsApplication_Should_Return_False_For_Other_Video_Product()
        {
            var rule = new VideoProductRule();
            var product = new Product { Type = ProductType.Video };

            rule.IsApplicable(product).Should().BeFalse();
        }
    }
}
