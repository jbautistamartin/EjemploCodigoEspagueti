using DesdeLasHorasExtras.EjemploCodigoEspagueti3.Mensajes;

namespace DesdeLasHorasExtras.EjemploCodigoEspagueti3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Instancio la clase gestor de mensajes, es la encargada de guardar los mensajes
            IGestorMensajes gestor = GestorMensajesFactory.Crear();

            //Guardo un mensaje de cada tipo.
            gestor.Guardar("Mensaje de ejemplo");
        }
    }
}