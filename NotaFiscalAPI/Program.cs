using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NotaFiscalAPI.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("NfConnection");

// Add services to the container.
builder.Services.AddDbContext<ClienteContext>(opts =>
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddDbContext<EnderecoContext>(opts =>
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddDbContext<PedidoContext>(opts =>
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddDbContext<NotaFiscalContext>(opts =>
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Add AutoMapper to the project
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Swagger documentation
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NotaFiscalAPI", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
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
