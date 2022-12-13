using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Billeteras
    {
        public Billeteras()
        {
            Transferencia = new HashSet<Transferencias>();
        }

        public int IdBilletera { get; set; }
        public int? CvuBille { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEstado { get; set; }

        public virtual Estados? IdEstadoNavigation { get; set; }
        public virtual Usuarios? IdUsuarioNavigation { get; set; }
        public virtual ICollection<Transferencias> Transferencia { get; set; }
    }
}
