namespace FlyApp.Entities;

public class Flight
{
    public int Id {
        get;
        set;
    }

    public decimal Price { get; set; }
    public DateTime Date { get; set; }
    public int Quantity { get; set; }
}