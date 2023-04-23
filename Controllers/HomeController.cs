using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Infrastructure;
using ShoppingCart.Models;
using System.Diagnostics;

namespace ShoppingCart.Controllers
{
        public class HomeController : Controller
        {
                private readonly ILogger<HomeController> _logger;
		private readonly DataContext _context;

		public HomeController(ILogger<HomeController> logger, DataContext context)
                {
                        _logger = logger;
			_context = context;
		}

                public IActionResult Index()
                {
                        return View();
                }
		public IActionResult Contact()
		{
			return View();
		}
		public IActionResult About()
		{
			return View();
		}
		
		public IActionResult Gallery()
		{
			return View();
		}

		public IActionResult SearchProduct(string productName)
		{
			 var product=_context.Products.Where(p=>p.Name.Contains(productName)).ToList();
			//var product = _context.Products.Where(p => p.Name==productName);

			return View(product);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
                public IActionResult Error()
                {
                        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
                }
        }
}