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
      
      Specialty newSpecialty = new Specialty(name);
      newSpecialty.Save();
      List<Specialty> allSpecialties = Specialty.GetAll();
      return RedirectToAction("Index", allSpecialties);
    }

    [HttpGet("/specialty/{specialtyId}")]
    public ActionResult Show(int specialtyId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty selectedSpecialty = Specialty.Find(specialtyId);
      model.Add("specialty", selectedSpecialty);
      List<Stylist> allStylists = selectedSpecialty.GetStylists();
      model.Add("stylistList", allStylists);
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
  }
}
