# Options Pattern

## 1 Configuration Concepts

`Section1:SubSection1:KeyA = "a val"`

inject `IConfiguration` ... `_configuration.GetValue<bool>("Features:Homepage:EnableX")`

or get the section `var section = _configuration.GetSection("Features:Homepage")` ... `section.GetValue<bool>("EnableX")`

### At startup

ctor takes IConfiguration.

`services.Configure<ClubConfiguration>(config.GetSection("ClubSettings"));` load section into matching class.

```c#
public static class WeatherServiceCollectionExtensions
{
    public static IServiceCollection AddWeatherForecasting(this IServiceCollection services, IConfiguration config)
    {
        if (config.GetValue<bool>("Features:WeatherForecasting:EnableWeatherForecast"))
        {
            services.AddHttpClient<IWeatherApiClient, WeatherApiClient>();
            services.TryAddSingleton<IWeatherForecaster, WeatherForecaster>();
            services.Decorate<IWeatherForecaster, CachedWeatherForecaster>();
        }
        else
        {
            services.TryAddSingleton<IWeatherForecaster, DisabledWeatherForecaster>();
        }

        return services;
    }
}
```

## 2 Options Pattern

Binding configuration to strongly typed option classes (like the simple Configuration pattern in .net, but with extra features)

`IOptions<T>`

`IOptionsSnapshot<T>`

`IOptionsMonitor<T>`

### IOptions (registers Singletons)

pop configuration class: `services.Configure<HomePageConfiguration>(config.GetSection("Features:HomePage"));`

replace `IConfiguration` in ctor with specific config class (cleaner as no unused props).

```c#
public IndexModel(IOptions<HomePageConfiguration> options) {
    _homePageConfig = options.Value;
}
```

### IOptionsSnapshot (registers scoped (once per request))

Automatic reloading when underlying values changes (eg: live modification of appSettings)

```c#
public IndexModel(IOptionsSnapshot<HomePageConfiguration> options) {
    _homePageConfig = options.Value;
}
```

### IOptionsMonitor

module scenario: error as can't inject an IOptionsSnapshot (scoped) into the custom GreetingService (singleton).

`IOptionsMonitor` is a singleton too, so can be used instead

```c#
private GreetingConfiguration _greetingConfiguration;
//private readonly IOptionsMonitor<GreetingConfiguration> _greetingConfiguration;

public GreetingService(
    IWebHostEnvironment webHostEnvironment, 
    ILogger<GreetingConfiguration> logger, 
    IOptionsMonitor<GreetingConfiguration> options)
{    
    _greetingConfiguration = options.CurrentValue;
    options.OnChange(config =>
    {
        _greetingConfiguration = config;
        logger.LogInformation("The greeting configuration has been updated.");
    }); // dispose?
}
public string GreetingColour => _greetingConfiguration.GreetingColour;
```

### named options

load different sections into same class (otherwise have to make different named classes that are the same)

```c#
services.Configure<ExternalServicesConfig>(ExternalServicesConfig.WeatherApi, Configuration.GetSection("ExternalServices:WeatherApi"));
services.Configure<ExternalServicesConfig>(ExternalServicesConfig.ProductsApi, Configuration.GetSection("ExternalServices:ProductsApi"));
```

IOptions can't cope with this. Instead

```c#
public WeatherApiClient(HttpClient httpClient, IOptionsMonitor<ExternalServicesConfig> options, ILogger<WeatherApiClient> logger)
{
    var externalServiceConfig = options.Get(ExternalServicesConfig.WeatherApi); // or options.Get("WeatherApi");

    httpClient.BaseAddress = new Uri(externalServiceConfig.Url);

    _httpClient = httpClient;
    _logger = logger;
}
```

### Options Validation

meh

## ref

[https://docs.microsoft.com/en-us/dotnet/core/extensions/options]
