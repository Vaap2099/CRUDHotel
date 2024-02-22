using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUDHotel.Models.ViewModels
{
    public class ReservacionVM
    {

        public Reservacion? oReservacion { get; set; }

        public List<SelectListItem>? olistaHabitacion { get; set; }
        public List<SelectListItem>? olistaCliente { get; set; }
    }
}
