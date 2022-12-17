using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Operaciones
    {
        public int IdTransferencia { get; set; }
        public decimal? MontoArsTransf { get; set; }
        public decimal? MontoBtcTrans { get; set; }
        public string? TipoTransf { get; set; }
        public int? IdBilletera { get; set; }

        public virtual Billeteras? IdBilleteraNavigation { get; set; }
    }
}
