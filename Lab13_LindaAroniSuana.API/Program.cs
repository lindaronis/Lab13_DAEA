using Lab13_LindaAroniSuana.Application.Features.Reports.Queries;
using Lab13_LindaAroniSuana.Application.Interfaces;
using Lab13_LindaAroniSuana.Infrastructure.Context;
using Lab13_LindaAroniSuana.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 👇 Esto asegura que Render detecte correctamente el puerto
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(int.Parse(port));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(ExportClientOrdersReportQuery).Assembly);
builder.Services.AddScoped<IReportRepository, ReportRepository>();

builder.Services.AddDbContext<Lab13DbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

// 👇 Ejecutar app
app.Run();
