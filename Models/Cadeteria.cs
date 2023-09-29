using System.Text;

namespace webApiTP4;

public class Cadeteria{
    private string nombreCadeteria;
    private string telefonoCadeteria;
    private List<Cadete> listadoCadetes;
    private List<Pedido> listadoPedido;
    public string TelefonoCadeteria { get => telefonoCadeteria; set => telefonoCadeteria = value; }
    public string NombreCadeteria { get => nombreCadeteria; set => nombreCadeteria = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; }
    public List<Pedido> ListadoPedido { get => listadoPedido; }
    private AccesoADatosPedidos accesoPedidos;
    private AccesoADatosCadeteria accesoCadeteria;
    private AccesoADatosCadetes accesoCadetes;
    // private static Cadeteria cadeteriaSingleton;
    private static Cadeteria instance;
    // public static Cadeteria getCadeteria(){
    //     if (cadeteriaSingleton == null)
    //     {
    //         Cadeteria cadeteriaStatic;
    //         AccesoADatos cargarDatosCSV = new AccesoCSV();
    //         cadeteriaSingleton = cargarDatosCSV.leerArchivoCadeteria("CadeteriaHrms.csv");
    //         cadeteriaSingleton.listadoCadetes = cargarDatosCSV.leerArchivoCadetes("CadetesInscriptos.csv");
    //     }
    //     return cadeteriaSingleton;
    // }
    public static Cadeteria GetInstance(){
        if (instance == null)
        {//NO es un constructorr
            instance = new AccesoADatosCadeteria().Obtener();
            instance.accesoCadetes = new AccesoADatosCadetes ();
            instance.accesoPedidos = new AccesoADatosPedidos ();
            instance.CargarCadetes();
            instance.CargarPedido();
        }
        return instance;
    }

    public Cadeteria(){

    }
    private void CargarPedido()
    {
        listadoPedido = accesoPedidos.Obtener();
    }

    private void CargarCadetes()
    {
        listadoCadetes = accesoCadetes.Obtener();
    }

    public Cadeteria(string Nombre, string Telefono){
        nombreCadeteria = Nombre;
        TelefonoCadeteria = Telefono;
        // listadoCadetes = new List<Cadete>();
        // listadoPedido = new List<Pedido>();
    }
    public bool EliminarPedido(int numeroPedido){
        var pedidoACambiar = BuscarPedido(numeroPedido);
        if (pedidoACambiar != null)
        {
            if (pedidoACambiar.CancelarPedido()){
                pedidoACambiar.IdCadete = Pedido.cadeteDefault;
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
            if (pedidoACambiar.CambiarPedidoDeEstado())
            {
                accesoPedidos.Guardar(ListadoPedido);
                return true;
            }
        }
        return false;   
    }
    public Cadete buscarCadete(int idCadete){
        Cadete cadeteBuscado;
        cadeteBuscado = ListadoCadetes.FirstOrDefault(cade => cade.IdCadete == idCadete);
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
                    accesoPedidos.Guardar(ListadoPedido);
                    return true;
                }
            }
        }
        return false;
    }
    public float JornalACobrar(int idCadete){
        float aCobrar = constantes.CobroPorEnvio;
        var pedidosRealizados = from pedi in ListadoPedido 
        where pedi.IdCadete == idCadete && pedi.Estado == Estado.Entregado 
        select pedi;
        aCobrar *= pedidosRealizados.Count();
        return aCobrar;
    }
    public void AgregarCadete(int IdCadete, string NombreCadete, string DireccionCadete, string TelefonoCadete){
        Cadete nuevoCadete = new Cadete(IdCadete,NombreCadete,DireccionCadete,TelefonoCadete);
        ListadoCadetes.Add(nuevoCadete);
    }
    // public void CargarCadetes(List <Cadete> listadoCadetes){
    //     ListadoCadetes.AddRange(listadoCadetes);
    // }
    public Pedido AgregarPedido(string observacionPedido, string nombreCliente, string direccionCliente, string telefonoCliente, string datoDeReferencia){
        Pedido nuevoPedido = new Pedido(observacionPedido,nombreCliente,direccionCliente,telefonoCliente,datoDeReferencia);
        if (nuevoPedido != null)
        {
            ListadoPedido.Add(nuevoPedido);
            nuevoPedido.NroPedido = ListadoPedido.Count;
            accesoPedidos.Guardar(ListadoPedido);
        }
            return nuevoPedido;

    }
    public Pedido AgregarPedido(Pedido pedido){
        ListadoPedido.Add(pedido);
        pedido.NroPedido = ListadoPedido.Count;
        accesoPedidos.Guardar(ListadoPedido);
        return pedido;
    }
    public string mostrarDatosCadeteria(){
        string datosCadeteria = nombreCadeteria + " - " + TelefonoCadeteria;
        return datosCadeteria;
    }
    public string mostrarPedidos(){
        StringBuilder listadoDePedidos = new StringBuilder();
        foreach (var pedido in ListadoPedido)
        {
            listadoDePedidos.AppendLine(pedido.DatosDelPedido());
        }
        return listadoDePedidos.ToString();
    }
    public string mostrarCadetes(){
        StringBuilder listadoDeCadetes = new StringBuilder();
        foreach (var cade in ListadoCadetes)
        {
            listadoDeCadetes.AppendLine(cade.MostrarInfo());
        }
        return listadoDeCadetes.ToString();
    }
}