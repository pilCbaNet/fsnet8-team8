using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BilleteraGrupoHWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedasController : ControllerBase
    {

        [HttpGet]
        public List<Moneda> Get()
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.Monedas.ToList();
            }
        }

        [HttpGet("{id:int}")]
        public Moneda? Get(int id)
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.Monedas.Include(a => a.UsuariosMoneda).FirstOrDefault(a => a.IdMoneda == id);
                //Creo que UsuariosMoneda es la relación con la tabla
            }
        }

        [HttpPost]
        public void Post([FromBody] Moneda oMoneda)
        {
            using (var db = new BilleteraCryptoContext())
            {
                db.Monedas.Add(oMoneda);
                db.SaveChanges();
            }
        }


        [HttpPut]
        public void Put(int id, string nombre)
        {
            using (var db = new BilleteraCryptoContext())
            {
                Moneda? monedaVieja = db.Monedas.FirstOrDefault(a => a.IdMoneda == id);
                monedaVieja.NombreMon = nombre;
                db.SaveChanges();
            }
        }
    }
}
