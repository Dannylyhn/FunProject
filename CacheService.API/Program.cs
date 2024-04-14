using ServiceStack.Redis;
using ServiceStack;
using CacheService.Services;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var test = config.GetValue<string>("Redis:Url");

Console.WriteLine(test);

builder.Services.AddSingleton<IRedisClientsManager>(new RedisManagerPool("localhost:6379"));
builder.Services.AddScoped<ICacheService, CacheService.Services.CacheService>();


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
