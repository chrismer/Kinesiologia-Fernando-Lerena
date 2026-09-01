using System.Collections.Generic;

namespace TESTSOLAPAS
{
    /// <summary>
    /// Contrato para el repositorio de pacientes.
    /// Separa la responsabilidad que antes vivía como ObtenerPacienteDemo() en IEvolucionRepository.
    /// </summary>
    public interface IPacienteRepository
    {
        /// <summary>Devuelve todos los pacientes.</summary>
        List<Paciente> ObtenerTodos();

        /// <summary>Devuelve un paciente por su ID, o null si no existe.</summary>
        Paciente? ObtenerPorId(int pacienteId);

        /// <summary>Inserta o actualiza un paciente.</summary>
        void Guardar(Paciente paciente);
    }
}
