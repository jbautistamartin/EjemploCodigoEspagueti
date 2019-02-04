namespace DesdeLasHorasExtras.EjemploCodigoEspagueti3
{
    /// <summary>
    /// Interfaz de GestorMensaje
    /// </summary>
    public interface IGestorMensajes
    {
        /// <summary>
        /// Guarda el mensaje segun el metodo que se indica como parametro
        /// </summary>
        /// <param name="mensaje">Mensaje a guardar</param>
        void Guardar(string mensaje);
    }
}