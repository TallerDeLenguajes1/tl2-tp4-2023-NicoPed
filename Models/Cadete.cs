namespace webApiTP4;

public class Cadete{
    private int idCadete;
    private string nombreCadete;
    private string direccionCadete;
    private string telefonoCadete;

    public int IdCadete { get => idCadete; set => idCadete = value; }
    public string NombreCadete { get => nombreCadete; set => nombreCadete = value; }
    public string DireccionCadete { get => direccionCadete; set => direccionCadete = value; }
    public string TelefonoCadete { get => telefonoCadete; set => telefonoCadete = value; }

    
    public Cadete (int Id, string Nombre, string Direccion, string Telefono ){
        IdCadete = Id;
        NombreCadete = Nombre;
        DireccionCadete = Direccion;
        TelefonoCadete = Telefono;
    }
    public Cadete (){
        
    }
    public string MostrarInfo(){
        string datos;
        datos = ($" Id: {IdCadete}\nNombre: {NombreCadete}\nDireccion: {DireccionCadete}\nTelefono: {TelefonoCadete}");
        return datos;
    }

    // public void AgregarPedido(Pedido nuevoPedido){
    //     listadoPedido.Add(nuevoPedido);
    // }
    // public int CantidadDePedidos(){
    //     return listadoPedido.Count();
    // }
    // public void eliminarPedido(Pedido PedidoAEliminar){
    //     listadoPedido.Remove(PedidoAEliminar);
    // }
    // public void CambiarPedidoDeEstado(int numeroPedido){
    //     Pedido pedidoACambiar = BuscarPedido(numeroPedido);
    //     if (pedidoACambiar.CambiarPedidoDeEstado())
    //     {
    //         pedidosRealizados ++;
    //     }
    // }
    // public Pedido BuscarPedido(int numeroPedido){
    //     Pedido pedidoBuscado;
    //     pedidoBuscado = ListadoPedido.FirstOrDefault(pedido => pedido.NroPedido == numeroPedido);
    //     return pedidoBuscado;
    // }
}