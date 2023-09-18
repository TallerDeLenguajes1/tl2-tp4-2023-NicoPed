using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace webApiTP4;

[ApiController]
[Route("[controller]")]

public class CadeteriaController : ControllerBase //queda
{
    private Cadeteria cadeteri;
    private readonly ILogger<CadeteriaController> _logger; //queda
    //QUEDA
    public CadeteriaController(ILogger<CadeteriaController> logger) //queda
    {
        _logger = logger;
        cadeteri = Cadeteria.getCadeteria();
    }
  
    [HttpGet]
    public ActionResult<string> getNombreCadeteria()
    {
        string datos = cadeteri.mostrarDatosCadeteria();
        return Ok(datos);
    }
    //para tener dos get sin parametros agregar route
    [HttpGet]
    [Route("Pedidos")]
    public ActionResult<IEnumerable<Pedido>> getPedidos()
    {
        var pedidos = cadeteri.ListadoPedido;
        return Ok(pedidos);
    }
    [HttpGet]
    [Route("Cadetes")]
    public ActionResult<IEnumerable<Pedido>> getCadetes()
    {
        var cadetes = cadeteri.ListadoCadetes;
        return Ok(cadetes);
    }
    
    [HttpPost]
    [Route("AgregarPedido")]
    public ActionResult<Pedido> agregarPedido(Pedido pedido){
        var nuevoPedido = cadeteri.AgregarPedido(pedido);
        return Created("",nuevoPedido);
    }

    [HttpPut]
    [Route ("AsignarPedido")]
    public ActionResult asignarPedido(int nroPedido, int idCadete){
        if (cadeteri.asignarCadeteAPedido(nroPedido,idCadete))
        {
            return Ok($"Pedido: {nroPedido} Asigando al cadete {idCadete}");
        }
        return BadRequest("Algo salio mal. Asegurese de ingresar correctamente los datos");
    }
    
    [HttpPut]
    [Route ("CambiarEstadoPedido")]
    public ActionResult CambiarEstadoPedido(int nroPedido){
        if (cadeteri.CambiarPedidoDeEstado(nroPedido))
        {
            return Ok($"Estado del pedido: {nroPedido} cambiado a Entregado");
        }
        return BadRequest("Algo salio mal. Asegurese de ingresar correctamente los datos");
    }

    [HttpPut]
    [Route ("CambiarCadetePedido")]
    public ActionResult cambiarCadetePedido(int nroPedido, int idCadete){
        if (cadeteri.asignarCadeteAPedido(nroPedido,idCadete))
        {
            return Ok($"Pedido: {nroPedido} Asigando al cadete {idCadete}");
        }
        return BadRequest("Algo salio mal. Asegurese de ingresar correctamente los datos");
    }   
    [HttpGet]
    [Route("getInforme")]
    public ActionResult <IEnumerable<Informe>> getInforme(){
        var nuevoInforme = Informe.GenerarInforme(cadeteri);
        return Ok(nuevoInforme);
    }
    // para añadir un pdedio le mandamos un json?
    // pedido.Nro = listadodepedidos.count es un autoincrementable ya que count devuelve la cantidad de elemenentoes en un IEnumerable
}
