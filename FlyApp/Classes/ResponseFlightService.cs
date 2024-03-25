using FlyApp.Services;

namespace FlyApp.Classes;

public class ResponseFlightService
{
    public int searchId { get; set; }
    public List<PricedItinerary> pricedItineraries { get; set; }
    public AdditionalData additionalData { get; set; }
    public string airTripType { get; set; }
    public string airTripTypeStr { get; set; }
    public int traceId { get; set; }
}