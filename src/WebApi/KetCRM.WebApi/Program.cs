using KetCRM.Account.Data;
using KetCRM.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();       
var loggerConfig = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
builder.Logging.AddSerilog(loggerConfig);

var config = builder.Configuration;


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(config.GetConnectionString("IdentityConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.SaveToken = false;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = config["JwtIssuer"],
            ValidAudience = config["JwtAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSecurityKey"]))
        };
    });

builder.Services.AddMvc().AddNewtonsoftJson();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

var app = builder.Build();


using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception exception)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(exception, "������ ������������� ���� ������");
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
