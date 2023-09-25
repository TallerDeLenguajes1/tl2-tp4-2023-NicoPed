using System.Text.Json;

namespace webApiTP4;

public class AccesoADatosCadeteria{
    Cadeteria Obtener(string nombreArchivo){
        string? archivo;
        Cadeteria nuevaCadeteria = null;
        using(var archivoOpen = new FileStream(nombreArchivo,FileMode.Open)){
            using (var strReader = new StreamReader(archivoOpen))
            {
                archivo = strReader.ReadToEnd();
                archivoOpen.Close();
            }
            nuevaCadeteria = JsonSerializer.Deserialize<Cadeteria>(archivo);
        }
        return nuevaCadeteria;
    }
}