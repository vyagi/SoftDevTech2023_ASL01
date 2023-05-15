using Newtonsoft.Json.Linq;

namespace AdapterPattern;

public class Detector
{
    private readonly IThermometer _thermometer;

    public Detector(IThermometer thermometer) => 
        _thermometer = thermometer;

    public Decision GetDecision() =>
        _thermometer.GetTemperature() switch
        {
            <-5 => Decision.TooCold,
            >25 => Decision.TooHot,
            _ => Decision.JustRight
        };
}

public class InternetThermometerAdapter : IThermometer
{
    private readonly InternetThermometer _internetThermometer;

    public InternetThermometerAdapter(InternetThermometer internetThermometer) => 
        _internetThermometer = internetThermometer;

    public double GetTemperature()
    {
        var temperature = double.Parse(_internetThermometer.Themperature.Replace(".", ","));

        return temperature - 273.15;
    }
}

//3-rd party library
public class InternetThermometer
{
    private static readonly HttpClient Client = new();

    public InternetThermometer() => Client.BaseAddress = new Uri("http://api.openweathermap.org/");

    public string Themperature =>
        ((dynamic)JObject.Parse(Client.GetAsync("data/2.5/weather?q=Rzeszow&appid=ccef0127848996431ec751a199c5f956")
            .Result.Content.ReadAsStringAsync()
            .Result))["main"]["temp"];
}

public class MercuryThermometer : IThermometer
{
    private static readonly Random Generator = new();
    
    public double GetTemperature() => Generator.NextDouble() * 100 - 50;
}

public interface IThermometer
{
    double GetTemperature();
}

public enum Decision
{
    TooCold,
    JustRight,
    TooHot
}