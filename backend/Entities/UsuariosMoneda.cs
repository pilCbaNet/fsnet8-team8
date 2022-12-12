using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class UsuariosMoneda
    {
        public int IdUsuarioMoneda { get; set; }
        public int? IdMoneda { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Moneda? IdMonedaNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
        public string NomUsuarioMoneda { get; set; }
    }
}
