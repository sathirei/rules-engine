using FluentAssertions;
using RulesEngine.Core;
using RulesEngine.Core.Domain;
using RulesEngine.Rules;
using RulesEngine.Rules.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace RulesEngine.App.Test
{
    public class IntegrationTest
    {
        //If the payment is for a physical product, generate a packing slip for shipping.
        [Fact]
        public void Physical_Product_Rule_Test()
        {
            IBussinessRuleEngine businessEngine = new BusinessRuleEngine();
            var rule = new PhysicalProductRule();
            businessEngine.AddRule(rule);
            var agent = new Agent { Name = "Test" };
            var product = new Product
            {
                Attribute = ProductAttribute.PHYSICAL,
                Id = 1,
                Type = "Book",
                Name = "Hitchhiker's Guide to the Galaxy"
            };

            var orderEngine = new OrderProcessor(businessEngine, agent);

            orderEngine.Add(new OrderLine(product, 1));
            orderEngine.Process().Single().Should().Be("Generating a packing slip for shipping.") ;
        }
        //If the payment is for a book, create a duplicate packing slip for the royalty department.
        [Fact]
        public void Book_Product_Rule_Test()
        {
            IBussinessRuleEngine businessEngine = new BusinessRuleEngine();
            var rule = new BookProductRule();
            businessEngine.AddRule(rule);
            var agent = new Agent { Name = "Test" };
            var product = new Product
            {
                Attribute = ProductAttribute.PHYSICAL,
                Id = 1,
                Type = ProductType.Book,
                Name = "Hitchhiker's Guide to the Galaxy"
            };

            var orderEngine = new OrderProcessor(businessEngine, agent);

            orderEngine.Add(new OrderLine(product, 1));
            orderEngine.Process().Single().Should().Be("Creating a duplicate packing slip for the royalty department");
        }
        //If the payment is for a membership, activate that membership.
        [Fact]
        public void Membership_Product_Rule_Test()
        {
            IBussinessRuleEngine businessEngine = new BusinessRuleEngine();
            var rule = new MembershipProductRule();
            businessEngine.AddRule(rule);
            var agent = new Agent { Name = "Test" };
            var product = new Product
            {
                Attribute = ProductAttribute.NONPHYSICAL,
                Id = 1,
                Type = ProductType.Membership,
                Name = "5 months subscription"
            };

            var orderEngine = new OrderProcessor(businessEngine, agent);

            orderEngine.Add(new OrderLine(product, 1));
            orderEngine.Process().Single().Should().Be("Activating membership");
        }
        //If the payment is an upgrade to a membership, apply the upgrade.
        [Fact]
        public void Upgrade_Product_Rule_Test()
        {
            IBussinessRuleEngine businessEngine = new BusinessRuleEngine();
            var rule = new UpgradeProductRule();
            businessEngine.AddRule(rule);
            var agent = new Agent { Name = "Test" };
            var product = new Product
            {
                Attribute = ProductAttribute.NONPHYSICAL,
                Id = 1,
                Type = ProductType.Upgrade,
                Name = "Upgrade to Premium"
            };

            var orderEngine = new OrderProcessor(businessEngine, agent);

            orderEngine.Add(new OrderLine(product, 1));
            orderEngine.Process().Single().Should().Be("Applying the upgrade");
        }
        //If the payment is for a membership or upgrade, e-mail the owner and inform them of the activation/upgrade.
        [Fact]
        public void Email_Rule_Test()
        {
            IBussinessRuleEngine businessEngine = new BusinessRuleEngine();
            var rule = new EmailRule();
            businessEngine.AddRule(rule);
            var agent = new Agent { Name = "Test" };
            var product = new Product
            {
                Attribute = ProductAttribute.NONPHYSICAL,
                Id = 1,
                Type = ProductType.Upgrade,
                Name = "Upgrade to Premium"
            };

            var orderEngine = new OrderProcessor(businessEngine, agent);

            orderEngine.Add(new OrderLine(product, 1));
            orderEngine.Process().Single().Should().Be("Sending email to the owner for activation/upgrade");
        }
        //If the payment is for the video “Learning to Ski,” add a free “First Aid” video to the packing slip (the result of a court decision in 1997).
        [Fact]
        public void VideoProduct_Rule_Test()
        {
            IBussinessRuleEngine businessEngine = new BusinessRuleEngine();
            var rule = new VideoProductRule();
            businessEngine.AddRule(rule);
            var agent = new Agent { Name = "Test" };
            var product = new Product
            {
                Attribute = ProductAttribute.NONPHYSICAL,
                Id = 1,
                Type = ProductType.Video,
                Name = "Learning to Ski"
            };

            var orderEngine = new OrderProcessor(businessEngine, agent);

            orderEngine.Add(new OrderLine(product, 1));
            orderEngine.Process().Single().Should().Be("Adding a free \"First Aid\" video to the packing slip (the result of a court decision in 1997)");
        }
        //If the payment is for a physical product or a book, generate a commission payment to the agent.
        [Fact]
        public void Commision_Rule_Test()
        {
            IBussinessRuleEngine businessEngine = new BusinessRuleEngine();
            var rule = new CommissionRule();
            businessEngine.AddRule(rule);
            var agent = new Agent { Name = "Test" };
            var product = new Product
            {
                Attribute = ProductAttribute.PHYSICAL,
                Id = 1,
                Type = ProductType.Book,
                Name = "Learning Python"
            };

            var orderEngine = new OrderProcessor(businessEngine, agent);

            orderEngine.Add(new OrderLine(product, 1));
            orderEngine.Process().Single().Should().Be("Generating commision payment to the agent");
        }

    }
}
