using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BilleteraGrupoHWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosMonedasController : ControllerBase
    {

        [HttpGet]
        public List<UsuariosMoneda> Get()
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.UsuariosMonedas.ToList();
            }
        }

        [HttpGet("{id:int}")]
        public UsuariosMoneda? Get(int id)
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.UsuariosMonedas.Include(a => a.IdUsuarioMoneda).FirstOrDefault(a => a.IdUsuarioMoneda == id);
                //aca nose que vergas pasó con IdUsuarioMoneda porq no me dejaba hacer ninguna relación con ninguna tabla
            }
        }

        [HttpPost]
        public void Post([FromBody] UsuariosMoneda oUsuariosMonedas)
        {
            using (var db = new BilleteraCryptoContext())
            {
                db.UsuariosMonedas.Add(oUsuariosMonedas);
                db.SaveChanges();
            }
        }


        [HttpPut]
        public void Put(int id, string nombre)
        {
            using (var db = new BilleteraCryptoContext())
            {
                UsuariosMoneda? usuarioMonedaVieja = db.UsuariosMonedas.FirstOrDefault(a => a.IdUsuarioMoneda == id);
                usuarioMonedaVieja.NomUsuarioMoneda = nombre;
                db.SaveChanges();
            }
        }
    }
}
