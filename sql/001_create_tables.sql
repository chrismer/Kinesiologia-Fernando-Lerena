-- ============================================================
-- Kinesiología - DDL Base de Datos
-- Motor: PostgreSQL (Neon)
-- Convenciones:
--   - PKs: PK_NombreTabla
--   - FKs: FK_TablaReferenciada
--   - Sin comillas dobles (Postgres normaliza a minúsculas)
--   - Las 5 columnas ambiguas del diagrama se omiten;
--     se agregarán con ALTER TABLE cuando se confirmen.
-- ============================================================

-- 1. Profesional
CREATE TABLE IF NOT EXISTS profesional (
    pk_profesional  SERIAL PRIMARY KEY,
    nombre          VARCHAR(100) NOT NULL,
    color           VARCHAR(20),
    activo          BOOLEAN DEFAULT TRUE
);

-- 2. Obra Social
CREATE TABLE IF NOT EXISTS obrasocial (
    pk_os           SERIAL PRIMARY KEY,
    descripcion     VARCHAR(200) NOT NULL,
    tipo            VARCHAR(50)
);

-- 3. Motivo Anulación (catálogo, 2 columnas)
CREATE TABLE IF NOT EXISTS motivoanulacion (
    pk_motivo       SERIAL PRIMARY KEY,
    motivo          VARCHAR(200) NOT NULL
);

-- 4. Paciente
CREATE TABLE IF NOT EXISTS paciente (
    pk_paciente     SERIAL PRIMARY KEY,
    documento       VARCHAR(20),
    nombre          VARCHAR(100) NOT NULL,
    apellido        VARCHAR(100) NOT NULL,
    fechanac        DATE,
    calle           VARCHAR(200),
    localidad       VARCHAR(100),
    codpostal       VARCHAR(10),
    telefono1       VARCHAR(30),
    telefono2       VARCHAR(30),
    telefono3       VARCHAR(30),
    email           VARCHAR(200),
    fk_os           INT REFERENCES obrasocial(pk_os),
    osafiliado      VARCHAR(50),
    osplan          VARCHAR(50),
    color           VARCHAR(20),
    sexo            VARCHAR(10),
    fechaingreso    DATE,
    observaciones   TEXT,
    certificadocovid VARCHAR(50)
);

-- 5. Orden
CREATE TABLE IF NOT EXISTS orden (
    pk_orden            SERIAL PRIMARY KEY,
    fk_paciente         INT NOT NULL REFERENCES paciente(pk_paciente),
    medico              VARCHAR(100),
    sesiones            INT,
    fecha               DATE,
    observaciones       TEXT,
    diagnostico         TEXT,
    fechaautorizacion   DATE,
    sesionesreservadas  INT DEFAULT 0,
    sesionespresentes   INT DEFAULT 0,
    cerrada             BOOLEAN DEFAULT FALSE,
    fk_os               INT REFERENCES obrasocial(pk_os),
    anulado             BOOLEAN DEFAULT FALSE,
    fk_motivo           INT REFERENCES motivoanulacion(pk_motivo),
    pago                BOOLEAN DEFAULT FALSE,
    importe             DECIMAL(10,2),
    sesionesausentes    INT DEFAULT 0
);

-- Columnas omitidas de Orden (ambiguas, se agregan con ALTER TABLE si se confirman):
--   mesfacturacion  VARCHAR(20)
--   fk_ordenanulada INT REFERENCES orden(pk_orden)
--   kinesiologo     VARCHAR(100)  -- ¿o FK a profesional?
--   copia           VARCHAR(100)

-- 6. Turno
CREATE TABLE IF NOT EXISTS turno (
    pk_turno        SERIAL PRIMARY KEY,
    fecha           DATE NOT NULL,
    turnohora       TIME,
    fk_orden        INT REFERENCES orden(pk_orden),
    presente        BOOLEAN DEFAULT FALSE,
    sobreturno      BOOLEAN DEFAULT FALSE,
    nota            TEXT,
    secuencia       INT,
    hora            TIME,
    horapresente    TIME,
    atendidopor     INT REFERENCES profesional(pk_profesional),
    ausente         BOOLEAN DEFAULT FALSE,
    importe         DECIMAL(10,2)
);

-- Columna omitida de Turno (ambigua):
--   horaatendido  TIME   -- ¿o "horaanulado"?

-- 7. Evolución (NUEVA - no está en el diagrama original)
-- Mapea 1:1 con EvolucionSesion de Pagina3
CREATE TABLE IF NOT EXISTS evolucion (
    pk_evolucion        SERIAL PRIMARY KEY,
    fk_paciente         INT NOT NULL REFERENCES paciente(pk_paciente),
    fk_turno            INT REFERENCES turno(pk_turno),
    fecha               TIMESTAMP NOT NULL DEFAULT NOW(),
    fk_profesional      INT NOT NULL REFERENCES profesional(pk_profesional),
    niveldoloreva       SMALLINT CHECK (niveldoloreva >= 0 AND niveldoloreva <= 10),
    tecnicasaplicadas   VARCHAR(500),
    comentariosevolucion TEXT NOT NULL
);

-- ============================================================
-- Índices útiles
-- ============================================================
CREATE INDEX IF NOT EXISTS idx_paciente_documento ON paciente(documento);
CREATE INDEX IF NOT EXISTS idx_paciente_apellido ON paciente(apellido);
CREATE INDEX IF NOT EXISTS idx_turno_fecha ON turno(fecha);
CREATE INDEX IF NOT EXISTS idx_evolucion_paciente ON evolucion(fk_paciente);
CREATE INDEX IF NOT EXISTS idx_evolucion_fecha ON evolucion(fecha);
CREATE INDEX IF NOT EXISTS idx_orden_paciente ON orden(fk_paciente);
