using Microsoft.AspNetCore.Mvc;

namespace TraderJoes.Controllers
{
  public class HomeController : Controller
  {

    // [HttpGet("/")]
    // public ActionResult Start()
    // {
    //   return View();
    // }

    // [HttpPost]
    // public ActionResult Start(Cart cart)
    // {
    //   _db.Cart.Add(cart);
    //   _db.SaveChanges();
    //   return RedirectToAction("Index");
    // }

    [HttpGet("/home")]
    public ActionResult Index()
    {
      return View();
    }
  }
}