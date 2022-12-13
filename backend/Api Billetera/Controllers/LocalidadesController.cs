//using Api_Billetera.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Negocio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Billetera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadesController : ControllerBase
    {
        // GET: api/<LocalidadesController>
        [HttpGet]
        public List<Localidades> Get()
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.Localidades.ToList();
            }

        }

        // GET api/<LocalidadesController>/5
        [HttpGet("{id}")]
        public Localidades Get(int id)
        {
            using (var db = new BilleteraCryptoContext())
            {
                return new LocalidadBC().ObtenerLocalidad(db, id);
            }
                
        }

        // POST api/<LocalidadesController>
        [HttpPost]
        public void Post([FromBody] Localidades oLocalidades)
        {
            using (var db = new BilleteraCryptoContext())
            {
                db.Localidades.Add(oLocalidades);
                db.SaveChanges();
            }
        }

        // PUT api/<LocalidadesController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Localidades oldLocal)
        {
            using(var db = new BilleteraCryptoContext())
            {
                Localidades oLocalidad = db.Localidades.Where(a => a.IdLocalidad == oldLocal.IdLocalidad).FirstOrDefault();
                oLocalidad.NomLocalidad = oldLocal.NomLocalidad;
                oLocalidad.IdProvincia=oldLocal.IdProvincia;
                db.SaveChanges();
            } 
        }

        // DELETE api/<LocalidadesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                using (var db = new BilleteraCryptoContext())
                {
                    Localidades oLocalidad = db.Localidades.FirstOrDefault(a => a.IdLocalidad == id);
                    db.Remove(oLocalidad);
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
