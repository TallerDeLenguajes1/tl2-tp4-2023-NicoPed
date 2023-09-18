namespace webApiTP4;
enum Estado
{
    Pendiente,
    Entregado,
    Cancelado
}
public class Pedido
{
    private int cadeteDefault = 999999;
    private int nroPedido;
    private string observacion;
    private Cliente cliente;
    private Estado estado;
    private int idCadete;
    internal Estado Estado { get => estado;  }
    public string Observacion { get => observacion;  }
    public int NroPedido { get => nroPedido; set => nroPedido = value;}
    public int IdCadete { get => idCadete; set => idCadete = value ;}
    public int CadeteDefault {get => cadeteDefault;}
    public Pedido (string observacionPedido, string nombreCliente, string direccionCliente, string telefonoCliente, string datoDeReferencia) {
        estado = Estado.Pendiente;
        observacion = observacionPedido;
        cliente = new Cliente(nombreCliente,direccionCliente,telefonoCliente,datoDeReferencia);
        idCadete = cadeteDefault;
    }
    public string verDireccionCliente(){
        string? direccion;
        direccion = cliente.Direccion + "-" + cliente.DatosReferencia;
        return direccion;
    }
    public string verDatosCliente(){
        string? datos;
        datos = cliente.Nombre + "-" + cliente.Telefono;
        return datos;
    }
     public bool CambiarPedidoDeEstado(){
        if (estado != Estado.Cancelado)
        {
            estado = Estado.Entregado;
            return true;
        }
        return false;
    }
    public bool CancelarPedido(){
        if (estado != Estado.Entregado)
        {
            estado = Estado.Cancelado;
            return true;
        }
        return false;
    }
    public string DatosDelPedido(){
        string? datos;
        datos = $" Nro Pedido: {NroPedido.ToString()}\nEstado: {Estado.ToString()}\nCadete Asignado: {IdCadete}\nObservacion: {Observacion}\nDatos del Cliente {verDatosCliente()}Direccion del Cliente : {verDireccionCliente()} ";
        return datos;
    }
}

