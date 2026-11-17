using System;
using System.Collections.Generic;
using System.Linq;

namespace TESTSOLAPAS
{
    /// <summary>Franjas de prueba para cuando no hay connection string.</summary>
    public class MemoryFranjaRepository : IFranjaRepository
    {
        private readonly List<ProfesionalItem> _profesionales;
        private readonly List<FranjaItem> _franjas;
        private readonly List<FranjaExcepcionItem> _excepciones = new();
        private int _siguienteExcepcion = 1;

        public MemoryFranjaRepository()
        {
            _profesionales = new List<ProfesionalItem>
            {
                new ProfesionalItem { Id = 1, Nombre = "Dr. Juan Pérez", Color = "#007ACC", Activo = true },
                new ProfesionalItem { Id = 2, Nombre = "Lic. Ana Torres", Color = "#28A745", Activo = true },
                new ProfesionalItem { Id = 3, Nombre = "Lic. Martín López", Color = "#E83E8C", Activo = true }
            };

            _franjas = new List<FranjaItem>
            {
                new FranjaItem { Id = 1, Nombre = "Mañana", HoraDesde = new TimeSpan(8, 0, 0), HoraHasta = new TimeSpan(12, 0, 0), ProfesionalId = 1, ProfesionalNombre = "Dr. Juan Pérez" },
                new FranjaItem { Id = 2, Nombre = "Tarde", HoraDesde = new TimeSpan(13, 0, 0), HoraHasta = new TimeSpan(17, 0, 0), ProfesionalId = 2, ProfesionalNombre = "Lic. Ana Torres" },
                new FranjaItem { Id = 3, Nombre = "Vespertino", HoraDesde = new TimeSpan(18, 0, 0), HoraHasta = new TimeSpan(21, 0, 0), ProfesionalId = 3, ProfesionalNombre = "Lic. Martín López" }
            };
        }

        public List<FranjaItem> ObtenerFranjas() => _franjas.Where(f => f.Activo).OrderBy(f => f.HoraDesde).ToList();

        public void GuardarTitular(int franjaId, int profesionalId)
        {
            var franja = _franjas.FirstOrDefault(f => f.Id == franjaId);
            var prof = _profesionales.FirstOrDefault(p => p.Id == profesionalId);
            if (franja is null || prof is null)
                return;

            franja.ProfesionalId = prof.Id;
            franja.ProfesionalNombre = prof.Nombre;
        }

        public void GuardarExcepcion(DateTime fecha, int franjaId, int profesionalId)
        {
            var prof = _profesionales.FirstOrDefault(p => p.Id == profesionalId);
            var franja = _franjas.FirstOrDefault(f => f.Id == franjaId);
            if (prof is null || franja is null)
                return;

            var existente = _excepciones.FirstOrDefault(e => e.Fecha.Date == fecha.Date && e.FranjaId == franjaId);
            if (existente is null)
            {
                _excepciones.Add(new FranjaExcepcionItem
                {
                    Id = _siguienteExcepcion++,
                    Fecha = fecha.Date,
                    FranjaId = franjaId,
                    FranjaNombre = franja.Nombre,
                    ProfesionalId = prof.Id,
                    ProfesionalNombre = prof.Nombre
                });
                return;
            }

            existente.ProfesionalId = prof.Id;
            existente.ProfesionalNombre = prof.Nombre;
        }

        public void QuitarExcepcion(DateTime fecha, int franjaId)
        {
            _excepciones.RemoveAll(e => e.Fecha.Date == fecha.Date && e.FranjaId == franjaId);
        }

        public List<FranjaExcepcionItem> ObtenerExcepciones(DateTime desde, DateTime hasta) =>
            _excepciones
                .Where(e => e.Fecha.Date >= desde.Date && e.Fecha.Date <= hasta.Date)
                .OrderBy(e => e.Fecha)
                .ToList();

        public AsignacionFranja ResolverProfesional(DateTime fecha, TimeSpan hora)
        {
            var franja = _franjas.FirstOrDefault(f => f.Activo && FranjaCalendario.CaeEnFranja(hora, f));
            if (franja is null)
                return new AsignacionFranja();

            var excepcion = _excepciones.FirstOrDefault(e => e.Fecha.Date == fecha.Date && e.FranjaId == franja.Id);
            var profesionalId = excepcion?.ProfesionalId ?? franja.ProfesionalId;
            var prof = _profesionales.FirstOrDefault(p => p.Id == profesionalId);

            return new AsignacionFranja
            {
                ProfesionalId = profesionalId,
                ProfesionalNombre = prof?.Nombre ?? "Sin asignar",
                ProfesionalColor = prof?.Color ?? "#6C757D"
            };
        }
    }
}
