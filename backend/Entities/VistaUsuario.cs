using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class VistaUsuario
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public long Dni { get; set; }
        public string? Localidad { get; set; }
        public string? Provincia { get; set; }
        public DateTime? FechaDeNacimiento { get; set; }
        public string Email { get; set; } = null!;
        public string? Telefono { get; set; }
    }
}
