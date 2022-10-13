using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TraderJoes.Models;
using System.Collections.Generic;
using System.Linq;

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
      Cart thisCart = _db.Carts.FirstOrDefault(cart => cart.CartId == id);
      return View(thisCart);
    }
    public ActionResult Edit(int id)
    {
      var thisCart = _db.Carts.FirstOrDefault(cart => cart.CartId == id);
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
      var thisCart = _db.Carts.FirstOrDefault(cart => cart.CartId == id);
      return View(thisCart);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCart = _db.Carts.FirstOrDefault(cart => cart.CartId == id);
      _db.Carts.Remove(thisCart);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}