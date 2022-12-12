using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Transferencia
    {
        public int IdTransferencia { get; set; }
        public double? MontoTransf { get; set; }
        public int? CvuOrigenTransf { get; set; }
        public int? CvuDestinoTransf { get; set; }
        public int? IdBilletera { get; set; }

        public virtual Billetera? IdBilleteraNavigation { get; set; }
        public string NomTransferencia { get;  set; }
    }
}
