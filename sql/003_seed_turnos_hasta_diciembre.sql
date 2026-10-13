-- ============================================================
-- Kinesiología - Carga masiva de TURNOS DEMO
-- Período: 22/09/2026 al 31/12/2026
-- Horario: Lunes a Viernes, 08:00 a 18:00 (cada 1 hora)
-- Ejecutar después de 002_seed_data.sql
-- ============================================================

-- ============================================================
-- 1. Profesionales adicionales (el seed ya tiene 1: Dr. Juan Pérez)
-- ============================================================
INSERT INTO profesional (nombre, color, activo)
VALUES
    ('Lic. Ana Torres',    '#E91E63', TRUE),
    ('Lic. Martín López',  '#4CAF50', TRUE)
ON CONFLICT DO NOTHING;

-- ============================================================
-- 2. Pacientes ficticios de prueba
-- ============================================================
INSERT INTO paciente (documento, nombre, apellido, fechanac, telefono1, fk_os, sexo, fechaingreso, observaciones)
VALUES
    ('20345678', 'Carlos',    'Fernández',  '1985-07-22', '0343-4551111', 1, 'Masculino',  '2026-01-15', 'Cervicalgia postraumática'),
    ('30456789', 'Sofía',     'Ramírez',    '1990-11-03', '0343-4552222', 2, 'Femenino',   '2026-02-10', 'Tendinitis hombro derecho'),
    ('31567890', 'Lucas',     'Díaz',       '1998-04-18', '0343-4553333', 1, 'Masculino',  '2026-03-05', 'Esguince tobillo grado II'),
    ('25678901', 'Valentina', 'Suárez',     '1988-09-30', '0343-4554444', 2, 'Femenino',   '2026-04-20', 'Rehabilitación LCA rodilla izq'),
    ('28789012', 'Tomás',     'Molina',     '1975-12-12', '0343-4555555', 3, 'Masculino',  '2026-05-01', 'Artrosis de cadera'),
    ('33890123', 'Elena',     'Castro',     '2001-01-25', '0343-4556666', 1, 'Femenino',   '2026-06-15', 'Dorsalgia postural'),
    ('22901234', 'Pedro',     'Acosta',     '1970-06-08', '0343-4557777', 2, 'Masculino',  '2026-07-10', 'Hombro congelado bilateral'),
    ('35012345', 'Julieta',   'Vega',       '1995-03-14', '0343-4558888', 3, 'Femenino',   '2026-08-01', 'Síndrome piriforme'),
    ('27123456', 'Bruno',     'Silva',      '1982-08-20', '0343-4559999', 1, 'Masculino',  '2026-08-20', 'Fascitis plantar crónica'),
    ('29234567', 'Camila',    'Herrera',    '1993-05-11', '0343-4560000', 2, 'Femenino',   '2026-09-01', 'Contractura cervical'),
    ('32345678', 'Matías',    'Rojas',      '1987-10-06', '0343-4561111', 3, 'Masculino',  '2026-09-10', 'Rehabilitación postquirúrgica rodilla'),
    ('26456789', 'Florencia', 'Méndez',     '1999-02-28', '0343-4562222', 1, 'Femenino',   '2026-09-15', 'Escoliosis - fortalecimiento'),
    ('34567890', 'Nicolás',   'Paz',        '1980-07-17', '0343-4563333', 2, 'Masculino',  '2026-09-18', 'Epicondilitis lateral (codo de tenista)'),
    ('23678901', 'Luciana',   'Ríos',       '1996-12-01', '0343-4564444', 3, 'Femenino',   '2026-09-20', 'Pubalgia deportiva');

-- ============================================================
-- 3. Órdenes para cada paciente (incluyendo la existente pk=1)
--    Necesitamos una orden por paciente para vincular los turnos.
-- ============================================================

-- Obtener los PKs de los pacientes recién insertados y crear órdenes.
-- Usamos un DO block para recorrerlos dinámicamente.
DO $$
DECLARE
    rec RECORD;
    v_os INT;
BEGIN
    FOR rec IN
        SELECT pk_paciente, nombre, apellido, observaciones, fk_os
        FROM paciente
        WHERE pk_paciente NOT IN (SELECT DISTINCT fk_paciente FROM orden)
    LOOP
        v_os := COALESCE(rec.fk_os, 3); -- default Particular

        INSERT INTO orden (fk_paciente, medico, sesiones, fecha, diagnostico, fk_os, sesionesreservadas)
        VALUES (
            rec.pk_paciente,
            'Dr. Roberto Martínez (Traumatólogo)',
            30,
            '2026-09-01',
            rec.observaciones,
            v_os,
            30
        );
    END LOOP;
END $$;

-- ============================================================
-- 4. Generar turnos: 22/09/2026 al 31/12/2026
--    Lunes a Viernes, 08:00 a 18:00 (cada 1 hora = 11 slots/día)
--
--    Estrategia: usamos generate_series para generar todos los
--    timestamps posibles y luego asignamos pacientes/órdenes/
--    profesionales en forma rotativa.
-- ============================================================

-- Tabla temporal con pacientes y sus órdenes
CREATE TEMP TABLE tmp_pacientes_ordenes AS
SELECT
    p.pk_paciente,
    p.nombre || ' ' || p.apellido AS nombre_completo,
    o.pk_orden,
    ROW_NUMBER() OVER (ORDER BY p.pk_paciente) - 1 AS idx
FROM paciente p
JOIN orden o ON o.fk_paciente = p.pk_paciente
WHERE o.cerrada = FALSE AND o.anulado = FALSE;

-- Tabla temporal con profesionales
CREATE TEMP TABLE tmp_profesionales AS
SELECT
    pk_profesional,
    ROW_NUMBER() OVER (ORDER BY pk_profesional) - 1 AS idx
FROM profesional
WHERE activo = TRUE;

-- Generar e insertar los turnos
INSERT INTO turno (fecha, turnohora, fk_orden, presente, sobreturno, nota, secuencia, hora, atendidopor, ausente)
SELECT
    slot_date,
    slot_time,
    po.pk_orden,
    -- Los turnos pasados (antes de hoy) se marcan como "presente" aleatoriamente
    CASE WHEN slot_date < CURRENT_DATE THEN (random() > 0.15) ELSE FALSE END,
    FALSE,
    NULL,
    slot_seq,
    slot_time,
    pr.pk_profesional,
    -- Los turnos pasados no-presentes se marcan como "ausente"
    CASE WHEN slot_date < CURRENT_DATE THEN (random() > 0.85) ELSE FALSE END
FROM (
    -- Generar todas las fechas L-V entre 22/09/2026 y 31/12/2026
    SELECT
        d::date AS slot_date,
        h.hora AS slot_time,
        ROW_NUMBER() OVER (ORDER BY d, h.hora) - 1 AS slot_seq
    FROM generate_series('2026-09-22'::date, '2026-12-31'::date, '1 day'::interval) d
    CROSS JOIN (
        SELECT make_time(h, 0, 0) AS hora
        FROM generate_series(8, 18) h
    ) h
    WHERE EXTRACT(DOW FROM d) BETWEEN 1 AND 5  -- Lunes(1) a Viernes(5)
) slots
-- Asignar paciente/orden rotativamente
JOIN tmp_pacientes_ordenes po ON po.idx = slots.slot_seq % (SELECT COUNT(*) FROM tmp_pacientes_ordenes)
-- Asignar profesional rotativamente
JOIN tmp_profesionales pr ON pr.idx = slots.slot_seq % (SELECT COUNT(*) FROM tmp_profesionales);

-- Limpiar tablas temporales
DROP TABLE IF EXISTS tmp_pacientes_ordenes;
DROP TABLE IF EXISTS tmp_profesionales;

-- ============================================================
-- 5. Resumen de lo insertado
-- ============================================================
-- Para verificar, ejecutar después:
--   SELECT COUNT(*) AS total_turnos FROM turno WHERE fecha >= '2026-09-22';
--   SELECT fecha, COUNT(*) AS turnos_dia FROM turno
--     WHERE fecha >= '2026-09-22'
--     GROUP BY fecha ORDER BY fecha;
