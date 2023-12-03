global using MiniERP.Data;
global using Microsoft.EntityFrameworkCore;
using MiniERP.Services;
using MiniERP.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<InvoiceService>();
builder.Services.AddScoped<SupplierService>();
builder.Services.AddScoped<ProductService>();

builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<InvoiceRepository>();
builder.Services.AddScoped<SupplierRepository>();
builder.Services.AddScoped<ProductRepository>();

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