-- ============================================================
-- Kinesiología - Login de usuarios
-- Motor: PostgreSQL (Neon)
-- Ejecutar después de sql/001_create_tables.sql
-- ============================================================

CREATE TABLE IF NOT EXISTS usuario (
    pk_usuario      SERIAL PRIMARY KEY,
    fk_profesional  INT UNIQUE REFERENCES profesional(pk_profesional),
    usuario         VARCHAR(50) NOT NULL,
    password_hash   VARCHAR(100) NOT NULL,
    rol             VARCHAR(20) NOT NULL,
    activo          BOOLEAN NOT NULL DEFAULT TRUE,
    CONSTRAINT ck_usuario_rol CHECK (rol IN ('kinesiologo', 'admin', 'recepcion')),
    CONSTRAINT ck_usuario_rol_profesional CHECK (
        (rol = 'kinesiologo' AND fk_profesional IS NOT NULL)
        OR (rol IN ('admin', 'recepcion') AND fk_profesional IS NULL)
    )
);

-- El login no distingue mayúsculas. Varios NULL en fk_profesional
-- son válidos: admin y recepción no ocupan un profesional.
CREATE UNIQUE INDEX IF NOT EXISTS ux_usuario_lower ON usuario (lower(usuario));
