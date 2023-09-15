using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace webApiTP4;

[ApiController]
[Route("[controller]")]

public class CadeteriaController : ControllerBase //queda
{

    private readonly ILogger<CadeteriaController> _logger; //queda
    //QUEDA
    public CadeteriaController(ILogger<CadeteriaController> logger) //queda
    {
        _logger = logger;
        var cadeteri = new Cadeteria("HOOAL","ffeaffda");
    }
  
    [HttpGet]
    public ActionResult<string> getNombreCadeteria()
    {
      
      return Ok("todo ok");
    }
    //para tener dos get sin parametros agregar route
    [HttpGet]
    [Route("Pedidos")]
    public ActionResult<string> getNombreCadeteriaPedidos()
    {
        return Ok("todo ok");
    }
    //para añadir un pdedio le mandamos un json?
    //pedido.Nro = listadodepedidos.count es un autoincrementable ya que count devuelve la cantidad de elemenentoes en un IEnumerable
}
