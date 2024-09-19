using Microsoft.EntityFrameworkCore;

public static class UsuarioApi
{
    public static void ConfigureUsuarioApi(this WebApplication app)
    {
        app.MapGet("/usuarios", async (AppDbContext db) =>
            await db.Usuarios.ToListAsync());

        app.MapGet("/usuarios/{id}", async (int id, AppDbContext db) => 
            await db.Usuarios.FindAsync(id) is Usuario usuario
                ? Results.Ok(usuario)
                : Results.NotFound());

        app.MapPost("/usuarios", async (Usuario usuario, AppDbContext db) => 
        {
            db.Usuarios.Add(usuario);
            await db.SaveChangesAsync();
            return Results.Created($"/usuarios/{usuario.id}", usuario);
        });

        app.MapPut("/usuarios/{id}", async (int id, Usuario usuario, AppDbContext db) => 
        {
            var usuarioExistente = await db.Usuarios.FindAsync(id);
            if (usuarioExistente is null) return Results.NotFound();
            
            usuarioExistente.nome = usuario.nome;
            usuarioExistente.senha = usuario.senha;
            usuarioExistente.perfil = usuario.perfil;
            
            await db.SaveChangesAsync();
            return Results.Ok(usuarioExistente);
        });

        app.MapDelete("/usuarios/{id}", async (int id, AppDbContext db) => 
        {
            var usuarioExistente = await db.Usuarios.FindAsync(id);
            if (usuarioExistente is null) return Results.NotFound();
            
            db.Usuarios.Remove(usuarioExistente);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
