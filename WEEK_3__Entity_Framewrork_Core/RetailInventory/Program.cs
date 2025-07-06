/*
 ============================
    Author - Utsav Saxena
    Date - 05-07-25
 ============================
*/

using Microsoft.EntityFrameworkCore;
using RetailInventory;
using RetailInventory.Models;

using var context = new AppDbContext();

var electronics = new Category { Name = "Electronics" };
var groceries = new Category { Name = "Groceries" };
var author = new Category { Name = "Author" };
await context.Categories.AddRangeAsync(electronics, groceries, author);
var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };
var product3 = new Product { Name = "Utsav Saxena", Price = 6361856, Category = author };
await context.Products.AddRangeAsync(product1, product2, product3);
await context.SaveChangesAsync();


Console.WriteLine("Name - Utsav Saxena, Superset ID - 6361856 \n");
var products = await context.Products.ToListAsync();
foreach (var p in products)
    Console.WriteLine($"{p.Name} - ₹{p.Price}");

var product = await context.Products.FindAsync(1);
Console.WriteLine($"Found: {product?.Name}");

var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
Console.WriteLine($"Expensive: {expensive?.Name}");
