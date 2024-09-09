namespace katchrApp.Models
{
  public class LineItem
  {
    public string? Item { get; set; }
    public string? Description { get; set; }
    public int Quantity { get; set; } = 0;
    public string? Classification { get; set; }
    public string Origin { get; set; } = "Domestic";
    public decimal Cost { get; set; } = 0.00M;
  }
}
