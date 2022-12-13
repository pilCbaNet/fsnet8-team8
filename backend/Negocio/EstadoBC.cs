using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EstadoBC
    {
        public Estados? ObtenerEstado(BilleteraCryptoContext db, int id)
        {
            return db.Estados.FirstOrDefault(a => a.IdEstado == id);
        }
    }
}
