using System.Text.Json.Serialization;

namespace AmazonPayHttpClient.Contracts;

/// <summary>
/// Report Types
/// </summary>
//[JsonConverter(typeof(StringEnumConverter))]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ScheduleFrequency
{
    /// <summary>
    /// Every 5 minutes.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    PT5M,

    /// <summary>
    /// Every 15 minutes.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    PT15M,

    /// <summary>
    /// Every 30 minutes.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    PT30M,

    /// <summary>
    /// Every hour.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    PT1H,

    /// <summary>
    /// Every 2 hours.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    PT2H,

    /// <summary>
    /// Every 4 hours.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    PT4H,

    /// <summary>
    /// Every 8 hours.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    PT8H,

    /// <summary>
    /// Every 12 hours.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    PT12H,

    /// <summary>
    /// Every 24 hours.
    /// </summary>
    // ReSharper disable once InconsistentNaming

    PT24H,
        
    /// <summary>
    /// Every 84 hours.
    /// </summary>
    // ReSharper disable once InconsistentNaming

    PT84H,

    /// <summary>
    /// Every day.
    /// </summary>
    // ReSharper disable once InconsistentNaming

    P1D,

    /// <summary>
    /// Every 2 days.
    /// </summary>
    // ReSharper disable once InconsistentNaming

    P2D,

    /// <summary>
    /// Every 3 days.
    /// </summary>
    // ReSharper disable once InconsistentNaming

    P3D,

    /// <summary>
    /// Every 7 days.
    /// </summary>
    // ReSharper disable once InconsistentNaming

    P7D,


    /// <summary>
    /// Every 14 days.
    /// </summary>
    // ReSharper disable once InconsistentNaming

    P14D,     


    /// <summary>
    /// Every 15 days.
    /// </summary>
    // ReSharper disable once InconsistentNaming

    P15D,


    /// <summary>
    /// Every 18 days.
    /// </summary>
    // ReSharper disable once InconsistentNaming

    P18D,


    /// <summary>
    /// Every 30 days.
    /// </summary>
    // ReSharper disable once InconsistentNaming

    P30D       
}