namespace DesdeLasHorasExtras.EjemploCodigoEspagueti3
{
    /// <summary>
    /// Define el destino del mensaje
    /// </summary>
    public enum ModoGuardado
    {
        /// <summary>
        /// Se guarda en un archivo plano en la ruta del ejecutable
        /// </summary>
        ArchivoPlano,

        /// <summary>
        /// Se guarda en una base de datos
        /// </summary>
        BaseDatos,

        /// <summary>
        /// Se guarda en el visor de eventos de windows.
        /// </summary>
        VisorEventos
    }
}