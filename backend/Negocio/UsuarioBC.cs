using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioBC
    {
        public Usuarios? ObtenerUsuario(BilleteraCryptoContext db, int id)
        {
            return db.Usuarios.FirstOrDefault(a => a.IdUsuario == id);
        }

        public Usuarios? LoginUsuario(BilleteraCryptoContext db, string email, string pass)
        {
            var usuarioLogueado = db.Usuarios.
                FirstOrDefault(c => c.EmailUsu == email && c.PasswordUsu == pass);
            return usuarioLogueado;
        }

      
    
    }
}
