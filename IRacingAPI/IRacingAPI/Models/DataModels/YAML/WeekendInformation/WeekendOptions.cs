namespace IRacingAPI.Models.DataModels.YAML.WeekendInformation ;
public class WeekendOptions
{
    public long NumStarters { get; set; }

    public string? StartingGrid { get; set; }

    public string? QualifyScoring { get; set; }

    public string? CourseCautions { get; set; }

    public long StandingStart { get; set; }

    public long ShortParadeLap { get; set; }

    public string? Restarts { get; set; }

    public string? WeatherType { get; set; }

    public string? Skies { get; set; }

    public string? WindDirection { get; set; }

    public string? WindSpeed { get; set; }

    public string? WeatherTemp { get; set; }

    public string? RelativeHumidity { get; set; }

    public string? FogLevel { get; set; }

    public string? TimeOfDay { get; set; }
    public DateTimeOffset Date { get; set; }
    public long EarthRotationSpeedupFactor { get; set; }
    public long Unofficial { get; set; }
    public string? CommercialMode { get; set; }
    public string? NightMode { get; set; }
    public long IsFixedSetup { get; set; }
    public string? StrictLapsChecking { get; set; }
    public long HasOpenRegistration { get; set; }
    public long HardcoreLevel { get; set; }
    public long NumJokerLaps { get; set; }
    public string? IncidentLimit { get; set; }
    public string? FastRepairsLimit { get; set; }
    public long GreenWhiteCheckeredLimit { get; set; }
}
