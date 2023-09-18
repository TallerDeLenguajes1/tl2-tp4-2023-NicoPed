namespace webApiTP4
{
    public class Informe
    {
        private string? nombreCadete;
        private int idCadete;
        private int pedidosRealizados;
        private float totalACobrar;
        private int enviosPromedio;

        public string? NombreCadete { get => nombreCadete; set => nombreCadete = value; }
        public int IdCadete { get => idCadete; set => idCadete = value; }
        public int PedidosRealizados { get => pedidosRealizados; set => pedidosRealizados = value; }
        public float TotalACobrar { get => totalACobrar; set => totalACobrar = value; }
        public int EnviosPromedio { get => enviosPromedio; set => enviosPromedio = value; }


        public static Informe GenerarInforme(Cadeteria cadeteria)
        {
            var informes = new Informe ();

            var pedidosRealizados = from pedi in cadeteria.ListadoPedido
                                    where pedi.Estado == Estado.Entregado
                                    select pedi;

            int cantidadDePedidosDeHoy = pedidosRealizados.Count();

            foreach (var cadete in cadeteria.ListadoCadetes)
            {
                int idCadete = cadete.IdCadete;
                float aCobrar = cadeteria.JornalACobrar(idCadete);
                int pedidosRealizadosCadete = Convert.ToInt32(aCobrar / constantes.CobroPorEnvio);
                int enviosPromedio = cantidadDePedidosDeHoy != 0 ? pedidosRealizadosCadete * 100 / cantidadDePedidosDeHoy : 0; //alfin pude usar un ternario xd

                var informe = new Informe
                {
                    NombreCadete = cadete.NombreCadete,
                    IdCadete = idCadete,
                    PedidosRealizados = pedidosRealizadosCadete,
                    TotalACobrar = aCobrar,
                    EnviosPromedio = enviosPromedio
                };
            }

            return informes;
        }
    }
}










// namespace webApiTP4;
//     class Informe
//     {
//         public void mostrarInforme(Cadeteria cadeteri){
//             var pediosRealizados = from pedi in cadeteri.ListadoPedido
//                                     where pedi.Estado == Estado.Entregado
//                                     select pedi;
                                    
//             int cantidadDePedidosDeHoy = pediosRealizados.Count();
//             Console.WriteLine("====================================");
//             foreach (var cadete in cadeteri.ListadoCadetes)
//             {
//                 int idCadete = cadete.IdCadete;
//                 float aCobrar = cadeteri.JornalACobrar(idCadete);
//                 int pedidosRealizadosCadete = Convert.ToInt32(aCobrar / constantes.CobroPorEnvio);
//                 Console.WriteLine("Nombre del Cadete: "+cadete.NombreCadete);
//                 Console.WriteLine("Id del Cadete: "+cadete.IdCadete);
//                 Console.WriteLine("Pedidos realizados: "+pedidosRealizadosCadete);
//                 if (cantidadDePedidosDeHoy != 0)
//                 {
//                     Console.WriteLine("Envios promedio del cadete del día de hoy : "+ pedidosRealizadosCadete * 100 / cantidadDePedidosDeHoy);
//                 }
//                 else
//                 {
//                     Console.WriteLine("Envios promedio del cadete del día de hoy : 0");
//                 }
                    
//                 Console.WriteLine("Total a cobrar: "+aCobrar);
//                 Console.WriteLine("====================================");
//             }
//         }
    
//     }
