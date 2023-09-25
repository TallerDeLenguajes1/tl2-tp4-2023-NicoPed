using System.Text.Json;
using webApiTP4;
class AccesoADatosPedidos{
    public List <Pedido> Obtener(string nombreArchivo){
        string? archivo;
        List<Pedido> nuevaListaDeCadetes = new List<Pedido>();
        using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
        {
            using (var strReader = new StreamReader(archivoOpen))
            {
                archivo = strReader.ReadToEnd();
                archivoOpen.Close();
            }
            nuevaListaDeCadetes = JsonSerializer.Deserialize<List<Pedido>>(archivo);
        }
        return nuevaListaDeCadetes;
    }
    public void Guardar(List<Pedido> listadoPedidos){
        var nombreArchivo = "listadoDePedidos.Json";
        if (!File.Exists(nombreArchivo))
        {
            File.Create(nombreArchivo).Close();
        }
        string Json = JsonSerializer.Serialize(listadoPedidos);
        File.WriteAllText(nombreArchivo,Json);
    }
    // void Guardar(List<Pedido> listadoPedidos, string nombreArchivo){
    //     using (var archivoOpen = new FileStream(nombreArchivo,FileMode.Open))
    //     {
    //         using (var strWriter = new StreamWriter(archivoOpen))
    //         {
    //             foreach (var pedido in listadoPedidos)
    //             {
    //                 strWriter.WriteLine($"{pedido.DatosDelPedido()}");
    //             }
    //         }
    //         archivoOpen.Close();
    //     }
    // }
}