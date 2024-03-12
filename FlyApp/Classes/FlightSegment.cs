namespace FlyApp.Classes;

public class FlightSegment
{
    public DateTime departureDateTime { get; set; }
    public DateTime arrivalDateTime { get; set; }
    public int stopQuantity { get; set; }
    public string flightNumber { get; set; }
    public string resBookDesigCode { get; set; }
    public string journeyDuration { get; set; }
    public int journeyDurationPerMinute { get; set; }
    public int connectionTimePerMinute { get; set; }
    public string departureAirportLocationCode { get; set; }
    public string arrivalAirportLocationCode { get; set; }
    public string marketingAirlineCode { get; set; }
    public string cabinClassCode { get; set; }
    public string cabinClassName { get; set; }
    public string cabinClassNameFa { get; set; }
    public OperatingAirline operatingAirline { get; set; }
    public int seatsRemaining { get; set; }
    public bool isCharter { get; set; }
    public bool isReturn { get; set; }
    public string baggage { get; set; }
    public string baggageFa { get; set; }
    public List<object> technicalStops { get; set; }
    public List<object> flightAmenities { get; set; }
}