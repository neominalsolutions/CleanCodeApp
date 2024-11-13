using CleanCode.Domain.Aggregates;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// key bazlý servis deðiþtirme senaryolarý için kullaným saðlar.
builder.Services.AddKeyedScoped<IProductService,ProductService>("default");
builder.Services.AddKeyedScoped<IProductService, S400ProductService>("s400");

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
