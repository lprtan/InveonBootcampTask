using InveonBootcamp.LibaryApi.Caching.Interfaces;
using InveonBootcamp.LibaryApi.Caching.Services;
using InveonBootcamp.LibaryApi.Controllers;
using InveonBootcamp.LibaryApi.Models.Pagination;
using InveonBootcamp.LibaryApi.Models.Repositories.Abstract;
using InveonBootcamp.LibaryApi.Models.Repositories.Concrete;
using InveonBootcamp.LibaryApi.Models.Repositories.Context;
using InveonBootcamp.LibaryApi.Models.Services.Abstract;
using InveonBootcamp.LibaryApi.Models.Services.Concrete;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System;

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

app.UseExceptionHandler(error =>
{
    error.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var execption = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        if (execption != null)
        {
            var response = new
            {
                message = "Bilinmyene bir hata oluþtur tekrar deneyiniz",
                details = app.Environment.IsDevelopment() ? execption.Message : null
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    });
});

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
