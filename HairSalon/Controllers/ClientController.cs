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
  }
}



    // [HttpGet("/items/{id}/edit")]
    // public ActionResult Edit(int id, int categoryId)
    // {
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Console.WriteLine(categoryId);
    //   Category category = Category.Find(categoryId);
    //   model.Add("itemCategories", category);
    //   Item selectedItem = Item.Find(id);
    //   model.Add("selectedItem", selectedItem);
    //   return View(model);
    // }
    //
    // [HttpPost("/items/{id}")]
    // public ActionResult Update(int id, string newDescription)
    // {
    //   Item selectedItem = Item.Find(id);
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   selectedItem.Edit(newDescription);
    //   List<Category> itemCategories = selectedItem.GetCategories();
    //   List<Category> allCategories = Category.GetAll();
    //   model.Add("itemCategories", itemCategories);
    //   model.Add("selectedItem", selectedItem);
    //   model.Add("allCategories", allCategories);
    //   return View("Show", model);
    // }

   // [HttpGet("/stylist/{stylistId}/client/{clientId}/edit")]
   // public ActionResult Edit(int stylistId, int clientId)
   // {
   //   Dictionary<string, object> model = new Dictionary<string, object>();
   //   Stylist stylist = Stylist.Find(stylistId);
   //   model.Add("stylist", stylist);
   //   Client client = Client.Find(clientId);
   //   model.Add("client", client);
   //   return View(model);
   // }
   //
   // [HttpPost("/stylist/{stylistId}/client/{clientId}")]
   // public ActionResult Update(int stylistId, int clientId, string newDescription)
   // {
   //   Client client = Client.Find(clientId);
   //   client.Edit(newDescription);
   //   Dictionary<string, object> model = new Dictionary<string, object>();
   //   Stylist stylist = Stylist.Find(stylistId);
   //   model.Add("stylist", stylist);
   //   model.Add("client", client);
   //   return View("Show", model);
   // }
   //
