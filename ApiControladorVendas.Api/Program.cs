using ApiControladorVendas.Aplicacao.Clientes;
using ApiControladorVendas.Clientes;
using ApiControladorVendas.Dominio.Clientes;
using ApiControladorVendas.Repositorio.Contextos;
using ApiControladorVendas.Repositorio.RepCad;
using ApiControladorVendas.Repositorio.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

static void RemoverInterfacesNaoInjetaveis(IServiceCollection services)
{
    var typesExcluir = new List<string>()
            {
                //"IRepCad<T>",               
            };

    var remover = services.Where(x => typesExcluir.Contains(x.ServiceType.Name)).ToList();
    foreach (var serviceDescriptor in remover)
    {
        services.Remove(serviceDescriptor);
    }
}

RemoverInterfacesNaoInjetaveis(builder.Services);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAplicCliente, AplicCliente>();
builder.Services.AddScoped<IRepCad<Cliente>, RepCad<Cliente>>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var connectionString = builder.Configuration.GetConnectionString("DataBase");
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<Contexto>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
