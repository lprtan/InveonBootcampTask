using InveonBootcamp.LibaryApi.Caching.Interfaces;
using InveonBootcamp.LibaryApi.Caching.Services;
using InveonBootcamp.LibaryApi.Controllers;
using InveonBootcamp.LibaryApi.Models.Pagination;
using InveonBootcamp.LibaryApi.Models.Repositories.Abstract;
using InveonBootcamp.LibaryApi.Models.Repositories.Concrete;
using InveonBootcamp.LibaryApi.Models.Repositories.Context;
using InveonBootcamp.LibaryApi.Models.Services.Abstract;
using InveonBootcamp.LibaryApi.Models.Services.Concrete;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
var redisConnection = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IMemberService, MemberService>();

builder.Services.AddSingleton<IConnectionMultiplexer>(redisConnection);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRedisCacheService, RedisCacheService>();

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
