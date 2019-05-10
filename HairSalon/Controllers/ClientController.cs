using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {

    [HttpGet("stylist/{id}/client")]
    public ActionResult Index(int id)
    {
      List<Client> allClients = Client.FindStylistList(id);
      return View(allClients);
    }

    [HttpGet("/client/new")]
    public ActionResult New()
    {
      return View();
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
