-- ============================================================
-- Kinesiología - Nombre y foto de usuario + admin de prueba
-- Motor: PostgreSQL (Neon)
-- Ejecutar después de 004 y 005. Se puede correr más de una vez.
--
-- IMPORTANTE: correr este script ANTES de usar la versión de la app
-- que trae la pantalla de Configuración. El login lee estas columnas.
-- ============================================================

-- nombre: lo usan admin y recepción, que no tienen profesional.
-- En kinesiólogos manda profesional.nombre.
ALTER TABLE usuario ADD COLUMN IF NOT EXISTS nombre VARCHAR(100);

-- foto: JPEG chico (la app la achica a 256 px antes de guardar).
ALTER TABLE usuario ADD COLUMN IF NOT EXISTS foto BYTEA;

-- SOLO DEV. Admin de prueba para entrar a Configuración. Clave: Kine2026.
CREATE EXTENSION IF NOT EXISTS pgcrypto;

INSERT INTO usuario (fk_profesional, usuario, nombre, password_hash, rol)
VALUES (NULL, 'admin', 'Administrador', crypt('Kine2026', gen_salt('bf', 10)), 'admin')
ON CONFLICT DO NOTHING;

UPDATE usuario SET nombre = 'Administrador' WHERE lower(usuario) = 'admin' AND nombre IS NULL;
UPDATE usuario SET nombre = 'Recepción'     WHERE lower(usuario) = 'recepcion' AND nombre IS NULL;
