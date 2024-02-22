using System;
using System.Collections.Generic;

namespace CRUDHotel.Models
{
    public partial class Cliente
    {
        public string IdCliente { get; set; } = null!;
        public string? NombreCliente { get; set; }
        public string? Telefono { get; set; }
    }
}
