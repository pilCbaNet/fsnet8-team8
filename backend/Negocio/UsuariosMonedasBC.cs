using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuariosMonedasBC
    {
        public UsuariosMonedas? ObtenerUsuariosMonedas(BilleteraCryptoContext db, int id)
        {
            return db.UsuariosMonedas.FirstOrDefault(a => a.IdUsuarioMoneda == id);
        }
    }
}
