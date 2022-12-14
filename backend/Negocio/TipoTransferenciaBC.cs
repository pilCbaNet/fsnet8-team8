
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TipoTransferenciaBC
    {
        public TipoTransferencia ObtenerTipoTransferencia(BilleteraCryptoContext db, int id)
        {
            return db.TipoTransferencias.FirstOrDefault(a => a.IdTipoTransferencia == id);
        }




    }
}
