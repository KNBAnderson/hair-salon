using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {

    [HttpGet("/stylist/{id}/client")]
    public ActionResult Index(int id)
    {
      List<Client> allClients = Client.FindStylistList(id);
      return View(allClients);
    }

    [HttpGet("/stylist/{id}/client/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/stylist/{stylistId}/client")]
    public ActionResult Create(string name, int stylistId, DateTime nextAppointment)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(stylistId);
      model.Add("stylist", selectedStylist);
      Client newClient = new Client(name, stylistId, nextAppointment);
      newClient.Save();
      return View("Show", "Stylist", stylistId);
    }

    // [HttpGet("/client/{id}")]
    // public ActionResult Show()
    // {
    // }

    // [HttpGet("stylist/{id}/client")]
    // public ActionResult index(int id)
    // {
    //   List<Client> allClients = Client.GetStylistList(id);
    //   return View(allClients);
    // }

    // [HttpPost("/stylist/{id}/delete")]
    // public ActionResult Destroy(int id)
    // {
    //   Stylist.RemoveHellBeast(id);
    //   return RedirectToAction("Index");
    // }
  }
}
