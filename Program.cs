using Microsoft.EntityFrameworkCore;
using Projeto_Ascii.Context;
using Projeto_Ascii.Profiles;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<AsciiDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddAutoMapper(options =>
{
    options.AddProfile(typeof(ProdutoProfile));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Projeto_Ascii v1"));
}

app.UseHttpsRedirection();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
