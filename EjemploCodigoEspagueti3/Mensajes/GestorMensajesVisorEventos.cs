using System;
using System.Diagnostics;
using System.IO;

namespace DesdeLasHorasExtras.EjemploCodigoEspagueti3
{
    /// <summary>
    /// Gestor de mensajes, su misión es guardar mensajes de bitacora en diversos medios.
    /// </summary>
    public class GestorMensajesVisorEventos
    {
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
            //Si no existe en memoria lo creo
            string source = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            string log = "Application";
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, log);
            }
        }

        /// <summary>
        /// Guarda el mensaje segun el metodo que se indica como parametro
        /// </summary>
        /// <param name="modo">Modo para guardar</param>
        /// <param name="mensaje">Mensaje a guardar</param>
        public void Guardar(ModoGuardado modo, string mensaje)
        {
            ConfigurarVisorEventos();
            string source = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;

            //Guardo el mensaje.
            System.Diagnostics.EventLog appLog = new System.Diagnostics.EventLog();
            appLog.Source = source;
            appLog.WriteEntry(mensaje);
        }
    }
}