using Entities;
using Microsoft.AspNetCore.Mvc;
using Negocio;

namespace BilleteraGrupoHWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciasController : ControllerBase
    {
        

        [HttpGet]
        public List<Provincia> Get()
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.Provincias.ToList();
            }
        }

        [HttpGet("{id:int}")]
        public  Provincia? Get(int id)
        {
            using (var db = new BilleteraCryptoContext())
            {
                return new ProvinciaBC().ObtenerProvincia(db,id);
            }
        }

        [HttpPost]
        public void Post([FromBody] Provincia oprovincia)
        {
            using (var db = new BilleteraCryptoContext())
            {
                db.Provincias.Add(oprovincia);
                db.SaveChanges();
            }
        }

        [HttpPut]
        public void Put( int id, string nombre)
        {
            using (var db = new BilleteraCryptoContext())
            {
                Provincia? provinciaVieja = db.Provincias.FirstOrDefault(a => a.IdProvincia == id);
                provinciaVieja.NomProvincia = nombre;
                db.SaveChanges();
            }
        }

        //[HttpDelete]
        //public void Delete(int id)
        //{
        //    try
        //    {
        //        using (var db = new BilleteraCryptoContext())
        //        {
        //            Provincia? oProvincia = db.Provincias.FirstOrDefault(x => x.IdProvincia == id);
        //            db.Remove(oProvincia);
        //            db.SaveChanges();
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ;
        //    }
        //}
    }
}
