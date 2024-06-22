using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using pos_service_api.Models;
using pos_service_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// depedency injection
builder.Services.AddDbContext<PosDbContext>(options => options.UseSqlServer("DefaultConnection", providerOptions => { providerOptions.CommandTimeout(180); }));
// service
builder.Services.AddScoped<CutoffReportTaspenSaveService>();
builder.Services.AddScoped<CutoffReportCreditLifeService>();
builder.Services.AddScoped<CutoffReportTGASarihusadaService>();
builder.Services.AddScoped<CutoffReportPerPolicyService>();



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
