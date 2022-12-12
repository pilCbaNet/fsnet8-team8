using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BilleteraGrupoHWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {

        [HttpGet]
        public List<Estado> Get()
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.Estados.ToList();
            }
        }


        [HttpGet("{id:int}")]
        public Estado? Get(int id)
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.Estados.Include(a => a.Billeteras).FirstOrDefault(a => a.IdEstado == id);
                //Nose porq en el include va Billeteras, creo que es la relacion de la tabla
            }
        }

        [HttpPost]
        public void Post([FromBody] Estado oEstado)
        {
            using (var db = new BilleteraCryptoContext())
            {
                db.Estados.Add(oEstado);
                db.SaveChanges();
            }
        }

        [HttpPut]
        public void Put(int id, string nombre)
        {
            using (var db = new BilleteraCryptoContext())
            {
                Estado? estadoViejo = db.Estados.FirstOrDefault(a => a.IdEstado == id);
                estadoViejo.NombreEst = nombre;
                db.SaveChanges();
            }
        }
    }
}
