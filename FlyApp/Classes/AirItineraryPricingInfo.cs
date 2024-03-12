namespace FlyApp.Classes;

public class AirItineraryPricingInfo
{
    public string fareType { get; set; }
    public ItinTotalFare itinTotalFare { get; set; }
    public List<PtcFareBreakdown> ptcFareBreakdown { get; set; }
    public List<object> fareInfoes { get; set; }
}