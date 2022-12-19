
//using Api_Billetera.Models;
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
    public List<Transferencias> Get()
    {
      using (var db = new BilleteraCryptoContext())
      {
        return db.Transferencias.ToList();
      }

    }

    // GET api/<TransferenciasController>/5
    [HttpGet("{id}")]
    public Transferencias Get(int id)
    {
      using (var db = new BilleteraCryptoContext())
      {
        return new TransferenciaBC().ObtenerTransferencias(db, id);
      }
    }
    [HttpGet]
    [Route("/Ultimos movimientos")]
    public List<Transferencias> GetUltimosMovimientos(int idUsuario)
    {
      var ultimaOperacion = _billeteraCryptoContext.Transferencias.Where(a => a.IdBilletera == idUsuario).ToList();
      return ultimaOperacion;
    }

    // POST api/<TransferenciasController>
    [HttpPost]
    public void Post([FromBody] Transferencias oTransferencias)
    {
      using (var db = new BilleteraCryptoContext())
      {
        db.Transferencias.Add(oTransferencias);
        db.SaveChanges();
      }
    }

    //POST RETIRO 

    [HttpPost]
    [Route("/agregarTransaccion/retiro/{IdTipo}")]
    public async Task<ActionResult> PostRetiro([FromBody] Transferencias oTransferencias, int IdTipo = 2)
    {
      using (var db = new BilleteraCryptoContext())
      {
        var nuevaTransaccion = new Transferencias()
        {
          IdTipoTransferencia = IdTipo,
          MontoTransf = oTransferencias.MontoTransf,
          CvuOrigenTransf = oTransferencias.CvuOrigenTransf,
          CvuDestinoTransf = oTransferencias.CvuDestinoTransf,
          IdBilletera = oTransferencias.IdBilletera

        };


        await db.Transferencias.AddAsync(nuevaTransaccion);
        await db.SaveChangesAsync();

        return Ok();
      }




    }

    //POST DEPOSITO

    [HttpPost]
    [Route("/agregarTransaccion/deposito/{IdTipo}")]
    public async Task<ActionResult> PostDeposito([FromBody] Transferencias oTransferencias, int IdTipo = 1)
    {
      using (var db = new BilleteraCryptoContext())
      {
        var nuevaTransaccion = new Transferencias()
        {
          IdTipoTransferencia = IdTipo,
          MontoTransf = oTransferencias.MontoTransf,
          CvuOrigenTransf = oTransferencias.CvuOrigenTransf,
          CvuDestinoTransf = oTransferencias.CvuDestinoTransf,
          IdBilletera = oTransferencias.IdBilletera

        };


        await db.Transferencias.AddAsync(nuevaTransaccion);
        await db.SaveChangesAsync();

        return Ok();
      }



    }

    // PUT api/<TransferenciasController>/5
    [HttpPut("{id}")]
    public void Put([FromBody] Transferencias oldTransf)
    {
      using (var db = new BilleteraCryptoContext())
      {
        Transferencias oTransferencias = db.Transferencias.Where(a => a.IdTransferencia == oldTransf.IdTransferencia).FirstOrDefault();
        oTransferencias.MontoTransf = oldTransf.MontoTransf;
        oTransferencias.CvuOrigenTransf = oldTransf.CvuOrigenTransf;
        oTransferencias.CvuDestinoTransf = oldTransf.CvuDestinoTransf;
        oTransferencias.IdBilletera = oldTransf.IdBilletera;
        oTransferencias.IdTipoTransferencia = oldTransf.IdTipoTransferencia;
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
          Transferencias oTransferencias = db.Transferencias.FirstOrDefault(a => a.IdTransferencia == id);
          db.Remove(oTransferencias);
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