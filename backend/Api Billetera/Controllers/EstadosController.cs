//using Api_Billetera.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Negocio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Billetera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        // GET: api/<EstadosController>
        [HttpGet]
        public List<Estados> Get()
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.Estados.ToList();
            }

        }

        // GET api/<EstadosController>/5
        [HttpGet("{id}")]
        public Estados Get(int id)
        {
            using (var db = new BilleteraCryptoContext())
            {
                return new EstadoBC().ObtenerEstado(db, id);
            }
        }

        // POST api/<EstadosController>
        [HttpPost]
        public void Post([FromBody] Estados oEstado)
        {
            using (var db = new BilleteraCryptoContext())
            {
                db.Estados.Add(oEstado);
                db.SaveChanges();
            }
        }

        // PUT api/<EstadosController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Estados oldEStado)
        {
            using (var db = new BilleteraCryptoContext())
            {
                Estados oEstado = db.Estados.Where(a => a.IdEstado == oldEStado.IdEstado).FirstOrDefault();
                oEstado.NombreEst = oldEStado.NombreEst;
                db.SaveChanges();
            }
        }

        // DELETE api/<EstadosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                using (var db = new BilleteraCryptoContext())
                {
                    Estados oEstado = db.Estados.FirstOrDefault(a => a.IdEstado == id);
                    db.Remove(oEstado);
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
