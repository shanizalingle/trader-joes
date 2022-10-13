using Microsoft.AspNetCore.Mvc;
using TraderJoes.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TraderJoes.Controllers
{
  public class CartsController : Controller
  {
    private readonly TraderJoesContext _db;

    public CartsController(TraderJoesContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Cart> model = _db.Carts.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Cart cart)
    {
      _db.Carts.Add(cart);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisCart = _db.Carts
        .Include(cart => cart.JoinProdCart)
        .ThenInclude(join => join.Product)
        .FirstOrDefault(cart => cart.CartId == id);
      return View(thisCart);
    }

    public ActionResult Edit(int id)
    {
      Cart thisCart = _db.Carts.FirstOrDefault(cart => cart.CartId == id);
      return View(thisCart);
    }

    [HttpPost]
    public ActionResult Edit(Cart cart)
    {
      _db.Entry(cart).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Cart thisCart = _db.Carts.FirstOrDefault(cart => cart.CartId == id);
      return View(thisCart);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Cart thisCart = _db.Carts.FirstOrDefault(cart => cart.CartId == id);
      _db.Carts.Remove(thisCart);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}