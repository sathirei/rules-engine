using FluentAssertions;
using Moq;
using RulesEngine.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RulesEngine.Core.Test
{
    public class OrderProcessorTest
    {
        [Fact]
        public void Add_Should_Add_To_OrderLine()
        {
            var businessEngineMock = new Mock<IBussinessRuleEngine>();
            var agent = new Agent { Name = "Test" };
            var orderEngine = new OrderProcessor(businessEngineMock.Object, agent);
            var book = new Product
            {
                Attribute = Domain.ProductAttribute.PHYSICAL,
                Id = 1,
                Type = "Book",
                Name = "Hitchhiker's Guide to the Galaxy"
            };

            orderEngine.Add(new OrderLine(book, 1));

            var order = orderEngine.Order;

            var orderLine = order.OrderLines.Single();
            order.OrderId.Should().NotBe(Guid.Empty);
            orderLine.Product.Should().Be(book);
            orderLine.Quantity.Should().Be(1);
        }

        [Fact]
        public void Add_Should_Add_To_Quantity_For_The_Same_Product()
        {
            var businessEngineMock = new Mock<IBussinessRuleEngine>();
            var agent = new Agent { Name = "Test" };
            var orderEngine = new OrderProcessor(businessEngineMock.Object, agent);
            var book = new Product
            {
                Attribute = Domain.ProductAttribute.PHYSICAL,
                Id = 1,
                Type = "Book",
                Name = "Hitchhiker's Guide to the Galaxy"
            };

            orderEngine.Add(new OrderLine(book, 1));
            orderEngine.Add(new OrderLine(book, 1));

            var order = orderEngine.Order;

            var orderLine = order.OrderLines.Single();
            order.OrderId.Should().NotBe(Guid.Empty);
            orderLine.Product.Should().Be(book);
            orderLine.Quantity.Should().Be(2);
        }

        [Fact]
        public void Process_Should_Process_Order()
        {
            var businessEngineMock = new Mock<IBussinessRuleEngine>();
            var agent = new Agent { Name = "Test" };            
            var book = new Product
            {
                Attribute = Domain.ProductAttribute.PHYSICAL,
                Id = 1,
                Type = "Book",
                Name = "Hitchhiker's Guide to the Galaxy"
            };

            var orderEngine = new OrderProcessor(businessEngineMock.Object, agent);

            orderEngine.Add(new OrderLine(book, 1));
            orderEngine.Add(new OrderLine(book, 1));
            var order = orderEngine.Order;
            var expected = new List<string> { "Applied" };

            businessEngineMock.Setup(x => x.Process(order)).Returns(expected);

            orderEngine.Process().Should().BeEquivalentTo(expected);

            businessEngineMock.Verify(x => x.Process(order), Times.Once);
        }
    }
}
