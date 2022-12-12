using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BilleteraGrupoHWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadesController : ControllerBase
    {

        [HttpGet]
        public List<Localidade> Get()
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.Localidades.ToList();
            }
        }

        
        [HttpGet("{id:int}")]
        public Localidade? Get(int id)
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.Localidades.Include(a => a.IdProvincia).FirstOrDefault(a => a.IdLocalidad == id);
                //Creo que IdProvincia es la relacion con la tabla
            }
        }

        [HttpPost]
        public void Post([FromBody] Localidade oLocalidad)
        {
            using (var db = new BilleteraCryptoContext())
            {
                db.Localidades.Add(oLocalidad);
                db.SaveChanges();
            }
        }


        [HttpPut]
        public void Put(int id, string nombre)
        {
            using (var db = new BilleteraCryptoContext())
            {
                Localidade? localidadVieja = db.Localidades.FirstOrDefault(a => a.IdLocalidad == id);
                localidadVieja.NomLocalidad = nombre;
                db.SaveChanges();
            }
        }
    }
}
