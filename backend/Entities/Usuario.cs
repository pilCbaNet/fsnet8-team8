using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Billeteras = new HashSet<Billetera>();
            UsuariosMoneda = new HashSet<UsuariosMoneda>();
        }

        public int IdUsuario { get; set; }
        public string? NombreUsu { get; set; }
        public string? ApellidoUsu { get; set; }
        public long Dni { get; set; }
        public DateTime? FechaNacUsu { get; set; }
        public string EmailUsu { get; set; } = null!;
        public string Usuario1 { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string? Telefono { get; set; }
        public DateTime? FechaAltaUsu { get; set; }
        public DateTime? FechaBajaUsu { get; set; }
        public int? IdLocalidad { get; set; }

        public virtual Localidade? IdLocalidadNavigation { get; set; }
        public virtual ICollection<Billetera> Billeteras { get; set; }
        public virtual ICollection<UsuariosMoneda> UsuariosMoneda { get; set; }
    }
}
