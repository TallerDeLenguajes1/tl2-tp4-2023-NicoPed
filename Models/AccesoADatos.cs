using System.Text.Json;

namespace webApiTP4;
public abstract class AccesoADatos{
    public abstract List<Cadete> leerArchivoCadetes(string nombreArchivo);
    public abstract Cadeteria leerArchivoCadeteria(string nombreArchivo);
}
public class AccesoCSV : AccesoADatos{
    private List<string[]> LeerArchivo(string nombreDelArchivo, char caracter)
        {
            FileStream MiArchivo = new FileStream(nombreDelArchivo, FileMode.Open);
            StreamReader StrReader = new StreamReader(MiArchivo);

            string Linea = "";
            List<string[]> LecturaDelArchivo = new List<string[]>();

            while ((Linea = StrReader.ReadLine()) != null)
            {
                string[] Fila = Linea.Split(caracter);
                LecturaDelArchivo.Add(Fila);
            }

            return LecturaDelArchivo;
        }
    public override List<Cadete> leerArchivoCadetes(string nombreArchivo)
    {
        var archivoConCadetes = LeerArchivo(nombreArchivo, ';');
        List<Cadete> ListadoCadetes = new List<Cadete>();
            foreach (string[] cadete in archivoConCadetes)
            {
                Cadete nuevoCadete = new Cadete(Convert.ToInt32(cadete[0]), cadete[1], cadete[2], cadete[3]);
                ListadoCadetes.Add(nuevoCadete);
            }
            return ListadoCadetes;
    }
    public override Cadeteria leerArchivoCadeteria(string rutaDatosCadeteria){
        string[] datosCadeteria;

        using (StreamReader s = new StreamReader(rutaDatosCadeteria))
        {
            datosCadeteria = s.ReadLine().Split(';');
        }

        Cadeteria cadeteria = new Cadeteria(datosCadeteria[0], datosCadeteria[1]);
        return cadeteria;
    }
    // public override Cadeteria leerArchivoCadeteria(string nombreArchivo)
    // {
    //     var archivoConCadeteria = LeerArchivo(nombreArchivo, ';');
    //     Cadeteria nuevaCadeteria = new Cadeteria("Error","Error");
    //         foreach (string[] cadeteri in archivoConCadeteria)
    //         {
    //             nuevaCadeteria.NombreCadeteria = cadeteri[0];
    //             nuevaCadeteria.TelefonoCadeteria = cadeteri[1];
    //             break;
    //         }
    //           return nuevaCadeteria;
    // }
}
public class AccesoJSON : AccesoADatos{
    public override Cadeteria leerArchivoCadeteria(string nombreArchivo)
    {  
        string? documento;
        Cadeteria nuevaCadeteria = null;
        using(var archivoOpen = new FileStream(nombreArchivo,FileMode.Open)){
            using (var strReader = new StreamReader(archivoOpen))
            {
                documento = strReader.ReadToEnd();
                archivoOpen.Close();
            }
            nuevaCadeteria = JsonSerializer.Deserialize<Cadeteria>(documento);
        }
        return nuevaCadeteria;
    }
    public override List<Cadete> leerArchivoCadetes(string nombreArchivo)
    {
        string? documento;
        List<Cadete> cadetes = null;
        using(var archivoOpen = new FileStream(nombreArchivo,FileMode.Open)){
            using (var strReader = new StreamReader(archivoOpen))
            {
                documento = strReader.ReadToEnd();
                archivoOpen.Close();
            }
            cadetes = JsonSerializer.Deserialize <List<Cadete>>(documento);
        }
        return cadetes;
    } 
}