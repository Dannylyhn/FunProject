using MassTransit;
using MassTransit.RabbitMqTransport.Topology;
using RabbitMQ.Client;
using WebshopService.API.Consumers;
using WebshopService.API.Models;
using WebshopService.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IItemsService, ItemsService>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<MessageConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        var messageQueueName = "message-queue";
        var messageExchangeName = "message-exchange";

        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint(messageQueueName, e =>
        {
            e.Bind(messageExchangeName, x =>
            {
                x.ExchangeType = ExchangeType.Direct;
            });
            e.ConfigureConsumer<MessageConsumer>(context);
        });
    });

    // Configure other endpoints if needed
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
