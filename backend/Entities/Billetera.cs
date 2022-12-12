using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Billetera
    {
        public Billetera()
        {
            Transferencia = new HashSet<Transferencia>();
        }

        public int IdBilletera { get; set; }
        public int? CvuBille { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEstado { get; set; }

        public virtual Estado? IdEstadoNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
        public virtual ICollection<Transferencia> Transferencia { get; set; }
        public string NomBilletera { get;  set; }
    }
}
