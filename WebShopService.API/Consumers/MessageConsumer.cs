using MassTransit;
using MassTransit.Internals;
using WebshopService.API.Models;

namespace WebshopService.API.Consumers
{
    public class MessageConsumer : IConsumer<Message>
    {
        ILogger<MessageConsumer> _logger;

        public MessageConsumer(ILogger<MessageConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<Message> context)
        {
            _logger.LogInformation("Logging context: {@Context}", context);
            return Task.CompletedTask;
        }
    }
}
