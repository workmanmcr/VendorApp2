using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VendorApp.Models;

namespace VendorApp.Controllers
{

  public class VendorController : Controller
  {
    [HttpGet("/Vendor")]
    public ActionResult Index()
    {
      List<Vendor> vendors = Vendor.GetAll();
      return View(vendors);
    }
    [HttpPost("/Vendor")]
    public ActionResult Create(string name, string description)
    {
      new Vendor(name, description);
      List<Vendor> vendors = Vendor.GetAll();
      return RedirectToAction("Index", vendors);
    }
    [HttpGet("/Vendor/new")]
    public ActionResult New()
    {
      return View();
    }
    [HttpGet("/Vendor/{id}")]
    public ActionResult Details(int id)
    {
      Vendor vendor = Vendor.GetVendorWithId(id);
      return View(vendor);
    }
    [HttpGet("/Vendor/{id}/Order/New")]
    public ActionResult newOrder(int id)
    {
      Vendor vendor = Vendor.GetVendorWithId(id);
      return View(vendor);
    }
    [HttpPost("/Vendor/{id}/Order/New")]
    public ActionResult CreateOrder(string title, string description, int price, DateTime orderDate, int vendorId)
    {
      Vendor vendor = Vendor.GetVendorWithId(vendorId);
      vendor.AddOrder(new Order(title, description, price, vendor.GetOrderCount(), vendor.Name, orderDate, vendor.Id));
      return RedirectToAction("Details");
    }
    [HttpGet("/Vendor/{id}/Order/{oid}")]
    public ActionResult ShowOrder(int id, int oid)
    {
      Vendor vendor = Vendor.GetVendorWithId(id);
      Order order = vendor.GetOrderWithId(oid);
      return View(order);
    }
   

    [HttpGet("/Vendor/Search")]
    public ActionResult Search()
    {

      return View();
    }
    [HttpPost("/Vendor/Search")]
    public ActionResult SearchVendor(string vendor)
    {
      Vendor vendor1 = Vendor.SearchVendor(vendor);
      
      return View("Details", vendor1);
    }


  }

}