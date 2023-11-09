using System.Net;
using Contracts;
using Entities;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseMySql(builder.Configuration
    .GetConnectionString("sqlConnection"), serverVersion, b =>
     b.MigrationsAssembly("MovieApp")));
     builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();     
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

app.UseExceptionHandler(appError => 
{
    appError.Run(async context => 
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; 
        context.Response.ContentType = "application/json";
        var contextFeature = context.Features.Get<IExceptionHandlerFeature>(); 
        if (contextFeature != null)
        {
            await context.Response.WriteAsync(new ErrorDetails() 
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error." 
            }.ToString());
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
