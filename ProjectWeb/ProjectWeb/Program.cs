using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjectWeb.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI
builder.Services.AddDbContext<SubscriptionContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("mycon")));
var app = builder.Build();

//CORS
builder.Services.AddCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	app.UseCors(options =>
	options.WithOrigins("http://localhost:4200")
	.AllowAnyMethod()
	.AllowAnyHeader());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
