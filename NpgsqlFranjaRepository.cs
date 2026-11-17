using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TESTSOLAPAS
{
    public class NpgsqlFranjaRepository : IFranjaRepository
    {
        public List<FranjaItem> ObtenerFranjas()
        {
            using var conn = DbConnectionFactory.CreateConnection();
            return conn.Query<FranjaItem>(
                @"SELECT f.pk_franja AS Id,
                         f.nombre AS Nombre,
                         f.hora_desde AS HoraDesde,
                         f.hora_hasta AS HoraHasta,
                         f.fk_profesional AS ProfesionalId,
                         pr.nombre AS ProfesionalNombre,
                         f.activo AS Activo
                  FROM franja f
                  JOIN profesional pr ON pr.pk_profesional = f.fk_profesional
                  WHERE f.activo = TRUE
                  ORDER BY f.hora_desde"
            ).ToList();
        }

        public void GuardarTitular(int franjaId, int profesionalId)
        {
            using var conn = DbConnectionFactory.CreateConnection();
            conn.Execute(
                @"UPDATE franja SET fk_profesional = @ProfesionalId WHERE pk_franja = @FranjaId",
                new { FranjaId = franjaId, ProfesionalId = profesionalId }
            );
        }

        public void GuardarExcepcion(DateTime fecha, int franjaId, int profesionalId)
        {
            using var conn = DbConnectionFactory.CreateConnection();
            conn.Execute(
                @"INSERT INTO franja_excepcion (fecha, fk_franja, fk_profesional)
                  VALUES (@Fecha, @FranjaId, @ProfesionalId)
                  ON CONFLICT (fecha, fk_franja)
                  DO UPDATE SET fk_profesional = EXCLUDED.fk_profesional",
                new { Fecha = fecha.Date, FranjaId = franjaId, ProfesionalId = profesionalId }
            );
        }

        public void QuitarExcepcion(DateTime fecha, int franjaId)
        {
            using var conn = DbConnectionFactory.CreateConnection();
            conn.Execute(
                @"DELETE FROM franja_excepcion WHERE fecha = @Fecha AND fk_franja = @FranjaId",
                new { Fecha = fecha.Date, FranjaId = franjaId }
            );
        }

        public List<FranjaExcepcionItem> ObtenerExcepciones(DateTime desde, DateTime hasta)
        {
            using var conn = DbConnectionFactory.CreateConnection();
            return conn.Query<FranjaExcepcionItem>(
                @"SELECT ex.pk_excepcion AS Id,
                         ex.fecha AS Fecha,
                         ex.fk_franja AS FranjaId,
                         f.nombre AS FranjaNombre,
                         ex.fk_profesional AS ProfesionalId,
                         pr.nombre AS ProfesionalNombre
                  FROM franja_excepcion ex
                  JOIN franja f ON f.pk_franja = ex.fk_franja
                  JOIN profesional pr ON pr.pk_profesional = ex.fk_profesional
                  WHERE ex.fecha >= @Desde AND ex.fecha <= @Hasta
                  ORDER BY ex.fecha, f.hora_desde",
                new { Desde = desde.Date, Hasta = hasta.Date }
            ).ToList();
        }

        public AsignacionFranja ResolverProfesional(DateTime fecha, TimeSpan hora)
        {
            using var conn = DbConnectionFactory.CreateConnection();
            return conn.QueryFirstOrDefault<AsignacionFranja>(
                @"SELECT COALESCE(ex.fk_profesional, f.fk_profesional) AS ProfesionalId,
                         pr.nombre AS ProfesionalNombre,
                         COALESCE(pr.color, '#007ACC') AS ProfesionalColor
                  FROM franja f
                  LEFT JOIN franja_excepcion ex
                         ON ex.fk_franja = f.pk_franja AND ex.fecha = @Fecha
                  JOIN profesional pr
                         ON pr.pk_profesional = COALESCE(ex.fk_profesional, f.fk_profesional)
                  WHERE f.activo = TRUE
                    AND @Hora >= f.hora_desde
                    AND @Hora < f.hora_hasta
                  ORDER BY f.hora_desde
                  LIMIT 1",
                new { Fecha = fecha.Date, Hora = new TimeSpan(hora.Hours, hora.Minutes, 0) }
            ) ?? new AsignacionFranja();
        }
    }
}
