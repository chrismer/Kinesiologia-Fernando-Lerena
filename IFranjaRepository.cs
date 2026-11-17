using System;
using System.Collections.Generic;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Grilla fija de franjas y el reemplazo de un día.
    /// Cambiar el titular o la excepción no reescribe turnos ya creados.
    /// </summary>
    public interface IFranjaRepository
    {
        List<FranjaItem> ObtenerFranjas();

        void GuardarTitular(int franjaId, int profesionalId);

        void GuardarExcepcion(DateTime fecha, int franjaId, int profesionalId);

        void QuitarExcepcion(DateTime fecha, int franjaId);

        List<FranjaExcepcionItem> ObtenerExcepciones(DateTime desde, DateTime hasta);

        /// <summary>Titular de esa hora, o la excepción si ese día hay reemplazo.</summary>
        AsignacionFranja ResolverProfesional(DateTime fecha, TimeSpan hora);
    }
}
