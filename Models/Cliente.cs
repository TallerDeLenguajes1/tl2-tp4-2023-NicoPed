namespace webApiTP4;

public class Cliente{
    private string nombre;
    private string direccion;
    private string telefono;
    private string datosReferencia;

    public global::System.String Nombre { get => nombre; set => nombre = value; }
    public global::System.String Direccion { get => direccion; set => direccion = value; }
    public global::System.String Telefono { get => telefono; set => telefono = value; }
    public global::System.String DatosReferencia { get => datosReferencia; set => datosReferencia = value; }

    public Cliente(string nombreCliente, string direccionCliente,string telefonoCliente,string datosReferencia){
        Nombre = nombreCliente;
        Direccion = direccionCliente;
        Telefono = telefonoCliente;
        DatosReferencia = datosReferencia;
    }
    public Cliente(){
        
    }
}