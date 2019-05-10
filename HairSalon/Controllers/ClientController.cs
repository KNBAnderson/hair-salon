using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FoodGuide.Models;
using System;

namespace FoodGuide.Controllers
{
  public class RestaurantController : Controller
  {

    [HttpGet("cuisine/{id}/restaurant")]
    public ActionResult Index(int id)
    {
      List<Restaurant> allRestaurants = Restaurant.FindCuisineList(id);
      return View(allRestaurants);
    }

    [HttpGet("/restaurant/new")]
    public ActionResult New()
    {
      return View();
    }
    // [HttpGet("/restaurant/{id}")]
    // public ActionResult Show()
    // {
    // }

    // [HttpGet("cuisine/{id}/restaurant")]
    // public ActionResult index(int id)
    // {
    //   List<Restaurant> allRestaurants = Restaurant.GetCuisineList(id);
    //   return View(allRestaurants);
    // }

    // [HttpPost("/cuisine/{id}/delete")]
    // public ActionResult Destroy(int id)
    // {
    //   Cuisine.RemoveHellBeast(id);
    //   return RedirectToAction("Index");
    // }
  }
}
