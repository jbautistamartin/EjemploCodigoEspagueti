﻿namespace DesdeLasHorasExtras.EjemploCodigoEspagueti3
{
    /// <summary>
    /// Gestor de mensajes, su misión es guardar mensajes de bitacora en diversos medios.
    /// </summary>
    public abstract class GestorMensajes : IGestorMensajes
    {
        /// <summary>
        /// Guarda el mensaje segun el metodo que se indica como parametro
        /// </summary>
        /// <param name="mensaje">Mensaje a guardar</param>
        public abstract void Guardar(string mensaje);
    }
}