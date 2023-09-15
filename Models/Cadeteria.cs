using System.Text;

namespace webApiTP4;

public class Cadeteria{
    private string nombreCadeteria;
    private string telefonoCadeteria;
    private List<Cadete> listadoCadetes;
    private List <Pedido> listadoPedido;
    public List<Cadete> ListadoCadetes { get => listadoCadetes;  }
    public string NombreCadeteria { get => nombreCadeteria;  }
    public string TelefonoCadeteria { get => telefonoCadeteria; }
    public List<Pedido> ListadoPedido { get => listadoPedido;  }

    
    public Cadeteria(string Nombre, string Telefono){
        nombreCadeteria = Nombre;
        telefonoCadeteria = Telefono;
        listadoCadetes = new List<Cadete>();
        listadoPedido = new List<Pedido>();
    }
    public bool EliminarPedido(int numeroPedido){
        var pedidoACambiar = BuscarPedido(numeroPedido);
        if (pedidoACambiar != null)
        {
            if (pedidoACambiar.CancelarPedido()){
                pedidoACambiar.IdCadete = pedidoACambiar.CadeteDefault;
                return true;
            }else
            {
                return false;
            }
            
        }else
        {
            return false;
        }
    }
    public bool CambiarPedidoDeEstado(int numeroPedido){
        var pedidoACambiar = BuscarPedido(numeroPedido);
        if (pedidoACambiar != null)
        {
            return pedidoACambiar.CambiarPedidoDeEstado();
            
        }else
        {
            return false;
        }
    }
    public Cadete buscarCadete(int idCadete){
        Cadete cadeteBuscado;
        cadeteBuscado = listadoCadetes.FirstOrDefault(cade => cade.IdCadete == idCadete);
        return cadeteBuscado;
    }
    public Pedido BuscarPedido(int numeroPedido){
        Pedido pedidoBuscado;
        pedidoBuscado = ListadoPedido.FirstOrDefault(pedido => pedido.NroPedido == numeroPedido);
        return pedidoBuscado;
    }
    public bool asignarCadeteAPedido(int numeroPedido, int idDelCadete){
        var pedioAsignar = BuscarPedido(numeroPedido);
        if (pedioAsignar != null)
        { 
            if (pedioAsignar.Estado != Estado.Entregado)
            {    
                if (buscarCadete(idDelCadete) != null)
                {
                    pedioAsignar.IdCadete = idDelCadete;
                    return true;

                }else
                {
                    return false;
                }
            }else
            {
                return false;
            }
        }else{
            return false;
        }
    }

    public float JornalACobrar(int idCadete){
        float aCobrar = constantes.CobroPorEnvio;
        var pedidosRealizados = from pedi in listadoPedido 
        where pedi.IdCadete == idCadete && pedi.Estado == Estado.Entregado 
        select pedi;
        aCobrar *= pedidosRealizados.Count();
        return aCobrar;
    }
    
    public void AgregarCadete(int IdCadete, string NombreCadete, string DireccionCadete, string TelefonoCadete){
        Cadete nuevoCadete = new Cadete(IdCadete,NombreCadete,DireccionCadete,TelefonoCadete);
        ListadoCadetes.Add(nuevoCadete);
    }
    public void CargarCadetes(List <Cadete> listadoCadetes){
        ListadoCadetes.AddRange(listadoCadetes);
    }
    public bool AgregarPedido(int numeroPedido, string observacionPedido, string nombreCliente, string direccionCliente, string telefonoCliente, string datoDeReferencia){
        Pedido nuevoPedido = new Pedido(numeroPedido,observacionPedido,nombreCliente,direccionCliente,telefonoCliente,datoDeReferencia);
        if (nuevoPedido != null)
        {
            listadoPedido.Add(nuevoPedido);
            return true;
        }
            return false;

    }
    public string mostrarDatosCadeteria(){
        string datosCadeteria = nombreCadeteria + " - " + telefonoCadeteria;
        return datosCadeteria;
    }
    public string mostrarPedidos(){
        StringBuilder listadoDePedidos = new StringBuilder();
        foreach (var pedido in listadoPedido)
        {
            listadoDePedidos.AppendLine(pedido.DatosDelPedido());
        }
        return listadoDePedidos.ToString();
    }
    public string mostrarCadetes(){
        StringBuilder listadoDeCadetes = new StringBuilder();
        foreach (var cade in listadoCadetes)
        {
            listadoDeCadetes.AppendLine(cade.MostrarInfo());
        }
        return listadoDeCadetes.ToString();
    }
}