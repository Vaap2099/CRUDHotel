using System;
using System.Collections.Generic;

namespace CRUDHotel.Models
{
    public partial class Habitacion
    {
        public int NumeroHabitacion { get; set; }
        public string? Fotos { get; set; }
        public string? Descripcion { get; set; }
        public double? Precio { get; set; }
        public int? NumeroCamas { get; set; }
        public bool? Suite { get; set; }
    }
}
