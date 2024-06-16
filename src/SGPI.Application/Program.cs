using System.Reflection;
using SGPI.Application;
using SGPI.Application.Common;
using SGPI.Application.Infrastructure;
using SGPI.Application.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSingleton(TimeProvider.System);
builder.Services
    .AddEndpointsApiExplorer()
    .AddNpgSql(builder
        .Configuration
        .GetConnectionString(Config.ConnectionStringAppDb))
    .AddMediatR(config => config
        .RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()))
    .AddSwaggerGen();

builder
    .Services
    .AddScoped<IFinancialProductRepository, FinancialProductRepository>()
    .AddSingleton<IProductCodeGenerator, ProductCodeGenerator>()
    .AddScoped<IFinancialProductTransactionRepository, FinancialProductTransactionRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(settings =>
    {
        settings.SwaggerEndpoint(Config.UrlSwagger, Config.NameApplication);
        settings.RoutePrefix = Config.RouteDocs;
    });
    app.MapRedirectToDocs();
}

app.MapEndpoints();
app.Run();