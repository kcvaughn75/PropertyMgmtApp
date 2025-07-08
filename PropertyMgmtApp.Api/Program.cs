using Microsoft.EntityFrameworkCore;
using PropertyMgmtApp.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// 1) Read connection string
var connString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2) Add the DbContext
builder.Services.AddDbContext<PropertyMgmtDbContext>(opts =>
    opts.UseSqlServer(connString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev", policy =>
    {
        policy
          .WithOrigins("http://localhost:4200")
          .AllowAnyHeader()
          .AllowAnyMethod();
    });
});

// 3) Add controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 4) Map controllers
app.UseHttpsRedirection();
app.UseCors("AllowAngularDev");
app.UseAuthorization();
app.MapControllers();

app.Run();
