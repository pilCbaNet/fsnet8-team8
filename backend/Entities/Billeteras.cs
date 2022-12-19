using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Billeteras
    {
        public Billeteras()
        {
            Operaciones = new HashSet<Operaciones>();
        }

        public int IdBilletera { get; set; }
        public int CvuBille { get; set; }
        public decimal? SaldoArsBille { get; set; }
        public decimal? SaldoBtcBille { get; set; }
        public bool? EstadoBille { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuarios? IdUsuarioNavigation { get; set; }
        public virtual ICollection<Operaciones> Operaciones { get; set; }
    }
}
