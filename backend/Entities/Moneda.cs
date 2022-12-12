using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Moneda
    {
        public Moneda()
        {
            UsuariosMoneda = new HashSet<UsuariosMoneda>();
        }

        public int IdMoneda { get; set; }
        public string? NombreMon { get; set; }

        public virtual ICollection<UsuariosMoneda> UsuariosMoneda { get; set; }
    }
}
