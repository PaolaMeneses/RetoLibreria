using Microsoft.EntityFrameworkCore;
using RetoLibreria.Configurations;
using RetoLibreria.Literals;
using RetoLibreria.Modelos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.SetDatabaseConfiguration();
builder.Services.SetRetoLibreriaAuthConfiguration();
builder.Services.AddControllers().AddJsonOptions(x=>x.JsonSerializerOptions.ReferenceHandler=ReferenceHandler.Preserve); // referencia circular (cuando reciba un caso de referencia dele un manejo y preserve la referencia que tenga)


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
}
);

app.Run();



