namespace webApiTP4;
enum Estado
{
    Pendiente,
    Entregado,
    Cancelado
}
public class Pedido
{
    public static int cadeteDefault = 999999;
    private int nroPedido;
    private string observacion;
    private Cliente cliente;
    private Estado estado;
    private int idCadete;
    internal Estado Estado { get => estado;  }
    public int NroPedido { get => nroPedido; set => nroPedido = value;}
    public int IdCadete { get => idCadete; set => idCadete = value ;}
    public string Observacion { get => observacion; set => observacion = value; }

    public Pedido (string observacionPedido, string nombreCliente, string direccionCliente, string telefonoCliente, string datoDeReferencia) {
        estado = Estado.Pendiente;
        Observacion = observacionPedido;
        cliente = new Cliente();
        idCadete = cadeteDefault;
    }
    public Pedido(){
        
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

