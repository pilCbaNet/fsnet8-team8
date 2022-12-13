using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Provincias
    {
        public Provincias()
        {
            Localidades = new HashSet<Localidades>();
        }

        public int IdProvincia { get; set; }
        public string? NomProvincia { get; set; }

        public virtual ICollection<Localidades> Localidades { get; set; }
    }
}
