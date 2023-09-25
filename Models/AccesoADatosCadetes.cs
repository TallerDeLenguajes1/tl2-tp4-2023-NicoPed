
using System.Text.Json;

namespace webApiTP4;

public class AccesoADatosCadetes{
    List<Cadete> Obtener (string nombreArchivo){
        string? archivo;
        List<Cadete> nuevaListaDeCadetes = new List<Cadete>();
        using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
        {
            using (var strReader = new StreamReader(archivoOpen))
            {
                archivo = strReader.ReadToEnd();
                archivoOpen.Close();
            }
            nuevaListaDeCadetes = JsonSerializer.Deserialize<List<Cadete>>(archivo);
        }
        return nuevaListaDeCadetes;
    }
}
