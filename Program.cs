using AspApi;
using AspApi.Context;
using AspApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepo, MysqlRepo>();

string _Default = builder.Configuration["ConnectionStrings:TodoDb"];
string _Docker = builder.Configuration["ConnectionStrings:TodoDb"];

builder.Services.AddDbContext<TodoContext>(opt => 
    opt.UseSqlServer(builder.Configuration.GetConnectionString(_Default)));
/* 
builder.Services.AddDbContext<TodoContext>(opt => 
    opt.UseMySql(_conectionString, ServerVersion.AutoDetect(_conectionString)));
 */
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
