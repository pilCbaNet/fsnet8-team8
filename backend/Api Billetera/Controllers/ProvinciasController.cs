
//using Api_Billetera.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Billetera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciasController : ControllerBase
    {
        // GET: api/<ProvinciasController>
        [HttpGet]
        public List<Provincias>Get()
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.Provincias.ToList();
            }
               
        }

        // GET api/<ProvinciasController>/5
        [HttpGet("{id}")]
        public Provincias Get(int id)
        {
            using (var db = new BilleteraCryptoContext())
            {
                return new ProvinciaBC().ObtenerProvincia(db, id);
            }
        }
        //[HttpGet("{idLocalidad:int}")]
        //public Provincias Get(int idLocalidad)
        //{
        //    using (var db = new BilleteraCryptoContext())
        //    {
        //        int? idProvincia = new LocalidadBC().ObtenerLocalidad(db, idLocalidad).IdProvincia;
        //        return new ProvinciaBC().ObtenerProvincia(db, idProvincia);
        //    }
        //}
        //--------------------------------------------------------------------------------------------//
        //[HttpGet("{idUusario:int}")]
        //public Provincias Get(int idUsuario)
        //{
        //    using (var db = new BilleteraCryptoContext())
        //    {
        //        int? idLocalidad = new UsuarioBC().ObtenerUsuario(db, idUsuario).IdLocalidad;
        //        int? idProvincia = new LocalidadBC().ObtenerLocalidad(db, idLocalidad.value).IdProvincia;
        //        return new ProvinciaBC().ObtenerProvincia(db, idProvincia);
        //    }
        //}

        // POST api/<ProvinciasController>
        [HttpPost]
        public void Post([FromBody] Provincias oProvincia)
        {
            using (var db = new BilleteraCryptoContext())
            {
                db.Provincias.Add(oProvincia);
                db.SaveChanges();
            }
        }

        //PUT api/<ProvinciasController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, string nombre)
        //{
        //    using (var db = new BilleteraCryptoContext())
        //    {
        //        Provincias provinciaVieja = db.Provincias.FirstOrDefault(a => a.IdProvincia == id);
        //        provinciaVieja.NomProvincia = nombre;
        //        db.SaveChanges();

        //    }
        //}
        [HttpPut("{id}")]
        public void Put([FromBody] Provincias oldProv)
        {
            using (var db = new BilleteraCryptoContext())
            {
                Provincias oProvincia = db.Provincias.Where(a => a.IdProvincia == oldProv.IdProvincia).FirstOrDefault();
                oProvincia.NomProvincia = oldProv.NomProvincia;
                db.SaveChanges();
            }

        }



        // DELETE api/<ProvinciasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                using (var db = new BilleteraCryptoContext())
                {
                    Provincias oProvincia = db.Provincias.FirstOrDefault(a => a.IdProvincia == id);
                    db.Remove(oProvincia);
                    db.SaveChanges();
                }

            }
            catch(Exception ex)
            {
                throw;
            }
                
        }
    }
}
