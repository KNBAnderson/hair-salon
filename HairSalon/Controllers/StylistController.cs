using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {

    [HttpGet("/stylist")]
    public ActionResult Index()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }

    [HttpGet("/stylist/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/stylist")]
    public ActionResult Create(string name, string daysAvailable)
    {
      Stylist newStylist = new Stylist(name, daysAvailable);
      newStylist.Save();
      return RedirectToAction("Index");
    }

    [HttpGet("/stylist/{stylistId}")]
    public ActionResult Show(int stylistId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(stylistId);
      model.Add("stylist", selectedStylist);
      List<Client> allClients = Client.FindStylistList(stylistId);
      model.Add("clientList", allClients);
      return View(model);
    }

    //Stretch Goals
    // [HttpPost("/stylist/{id}/delete")]
    // public ActionResult Destroy(int id)
    // {
    //   Stylist.RemoveStylist(id);
    //   return RedirectToAction("Index");
    // }
  }
}
