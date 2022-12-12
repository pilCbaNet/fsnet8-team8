using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Provincia
    {
        public Provincia()
        {
            Localidades = new HashSet<Localidade>();
        }

        public int IdProvincia { get; set; }
        public string? NomProvincia { get; set; }

        public virtual ICollection<Localidade> Localidades { get; set; }
    }
}
