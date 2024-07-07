using Ecommerce.Server.Middlewares;
using Ecommerce.Server.Entites;
using Ecommerce.Server.Repositories.Implements;
using Ecommerce.Server.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Server.Services.Interfaces;
using Ecommerce.Server.Services.Implements;
using Microsoft.OpenApi.Models;
using Ecommerce.Server.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Document Ecommerce API", Version = "v1" });
    c.DocumentFilter<LowercaseDocumentFilter>();
});

// Add DbContext
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connection));

// DI Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// DI Services
builder.Services.AddScoped<IProductService, ProductService>();


var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecommerce API Version 1"));

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
