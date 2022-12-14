using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public partial class TipoTransferencia
    {
        public TipoTransferencia()
        {
            Transferencia = new HashSet<Transferencias>();
        }

        public int IdTipoTransferencia { get; set; }
        public string? NomTrasferencia { get; set; }

        public virtual ICollection<Transferencias> Transferencia { get; set; }
    }
}
