using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MonedaBC
    {
        public Monedas ObtenerMoneda(BilleteraCryptoContext db, int id)
        {
            return db.Monedas.FirstOrDefault(a => a.IdMoneda == id);
        }
    }
}
