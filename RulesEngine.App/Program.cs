using RulesEngine.Core;
using RulesEngine.Core.Domain;
using RulesEngine.Rules;
using RulesEngine.Rules.Rules;
using System;

namespace RulesEngine.App
{
    class Program
    {
        static public void Main(String[] args)
        {
            var ruleEngine = SetUpBusinessRuleEngine();
            var orderProcessor = new OrderProcessor(ruleEngine, new Agent { Name = "Real Agent" });
            var results = orderProcessor
                .Add(new OrderLine(book, 1))
                .Add(new OrderLine(membership, 1))
                .Add(new OrderLine(upgrade, 1))
                .Add(new OrderLine(video, 1))
                .Process();

            Console.WriteLine();
            Console.WriteLine("Final Result");

            foreach (var x in results) { Console.WriteLine(x);  };
        }

        private static Product book = new Product
        {
            Attribute = Core.Domain.ProductAttribute.PHYSICAL,
            Name = "Hitchhiker's Guide to the Galaxy",
            Type = ProductType.Book,
            Price = 100,
            Id = 5
        };

        private static Product membership = new Product
        {
            Attribute = Core.Domain.ProductAttribute.NONPHYSICAL,
            Name = "5 Month subscription",
            Type = ProductType.Membership,
            Price = 100,
            Id = 6
        };

        private static Product upgrade = new Product
        {
            Attribute = Core.Domain.ProductAttribute.NONPHYSICAL,
            Name = "Upgrade to Premium",
            Type = ProductType.Upgrade,
            Price = 45,
            Id = 7
        };

        private static Product video = new Product
        {
            Attribute = Core.Domain.ProductAttribute.NONPHYSICAL,
            Name = "Learning to Ski",
            Type = ProductType.Video,
            Price = 145,
            Id = 8
        };

        private static IBussinessRuleEngine SetUpBusinessRuleEngine()
        {
            IBussinessRuleEngine businessRuleEngine = new BusinessRuleEngine();
            businessRuleEngine
                .AddRule(new PhysicalProductRule())
                .AddRule(new CommissionRule())
                .AddRule(new EmailRule())
                .AddRule(new MembershipProductRule())
                .AddRule(new BookProductRule())
                .AddRule(new UpgradeProductRule())
                .AddRule(new VideoProductRule());

            return businessRuleEngine;
        }
    }
}
