using katchrApp.Models;

namespace katchrApp.Classes
{
  public class ReceiptService
  {
    private static readonly string[] basicTaxExemptions  = { "Book", "Food", "Medical" };
    private static readonly string[] itemClassifications = { "Book", "Food", "Fragrance", "Medical", "Music" };
    private const decimal basicTaxRate = 0.1M;
    private const decimal importDutyRate = 0.05M;
    private const decimal roundingValue = 20.0M;

    private decimal ApplyRounding(decimal value)
    {
      // round up to the nearest 0.05p
      decimal roundedValue = Math.Ceiling(value * roundingValue) / roundingValue;

      return roundedValue;
    }


    private void ApplyBasicTax(IEnumerable<Receipt> receipt)
    {
      // apply basic tax where an item is not in the exemption list, ie. = FALSE 
      foreach (var item in receipt.Where(t => (basicTaxExemptions.Contains(t.Classification) == false)))
      {
        item.BasicTax = ApplyRounding(item.Cost * basicTaxRate);
      };
    }


    private void ApplyImportDuty(IEnumerable<Receipt> receipt)
    {
      // apply import duty where item Origin = Foreign
      foreach (var item in receipt.Where(t => t.Origin == "Foreign"))
      {
        item.ImportDuty = ApplyRounding(item.Cost * importDutyRate);
      };
    }


    private void CalculateTotals(IEnumerable<Receipt> receipt)
    {
      // calculate tootal cost and sales taxes per item
      foreach (var item in receipt)
      {
        item.Total = item.Cost + item.BasicTax + item.ImportDuty;
        item.SalesTax = item.BasicTax + item.ImportDuty;
      };
    }


    public IEnumerable<LineItem> GetBasket(int basketNumber)
    {
      var receiptDAO = new ReceiptRepository();

      var basket = receiptDAO.GetBasket(basketNumber);

      return basket;
    }


    public decimal GetTotalCost(IEnumerable<Receipt> receipt)
    {
      // calculate Total cost
      decimal totalCost = receipt.Sum(item => item.Total);

      return totalCost;
    }


    public decimal GetTotalSalesTax(IEnumerable<Receipt> receipt)
    {
      // calculate total sales taxes
      decimal totalSalesTax = receipt.Sum(item => item.SalesTax);

      return totalSalesTax;
    }


    public IEnumerable<Receipt> AnalyzeBasket(IEnumerable<LineItem> basket)
    {
      // copy the basket items to the sales receipt and then analyze
      var receipt = basket.Select(item => new Receipt
      {
        Item = item.Item,
        Description = item.Description,
        Quantity = item.Quantity,
        Classification = item.Classification,
        Origin = item.Origin,
        Cost = item.Cost
      }).ToList();

      this.ApplyBasicTax(receipt);

      this.ApplyImportDuty(receipt);

      this.CalculateTotals(receipt);

      return receipt;
    }
  }
}
