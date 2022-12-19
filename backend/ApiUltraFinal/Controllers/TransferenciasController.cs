

using Entities;
using Microsoft.AspNetCore.Mvc;
using Negocio;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Billetera.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TransferenciasController : ControllerBase
  {
    private readonly BilleteraCryptoContext _billeteraCryptoContext;
    public TransferenciasController(BilleteraCryptoContext billeteraCryptoContext)
    {
      _billeteraCryptoContext = billeteraCryptoContext;
    }
    // GET: api/<TransferenciasController>
    [HttpGet]
    public List<Operaciones> Get()
    {
      using (var db = new BilleteraCryptoContext())
      {
        return db.Operaciones.ToList();
      }

    }

    // GET api/<TransferenciasController>/5
    [HttpGet("{id}")]
    public Operaciones Get(int id)
    {
      using (var db = new BilleteraCryptoContext())
      {
        return new OperacionesBC().ObtenerTransferencias(db, id);
      }
    }
    [HttpGet]
    [Route("/Ultimos movimientos")]
    public List<Operaciones> GetUltimosMovimientos(int idUsuario)
    {
      var ultimaOperacion = _billeteraCryptoContext.Operaciones.Where(a => a.IdBilletera == idUsuario).ToList();
      return ultimaOperacion;
    }

    // POST api/<TransferenciasController>
    [HttpPost]
    public void Post([FromBody] Operaciones oOperaciones)
    {
      using (var db = new BilleteraCryptoContext())
      {
        db.Operaciones.Add(oOperaciones);
        db.SaveChanges();
      }
    }

    //POST RETIRO 

    [HttpPost]
    [Route("/agregarTransaccion/retiro/{IdTipo}")]
    public async Task<ActionResult> PostRetiro([FromBody] Operaciones oOperaciones, int IdTipo = 2)
    {
      using (var db = new BilleteraCryptoContext())
      {
        var nuevaTransaccion = new Operaciones()
        {
            //TipoTransf = IdTipo,
            MontoArsTransf = oOperaciones.MontoArsTransf,
            MontoBtcTrans = oOperaciones.MontoBtcTrans,

            IdBilletera = oOperaciones.IdBilletera

        };


                await db.Operaciones.AddAsync(nuevaTransaccion);
        await db.SaveChangesAsync();

        return Ok();
      }




    }

    //POST DEPOSITO
    //ACA YO LO HABIA PENSADO CON ID TIPO TRANSF PERO AHORA EN LA TABLA OPERACIONES EXISTE TIPO_TRANSF , SUPONGO QUE SERA STRING ASI QUE HABRIA QUE VER COMO HACER CON ESTE METODO
    [HttpPost]
    [Route("/agregarTransaccion/deposito/{IdTipo}")]
    public async Task<ActionResult> PostDeposito([FromBody] Operaciones oOperaciones, int IdTipo = 1)
    {
      using (var db = new BilleteraCryptoContext())
      {
        var nuevaTransaccion = new Operaciones()
        {
          //TipoTransf = IdTipo,
          MontoArsTransf = oOperaciones.MontoArsTransf,
          MontoBtcTrans = oOperaciones.MontoBtcTrans,
          
          IdBilletera = oOperaciones.IdBilletera

        };


        await db.Operaciones.AddAsync(nuevaTransaccion);
        await db.SaveChangesAsync();

        return Ok();
      }



    }

    // PUT api/<TransferenciasController>/5
    [HttpPut("{id}")]
    public void Put([FromBody] Operaciones oldOperaciones)
    {
      using (var db = new BilleteraCryptoContext())
      {
                Operaciones oOperaciones = db.Operaciones.Where(a => a.IdTransferencia == oldOperaciones.IdTransferencia).FirstOrDefault();
                oOperaciones.MontoArsTransf = oldOperaciones.MontoArsTransf;
                oOperaciones.MontoBtcTrans = oldOperaciones.MontoBtcTrans;
                
                oOperaciones.IdBilletera = oldOperaciones.IdBilletera;
                oOperaciones.TipoTransf = oldOperaciones.TipoTransf;
        db.SaveChanges();
      }
    }

    // DELETE api/<TransferenciasController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      try
      {
        using (var db = new BilleteraCryptoContext())
        {
                    Operaciones oOperaciones = db.Operaciones.FirstOrDefault(a => a.IdTransferencia == id);
          db.Remove(oOperaciones);
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
