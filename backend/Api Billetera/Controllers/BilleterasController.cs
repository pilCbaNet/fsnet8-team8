//using Api_Billetera.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Negocio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Billetera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BilleterasController : ControllerBase
    {
        // GET: api/<BilleteraController>
        [HttpGet]
        public List<Billeteras> Get()
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.Billeteras.ToList();
            }

        }

        // GET api/<BilleteraController>/5
        [HttpGet("{id}")]
        public Billeteras Get(int id)
        {
            using (var db = new BilleteraCryptoContext())
            {
                return new BilleteraBC().ObtenerBilletera(db, id);
            }
        }

        // POST api/<BilleteraController>
        [HttpPost]
        public void Post([FromBody] Billeteras oBilleteras)
        {
            using (var db = new BilleteraCryptoContext())
            {
                db.Billeteras.Add(oBilleteras);
                db.SaveChanges();
            }
        }

        // PUT api/<BilleteraController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Billeteras OldBille)
        {
            using(var db = new BilleteraCryptoContext())
            {
                Billeteras oBilleteras = db.Billeteras.Where(a => a.IdBilletera == OldBille.IdBilletera).FirstOrDefault();
                oBilleteras.CvuBille = OldBille.CvuBille;
                oBilleteras.IdUsuario = OldBille.IdUsuario;
                oBilleteras.IdEstado = OldBille.IdEstado;
                db.SaveChanges();
            }
        }

        
       

        // DELETE api/<BilleteraController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                using (var db = new BilleteraCryptoContext())
                {
                    Billeteras oBilleteras = db.Billeteras.FirstOrDefault(a => a.IdBilletera == id);
                    db.Remove(oBilleteras);
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
