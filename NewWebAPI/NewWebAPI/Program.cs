using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.Storage.Internal;
using NewWebAPI.Context;
using NewWebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PetContext>(opt => opt.UseInMemoryDatabase(databaseName: "NewDatabase"));

//builder.Services.AddScoped<IClientRepository, ClientRepository>();
//builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.MapSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
