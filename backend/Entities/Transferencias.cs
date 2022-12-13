using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Transferencias
    {
        public int IdTransferencia { get; set; }
        public double? MontoTransf { get; set; }
        public int? CvuOrigenTransf { get; set; }
        public int? CvuDestinoTransf { get; set; }
        public int? IdBilletera { get; set; }

        public virtual Billeteras? IdBilleteraNavigation { get; set; }
    }
}
