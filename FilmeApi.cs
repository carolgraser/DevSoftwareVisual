using Microsoft.EntityFrameworkCore;

public static class FilmeApi
{
    public static void ConfigureFilmeApi(this WebApplication app)
    {
        app.MapGet("/filmes", async (AppDbContext db) =>
            await db.Filmes.ToListAsync());

        app.MapGet("/filmes/{id}", async (int id, AppDbContext db) => 
            await db.Filmes.FindAsync(id) is Filme filme
                ? Results.Ok(filme)
                : Results.NotFound());

        app.MapPost("/filmes", async (Filme filme, AppDbContext db) => 
        {
            db.Filmes.Add(filme);
            await db.SaveChangesAsync();
            return Results.Created($"/filmes/{filme.id}", filme);
        });

        app.MapPut("/filmes/{id}", async (int id, Filme filme, AppDbContext db) => 
        {
            var filmeExistente = await db.Filmes.FindAsync(id);
            if (filmeExistente is null) return Results.NotFound();
            
            filmeExistente.titulo = filme.titulo;
            
            await db.SaveChangesAsync();
            return Results.Ok(filmeExistente);
        });

        app.MapDelete("/filmes/{id}", async (int id, AppDbContext db) => 
        {
            var filmeExistente = await db.Filmes.FindAsync(id);
            if (filmeExistente is null) return Results.NotFound();
            
            db.Filmes.Remove(filmeExistente);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
