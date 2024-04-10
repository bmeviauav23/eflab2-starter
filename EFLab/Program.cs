using EFLab;
using EFLab.Entities;

using var ctx = new LabDbContext();
SeedDatabase(ctx);
var p = ctx.Products.FirstOrDefault();

Console.ReadKey();

static void SeedDatabase(LabDbContext ctx)
{
    if (ctx.Products.Any())
    {
        return;
    }

    var drink = new Category() { Name = "Ital" };
    var food = new Category() { Name = "Étel" };

    ctx.Categories.Add(drink);
    ctx.Categories.Add(food);

    ctx.Products.Add(new Product() { Name = "Sör", UnitPrice = 50, Category = drink });
    ctx.Products.Add(new Product() { Name = "Bor", Category = drink });
    ctx.Products.Add(new Product() { Name = "Tej", Category = drink });

    ctx.SaveChanges();
}