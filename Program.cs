using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Registrar todas as APIs
app.ConfigureUsuarioApi();

app.MapGet("/", () => "Planner API");

app.Run();
