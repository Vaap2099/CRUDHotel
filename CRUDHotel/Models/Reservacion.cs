﻿using System;
using System.Collections.Generic;

namespace CRUDHotel.Models
{
    public partial class Reservacion
    {
        public int NumeroHabitacion { get; set; }
        public string IdCliente { get; set; } = null!;
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public int? NoPersonas { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Habitacion NumeroHabitacionNavigation { get; set; } = null!;
    }
}
