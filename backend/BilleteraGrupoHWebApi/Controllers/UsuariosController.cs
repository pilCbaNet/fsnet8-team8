using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BilleteraGrupoHWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        [HttpGet]
        public List<Usuario> Get()
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.Usuarios.ToList();
            }
        }


        [HttpGet("{id:int}")]
        public Usuario? Get(int id)
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.Usuarios.Include(a => a.Billeteras).FirstOrDefault(a => a.IdUsuario == id);
                //Creo que Billeteras es la relación con la tabla
            }
        }

        [HttpPost]
        public void Post([FromBody] Usuario oUsuario)
        {
            using (var db = new BilleteraCryptoContext())
            {
                db.Usuarios.Add(oUsuario);
                db.SaveChanges();
            }
        }


        [HttpPut]
        public void Put(int id, string nombre)
        {
            using (var db = new BilleteraCryptoContext())
            {
                Usuario? usuarioViejo = db.Usuarios.FirstOrDefault(a => a.IdUsuario == id);
                usuarioViejo.NombreUsu = nombre;
                db.SaveChanges();
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                using (var db = new BilleteraCryptoContext())
                {
                    Usuario? oUsuario = db.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
                    db.Remove(oUsuario);
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
