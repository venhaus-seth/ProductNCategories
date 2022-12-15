using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductNCategories.Models;

namespace ProductNCategories.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        MyViewModel MyModels = new MyViewModel
        {
            AllProducts = _context.Products.ToList()
        };   
        return View("Index", MyModels);
    }

    [HttpGet("categories")]
    public IActionResult Categories()
    {
        MyViewModel MyModels = new MyViewModel
        {
            AllCategories = _context.Categories.ToList()
        };   
        return View("Categories", MyModels);
    }

    [HttpPost("categories/create")]
    public IActionResult CreateCategory( Category newCategory)
    {
        if (ModelState.IsValid)
        {
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("Categories");
        } else {
        return Categories();
        }
    }

    [HttpPost("products/create")]
    public IActionResult CreateProduct(Product newProduct)
    {   
        Console.WriteLine(newProduct);
        if(ModelState.IsValid)
        {
            
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else {
            return Index();
        }

    }

    [HttpGet("category/{CategoryId}")]
    public IActionResult OneCategory(int CategoryId)
    {
        ViewBag.AllProducts = _context.Products.ToList();
        MyViewModel MyModels = new MyViewModel
        {
            Connection = new Connection(),
            Category = _context.Categories.Include(c=>c.Connections)
                                        .ThenInclude(d=>d.Product)
                                        .FirstOrDefault(c=>c.CategoryId == CategoryId)
        };
        return View(MyModels);
    }

    [HttpGet("products/{ProductId}")]
    public IActionResult OneProduct(int ProductId)
    {
        ViewBag.AllCategories = _context.Categories.ToList();
        MyViewModel MyModels = new MyViewModel
        {
            Connection = new Connection(),
            Product = _context.Products.Include(c=>c.Connections)
                                        .ThenInclude(d=>d.Category)
                                        .FirstOrDefault(c=>c.ProductId == ProductId)
        };
        return View(MyModels);
    }

    [HttpPost("connections/product/create")]
    public IActionResult AddConnectionProd(Connection connection)
    {
        if(_context.Connections.Any(c=>c.ConnectionId == connection.CategoryId && c.ProductId == connection.ProductId))
            {
                return RedirectToAction("OneCategory", new {CategoryId = connection.CategoryId});
            }
        _context.Connections.Add(connection);
        _context.SaveChanges();
        return RedirectToAction("OneProduct", new {ProductId = connection.ProductId});
    }

    [HttpPost("connections/category/create")]
    public IActionResult AddConnectionCat(Connection connection)
    {
        if(_context.Connections.Any(c=>c.ConnectionId == connection.CategoryId && c.ProductId == connection.ProductId))
            {
                return RedirectToAction("OneCategory", new {CategoryId = connection.CategoryId});
            }
        _context.Connections.Add(connection);
        _context.SaveChanges();
        return RedirectToAction("OneCategory", new {CategoryId = connection.CategoryId});
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
