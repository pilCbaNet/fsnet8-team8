using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Billeteras = new HashSet<Billeteras>();
            UsuariosMoneda = new HashSet<UsuariosMonedas>();
        }

        public int IdUsuario { get; set; }
        public string? NombreUsu { get; set; }
        public string? ApellidoUsu { get; set; }
        public long Dni { get; set; }
        public DateTime? FechaNacUsu { get; set; }
        public string EmailUsu { get; set; } = null!;
        public string Usuario { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string? Telefono { get; set; }
        public DateTime? FechaAltaUsu { get; set; }
        public DateTime? FechaBajaUsu { get; set; }
        public int? IdLocalidad { get; set; }

        public virtual Localidades? IdLocalidadNavigation { get; set; }
        public virtual ICollection<Billeteras> Billeteras { get; set; }
        public virtual ICollection<UsuariosMonedas> UsuariosMoneda { get; set; }
    }
}
