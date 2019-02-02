namespace DesdeLasHorasExtras.EjemploCodigoEspagueti2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Instancio la clase gestor de mensajes, es la encargada de guardar los mensajes
            GestorMensajes gestor = new GestorMensajes();

            //Guardo un mensaje de cada tipo.
            gestor.Guardar(ModoGuardado.ArchivoPlano, "Mensaje de ejemplo en texto plano");
            gestor.Guardar(ModoGuardado.BaseDatos, "Mensaje de ejemplo en base de datos");
            gestor.Guardar(ModoGuardado.VisorEventos, "Mensaje de ejemplo en visor de eventos");
        }
    }
}