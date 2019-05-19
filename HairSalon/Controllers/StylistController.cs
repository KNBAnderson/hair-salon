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
      List<Stylist> allStylists = Stylist.GetAll();
      return RedirectToAction("Index", allStylists);
    }

    [HttpGet("/stylist/{stylistId}")]
    public ActionResult Show(int stylistId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(stylistId);
      model.Add("stylist", selectedStylist);
      List<Client> allClients = Client.FindStylistList(stylistId);
      model.Add("clientList", allClients);
      List<Specialty> stylistSpecialty = selectedStylist.GetSpecialties();
      model.Add("stylistSpecialty", stylistSpecialty);
      List<Specialty> allSpecialties = Specialty.GetAll();
      model.Add("allSpecialties", allSpecialties);
      return View(model);
    }

    [HttpPost("/stylist/{stylistId}/client")]
    public ActionResult Create(string name, int stylistId, DateTime nextAppointment)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(stylistId);
      model.Add("stylist", selectedStylist);
      Client newClient = new Client(name, stylistId, nextAppointment);
      newClient.Save();
      List<Client> allClients = Client.FindStylistList(stylistId);
      model.Add("clientList", allClients);
      return View("Show", model);
    }

    [HttpGet("/stylist/delete")]
    public ActionResult DeleteAll()
    {
      Stylist.ClearAll();
      List<Stylist> allStylists = Stylist.GetAll();
      return RedirectToAction("Index", allStylists);
    }

    [HttpGet("/stylist/{stylistId}/delete")]
    public ActionResult Destroy(int stylistId)
    {
      Stylist stylist = Stylist.Find(stylistId);
      Console.WriteLine(stylist.Name);
      stylist.Delete();
      List<Stylist> allStylists = Stylist.GetAll();
      return RedirectToAction("Index", allStylists);
    }
    [HttpGet("/stylist/{stylistId}/edit")]
    public ActionResult Edit(int stylistId)
    {
      Stylist stylist = Stylist.Find(stylistId);
      return View(stylist);
    }

    [HttpPost("/stylist/{stylistId}")]
    public ActionResult Update(int stylistId, string newName)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist selectedStylist = Stylist.Find(stylistId);
      selectedStylist.Edit(newName);
      List<Client> allClients = Client.FindStylistList(stylistId);
      model.Add("clientList", allClients);
      model.Add("stylist", selectedStylist);
      return View("Show", model);
    }
//item= stylist cate=specialty
    [HttpPost("/stylist/{stylistId}/specialty/new")]
     public ActionResult AddSpecialty(int specialtyId, int stylistId)
     {
       Stylist stylist = Stylist.Find(stylistId);
       Specialty newSpecialty = Specialty.Find(specialtyId);
       // List<Specialty> searchList = stylist.GetSpecialties();
       int count = 0;
       foreach (Specialty specialty in stylist.GetSpecialties())
       {
         if (specialty.Name == newSpecialty.Name)
         {
           count++;
         }
       }
       if (count == 0)
       {
         stylist.AddSpecialty(newSpecialty);
       }
       return RedirectToAction("Show",  new { id = stylistId });
     }
  }
}
