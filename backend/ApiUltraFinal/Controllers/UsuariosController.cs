
using Entities;
using Microsoft.AspNetCore.Mvc;
using Negocio;
using System.Text.Json.Nodes;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Billetera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // GET: api/<UsuariosController>
        [HttpGet]
        public List<Usuarios> Get()
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.Usuarios.ToList();
            }

        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public Usuarios Get(int id)
        {
            using(var db = new BilleteraCryptoContext())
            {
                return new UsuarioBC().ObtenerUsuario(db, id);
            }
        }

        [HttpPost("login")]
        public JsonObject PostByLogin([FromBody] JsonObject login)
        {
            using (var db = new BilleteraCryptoContext())
            {
                Usuarios user = new UsuarioBC().LoginUsuario(db, login["username"].ToString(), login["password"].ToString());
                var loginResponse = new JsonObject
                {


                    ["userId"] = user.IdUsuario,
                    ["name"] = user.NombreUsu + ", " + user.ApellidoUsu,
                    
                };

                return loginResponse;
            }
        }




    [HttpPost]
    [Route("registrar")]
    public void PostNewUser([FromBody] Usuarios oUsuarios)
    {
      using (var db = new BilleteraCryptoContext())
      {


        oUsuarios.FechaAltaUsu = DateTime.Now;
        oUsuarios.FechaBajaUsu = null;
        db.Usuarios.Add(oUsuarios);
        db.SaveChanges();

        Billeteras oBilletera = new Billeteras();
        oBilletera.SaldoArsBille = 0;
        Random rd = new();
        oBilletera.CvuBille = rd.Next(1000000000, 999999999);
        oBilletera.IdUsuario = oUsuarios.IdUsuario;


        db.Billeteras.Add(oBilletera);
        db.SaveChanges();
      }
    }



        [HttpPut("{id}")]
        public void Put( [FromBody] Usuarios OldUser)
        {
            using (var db = new BilleteraCryptoContext())
            {
                Usuarios oUsuarios = db.Usuarios.Where(a => a.IdUsuario == OldUser.IdUsuario).FirstOrDefault();
                oUsuarios.NombreUsu = OldUser.NombreUsu;
                oUsuarios.ApellidoUsu=OldUser.ApellidoUsu;
                oUsuarios.DniUsu = OldUser.DniUsu;
                oUsuarios.FechaNacUsu=OldUser.FechaNacUsu;
                oUsuarios.EmailUsu = OldUser.EmailUsu;
                
                oUsuarios.PasswordUsu = OldUser.PasswordUsu;
                
                oUsuarios.FechaAltaUsu=OldUser.FechaAltaUsu;
                oUsuarios.FechaBajaUsu = OldUser.FechaBajaUsu;
                
                db.SaveChanges();
            }
                
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                using (var db = new BilleteraCryptoContext())
                {
                    Usuarios oUsuario = db.Usuarios.FirstOrDefault(a => a.IdUsuario == id);
                    db.Remove(oUsuario);
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
