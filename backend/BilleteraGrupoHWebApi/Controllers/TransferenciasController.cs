using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BilleteraGrupoHWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferenciasController : ControllerBase
    {

        [HttpGet]
        public List<Transferencia> Get()
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.Transferencias.ToList();
            }
        }

        [HttpGet("{id:int}")]
        public Transferencia? Get(int id)
        {
            using (var db = new BilleteraCryptoContext())
            {
                return db.Transferencias.Include(a => a.IdBilletera).FirstOrDefault(a => a.IdTransferencia == id);
                //aca nose que vergas pasó con IdBilletera porq no me dejaba ninguna relación con ninguna tabla
            }
        }

        [HttpPost]
        public void Post([FromBody] Transferencia oTransferencia)
        {
            using (var db = new BilleteraCryptoContext())
            {
                db.Transferencias.Add(oTransferencia);
                db.SaveChanges();
            }
        }


        [HttpPut]
        public void Put(int id, string nombre)
        {
            using (var db = new BilleteraCryptoContext())
            {
                Transferencia? transferenciaVieja = db.Transferencias.FirstOrDefault(a => a.IdTransferencia == id);
                transferenciaVieja.NomTransferencia= nombre;
                db.SaveChanges();
            }
        }
    }
}
