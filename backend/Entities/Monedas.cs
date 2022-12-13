using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Monedas
    {
        public Monedas()
        {
            UsuariosMoneda = new HashSet<UsuariosMonedas>();
        }

        public int IdMoneda { get; set; }
        public string? NombreMon { get; set; }

        public virtual ICollection<UsuariosMonedas> UsuariosMoneda { get; set; }
    }
}
