using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Estados
    {
        public Estados()
        {
            Billeteras = new HashSet<Billeteras>();
        }

        public int IdEstado { get; set; }
        public string? NombreEst { get; set; }

        public virtual ICollection<Billeteras> Billeteras { get; set; }
    }
}
