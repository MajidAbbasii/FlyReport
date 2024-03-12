namespace FlyApp.Classes;

public class ItinTotalFare
{
    public int totalService { get; set; }
    public int totalFare { get; set; }
    public int grandTotalWithoutDiscount { get; set; }
    public object discountAmount { get; set; }
    public int totalVat { get; set; }
    public int totalTax { get; set; }
    public int totalServiceTax { get; set; }
    public int totalCommission { get; set; }
    public int totalSurcharge { get; set; }
}