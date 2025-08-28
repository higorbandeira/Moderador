using Moderador.API.Models;
using Moderador.Lib.interfaces;
using Moderador.Lib.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<OpenAIConfig>(
    builder.Configuration.GetSection("OpenAIConfig"));

// Add services to the container.
builder.Services.AddScoped<IModeradorService, ModeradorService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
