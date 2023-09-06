using Microsoft.EntityFrameworkCore;
using SuitSupply.Application.Services.Abstract;
using SuitSupply.Application.Services.Concrete;
using SuitSupply.Domain.Common.Interfaces;
using SuitSupply.Infrastructure.Contexts;
using SuitSupply.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<SuitSupplyDbContext>(
		//options => options.UseSqlServer("DB CONNECTION SHOULD BE PUT HERE")
		options => options.UseInMemoryDatabase("InMemoryDb")
);
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISuitRepository, SuitRepository>();
builder.Services.AddScoped<IAlterationFormRepository, AlterationFormRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAlterationService, AlterationService>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwaggerUI(options =>
{
	options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
	options.RoutePrefix = string.Empty;
});

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.Run();
