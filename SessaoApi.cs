using Microsoft.EntityFrameworkCore;

public static class SessaoApi
{
    public static void ConfigureSessaoApi(this WebApplication app)
    {
        app.MapGet("/sessoes", async (AppDbContext db) =>
            await db.Sessoes.ToListAsync());

        app.MapGet("/sessoes/{id}", async (int id, AppDbContext db) => 
            await db.Sessoes.FindAsync(id) is Sessao sessao
                ? Results.Ok(sessao)
                : Results.NotFound());

        app.MapPost("/sessoes", async (Sessao sessao, AppDbContext db) => 
        {
            db.Sessoes.Add(sessao);
            await db.SaveChangesAsync();
            return Results.Created($"/sessoes/{sessao.id}", sessao);
        });

        app.MapPut("/sessoes/{id}", async (int id, Sessao sessao, AppDbContext db) => 
        {
            var sessaoExistente = await db.Sessoes.FindAsync(id);
            if (sessaoExistente is null) return Results.NotFound();
            
            sessaoExistente.idFilme = sessao.idFilme;
            sessaoExistente.idSala = sessao.idSala;
            sessaoExistente.data = sessao.data;
            
            await db.SaveChangesAsync();
            return Results.Ok(sessaoExistente);
        });

        app.MapDelete("/sessoes/{id}", async (int id, AppDbContext db) => 
        {
            var sessaoExistente = await db.Sessoes.FindAsync(id);
            if (sessaoExistente is null) return Results.NotFound();
            
            db.Sessoes.Remove(sessaoExistente);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
