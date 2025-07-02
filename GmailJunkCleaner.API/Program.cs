using GmailJunkCleaner.Services;
using GmailJunkCleaner.Domain.Interfaces;
using GmailJunkCleaner.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using GmailJunkCleaner.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = new ServiceCollection();

services.AddScoped<IGmailRepository, GmailRepository>();
services.AddScoped<JunkInboxCleanerService>();

var provider = services.BuildServiceProvider();

var cleaner = provider.GetRequiredService<JunkInboxCleanerService>();
int count = await cleaner.CleanAsync();

Console.WriteLine($"Cleaned {count} junk emails!");

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
