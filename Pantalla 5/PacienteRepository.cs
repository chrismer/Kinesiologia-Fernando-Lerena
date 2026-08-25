using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTSOLAPAS.Pantalla_5
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PacienteRepository
    {
        // Lista interna que simula la base de datos
        private readonly List<Paciente> _pacientes;

        public PacienteRepository()
        {
            _pacientes = new List<Paciente>
        {
            new Paciente { Id = 1, Nombre = "Juan", Apellido = "Pérez", DNI = "12345678" },
            new Paciente { Id = 2, Nombre = "María", Apellido = "Gómez", DNI = "87654321" },
            new Paciente { Id = 3, Nombre = "Carlos", Apellido = "López", DNI = "11223344" }
        };
        }

        /// <summary>
        /// Devuelve todos los pacientes.
        /// </summary>
        public List<Paciente> ObtenerTodos()
        {
            return _pacientes.ToList();
        }

        /// <summary>
        /// Busca pacientes por nombre, apellido o DNI.
        /// </summary>
        public List<Paciente> Buscar(string criterio)
        {
            if (string.IsNullOrWhiteSpace(criterio))
                return ObtenerTodos();

            return _pacientes
                .Where(p =>
                    p.Nombre.Contains(criterio, StringComparison.OrdinalIgnoreCase) ||
                    p.Apellido.Contains(criterio, StringComparison.OrdinalIgnoreCase) ||
                    p.DNI.Contains(criterio))
                .ToList();
        }

        /// <summary>
        /// Agrega un nuevo paciente.
        /// </summary>
        public void Agregar(Paciente nuevo)
        {
            // Generar ID automático
            nuevo.Id = _pacientes.Any() ? _pacientes.Max(p => p.Id) + 1 : 1;
            _pacientes.Add(nuevo);
        }

        /// <summary>
        /// Elimina un paciente por ID.
        /// </summary>
        public bool Eliminar(int id)
        {
            var paciente = _pacientes.FirstOrDefault(p => p.Id == id);
            if (paciente != null)
            {
                _pacientes.Remove(paciente);
                return true;
            }
            return false;
        }
    }


}