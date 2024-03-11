using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ManualMigration.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite(builder.Configuration
        .GetConnectionString("api")));

builder.Services.AddControllers();
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

// GET all products
app.MapGet("/api/products", async (DatabaseContext dbContext) =>
{
    return await dbContext.Products.ToListAsync();
})
.WithName("GetAllProducts")
.WithMetadata(new HttpMethodMetadata(new[] { "GET" }))
.WithOpenApi();

// GET product by ID
app.MapGet("/api/products/{id}", async (int id, DatabaseContext dbContext) =>
{
    return await dbContext.Products.FindAsync(id);
})
.WithName("GetProductById")
.WithMetadata(new HttpMethodMetadata(new[] { "GET" }))
.WithOpenApi();

// POST new product
app.MapPost("/api/products", async (Product product, DatabaseContext dbContext) =>
{
    dbContext.Products.Add(product);
    await dbContext.SaveChangesAsync();
    return Results.Created($"/api/products/{product.Id}", product);
})
.WithName("CreateProduct")
.WithMetadata(new HttpMethodMetadata(new[] { "POST" }))
.WithOpenApi();

// PUT update product
app.MapPut("/api/products/{id}", async (int id, Product updatedProduct, DatabaseContext dbContext) =>
{
    var product = await dbContext.Products.FindAsync(id);
    if (product == null)
    {
        return Results.NotFound();
    }

    product.Name = updatedProduct.Name;
    product.Price = updatedProduct.Price;
    await dbContext.SaveChangesAsync();
    return Results.NoContent();
})
.WithName("UpdateProduct")
.WithMetadata(new HttpMethodMetadata(new[] { "PUT" }))
.WithOpenApi();

// DELETE product
app.MapDelete("/api/products/{id}", async (int id, DatabaseContext dbContext) =>
{
    var product = await dbContext.Products.FindAsync(id);
    if (product == null)
    {
        return Results.NotFound();
    }

    dbContext.Products.Remove(product);
    await dbContext.SaveChangesAsync();
    return Results.NoContent();
})
.WithName("DeleteProduct")
.WithMetadata(new HttpMethodMetadata(new[] { "DELETE" }))
.WithOpenApi();

app.Run();
