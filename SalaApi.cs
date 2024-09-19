using Microsoft.EntityFrameworkCore;

public static class SalaApi
{
    public static void ConfigureSalaApi(this WebApplication app)
    {
        app.MapGet("/salas", async (AppDbContext db) =>
            await db.Salas.ToListAsync());

        app.MapGet("/salas/{id}", async (int id, AppDbContext db) => 
            await db.Salas.FindAsync(id) is Sala sala
                ? Results.Ok(sala)
                : Results.NotFound());

        app.MapPost("/salas", async (Sala sala, AppDbContext db) => 
        {
            db.Salas.Add(sala);
            await db.SaveChangesAsync();
            return Results.Created($"/salas/{sala.Id}", sala);
        });

        app.MapPut("/salas/{id}", async (int id, Sala sala, AppDbContext db) => 
        {
            var salaExistente = await db.Salas.FindAsync(id);
            if (salaExistente is null) return Results.NotFound();
            
            salaExistente.qntCadeiras = sala.qntCadeiras;
            
            await db.SaveChangesAsync();
            return Results.Ok(salaExistente);
        });

        app.MapDelete("/salas/{id}", async (int id, AppDbContext db) => 
        {
            var salaExistente = await db.Salas.FindAsync(id);
            if (salaExistente is null) return Results.NotFound();
            
            db.Salas.Remove(salaExistente);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
