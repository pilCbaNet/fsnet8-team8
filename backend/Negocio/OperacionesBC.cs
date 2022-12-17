using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class OperacionesBC
    {
        public Operaciones ObtenerTransferencias(BilleteraCryptoContext db, int id)
        {
            return db.Operaciones.FirstOrDefault(a => a.IdTransferencia == id);
        }
    }
}
