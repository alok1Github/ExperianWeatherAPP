using Experian.API.ExceptionHandlers;
using Experian.API.Features.City;
using Experian.API.Features.Weather;
using Experian.API.Filters;
using Experian.API.Interface;
using Experian.API.Model;
using Experian.API.Request;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);


// Weather Injection
builder.Services.AddScoped<IAppSettings<WeatherConfigRequest>, WeatherAppSettings>();
builder.Services.AddScoped<IAPIGetService<WeatherModel>, WeatherService>();
builder.Services.AddScoped<IGet<WeatherRequest, WeatherModel>, GetWeather>();
builder.Services.AddScoped<IURI<WeatherConfigRequest, WeatherRequest>, WeatherURIBuilder>();

// City Injection
builder.Services.AddScoped<IAppSettings<CityConfigRequest>, CityAppSettings>();
builder.Services.AddScoped<IAPIGetService<CityModel>, CityService>();
builder.Services.AddScoped<IGet<CityRequest, CityModel>, GetCitiesByCountryCode>();
builder.Services.AddScoped<IURI<CityConfigRequest, CityRequest>, CityURIBuilder>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// HttpLogging
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
});

// Enable Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                                              .AllowAnyHeader()
                                              .AllowAnyMethod();
        });
});

// Filters
builder.Services.AddControllersWithViews(options =>
    options.Filters.Add<ValidationFilter>()
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpLogging();

app.UseCors("AllowOrigin");

app.UseHttpsRedirection();

// Excetion handler 
app.UseMiddleware(typeof(GlobalErrorHandler));

// To Do : apply the security for api

app.UseAuthorization();

app.MapControllers();

app.Run();
