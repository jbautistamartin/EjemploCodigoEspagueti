using System;
using System.Diagnostics;
using System.IO;

namespace DesdeLasHorasExtras.EjemploCodigoEspagueti2
{
    /// <summary>
    /// Gestor de mensajes, su misión es guardar mensajes de bitacora en diversos medios.
    /// </summary>
    public class GestorMensajes
    {
        /// <summary>
        /// Guarda el mensaje segun el metodo que se indica como parametro
        /// </summary>
        /// <param name="modo">Modo para guardar</param>
        /// <param name="mensaje">Mensaje a guardar</param>
        public void Guardar(ModoGuardado modo, string mensaje)
        {
            switch (modo)
            {
                case ModoGuardado.ArchivoPlano:
                    //Guardo la información en el archivo de texto
                    GuardarArchivoPlano(mensaje);
                    break;

                case ModoGuardado.BaseDatos:
                    //Guardo la información en la base de datos
                    GuardarBaseDatos(mensaje);
                    break;

                case ModoGuardado.VisorEventos:
                    //Lo guardo en el Visor de eventos de Windows
                    GuardarVisorEventos(mensaje);
                    break;

                default:
                    throw new InvalidOperationException($"No se reconoce el tipo de guardado {modo}");
            }
        }

        /// <summary>
        /// Guarda el mensaje dentro de un archivo plano
        /// </summary>
        /// <param name="mensaje">Mensaje a guardar</param>
        private static void GuardarArchivoPlano(string mensaje)
        {
            string directorioArchivo = AppDomain.CurrentDomain.BaseDirectory;
            string rutaArchivo = Path.Combine(directorioArchivo, "bitacora.txt");

            File.AppendAllText(rutaArchivo, $"{mensaje}{Environment.NewLine}");
        }

        /// <summary>
        /// Configura la base de datos, creandola si no existe
        /// </summary>
        private static void ConfigurarBaseDatos()
        {
            using (EjemploCodigoEspaguetiEntities context = new EjemploCodigoEspaguetiEntities())
            {
                //Si no existe la base de datos (archivo mdf) lo creo
                string directorioBaseDatos = AppDomain.CurrentDomain.BaseDirectory;
                AppDomain.CurrentDomain.SetData("DataDirectory", directorioBaseDatos);
                string rutaBaseDatos = Path.Combine(directorioBaseDatos, @"EjemploCodigoEspagueti.mdf");

                context.Database.CreateIfNotExists();
            }
        }

        /// <summary>
        /// Guarda el mensaje dentro de una base de datos
        /// </summary>
        /// <param name="mensaje">Mensaje a guardar</param>
        private static void GuardarBaseDatos(string mensaje)
        {
            using (EjemploCodigoEspaguetiEntities context = new EjemploCodigoEspaguetiEntities())
            {
                ConfigurarBaseDatos();

                //Agrego el mensaje en la base de datos
                context.Bitacora.Add(new Bitacora { mensaje = mensaje });
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Crea la fuente para el visor de eventos.
        /// </summary>
        private static void ConfigurarVisorEventos()
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
        /// Guarda el mensaje en el visor de eventos de windows
        /// </summary>
        /// <param name="mensaje">Mensaje a guardar</param>
        private static void GuardarVisorEventos(string mensaje)
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