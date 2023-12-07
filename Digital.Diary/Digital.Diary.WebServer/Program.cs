using Digital.Diary.Configurations;
using Digital.Diary.Databases.Data;
using Digital.Diary.Models.AuthModels;
using Digital.Diary.Repositories.Abstractions.Base;
using Digital.Diary.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Services
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString"));
//});

//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
ConfigurationSettings.ConfigurationResolve(builder.Services);

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
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();