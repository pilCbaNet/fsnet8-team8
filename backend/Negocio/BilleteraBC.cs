using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class BilleteraBC
    {
        public Billeteras? ObtenerBilletera(BilleteraCryptoContext db, int id)
        {
            return db.Billeteras.FirstOrDefault(a => a.IdBilletera == id);
        }
    }
}
