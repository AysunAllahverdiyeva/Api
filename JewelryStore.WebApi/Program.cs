
using JewelryStore.Application;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using JewelryStore.Application.Validators.FluentValidations;

using JawelryStore.Persistance;
using System.Net;
using System.Text.Json;
using JobSearchManagementSystem.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register other services like persistence, application services, authentication, etc.
builder.Services.AddPersistanceServices(builder.Configuration);
builder.Services.AddApplicationServices();

// Configure FluentValidation.
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateUserCommandValidator>())
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull; // Optional
    });

// Configure JWT authentication.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c")),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };
    });

// Configure Swagger/OpenAPI.
builder.Services.AddSwaggerGen(options =>
{
    var basicSecurityScheme = new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    options.AddSecurityDefinition(basicSecurityScheme.Reference.Id, basicSecurityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { basicSecurityScheme, Array.Empty<string>() }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add the built-in exception handling middleware
//app.UseExceptionHandler(options =>
//{
//    options.Run(async context =>
//    {
//        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//        context.Response.ContentType = "application/json";

//        var ex = context.Features.Get<IExceptionHandlerFeature>();
//        if (ex != null)
//        {
//            var result = JsonSerializer.Serialize(new { error = ex.Error.Message });
//            await context.Response.WriteAsync(result);
//        }
//    });
//});

// If you're using custom exception handling middleware, it should come after the built-in handler
// app.UseMiddleware<ExceptionHandlerMiddleware>();

// Authentication & Authorization Middleware
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ExceptionHandlerMiddleware>();

// Map controllers to endpoints.
app.MapControllers();

app.Run();
