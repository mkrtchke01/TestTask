using Microsoft.EntityFrameworkCore;
using TestTask;
using TestTask.Models;
using TestTask.Repositories.Contracts;
using TestTask.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
); ;
builder.Services.AddDbContext<TestTaskDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s=> 
{ 
    s.EnableAnnotations(); 
});

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
