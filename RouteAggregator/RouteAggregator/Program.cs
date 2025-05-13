using RouteAggregator.Model;
using RouteAggregator.Model.Services;
using RouteAggregator.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddTransient<IApplicationConfiguration, ApplicationConfiguration>();
builder.Services.AddTransient<IRouteAggregatorService, RouteAggregatorService>();
builder.Services.AddTransient<IRouteProvider, Flight1Provider>();
builder.Services.AddTransient<IRouteProvider, Flight2Provider>();

builder.Services.AddMvc()
    .AddControllersAsServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();