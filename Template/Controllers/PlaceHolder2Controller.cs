using Microsoft.AspNetCore.Mvc;
using Template.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Template.Controllers
{
  public class PlaceHolder2sController : Controller
  {
    private readonly TemplateContext _db;

    public PlaceHolder2sController(TemplateContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<PlaceHolder2> sortedPlaceHolder2s = _db.PlaceHolder2s.OrderBy(placeHolder2 => placeHolder2.DueDate).ToList();
      return View(sortedPlaceHolder2s);
    }

    public ActionResult Create()
    {
      ViewBag.PlaceHolderId = new SelectList(_db.PlaceHolders, "PlaceHolderId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(PlaceHolder2 placeHolder2, int PlaceHolderId, bool Completed, DateTime DueDate)
    {
      _db.PlaceHolder2s.Add(placeHolder2);
      _db.SaveChanges();
      if (PlaceHolderId != 0)
      {
        _db.PlaceHolderPlaceHolder2.Add(new PlaceHolderPlaceHolder2() { PlaceHolderId = PlaceHolderId, PlaceHolder2Id = placeHolder2.PlaceHolder2Id });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisPlaceHolder2 = _db.PlaceHolder2s
        .Include(placeHolder2 => placeHolder2.JoinEntities)
        .ThenInclude(join => join.PlaceHolder)
        .FirstOrDefault(placeHolder2 => placeHolder2.PlaceHolder2Id == id);
      return View(thisPlaceHolder2);
    }

    public ActionResult Edit(int id)
    {
      PlaceHolder2 thisPlaceHolder2 = _db.PlaceHolder2s.FirstOrDefault(placeHolder2 => placeHolder2.PlaceHolder2Id == id);
      ViewBag.PlaceHolderId = new SelectList(_db.PlaceHolders, "PlaceHolderId", "Name");
      return View(thisPlaceHolder2);
    }

    [HttpPost]
    public ActionResult Edit(PlaceHolder2 placeHolder2, int PlaceHolderId)
    {
      if (PlaceHolderId != 0)
      {
        _db.PlaceHolderPlaceHolder2.Add(new PlaceHolderPlaceHolder2() { PlaceHolderId = PlaceHolderId, PlaceHolder2Id = placeHolder2.PlaceHolder2Id });
      }
      _db.Entry(placeHolder2).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddPlaceHolder(int id)
    {
      var thisPlaceHolder2 = _db.PlaceHolder2s.FirstOrDefault(placeHolder2 => placeHolder2.PlaceHolder2Id == id);
      ViewBag.PlaceHolderId = new SelectList(_db.PlaceHolders, "PlaceHolderId", "Name");
      return View(thisPlaceHolder2);
    }

    [HttpPost]
    public ActionResult AddPlaceHolder(PlaceHolder2 placeHolder2, int PlaceHolderId)
    {
      if (PlaceHolderId != 0)
      {
        _db.PlaceHolderPlaceHolder2.Add(new PlaceHolderPlaceHolder2() { PlaceHolderId = PlaceHolderId, PlaceHolder2Id = placeHolder2.PlaceHolder2Id });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      PlaceHolder2 thisPlaceHolder2 = _db.PlaceHolder2s.FirstOrDefault(placeHolder2 => placeHolder2.PlaceHolder2Id == id);
      return View(thisPlaceHolder2);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      PlaceHolder2 thisPlaceHolder2 = _db.PlaceHolder2s.FirstOrDefault(placeHolder2 => placeHolder2.PlaceHolder2Id == id);
      _db.PlaceHolder2s.Remove(thisPlaceHolder2);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeletePlaceHolder(int joinId)
    {
      var joinEntry = _db.PlaceHolderPlaceHolder2.FirstOrDefault(entry => entry.PlaceHolderPlaceHolder2Id == joinId);
      _db.PlaceHolderPlaceHolder2.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}