using Subscriptions.Data;
using Subscriptions.Services;

var builder = WebApplication.CreateBuilder(args);

// Add repositories to the container.
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

// Add services to the container.
builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
