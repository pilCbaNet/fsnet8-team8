using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Localidade
    {
        public Localidade()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdLocalidad { get; set; }
        public string? NomLocalidad { get; set; }
        public int? IdProvincia { get; set; }

        public virtual Provincia? IdProvinciaNavigation { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
