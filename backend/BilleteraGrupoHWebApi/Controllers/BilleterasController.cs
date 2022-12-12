using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BilleteraGrupoHWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BilleterasController : ControllerBase
    {
        [HttpGet]
        public List<Billetera> Get()
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.Billeteras.ToList();
            }
        }

        [HttpGet("{id:int}")]
        public Billetera? Get(int id)
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.Billeteras.Include(a => a.Transferencia).FirstOrDefault(a => a.IdBilletera == id);
                //Creo que Transferencia es la relación con la tabla
            }
        }

        [HttpPost]
        public void Post([FromBody] Billetera oBilletera)
        {
            using (var db = new BilleteraCryptoContext())
            {
                db.Billeteras.Add(oBilletera);
                db.SaveChanges();
            }
        }


        [HttpPut]
        public void Put(int id, string nombre)
        {
            using (var db = new BilleteraCryptoContext())
            {
                Billetera? billeteraVieja = db.Billeteras.FirstOrDefault(a => a.IdBilletera == id);
                billeteraVieja.NomBilletera = nombre;
                db.SaveChanges();
            }
        }
    }
}
