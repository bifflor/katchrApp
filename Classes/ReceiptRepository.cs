using katchrApp.Models;

namespace katchrApp.Classes
{
  public class ReceiptRepository
  {
    #region sampleData
    // Sample data added here. This class mocks the Data Access Layer / Data Transfer Object / Data Access Object (DAL / DTO / DAO) methods.

    // The shopping basket data scenarios
    private static readonly List<LineItem> BasketOne = new List<LineItem>
    {
      new() { Item = "Book"         , Description = "book"         , Quantity = 1, Classification = "Book" , Origin = "Domestic", Cost = 12.49M },
      new() { Item = "Music CD"     , Description = "music CD"     , Quantity = 1, Classification = "Music", Origin = "Domestic", Cost = 14.99M },
      new() { Item = "Chocolate Bar", Description = "chocolate bar", Quantity = 1, Classification = "Food" , Origin = "Domestic", Cost =  0.85M },
    };

    private static readonly List<LineItem> BasketTwo = new List<LineItem>
    {
      new() { Item = "Chocolate Box", Description = "box of chocolates", Quantity = 1, Classification = "Food"     , Origin = "Foreign", Cost = 10.00M },
      new() { Item = "Perfume"      , Description = "bottle of perfume", Quantity = 1, Classification = "Fragrance", Origin = "Foreign", Cost = 47.50M }
    };

    private static readonly List<LineItem> BasketThree = new List<LineItem>
    {
      new() { Item = "Perfume"      , Description = "bottle of perfume"       , Quantity = 1, Classification = "Fragrance", Origin = "Foreign" , Cost = 27.99M },
      new() { Item = "Perfume"      , Description = "bottle of perfume"       , Quantity = 1, Classification = "Fragrance", Origin = "Domestic", Cost = 18.99M },
      new() { Item = "Paracetamol"  , Description = "packet of headache pills", Quantity = 1, Classification = "Medical"  , Origin = "Domestic", Cost =  9.75M },
      new() { Item = "Chocolate Box", Description = "box of chocolates"       , Quantity = 1, Classification = "Food"     , Origin = "Foreign" , Cost = 11.25M }
    };
    #endregion sampleData

    public IEnumerable<LineItem> GetBasket(int basketNumber)
    {
      switch (basketNumber)
      {
        case 1:
          return BasketOne;
        case 2:
          return BasketTwo;
        case 3:
          return BasketThree;
        default:
          return BasketOne;
      };
    }
  }
}
