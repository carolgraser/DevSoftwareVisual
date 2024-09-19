using Microsoft.EntityFrameworkCore;

public static class IngressoApi
{
    public static void ConfigureIngressoApi(this WebApplication app)
    {
        app.MapGet("/ingressos", async (AppDbContext db) =>
            await db.Ingressos.ToListAsync());

        app.MapGet("/ingressos/{id}", async (int id, AppDbContext db) => 
            await db.Ingressos.FindAsync(id) is Ingresso ingresso
                ? Results.Ok(ingresso)
                : Results.NotFound());

        app.MapPost("/ingressos", async (Ingresso ingresso, AppDbContext db) => 
        {
            db.Ingressos.Add(ingresso);
            await db.SaveChangesAsync();
            return Results.Created($"/ingressos/{ingresso.id}", ingresso);
        });

        app.MapPut("/ingressos/{id}", async (int id, Ingresso ingresso, AppDbContext db) => 
        {
            var ingressoExistente = await db.Ingressos.FindAsync(id);
            if (ingressoExistente is null) return Results.NotFound();
            
            ingressoExistente.assento = ingresso.assento;
            ingressoExistente.idSessao = ingresso.idSessao;
            
            await db.SaveChangesAsync();
            return Results.Ok(ingressoExistente);
        });

        app.MapDelete("/ingressos/{id}", async (int id, AppDbContext db) => 
        {
            var ingressoExistente = await db.Ingressos.FindAsync(id);
            if (ingressoExistente is null) return Results.NotFound();
            
            db.Ingressos.Remove(ingressoExistente);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
