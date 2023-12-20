using Autofac.Extensions.DependencyInjection;
using GraphQL;
using GraphQL.API.Context;
using GraphQL.Server;
using Microsoft.EntityFrameworkCore;
using GraphQL.SystemTextJson;
using GraphQL.MicrosoftDI;
using HotChocolate;
using GraphQL.Server.Ui.Altair;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Use Autofac as the DI container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Add DbContext
builder.Services.AddEntityFrameworkInMemoryDatabase();
builder.Services.AddDbContext<MovieContext>(options => options.UseInMemoryDatabase("MovieDb"));

// Configure GraphQL services
// Configure GraphQL services
builder.Services.AddGraphQLServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Enable Altair UI at path /
app.UseGraphQLAltair(new GraphQLAltairOptions { Path = "/" });

app.Run();
