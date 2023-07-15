using System.Text;
using APP_API.Data;
using APP_API.Interfaces;
using APP_API.Services;
using APP_API.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddDbContext<AppDbContext>(
//     opts =>
//     {
//         opts.UseLazyLoadingProxies().UseMySql(builder.Configuration.GetConnectionString("ConnectionPadrao"),
//                       new MySqlServerVersion(new Version(8, 0)));
//     });
builder.Services.AddDbContext<AppDbContext>(
    opts => 
    {
        opts.UseSqlServer(
            builder.Configuration.GetConnectionString("SqlServerConnection")
        );
    }

);
builder.Services.AddScoped<ITokenService , TokenService>();
builder.Services.AddScoped<IGerarIdentificadorService , GerarIdentificadorService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var key = Encoding.ASCII.GetBytes(Setting.ChaveSecreta);
builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
