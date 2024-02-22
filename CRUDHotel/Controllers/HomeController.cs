using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDHotel.Models;
using CRUDHotel.Models.ViewModels;
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

        [HttpGet]
        public IActionResult Habitacion_detalle()
        {
            HabitacionVM oHabitacionVM = new HabitacionVM()
            {
                oHabitacion = new Habitacion(),

            };
            return View(oHabitacionVM);
        }

        //public IActionResult Cliente_detalle(object clienteVM)
        //{
        //    ClienteVM oClienteVM = new ClienteVM()
        //    {
        //        oCliente = new Cliente(),

        //    };
        //    return View(model: ClienteVM);
        //}

        //public IActionResult Reservacion_detalle()
        //{
        //    ReservacionVM oReservacionVM = new ReservacionVM()
        //    {
        //        oReservacion = new Reservacion(),
        //        olistaCliente = _HotelContext.Clientes.Select(idcliente => new SelectListItem()
        //        {
        //            Text = idcliente.NombreCliente,
        //            Value = idcliente.IdCliente.ToString()
        //        }).ToList(),
        //        olistaHabitacion = _HotelContext.Habitaciones.Select(NoHabitacion => new SelectListItem()
        //        {
        //            Text = NoHabitacion.NumeroHabitacion.ToString(),
        //            Value = NoHabitacion.NumeroHabitacion.ToString()
        //        }).ToList()
        //    };
            
        //    return View(ReservacionVM);
        //}

        [HttpPost]
        public IActionResult Habitacion_detalle(HabitacionVM oHabitacionVM)
        {
            if (true)
            {
                _HotelContext.Habitaciones.Add(oHabitacionVM.oHabitacion);
            }
            _HotelContext.SaveChanges();
            return RedirectToAction("Index", "Home");

        }

        //public IActionResult Cliente_detalle(ClienteVM oClienteVM)
        //{
        //    if (oClienteVM.oCliente.IdCliente = 0)
        //    {
        //        _HotelContext.Clientes.Add(oClienteVM.oCliente);
        //    }
        //    _HotelContext.SaveChanges();
        //    return RedirectToAction("Index", "Home");
        //}

        //public IActionResult Reservacion_detalle(ReservacionVM oReservacionVM)
        //{
        //    if (oReservacionVM.oReservacion.NumeroHabitacion == 0)
        //    {
        //        _HotelContext.Clientes.Add(oReservacionVM.oReservacion);
        //    }
        //    _HotelContext.SaveChanges();
        //    return RedirectToAction("Index", "Home");
        //}

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
