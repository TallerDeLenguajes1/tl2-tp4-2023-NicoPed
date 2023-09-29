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
    public Cliente Cliente { get => cliente; }

    public Pedido (string observacionPedido, string nombreCliente, string direccionCliente, string telefonoCliente, string datoDeReferencia) {
        estado = Estado.Pendiente;
        Observacion = observacionPedido;
        cliente = new Cliente(nombreCliente,direccionCliente,telefonoCliente,datoDeReferencia);
        idCadete = cadeteDefault;
    }
    public Pedido(){
        
    }
    public string verDireccionCliente(){
        string? direccion;
        direccion = Cliente.Direccion + ";" + Cliente.DatosReferencia;
        return direccion;
    }
    public string verDatosCliente(){
        string? datos;
        datos = $"{Cliente.Nombre};{Cliente.Direccion};{Cliente.Telefono};{Cliente.DatosReferencia}";
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
        datos = $"{NroPedido.ToString()};{Estado.ToString()};{IdCadete};{Observacion};{verDatosCliente()}";
        return datos;
    }
}

