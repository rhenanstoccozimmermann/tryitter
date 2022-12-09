// using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.EntityFrameworkCore;
using tryitter.Repository;
using tryitter.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Scopes
#region Context
builder.Services.AddScoped<IPostContext, PostContext>();
#endregion

#region Repositories
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
#endregion

#region Services
builder.Services.AddScoped<IAccountService, AccountService>();
#endregion
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

app.UseHttpsRedirection();

// Adicionar uso de autenticação
app.UseAuthentication();
// Adicionar uso de autorização
app.UseAuthorization();

app.MapControllers();

app.Run();
