using GlobalErrorApp;
using GlobalErrorApp.Configurations;
using GlobalErrorApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<applicationDbContext>(optins => optins.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionStrings")));
builder.Services.AddTransient<IDriverService,DriverService>();
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

app.AddGlobalErrorHandler();
//app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
app.Run();
