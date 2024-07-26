using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
namespace Consumer.Microservice.Consumers
{
    public class OrderConsumer : IConsumer<Order>
    {
        public async Task Consume(ConsumeContext<Order> context)
        {
            Order data = context.Message;
            // Process the data.
        }
    }
}
