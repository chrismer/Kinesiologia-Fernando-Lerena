using System;
using System.Collections.Generic;
using System.Linq;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Implementación en memoria de IEvolucionRepository.
    /// Los datos persisten durante la vida útil de la aplicación (mientras la instancia exista).
    /// La instancia debe crearse una sola vez en Inicio.cs y pasarse a Pagina3 cada vez
    /// que se abre, para que las evoluciones guardadas no se pierdan al navegar entre pantallas.
    /// </summary>
    public class MemoryEvolucionRepository : IEvolucionRepository
    {
        private readonly List<EvolucionSesion> _evoluciones;
        private readonly Paciente _pacienteDemo;
        private int _nextId;

        public MemoryEvolucionRepository()
        {
            _pacienteDemo = new Paciente
            {
                Id = 1,
                Dni = "12378738",
                NombreCompleto = "María Gómez Blanía",
                Edad = 34,
                Cobertura = "OSDE 210",
                MotivoConsulta = "Dolor lumbar con irradiación a miembro inferior izquierdo",
                DiagnosticoInicial = "Lumbalgia crónica - Hernia L4-L5"
            };

            // Historial pre-poblado con sesiones anteriores del paciente demo
            _evoluciones = new List<EvolucionSesion>
            {
                new EvolucionSesion
                {
                    Id = 1,
                    PacienteId = 1,
                    Fecha = DateTime.Today.AddDays(-14),
                    Profesional = "Dr. Juan Pérez",
                    NivelDolorEva = 8,
                    TecnicasAplicadas = "Magnetoterapia, Terapia Manual",
                    ComentariosEvolucion = "Primera sesión. Paciente refiere dolor intenso en zona lumbar. " +
                                          "Se realizó evaluación inicial y aplicación de magnetoterapia. " +
                                          "Toleró bien el tratamiento."
                },
                new EvolucionSesion
                {
                    Id = 2,
                    PacienteId = 1,
                    Fecha = DateTime.Today.AddDays(-10),
                    Profesional = "Dr. Juan Pérez",
                    NivelDolorEva = 6,
                    TecnicasAplicadas = "Magnetoterapia, Ultrasonido, Ejercicio Terapéutico",
                    ComentariosEvolucion = "Paciente refiere leve mejoría respecto a la sesión anterior. " +
                                          "Se incorpora ultrasonido en zona paravertebral L4-L5. " +
                                          "Se comienza plan de ejercicios de fortalecimiento de core."
                },
                new EvolucionSesion
                {
                    Id = 3,
                    PacienteId = 1,
                    Fecha = DateTime.Today.AddDays(-6),
                    Profesional = "Dr. Juan Pérez",
                    NivelDolorEva = 5,
                    TecnicasAplicadas = "Ultrasonido, Ejercicio Terapéutico, Terapia Manual",
                    ComentariosEvolucion = "Presenta menos dolor en zona lumbar. Se realizaron ejercicios " +
                                          "con banda elástica y movilizaciones articulares. " +
                                          "Paciente colabora correctamente con el plan de ejercicios."
                },
                new EvolucionSesion
                {
                    Id = 4,
                    PacienteId = 1,
                    Fecha = DateTime.Today.AddDays(-2),
                    Profesional = "Dr. Juan Pérez",
                    NivelDolorEva = 4,
                    TecnicasAplicadas = "Ejercicio Terapéutico, Terapia Manual",
                    ComentariosEvolucion = "Evolución favorable. Dolor reducido a EVA 4. " +
                                          "Se refuerza ejercicio de estiramiento de piriforme y cadena posterior. " +
                                          "Se indica continuar ejercicios en domicilio."
                }
            };

            _nextId = _evoluciones.Count + 1;
        }

        /// <inheritdoc/>
        public List<EvolucionSesion> ObtenerHistorialPorPaciente(int pacienteId)
        {
            return _evoluciones
                .Where(e => e.PacienteId == pacienteId)
                .OrderByDescending(e => e.Fecha)
                .ToList();
        }

        /// <inheritdoc/>
        public void GuardarEvolucion(EvolucionSesion evolucion)
        {
            evolucion.Id = _nextId++;
            _evoluciones.Add(evolucion);
        }

        /// <inheritdoc/>
        public Paciente ObtenerPacienteDemo()
        {
            return _pacienteDemo;
        }
    }
}
