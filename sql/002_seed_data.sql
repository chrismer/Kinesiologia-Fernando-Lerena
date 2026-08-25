-- ============================================================
-- Kinesiología - Datos iniciales de prueba
-- Ejecutar después de 001_create_tables.sql
-- ============================================================

-- Profesional
INSERT INTO profesional (nombre, color, activo)
VALUES ('Dr. Juan Pérez', '#007ACC', TRUE);

-- Obra Social
INSERT INTO obrasocial (descripcion, tipo)
VALUES
    ('OSDE 210', 'Prepaga'),
    ('IOMA', 'Provincial'),
    ('Particular', 'Particular');

-- Motivo Anulación
INSERT INTO motivoanulacion (motivo)
VALUES
    ('Paciente no se presentó'),
    ('Cancelado por el profesional'),
    ('Reprogramado'),
    ('Orden vencida');

-- Paciente de prueba (el mismo que usaba MemoryEvolucionRepository)
INSERT INTO paciente (documento, nombre, apellido, fechanac, calle, localidad, codpostal,
                      telefono1, email, fk_os, osafiliado, osplan, sexo, fechaingreso, observaciones)
VALUES ('12378738', 'María', 'Gómez Blanía', '1992-03-15', 'Av. San Martín 1234', 'Paraná',
        '3100', '0343-4561234', 'maria.gomez@email.com', 1, '12378738-00', '210',
        'Femenino', CURRENT_DATE, 'Lumbalgia crónica - Hernia L4-L5');

-- Orden para el paciente de prueba
INSERT INTO orden (fk_paciente, medico, sesiones, fecha, diagnostico, fk_os, sesionesreservadas)
VALUES (1, 'Dr. Roberto Martínez (Traumatólogo)', 20, CURRENT_DATE - INTERVAL '30 days',
        'Lumbalgia crónica - Hernia L4-L5. Indicación de kinesiología.', 1, 10);

-- Turno de prueba
INSERT INTO turno (fecha, turnohora, fk_orden, presente, hora, secuencia, atendidopor)
VALUES (CURRENT_DATE, '09:00', 1, TRUE, '09:00', 1, 1);

-- Evoluciones de prueba (replican el historial que tenía MemoryEvolucionRepository)
INSERT INTO evolucion (fk_paciente, fk_turno, fecha, fk_profesional, niveldoloreva, tecnicasaplicadas, comentariosevolucion)
VALUES
    (1, NULL, NOW() - INTERVAL '14 days', 1, 8, 'Magnetoterapia, Terapia Manual',
     'Primera sesión. Paciente refiere dolor intenso en zona lumbar. Se realizó evaluación inicial y aplicación de magnetoterapia. Toleró bien el tratamiento.'),
    (1, NULL, NOW() - INTERVAL '10 days', 1, 6, 'Magnetoterapia, Ultrasonido, Ejercicio Terapeutico',
     'Paciente refiere leve mejoría respecto a la sesión anterior. Se incorpora ultrasonido en zona paravertebral L4-L5. Se comienza plan de ejercicios de fortalecimiento de core.'),
    (1, NULL, NOW() - INTERVAL '6 days', 1, 5, 'Ultrasonido, Ejercicio Terapeutico, Terapia Manual',
     'Presenta menos dolor en zona lumbar. Se realizaron ejercicios con banda elástica y movilizaciones articulares. Paciente colabora correctamente con el plan de ejercicios.'),
    (1, NULL, NOW() - INTERVAL '2 days', 1, 4, 'Ejercicio Terapeutico, Terapia Manual',
     'Evolución favorable. Dolor reducido a EVA 4. Se refuerza ejercicio de estiramiento de piriforme y cadena posterior. Se indica continuar ejercicios en domicilio.');
