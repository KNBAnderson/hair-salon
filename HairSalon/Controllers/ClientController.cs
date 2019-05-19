using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {

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

    [HttpGet("/client")]
    public ActionResult Index()
    {
      List<Client> allClients = Client.GetAll();
      return View(allClients);
    }

    [HttpGet("/client/delete")]
    public ActionResult DeleteAll()
    {
      Client.ClearAll();
      List<Client> allClients = Client.GetAll();
      return RedirectToAction("Index", allClients);
    }

    [HttpGet("/client/{clientId}/delete")]
    public ActionResult Destroy(int clientId)
    {
      Client client = Client.Find(clientId);
      Console.WriteLine(client.Name);
      client.Delete();
      List<Client> allClients = Client.GetAll();
      return RedirectToAction("Index", allClients);
    }

    [HttpGet("/stylist/{stylistId}/client/{clientId}/edit")]
    public ActionResult Edit(int stylistId, int clientId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      model.Add("stylist", stylist);
      Client client = Client.Find(clientId);
      model.Add("client", client);
      return View(model);
    }

    [HttpPost("/stylist/{stylistId}/client/{clientId}")]
    public ActionResult Update(int stylistId, int clientId, string newName, DateTime newNextAppointment)
    {
      Client selectedClient = Client.Find(clientId);
      if (newName == "")
      {
        newName = selectedClient.Name;
      }
      Dictionary<string, object> model = new Dictionary<string, object>();
      selectedClient.Edit(newName, newNextAppointment);
      Stylist selectedStylist = Stylist.Find(stylistId);
      model.Add("client", selectedClient);
      model.Add("stylist", selectedStylist);
      return View("Show", model);
    }

  }
}
