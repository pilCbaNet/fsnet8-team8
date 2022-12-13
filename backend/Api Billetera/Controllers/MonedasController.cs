//using Api_Billetera.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Negocio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Billetera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedasController : ControllerBase
    {
        // GET: api/<MonedasController>
        [HttpGet]
        public List<Monedas> Get()
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.Monedas.ToList();
            }

        }

        // GET api/<MonedasController>/5
        [HttpGet("{id}")]
        public Monedas? Get(int id)
        {
           using(var db = new BilleteraCryptoContext())
            {
                return new MonedaBC().ObtenerMoneda(db, id);
            }
        }

        // POST api/<MonedasController>
        [HttpPost]
        public void Post([FromBody] Monedas oMonedas)
        {
            using (var db = new BilleteraCryptoContext())
            {
                db.Monedas.Add(oMonedas);
                db.SaveChanges();
            }
        }

        // PUT api/<MonedasController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Monedas oldMonedas)
        {
            using (var db = new BilleteraCryptoContext())
            {
                Monedas? oMoneda = db.Monedas.Where(a => a.IdMoneda == oldMonedas.IdMoneda).FirstOrDefault();
                oMoneda.NombreMon = oldMonedas.NombreMon;
                db.SaveChanges();
            }

        }

        // DELETE api/<MonedasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                using (var db = new BilleteraCryptoContext())
                {
                    Monedas? oMoneda = db.Monedas.FirstOrDefault(a => a.IdMoneda == id);
                    db.Remove(oMoneda);
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
