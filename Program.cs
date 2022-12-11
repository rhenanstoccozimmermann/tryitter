// using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.EntityFrameworkCore;
using tryitter.Repository;
using tryitter.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

 builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
//Scopes
#region Context
builder.Services.AddScoped<IContext, Context>();
#endregion

#region Repositories
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
#endregion

#region Services
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IPostService, PostService>();
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
