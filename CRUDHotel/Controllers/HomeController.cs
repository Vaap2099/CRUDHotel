using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDHotel.Models;
using System.Diagnostics;

namespace CRUDHotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly HotelContext _HotelContext;

        public HomeController(HotelContext context)
        {
            _HotelContext = context;
        }

        public IActionResult Index()
        {
            List<Habitacion> habitaciones = _HotelContext.Habitaciones.ToList();
            return View(habitaciones);
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
    }
}
