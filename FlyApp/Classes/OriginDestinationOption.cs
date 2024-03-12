namespace FlyApp.Classes;

public class OriginDestinationOption
{
    public int journeyDurationPerMinute { get; set; }
    public int connectionTimePerMinute { get; set; }
    public List<FlightSegment> flightSegments { get; set; }
}