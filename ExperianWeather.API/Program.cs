using Experian.API.ExceptionHandlers;
using Experian.API.Features.Weather;
using Experian.API.Filters;
using Experian.API.Interface;
using Experian.API.Interface.Weather;
using Experian.API.Model;
using Experian.API.Request;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// generic injection 
builder.Services.AddScoped<IAppSettings<WeatherConfigRequest>, AppSettings>();
builder.Services.AddScoped<IAPIGetService<WeatherModel>, WeatherService>();

// Weather Injection
builder.Services.AddScoped<IGetWeather, GetWeather>();
builder.Services.AddScoped<IWeatherURI, WeatherURIBuilder>();


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
            builder.WithOrigins("http://api.weatherapi.com")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

// Filters
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<TempratureFilter>();
    options.Filters.Add<ValidationFilter>();
});


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

app.UseAuthorization();

app.MapControllers();

app.Run();
