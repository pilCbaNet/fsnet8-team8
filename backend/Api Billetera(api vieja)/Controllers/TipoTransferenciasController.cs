using Entities;
using Microsoft.AspNetCore.Mvc;
using Negocio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Billetera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTransferenciasController : ControllerBase
    {
        // GET: api/<TipoTransferenciasController>
        [HttpGet]
        public List<TipoTransferencia> Get()
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.TipoTransferencias.ToList();
            }

        }

        // GET api/<TipoTransferenciasController>/5
        [HttpGet("{id}")]
        public TipoTransferencia Get(int id)
        {
            using (var db = new BilleteraCryptoContext())
            {
                return new TipoTransferenciaBC().ObtenerTipoTransferencia(db, id);
            }
        }

        // POST api/<TipoTransferenciasController>
        [HttpPost]
        public void Post([FromBody] TipoTransferencia oTipoTransferencia)
        {
            using (var db = new BilleteraCryptoContext())
            {
                db.TipoTransferencias.Add(oTipoTransferencia);
                db.SaveChanges();
            }
        }

        // PUT api/<TipoTransferenciasController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] TipoTransferencia OldTipoTransf)
        {
            using (var db = new BilleteraCryptoContext())
            {
                TipoTransferencia oTipoTransferencia = db.TipoTransferencias.Where(a => a.IdTipoTransferencia == OldTipoTransf.IdTipoTransferencia).FirstOrDefault();
                oTipoTransferencia.NomTrasferencia = OldTipoTransf.NomTrasferencia;
               
                db.SaveChanges();
            }
        }

        // DELETE api/<TipoTransferenciasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                using (var db = new BilleteraCryptoContext())
                {
                    TipoTransferencia oTipoTransferencia = db.TipoTransferencias.FirstOrDefault(a => a.IdTipoTransferencia == id);
                    db.Remove(oTipoTransferencia);
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
