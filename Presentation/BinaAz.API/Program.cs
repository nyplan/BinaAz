using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using BinaAz.API.Configurations.ColumnWriters;
using BinaAz.API.Extensions;
using BinaAz.Application;
using BinaAz.Application.DTOs.User;
using BinaAz.Infrastructure;
using BinaAz.Persistence;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Sinks.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices();

Logger log = new LoggerConfiguration()
    .WriteTo.File("logs/log.txt")
    .WriteTo.PostgreSQL(builder.Configuration.GetConnectionString("PostgreSQL"), "logs", needAutoCreateTable: true,
        columnOptions: new Dictionary<string, ColumnWriterBase>
        {
            { "message", new RenderedMessageColumnWriter() },
            { "message_template", new MessageTemplateColumnWriter() },
            { "level", new LevelColumnWriter() },
            { "time_stamp", new TimestampColumnWriter() },
            { "exception", new ExceptionColumnWriter() },
            { "log_event", new LogEventSerializedColumnWriter() },
            { "user_name", new UsernameColumnWriter() }
        })
    .Enrich.FromLogContext()
    .MinimumLevel.Error()
    .CreateLogger();
builder.Host.UseSerilog(log);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateUser>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
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
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Token:Issuer"],
        ValidAudience = builder.Configuration["Token:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"]!)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        NameClaimType = ClaimTypes.Name,
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler(app.Services.GetRequiredService<ILogger<Program>>());
app.UseStaticFiles();

app.UseSerilogRequestLogging();

app.UseHttpLogging();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Use(async (context, next) =>
{
    var username = context.User.Identity?.Name;
    LogContext.PushProperty("user_name", username);
    await next();
});

app.MapControllers();

app.Run();