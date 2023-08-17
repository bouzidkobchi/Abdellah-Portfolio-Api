using Abdellah_Portfolio.Api;

var builder = WebApplication.CreateBuilder(args);

builder.ConfiguringSwagger();
builder.Services.AddControllers();

WebApplication app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();
app.MapControllers();

app.ConfiguringSwagger();

app.Run();
