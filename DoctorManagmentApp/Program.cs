using AutoMapper;
using DoctorManagmentApp.Configurations;
using DoctorManagmentApp.Data;
using DoctorManagmentApp.Helpers;
using DoctorManagmentApp.Middleware;
using DoctorManagmentApp.Model.AutoMapper;
using DoctorManagmentApp.Model.Dto;
using DoctorManagmentApp.Services;
using DoctorManagmentApp.Services.Interface;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDbConnection"));
    options.UseInMemoryDatabase(databaseName: "DoctorManagmentDb");
});

builder.Services.AddCors();

#region Dependency Injection

builder.Services.AddHttpClient();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddSingleton(typeof(ApiHelper<>));

#endregion

#region FluentValidation

builder.Services.AddScoped<IValidator<PatientDtoNoPK>, PatientDtoNoPKValidator>();

#endregion


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Auto Mapper

// Auto Mapper Configurations
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion

#region AppSettings

builder.Services.Configure<AppSettings>(builder.Configuration);

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// TODO: add more restriction to this to only allow the specific Origin
app.UseCors(o => o.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().WithExposedHeaders("*"));

app.UseMiddleware<ExceptionMiddleware>();

// TODO: implement Authentication to protect the api
//app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
