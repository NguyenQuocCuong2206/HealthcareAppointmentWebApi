using HealthcareAppointment.Business;
using HealthcareAppointment.Data;
using HealthcareAppointment.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using PraticeWebApi1.Data;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<HealthcareDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Converter enum to string
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonDateTimeConverter());
    });

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HealthcareAppointment API", Version = "v1" });
    c.MapType<UserDTO>(() => new OpenApiSchema
    {
        Properties =
        {
            ["name"] = new OpenApiSchema { Type = "string", Example = new OpenApiString("string") },
            ["email"] = new OpenApiSchema { Type = "string", Example = new OpenApiString("string") },
            ["dateOfBirth"] = new OpenApiSchema{Type = "string", Example = new OpenApiString("yyyy-mm-dd")},
            ["password"] = new OpenApiSchema { Type = "string", Example = new OpenApiString("string") },
            ["specialization"] = new OpenApiSchema { Type = "string", Example = new OpenApiString("string") }
        }
    });
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
