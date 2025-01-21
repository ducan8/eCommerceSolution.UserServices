using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middleware;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//Add services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

// Add controllers to the service collection
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())); // add json serialize at controller level because model binding occur before execute controller

builder.Services.AddAutoMapper(typeof(AppUserMappingProfile).Assembly);

builder.Services.AddFluentValidationAutoValidation();

//Build the web app
var app = builder.Build();


app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
