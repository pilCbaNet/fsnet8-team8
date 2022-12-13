using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class UsuariosMonedas
    {
        public int IdUsuarioMoneda { get; set; }
        public int? IdMoneda { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Monedas? IdMonedaNavigation { get; set; }
        public virtual Usuarios? IdUsuarioNavigation { get; set; }
    }
}
