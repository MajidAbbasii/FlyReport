namespace FlyApp.Classes;

public class PassengerFare
{
    public int baseFare { get; set; }
    public int totalFare { get; set; }
    public int serviceTax { get; set; }
    public List<object> taxes { get; set; }
    public int total { get; set; }
    public int tax { get; set; }
    public int vat { get; set; }
    public int baseFareWithMarkup { get; set; }
    public int totalFareWithMarkupAndVat { get; set; }
    public int commission { get; set; }
    public int priceCitizen { get; set; }
    public List<object> surcharge { get; set; }
}