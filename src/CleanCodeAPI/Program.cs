using CleanCode.Application.Features.Products.Handlers;
using CleanCode.Domain.Aggregates;
using CleanCode.Infrastructure.EF.Repositories;
using CleanCode.Infrastructure.EF.UnitOfWorks;
using CleanCode.Infrastructure.Mongo;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// key bazlý servis deðiþtirme senaryolarý için kullaným saðlar.
builder.Services.AddKeyedScoped<IProductService,ProductService>("default");
builder.Services.AddKeyedScoped<IProductService, S400ProductService>("s400");

builder.Services.AddScoped<IProductRepository, MongoProductRepository>();
builder.Services.AddScoped<IUnitOfWork, MongoUnitOfWork>();

var applicationAssembly = Assembly.GetAssembly(typeof(CreateProductRequestHandler));
var domainAssembly = Assembly.GetAssembly(typeof(ProductPriceChangeHandler));

// Reflection ile ilgili assembly 
builder.Services.AddMediatR(config =>
{
  config.RegisterServicesFromAssemblies(applicationAssembly,domainAssembly);
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
