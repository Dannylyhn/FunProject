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
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("message-queue", e =>
        {
            e.Bind("message-exchange", x =>
            {
                x.ExchangeType = "direct";
            });
            e.Bind<Message>();
            e.ConfigureConsumer<MessageConsumer>(context);
            //e.Consumer<MessageConsumer>();
        });

        cfg.ConfigureEndpoints(context);


    });
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
