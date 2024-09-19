using Microsoft.EntityFrameworkCore;

public static class BomboniereApi
{
    public static void ConfigureBomboniereApi(this WebApplication app)
    {
        app.MapGet("/bombonieres", async (AppDbContext db) =>
            await db.Bombonieres.ToListAsync());

        app.MapGet("/bombonieres/{id}", async (int id, AppDbContext db) =>
            await db.Bombonieres.FindAsync(id) is Bomboniere bomboniere
                ? Results.Ok(bomboniere)
                : Results.NotFound());

        app.MapPost("/bombonieres", async (Bomboniere bomboniere, AppDbContext db) =>
        {
            db.Bombonieres.Add(bomboniere);
            await db.SaveChangesAsync();
            return Results.Created($"/bombonieres/{bomboniere.id}", bomboniere);
        });

        app.MapPut("/bombonieres/{id}", async (int id, Bomboniere bomboniere, AppDbContext db) =>
        {
            var bomboniereExistente = await db.Bombonieres.FindAsync(id);
            if (bomboniereExistente is null) return Results.NotFound();

            bomboniereExistente.produto = bomboniere.produto;
            bomboniereExistente.valor = bomboniere.valor;

            await db.SaveChangesAsync();
            return Results.Ok(bomboniereExistente);
        });

        app.MapDelete("/bombonieres/{id}", async (int id, AppDbContext db) =>
        {
            var bomboniereExistente = await db.Bombonieres.FindAsync(id);
            if (bomboniereExistente is null) return Results.NotFound();

            db.Bombonieres.Remove(bomboniereExistente);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
