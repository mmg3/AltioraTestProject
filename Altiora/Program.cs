using Altiora.Contexts;
using Altiora.Dtos;
using Altiora.Repositories;
using Altiora.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var CorsPolicy = "CorsPolicy";
var allowedHosts = builder.Configuration.GetSection("AllowedDomains").Get<string[]>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsPolicy,
                        polBuilder =>
                            polBuilder.WithOrigins(allowedHosts)
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AltioraContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<GeneralResponseDto>();

builder.Services.AddScoped<IClientRepository,ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(CorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
