using FluentAssertions;
using Moq;
using RulesEngine.Core;
using System;
using Xunit;

namespace RulesEngine.Rules.Test
{
    public class BusinessRuleEngineTest
    {
        [Fact]
        public void AddRule_Should_Add_Rule_ToEngine()
        {
            IBussinessRuleEngine ruleEngine = new BusinessRuleEngine();
            IRule rule = new PhysicalProductRule();
            ruleEngine.AddRule(rule);

            ruleEngine.Rules.Should().Contain(rule);
        }

        [Fact]
        public void AddRule_Should_Remove_Rule_FromEngine()
        {
            IBussinessRuleEngine ruleEngine = new BusinessRuleEngine();
            IRule rule = new PhysicalProductRule();
            ruleEngine.AddRule(rule);
            ruleEngine.RemoveRule(rule);

            ruleEngine.Rules.Should().NotContain(rule);
        }

        [Fact]
        public void Process_Should_Execute_Rule()
        {
            IBussinessRuleEngine ruleEngine = new BusinessRuleEngine();
            IRule rule = new PhysicalProductRule();
            var order = new Order(Guid.NewGuid(), new Agent { Name = "Test" });
            var product = new Product();
            order.Add(new OrderLine(product, 1));

            var ruleMock = new Mock<IRule>();
            ruleMock.Setup(x => x.IsApplicable(product)).Returns(true);
            ruleMock.Setup(x => x.Apply()).Returns("Applied Rule");

            ruleEngine.AddRule(ruleMock.Object);
            ruleEngine.Process(order);

            ruleMock.Verify(x => x.IsApplicable(product), Times.Once);
            ruleMock.Verify(x => x.Apply(), Times.Once);

        }

        [Fact]
        public void Process_Should_Not_Execute_Rule()
        {
            IBussinessRuleEngine ruleEngine = new BusinessRuleEngine();
            IRule rule = new PhysicalProductRule();
            var order = new Order(Guid.NewGuid(), new Agent { Name = "Test" });
            var product = new Product();
            order.Add(new OrderLine(product, 1));

            var ruleMock = new Mock<IRule>();
            ruleMock.Setup(x => x.IsApplicable(product)).Returns(false);
            ruleMock.Setup(x => x.Apply()).Returns("Applied Rule");

            ruleEngine.AddRule(ruleMock.Object);
            ruleEngine.Process(order);

            ruleMock.Verify(x => x.IsApplicable(product), Times.Once);
            ruleMock.Verify(x => x.Apply(), Times.Never);

        }
    }
}
