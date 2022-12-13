using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Localidades
    {
        public Localidades()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdLocalidad { get; set; }
        public string? NomLocalidad { get; set; }
        public int? IdProvincia { get; set; }

        public virtual Provincias? IdProvinciaNavigation { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
