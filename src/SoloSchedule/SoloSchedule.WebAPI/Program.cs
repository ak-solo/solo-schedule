using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SoloSchedule.Infrastructure.SqlServer;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var cnnBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("SoloSchedule"))
{
    Password = builder.Configuration["DbPassword"],
};
var connection = cnnBuilder.ConnectionString;
builder.Services.AddDbContext<SoloScheduleContext>(options => options.UseSqlServer(connection));

// Add services to the container.
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
