using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {

    // [HttpGet("/stylist/{stylistId}/client")]
    // public ActionResult Index(int stylistId)
    // {
    //   List<Client> allClients = Client.FindStylistList(stylistId);
    //   return View(allClients);
    // }

    [HttpGet("/stylist/{stylistId}/client/new")]
    public ActionResult New(int stylistId)
    {
      Stylist stylist = Stylist.Find(stylistId);
      return View(stylist);
    }

    [HttpGet("/stylist/{stylistId}/client/{clientId}")]
    public ActionResult Show(int stylistId, int clientId)
    {
      Client client = Client.Find(clientId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      model.Add("client", client);
      model.Add("stylist", stylist);
      return View(model);
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


  }
}
