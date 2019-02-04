using DesdeLasHorasExtras.EjemploCodigoEspagueti3.Properties;
using System.Reflection;

namespace DesdeLasHorasExtras.EjemploCodigoEspagueti3.Mensajes
{
    /// <summary>
    /// Clase que se encarga de crear el objeto de tipo GestorMensajes
    /// </summary>
    public static class GestorMensajesFactory
    {
        /// <summary>
        /// Crea una clase de Gestor Mensajes, segun los indicado en el App.config
        /// </summary>
        /// <returns></returns>
        public static IGestorMensajes Crear()
        {
            return (IGestorMensajes)Assembly.GetExecutingAssembly().CreateInstance(Settings.Default.GestorMensajes);
        }
    }
}