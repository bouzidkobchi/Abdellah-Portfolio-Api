using Abdellah_Portfolio.Api;
using Abdellah_Portfolio.Data;
using Abdellah_Portfolio.Data.Repositories;
using Abdellah_Portfolio.Data.Tools;

var builder = WebApplication.CreateBuilder(args);

builder.ConfiguringSwagger();
builder.Services.AddControllers();

WebApplication app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();
app.MapControllers();

app.ConfiguringSwagger();

Console.WriteLine(Hash.GeneratePasswordHash(new AppDbContext().Users.First(),"123"));

app.Run();
