

using AutoMapper;
using IntranetCorrespondencia.api.Handlers;
using IntranetCorrespondencia.Repository.EFCore;
using MediatR;
using System.Reflection;
using Microsoft.OpenApi.Models;
using IntranetCorrespondencia.api.Middleware;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

#region Mapper
builder.Services.AddTransient<IMapper, Mapper>((services) =>
{
    MapperConfiguration mapperConfiguration = new MapperConfiguration(config =>
    {
        config.CreateMap<IntranetCorrespondencia.Entities.POCOs.Task, GetTaskResponse>();
        config.CreateMap<CreateTaskRequest, IntranetCorrespondencia.Entities.POCOs.Task>();
        config.CreateMap<IntranetCorrespondencia.Entities.POCOs.Task, CreateTaskResponse>();
    });
    return new Mapper(mapperConfiguration);
});
#endregion

#region DBContext Factory
builder.Services.AddDbContext(builder.Configuration, typeof(Program).Assembly.GetName().Name);
#endregion

#region Repository Factory
builder.Services.AddRepositories();
#endregion

#region MediatR y Fluent Validation
builder.Services.Configure<ApiBehaviorOptions>(options =>
    options.SuppressModelStateInvalidFilter = true);
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

builder.Services.AddMediatR(typeof(Program).Assembly);
#endregion

#region Swagger
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo {
        Title = "Intranet Corrrespondencia API",
        Version = "v1"
    });
});
#endregion

#region Routing
builder.Services.AddRouting(x =>
{
    x.LowercaseUrls = true;
    x.LowercaseQueryStrings = true;
});
#endregion

#region Versioning
builder.Services.AddApiVersioning();
builder.Services.AddVersionedApiExplorer(x =>
{
    x.GroupNameFormat = "'v'VVV";
    x.SubstituteApiVersionInUrl = true;
});
#endregion

var app = builder.Build();

#region Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "Intranet Correspondencia API");
    });
}
#endregion

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandling>();

app.UseAuthorization();

app.MapControllers();

app.Run();
