namespace katchrApp.Models
{
  public class Receipt : LineItem
  {
    public decimal BasicTax { get; set; } = 0.00M;
    public decimal ImportDuty { get; set; } = 0.00M;
    public decimal Total { get; set; } = 0.00M;
    public decimal SalesTax { get; set; } = 0.00M;
  }
}
