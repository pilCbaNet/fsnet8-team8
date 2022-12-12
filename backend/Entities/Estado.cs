using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Estado
    {
        public Estado()
        {
            Billeteras = new HashSet<Billetera>();
        }

        public int IdEstado { get; set; }
        public string? NombreEst { get; set; }

        public virtual ICollection<Billetera> Billeteras { get; set; }
       
    }
}
