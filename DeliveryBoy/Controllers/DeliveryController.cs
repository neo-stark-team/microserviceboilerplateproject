using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DeliveryBoy.Models;

namespace DeliveryBoy.Controllers;

public class DeliveryController : Controller
{
    private readonly DeliveryBoyDbContext deliveryBoyDbContext;
    public DeliveryController(DeliveryBoyDbContext _deliveryBoyDbContext)
    {
deliveryBoyDbContext =_deliveryBoyDbContext;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult AvailableOrders()
    {
        var availableOrders = deliveryBoyDbContext.Orders.ToList();
        return View(availableOrders);
    }
}