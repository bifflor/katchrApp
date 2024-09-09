using Microsoft.AspNetCore.Mvc;
using katchrApp.Classes;
using katchrApp.Models;

namespace katchrApp.Controllers
{
  public class IndexController : Controller
  {
    // GET: IndexController
    public ActionResult Index()
    {
      var receiptService = new ReceiptService();
      int dataSet = 1;

      this.GetBasket(dataSet);

      return View();
    }


    // GET: IndexController/GetBasket/id
    public ActionResult GetBasket(int basket)
    {
      var receiptService = new ReceiptService();

      IEnumerable<Receipt> receipt = receiptService.AnalyzeBasket(receiptService.GetBasket(basket)).ToList();

      decimal totalCost = receiptService.GetTotalCost(receipt);
      decimal totalSalesTax = receiptService.GetTotalSalesTax(receipt);

      ViewData["DataSet"] = basket;
      ViewData["Receipt"] = receipt;
      ViewData["TotalCost"] = totalCost;
      ViewData["TotalTax"] = totalSalesTax;

      return View();
    }
  }
}
