using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
  public class SpecialtyController : Controller
  {

    [HttpGet("/specialty")]
    public ActionResult Index()
    {
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View(allSpecialties);
    }

    [HttpGet("/specialty/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/specialty")]
    public ActionResult Create(string name)
    {
      List<Specialty> checkDatabase = Specialty.GetAll();
      int repeatCount = 0;
      foreach(Specialty specialty in checkDatabase)
      {
        if(specialty.Name.ToLower() == name.ToLower())
        {
          repeatCount++;
        }
      }
      if (repeatCount == 0)
      {
        Specialty newSpecialty = new Specialty(name);
        newSpecialty.Save();
      }
      List<Specialty> allSpecialties = Specialty.GetAll();
      return RedirectToAction("Index", allSpecialties);
    }

    [HttpGet("/specialty/{specialtyId}")]
    public ActionResult Show(int specialtyId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty selectedSpecialty = Specialty.Find(specialtyId);
      model.Add("specialty", selectedSpecialty);
      List<Stylist> allStylists = Stylist.GetAll();
      model.Add("allStylists", allStylists);
      List<Stylist> stylistList = selectedSpecialty.GetStylists();
      model.Add("stylistList", stylistList);
      return View(model);
    }

    [HttpGet("/specialty/delete")]
    public ActionResult DeleteAll()
    {
      Specialty.ClearAll();
      List<Specialty> allSpecialties = Specialty.GetAll();
      return RedirectToAction("Index", allSpecialties);
    }

    [HttpGet("/specialty/{specialtyId}/delete")]
    public ActionResult Destroy(int specialtyId)
    {
      Specialty specialty = Specialty.Find(specialtyId);
      specialty.Delete();
      List<Specialty> allSpecialties = Specialty.GetAll();
      return RedirectToAction("Index", allSpecialties);
    }

    [HttpPost("/specialty/{specialtyId}/stylist/new")]
     public ActionResult AddStylist(int specialtyId, int stylistId)
     {
       Specialty specialty = Specialty.Find(specialtyId);
       Stylist newStylist = Stylist.Find(stylistId);
       int count = 0;
       foreach (Stylist stylist in specialty.GetStylists())
       {
         if (stylist.Name == newStylist.Name)
         {
           count++;
         }
       }
       if (count == 0)
       {
         specialty.AddStylist(newStylist);
       }
       return RedirectToAction("Show",  new { id = specialtyId });
     }
  }
}
