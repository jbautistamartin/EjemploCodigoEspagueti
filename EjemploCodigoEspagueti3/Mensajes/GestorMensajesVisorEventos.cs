using System.Diagnostics;

namespace DesdeLasHorasExtras.EjemploCodigoEspagueti3
{
    /// <summary>
    /// Gestor de mensajes, su misión es guardar mensajes de bitacora en diversos medios.
    /// </summary>
    public class GestorMensajesVisorEventos : GestorMensajes
    {
        /// <summary>
        /// Nombre de la fuente
        /// </summary>
        private string source;

        /// <summary>
        /// Contructor por defecto
        /// </summary>
        public GestorMensajesVisorEventos()
        {
            //Inicializa la base de datos
            ConfigurarVisorEventos();
        }

        /// <summary>
        /// Crea la fuente para el visor de eventos.
        /// </summary>
        private void ConfigurarVisorEventos()
        {
            string log = "Application";
            source = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

            //Si no existe en memoria lo creo

            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, log);
            }
        }

        /// <summary>
        /// Guarda el mensaje segun el metodo que se indica como parametro
        /// </summary>
        /// <param name="mensaje">Mensaje a guardar</param>
        public override void Guardar(string mensaje)
        {
            //Guardo el mensaje.
            System.Diagnostics.EventLog appLog = new System.Diagnostics.EventLog();

            appLog.Source = source;
            appLog.WriteEntry(mensaje);
        }
    }
}