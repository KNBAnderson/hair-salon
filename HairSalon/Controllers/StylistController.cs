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

    // [HttpGet("/stylist/{id}")]
    // public ActionResult Index(int id)
    // {
    //   List<Client> allClients = Client.GetStylistList(id);
    //   return View("~/Client/", allClients);
    // }

    // [HttpPost("/stylist/{id}/delete")]
    // public ActionResult Destroy(int id)
    // {
    //   Stylist.RemoveStylist(id);
    //   return RedirectToAction("Index");
    // }
  }
}
