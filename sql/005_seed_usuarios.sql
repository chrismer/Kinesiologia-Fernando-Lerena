-- ============================================================
-- Kinesiología - Usuarios de prueba
-- SOLO DEV. Clave compartida: Kine2026. No usar fuera de la práctica.
--
-- Ejecutar después de 004_create_usuario.sql y de cualquiera de los
-- dos seeds 003 (los dos dejan a Juan Pérez, Ana Torres y Martín López).
--
-- 003_seed_turnos.sql trunca profesional con CASCADE y borra esta
-- tabla. Después de volver a correr ese script, correr 005 otra vez.
--
-- No usa ids fijos. Si hasta_diciembre duplicó un nombre, se queda
-- con el pk_profesional activo más bajo. ON CONFLICT sin target
-- también saltea la fila si ese profesional ya tiene otro login.
-- ============================================================

CREATE EXTENSION IF NOT EXISTS pgcrypto;

INSERT INTO usuario (fk_profesional, usuario, password_hash, rol, activo)
SELECT p.pk_profesional,
       v.usuario,
       crypt('Kine2026', gen_salt('bf', 10)),
       'kinesiologo',
       TRUE
FROM (VALUES
    ('jperez',  'Dr. Juan Pérez'),
    ('atorres', 'Lic. Ana Torres'),
    ('mlopez',  'Lic. Martín López')
) AS v(usuario, nombre)
JOIN LATERAL (
    SELECT pk_profesional
    FROM profesional
    WHERE nombre = v.nombre AND activo
    ORDER BY pk_profesional
    LIMIT 1
) p ON TRUE
ON CONFLICT DO NOTHING;
