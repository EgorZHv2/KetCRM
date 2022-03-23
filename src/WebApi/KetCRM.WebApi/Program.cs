using KetCRM.Infrastructure.Persistence.ContextDb;
using KetCRM.Application.Common.Interfaces;
using KetCRM.Infrastructure.Persistence;
using AutoMapper;
using System.Reflection;
using KetCRM.Application.Common.Mapping;
using KetCRM.Application;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new MappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new MappingProfile(typeof(IApplicationDbContext).Assembly));
});
var app = builder.Build();

using(var Scope = app.Services.CreateScope())
{
    var Provider = Scope.ServiceProvider;
    try
    {
        var context = Provider.GetRequiredService<ApplicationDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception exception)
    {
        var logger = Provider.GetRequiredService<ILogger<Program>>();
        logger.LogError(exception, "An error occured while database initialization");
    }
}

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
