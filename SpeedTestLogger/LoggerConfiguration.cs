using System;
using System.Globalization;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace SpeedTestLogger;

// Omitting namespace
public class LoggerConfiguration
{
    // readonly so only the constructor in LoggerConfiguration can access it
    public readonly RegionInfo LoggerLocation;
    public readonly Uri ApiUrl;
    public readonly string UserId;
    public readonly int LoggerId;

    public LoggerConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        var configuration = builder.Build();

        ApiUrl = new Uri(configuration["speedTestApiUrl"]);

        var countryCode = configuration["loggerLocationCountryCode"];
        LoggerLocation = new RegionInfo(countryCode);

        Console.WriteLine("Logger located in {0}", LoggerLocation.EnglishName);
        
        UserId = configuration["userId"];
        LoggerId = int.Parse(configuration["loggerId"]);
        LoggerLocation = new RegionInfo(configuration["loggerLocationCountryCode"]);
    }

}