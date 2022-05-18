using CoursesManagementService.Models;
using CoursesManagementService.Models.Domain;
using CoursesManagementService.Processors;
using CoursesManagementService.Processors.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDb.Models;
using MongoDb.Repository;
using MongoDb.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection(nameof(MongoDbSettings)));

builder.Services.TryAddSingleton<IMongoConnection, MongoConnection>();
builder.Services.TryAddSingleton<IRepository<CourseDomain>, Repository<CourseDomain>>();
builder.Services.TryAddSingleton<IRepository<UserAssignmentDomain>, Repository<UserAssignmentDomain>>();

builder.Services.TryAddScoped<ICourseProcessor, CourseProcessor>();
builder.Services.TryAddScoped<ICourseAssignmentsProcessor, CourseAssignmentsProcessor>();

// add more Api configuration
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true).AddNewtonsoftJson();
builder.Services.AddCors();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// set app middlewares
app.UseCors(options =>
{
    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
});

app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.Run();
