namespace FlyApp.Classes;

public class PricedItinerary
{
    public string passportMandatoryType { get; set; }
    public string domesticCountryCode { get; set; }
    public bool isPassportMandatory { get; set; }
    public bool isDestinationAddressMandatory { get; set; }
    public bool isPassportIssueDateMandatory { get; set; }
    public int directionInd { get; set; }
    public string refundMethod { get; set; }
    public string validatingAirlineCode { get; set; }
    public string fareSourceCode { get; set; }
    public bool hasFareFamilies { get; set; }
    public AirItineraryPricingInfo airItineraryPricingInfo { get; set; }
    public List<OriginDestinationOption> originDestinationOptions { get; set; }
    public object featured { get; set; }
    public int bestExperienceIndex { get; set; }
    public bool isCharter { get; set; }
    public bool isSystem { get; set; }
    public bool isInstance { get; set; }
    public bool isOffer { get; set; }
    public bool isSeatServiceMandatory { get; set; }
    public bool isMealServiceMandatory { get; set; }
    public bool hasAmenities { get; set; }
    public string sellingStrategy { get; set; }
    public List<object> visaRequirements { get; set; }
}