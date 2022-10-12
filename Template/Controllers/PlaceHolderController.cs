using Microsoft.AspNetCore.Mvc;
using Template.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Template.Controllers
{
  public class PlaceHoldersController : Controller
  {
    private readonly TemplateContext _db;

    public PlaceHoldersController(TemplateContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<PlaceHolder> model = _db.PlaceHolders.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(PlaceHolder placeHolder)
    {
      _db.PlaceHolders.Add(placeHolder);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisPlaceHolder = _db.PlaceHolders
        .Include(placeHolder => placeHolder.JoinEntities)
        .ThenInclude(join => join.PlaceHolder2)
        .FirstOrDefault(placeHolder => placeHolder.PlaceHolderId == id);
      return View(thisPlaceHolder);
    }

    public ActionResult Edit(int id)
    {
      PlaceHolder thisPlaceHolder = _db.PlaceHolders.FirstOrDefault(placeHolder => placeHolder.PlaceHolderId == id);
      return View(thisPlaceHolder);
    }

    [HttpPost]
    public ActionResult Edit(PlaceHolder placeHolder)
    {
      _db.Entry(placeHolder).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      PlaceHolder thisPlaceHolder = _db.PlaceHolders.FirstOrDefault(placeHolder => placeHolder.PlaceHolderId == id);
      return View(thisPlaceHolder);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      PlaceHolder thisPlaceHolder = _db.PlaceHolders.FirstOrDefault(placeHolder => placeHolder.PlaceHolderId == id);
      _db.PlaceHolders.Remove(thisPlaceHolder);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}