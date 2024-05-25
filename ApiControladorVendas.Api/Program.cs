using ApiControladorVendas.Api.Extencoes.Token;
using ApiControladorVendas.Aplicacao.Clientes;
using ApiControladorVendas.Aplicacao.Fornecedores;
using ApiControladorVendas.Aplicacao.ItemVendas;
using ApiControladorVendas.Aplicacao.Itens;
using ApiControladorVendas.Aplicacao.Usuarios;
using ApiControladorVendas.Aplicacao.Vendas;
using ApiControladorVendas.Clientes;
using ApiControladorVendas.Dominio.Account;
using ApiControladorVendas.Dominio.Clientes;
using ApiControladorVendas.Dominio.Fornecedores;
using ApiControladorVendas.Dominio.ItemVendas;
using ApiControladorVendas.Dominio.Itens;
using ApiControladorVendas.Dominio.Usuarios;
using ApiControladorVendas.Dominio.Usuarios.Validations;
using ApiControladorVendas.Dominio.Vendas;
using ApiControladorVendas.Repositorio.Authentications;
using ApiControladorVendas.Repositorio.Contextos;
using ApiControladorVendas.Repositorio.RepCad;
using ApiControladorVendas.Repositorio.UnitOfWork;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Globalization;
using System.Text;
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

builder.Services.AddValidatorsFromAssemblyContaining<Usuario>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddScoped<IAplicCliente, AplicCliente>();
builder.Services.AddScoped<IAplicFornecedor, AplicFornecedor>();
builder.Services.AddScoped<IAplicItemVenda, AplicItemVenda>();
builder.Services.AddScoped<IAplicItem, AplicItem>();
builder.Services.AddScoped<IAplicUsuario, AplicUsuario>();
builder.Services.AddScoped<IAplicVenda, AplicVenda>();

builder.Services.AddScoped<IRepCad<Cliente>, RepCad<Cliente>>();
builder.Services.AddScoped<IRepCad<Fornecedor>, RepCad<Fornecedor>>();
builder.Services.AddScoped<IRepCad<ItemVenda>, RepCad<ItemVenda>>();
builder.Services.AddScoped<IRepCad<Item>, RepCad<Item>>();
builder.Services.AddScoped<IRepCad<Usuario>, RepCad<Usuario>>();
builder.Services.AddScoped<IRepCad<Venda>, RepCad<Venda>>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IAuthenticate, AuthenticateService>();


var connectionString = builder.Configuration.GetConnectionString("DataBase");
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<Contexto>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,


        ValidIssuer = builder.Configuration["jwt:issuer"],
        ValidAudience = builder.Configuration["jwt:audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["jwt:secretKey"])),
        ClockSkew = TimeSpan.Zero
    };

    opt.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null && context.Request.Headers["Authorization"].ToString().StartsWith("Bearer "))
            {
                context.Token = token;
            }
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter JWT Bearer token **_only_**",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer", // Must be lower case
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, Array.Empty<string>() }
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseTokenVerification();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


var cultureInfo = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

app.Run();
