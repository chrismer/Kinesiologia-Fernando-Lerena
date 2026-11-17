-- ============================================================
-- Kinesiología - Franjas horarias (un kinesiólogo titular)
-- Motor: PostgreSQL (Neon)
-- Ejecutar después de sql/003 (tiene que existir profesional).
-- No reescribe turnos ya cargados.
-- ============================================================

CREATE TABLE IF NOT EXISTS franja (
    pk_franja       SERIAL PRIMARY KEY,
    nombre          VARCHAR(40) NOT NULL UNIQUE,
    hora_desde      TIME NOT NULL,
    hora_hasta      TIME NOT NULL,
    fk_profesional  INT NOT NULL REFERENCES profesional(pk_profesional),
    activo          BOOLEAN NOT NULL DEFAULT TRUE,
    CONSTRAINT ck_franja_horario CHECK (hora_desde < hora_hasta)
);

-- Un día y una franja tienen un solo reemplazo.
-- Los turnos nuevos de ese día usan este profesional.
-- Los turnos ya creados no se mueven.
CREATE TABLE IF NOT EXISTS franja_excepcion (
    pk_excepcion    SERIAL PRIMARY KEY,
    fecha           DATE NOT NULL,
    fk_franja       INT NOT NULL REFERENCES franja(pk_franja),
    fk_profesional  INT NOT NULL REFERENCES profesional(pk_profesional),
    CONSTRAINT uq_franja_excepcion UNIQUE (fecha, fk_franja)
);

INSERT INTO franja (nombre, hora_desde, hora_hasta, fk_profesional)
SELECT v.nombre, v.desde, v.hasta, p.pk_profesional
FROM (VALUES
    ('Mañana',     TIME '08:00', TIME '12:00', 'Dr. Juan Pérez'),
    ('Tarde',      TIME '13:00', TIME '17:00', 'Lic. Ana Torres'),
    ('Vespertino', TIME '18:00', TIME '21:00', 'Lic. Martín López')
) AS v(nombre, desde, hasta, prof)
JOIN LATERAL (
    SELECT pk_profesional
    FROM profesional
    WHERE nombre = v.prof AND activo
    ORDER BY pk_profesional
    LIMIT 1
) p ON TRUE
WHERE NOT EXISTS (SELECT 1 FROM franja f WHERE f.nombre = v.nombre);
