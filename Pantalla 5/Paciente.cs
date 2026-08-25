using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTSOLAPAS.Pantalla_5
{
    public class Paciente
    {
        // Identificador único
        public int Id { get; set; }

        // Datos personales
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }

        // Información adicional
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        // Propiedad calculada: Edad
        public int Edad
        {
            get
            {
                var hoy = DateTime.Today;
                int edad = hoy.Year - FechaNacimiento.Year;
                if (FechaNacimiento.Date > hoy.AddYears(-edad)) edad--;
                return edad;
            }
        }

        // Método auxiliar para mostrar nombre completo
        public string NombreCompleto => $"{Nombre} {Apellido}";
    }
}
