using Academic_Blog.Domain;
using Academic_Blog.Middlewares;
using Academic_Blog.Repository.Implement;
using Academic_Blog.Repository.Interfaces;
using Academic_Blog.Services.Implements;
using Academic_Blog.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.   

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo() { Title = "Blog System", Version = "v1" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
      {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
      });
    options.MapType<TimeOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "time",
        Example = OpenApiAnyFactory.CreateFromJson("\"13:45:42.0000000\"")
    });
});
builder.Services.AddDbContext<AcademicBlogContext>();
builder.Services.AddScoped<IUnitOfWork<AcademicBlogContext>,UnitOfWork<AcademicBlogContext>>();
builder.Services.AddControllers(opt => opt.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true).AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyDefaultPolicy",
        policy => { policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod(); });
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAccountService, AccountService>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.UseCors("MyDefaultPolicy");
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.Run();
