using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgriEnergyConnect.Data;
using AgriEnergyConnect.Models;

namespace AgriEnergyConnect.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // Login actions
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        var user = await _context.Users
            .Include(u => u.Farmer)
            .FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == password && u.IsActive);

        if (user != null)
        {
            // In a real application, use proper session management
            HttpContext.Session.SetString("UserId", user.Id.ToString());
            HttpContext.Session.SetString("Username", user.Username);
            HttpContext.Session.SetString("Role", user.Role);
            if (user.FarmerId.HasValue)
            {
                HttpContext.Session.SetString("FarmerId", user.FarmerId.Value.ToString());
            }

            if (user.Role == "Farmer")
            {
                return RedirectToAction("FarmerDashboard");
            }
            else
            {
                return RedirectToAction("EmployeeDashboard");
            }
        }

        ModelState.AddModelError("", "Invalid username or password");
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    // Farmer Dashboard
    public async Task<IActionResult> FarmerDashboard()
    {
        var farmerId = HttpContext.Session.GetString("FarmerId");
        if (string.IsNullOrEmpty(farmerId))
        {
            return RedirectToAction("Login");
        }

        var farmer = await _context.Farmers
            .Include(f => f.Products)
            .FirstOrDefaultAsync(f => f.Id == int.Parse(farmerId));

        return View(farmer);
    }

    // Employee Dashboard
    public async Task<IActionResult> EmployeeDashboard()
    {
        var role = HttpContext.Session.GetString("Role");
        if (role != "Employee")
        {
            return RedirectToAction("Login");
        }

        var farmers = await _context.Farmers
            .Include(f => f.Products)
            .Where(f => f.IsActive)
            .ToListAsync();

        return View(farmers);
    }
}
