using System;
using System.Diagnostics;
using System.IO;

namespace DesdeLasHorasExtras.EjemploCodigoEspagueti3
{
    /// <summary>
    /// Gestor de mensajes, su misión es guardar mensajes de bitacora en diversos medios.
    /// </summary>
    public class GestorMensajesBaseDatos
    {
        /// <summary>
        /// Contructor por defecto
        /// </summary>
        public GestorMensajesBaseDatos()
        {
            //Inicializa la base de datos
            ConfigurarBaseDatos();
        }

        /// <summary>
        /// Configura la base de datos, creandola si no existe
        /// </summary>
        private void ConfigurarBaseDatos()
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
        /// Guarda el mensaje segun el metodo que se indica como parametro
        /// </summary>
        /// <param name="mensaje">Mensaje a guardar</param>
        public void Guardar(string mensaje)
        {
            using (EjemploCodigoEspaguetiEntities context = new EjemploCodigoEspaguetiEntities())
            {
                //Agrego el mensaje en la base de datos
                context.Bitacora.Add(new Bitacora { mensaje = mensaje });
                context.SaveChanges();
            }
        }
    }
}