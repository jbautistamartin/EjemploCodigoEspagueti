using System;
using System.Diagnostics;
using System.IO;

namespace DesdeLasHorasExtras.EjemploCodigoEspagueti1
{
    /// <summary>
    /// Gestor de mensajes, su misión es guardar mensajes de bitacora en diversos medios.
    /// </summary>
    public class GestorMensajes
    {
        public void Guardar(ModoGuardado modo, string mensaje)
        {
            if (modo == ModoGuardado.ArchivoPlano) //Guardo la información en el archivo de texto
            {
                string directorioArchivo = AppDomain.CurrentDomain.BaseDirectory;
                string rutaArchivo = Path.Combine(directorioArchivo, "bitacora.txt");

                File.AppendAllText(rutaArchivo, $"{mensaje}{Environment.NewLine}");
            }
            if (modo == ModoGuardado.BaseDatos) //Guardo la información en la base de datos
            {
                using (EjemploCodigoEspaguetiEntities context = new EjemploCodigoEspaguetiEntities())
                {
                    //Si no existe la base de datos (archivo mdf) lo creo
                    string directorioBaseDatos = AppDomain.CurrentDomain.BaseDirectory;
                    AppDomain.CurrentDomain.SetData("DataDirectory", directorioBaseDatos);
                    string rutaBaseDatos = Path.Combine(directorioBaseDatos, @"EjemploCodigoEspagueti.mdf");

                    context.Database.CreateIfNotExists();

                    //Agrego el mensaje en la base de datos
                    context.Bitacora.Add(new Bitacora { mensaje = mensaje });
                    context.SaveChanges();
                }
            }
            else if (modo == ModoGuardado.VisorEventos) //Lo guardo en el Visor de eventos de Windows
            {
                //Si no existe en memoria lo creo
                string source = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                string log = "Application";
                if (!EventLog.SourceExists(source))
                {
                    EventLog.CreateEventSource(source, log);
                }

                //Guardo el mensaje.
                System.Diagnostics.EventLog appLog = new System.Diagnostics.EventLog();
                appLog.Source = source;
                appLog.WriteEntry(mensaje);
            }
        }
    }
}