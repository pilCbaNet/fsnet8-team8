using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TransferenciaBC
    {
        public Transferencias ObtenerTransferencias(BilleteraCryptoContext db, int id)
        {
            return db.Transferencias.FirstOrDefault(a => a.IdTransferencia == id);
        }
    }
}
