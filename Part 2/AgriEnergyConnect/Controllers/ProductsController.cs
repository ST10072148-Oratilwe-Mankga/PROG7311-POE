using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgriEnergyConnect.Data;
using AgriEnergyConnect.Models;

namespace AgriEnergyConnect.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products (Employee view - all products)
        public async Task<IActionResult> Index(string? category, DateTime? startDate, DateTime? endDate, int? farmerId)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != "Employee")
            {
                return RedirectToAction("Login", "Home");
            }

            var query = _context.Products.Include(p => p.Farmer).AsQueryable();

            // Apply filters
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category == category);
            }

            if (startDate.HasValue)
            {
                query = query.Where(p => p.ProductionDate >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(p => p.ProductionDate <= endDate.Value);
            }

            if (farmerId.HasValue)
            {
                query = query.Where(p => p.FarmerId == farmerId.Value);
            }

            ViewBag.Categories = new SelectList(await _context.Products.Select(p => p.Category).Distinct().ToListAsync());
            ViewBag.Farmers = new SelectList(await _context.Farmers.ToListAsync(), "Id", "Name");

            return View(await query.ToListAsync());
        }

        // GET: Products/MyProducts (Farmer view - own products)
        public async Task<IActionResult> MyProducts()
        {
            var farmerId = HttpContext.Session.GetString("FarmerId");
            if (string.IsNullOrEmpty(farmerId))
            {
                return RedirectToAction("Login", "Home");
            }

            var products = await _context.Products
                .Where(p => p.FarmerId == int.Parse(farmerId))
                .ToListAsync();

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            var farmerId = HttpContext.Session.GetString("FarmerId");
            if (string.IsNullOrEmpty(farmerId))
            {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.Categories = new SelectList(new[] { "Grains", "Vegetables", "Fruits", "Dairy", "Livestock", "Other" });
            ViewBag.Units = new SelectList(new[] { "kg", "tons", "liters", "pieces", "boxes", "bags" });

            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Category,ProductionDate,Description,Price,Quantity,Unit")] Product product)
        {
            var farmerId = HttpContext.Session.GetString("FarmerId");
            if (string.IsNullOrEmpty(farmerId))
            {
                return RedirectToAction("Login", "Home");
            }

            if (ModelState.IsValid)
            {
                product.FarmerId = int.Parse(farmerId);
                product.CreatedDate = DateTime.Now;
                product.IsAvailable = true;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MyProducts));
            }

            ViewBag.Categories = new SelectList(new[] { "Grains", "Vegetables", "Fruits", "Dairy", "Livestock", "Other" });
            ViewBag.Units = new SelectList(new[] { "kg", "tons", "liters", "pieces", "boxes", "bags" });

            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var farmerId = HttpContext.Session.GetString("FarmerId");
            if (string.IsNullOrEmpty(farmerId))
            {
                return RedirectToAction("Login", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null || product.FarmerId != int.Parse(farmerId))
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(new[] { "Grains", "Vegetables", "Fruits", "Dairy", "Livestock", "Other" });
            ViewBag.Units = new SelectList(new[] { "kg", "tons", "liters", "pieces", "boxes", "bags" });

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Category,ProductionDate,Description,Price,Quantity,Unit,CreatedDate,IsAvailable,FarmerId")] Product product)
        {
            var farmerId = HttpContext.Session.GetString("FarmerId");
            if (string.IsNullOrEmpty(farmerId) || product.FarmerId != int.Parse(farmerId))
            {
                return RedirectToAction("Login", "Home");
            }

            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(MyProducts));
            }

            ViewBag.Categories = new SelectList(new[] { "Grains", "Vegetables", "Fruits", "Dairy", "Livestock", "Other" });
            ViewBag.Units = new SelectList(new[] { "kg", "tons", "liters", "pieces", "boxes", "bags" });

            return View(product);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Farmer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
} 