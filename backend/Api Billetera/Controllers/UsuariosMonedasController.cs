
//using Api_Billetera.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Negocio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Billetera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosMonedasController : ControllerBase
    {
        // GET: api/<UsuariosMonedasController>
        [HttpGet]
        public List<UsuariosMonedas> Get()
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.UsuariosMonedas.ToList();
            }

        }

        // GET api/<UsuariosMonedasController>/5
        [HttpGet("{id}")]
        public UsuariosMonedas? Get(int id)
        {
            using (var db = new BilleteraCryptoContext())
            {
                return new UsuariosMonedasBC().ObtenerUsuariosMonedas(db, id);
            }
               
        }

        // POST api/<UsuariosMonedasController>
        [HttpPost]
        public void Post([FromBody] UsuariosMonedas oUsuarioMoneda)
        {
            using (var db = new BilleteraCryptoContext())
            {
                db.UsuariosMonedas.Add(oUsuarioMoneda);
                db.SaveChanges();
            }
        }

        // PUT api/<UsuariosMonedasController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] UsuariosMonedas oldUsuaMon)
        {
            using (var db = new BilleteraCryptoContext())
            {
                UsuariosMonedas oUsuarioMoneda = db.UsuariosMonedas.Where(a => a.IdUsuarioMoneda == oldUsuaMon.IdUsuarioMoneda).FirstOrDefault();
                oUsuarioMoneda.IdMoneda=oldUsuaMon.IdUsuarioMoneda;
                oUsuarioMoneda.IdUsuario = oldUsuaMon.IdUsuario;
                db.SaveChanges();
            }
        }

        // DELETE api/<UsuariosMonedasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                using (var db = new BilleteraCryptoContext())
                {
                    UsuariosMonedas oUsuarioMoneda = db.UsuariosMonedas.FirstOrDefault(a => a.IdUsuarioMoneda == id);
                    db.Remove(oUsuarioMoneda);
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
