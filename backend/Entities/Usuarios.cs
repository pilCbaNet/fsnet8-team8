using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Billeteras = new HashSet<Billeteras>();
        }

        public int IdUsuario { get; set; }
        public string? NombreUsu { get; set; }
        public string? ApellidoUsu { get; set; }
        public string? DniUsu { get; set; } = null!;
        public DateTime? FechaNacUsu { get; set; }
        public string? EmailUsu { get; set; } = null!;
        public string? PasswordUsu { get; set; } = null!;
        public DateTime? FechaAltaUsu { get; set; }
        public DateTime? FechaBajaUsu { get; set; }

        public virtual ICollection<Billeteras> Billeteras { get; set; }
    }
}
