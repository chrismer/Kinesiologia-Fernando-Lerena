-- =====================================================================
-- Kinesiología - Seed de Datos de Turnos, Pacientes y Profesionales (v3)
-- Archivo: sql/003_seed_turnos.sql
-- NOTA: Este script reemplaza y expande 002_seed_data.sql.
-- Es IDEMPOTENTE: puede ejecutarse múltiples veces sin duplicar registros.
-- =====================================================================

-- 1. Limpieza previa respetando integridad referencial (CASCADE)
TRUNCATE TABLE evolucion, turno, orden, paciente, profesional, obrasocial, motivoanulacion RESTART IDENTITY CASCADE;

-- 2. Obras Sociales
INSERT INTO obrasocial (descripcion, tipo)
VALUES 
    ('OSDE 210', 'Prepaga'),
    ('IOMA', 'Provincial'),
    ('PAMI', 'Nacional'),
    ('Swiss Medical', 'Prepaga'),
    ('Particular', 'Particular');

-- 3. Motivos de Anulación
INSERT INTO motivoanulacion (motivo)
VALUES
    ('Paciente no se presentó'),
    ('Cancelado por el profesional'),
    ('Reprogramado'),
    ('Orden vencida');

-- 4. Profesionales (con colores para la Agenda)
INSERT INTO profesional (nombre, color, activo)
VALUES
    ('Dr. Juan Pérez', '#007ACC', TRUE),     -- Azul institucional (Kinesiología General / Lumbar)
    ('Lic. Ana Torres', '#28A745', TRUE),    -- Verde (Fisioterapia / Rehabilitación)
    ('Lic. Martín López', '#E83E8C', TRUE);  -- Rosa/Magenta (Kinesiología Deportiva)

-- 5. Pacientes
INSERT INTO paciente (documento, nombre, apellido, fechanac, calle, localidad, codpostal, telefono1, email, fk_os, osafiliado, osplan, sexo, fechaingreso, observaciones)
VALUES
    ('12378738', 'María', 'Gómez Blanía', '1992-03-15', 'Av. San Martín 1234', 'Paraná', '3100', '0343-4561234', 'maria.gomez@email.com', 1, '12378738-00', '210', 'Femenino', CURRENT_DATE - INTERVAL '60 days', 'Lumbalgia crónica - Hernia L4-L5'),
    ('24567890', 'Carlos', 'Fernández', '1985-07-22', 'Urquiza 567', 'Paraná', '3100', '0343-4223344', 'carlos.f@email.com', 2, '24567890/01', 'Básico', 'Masculino', CURRENT_DATE - INTERVAL '45 days', 'Rehabilitación post-quirúrgica LCA rodilla derecha'),
    ('31234567', 'Sofía', 'Ramírez', '1998-11-05', 'Gualeguaychú 890', 'Paraná', '3100', '0343-4112233', 'sofia.r@email.com', 1, '31234567-02', '310', 'Femenino', CURRENT_DATE - INTERVAL '30 days', 'Cervicobraquialgia por estrés postural'),
    ('29876543', 'Lucas', 'Díaz', '1990-04-18', '25 de Mayo 112', 'Paraná', '3100', '0343-4998877', 'lucas.diaz@email.com', 4, 'SM-987654', 'Black', 'Masculino', CURRENT_DATE - INTERVAL '20 days', 'Desgarro gemelo interno grado 2'),
    ('35678901', 'Valentina', 'Suárez', '2001-09-30', 'Pellegrini 432', 'Paraná', '3100', '0343-4334455', 'valen.s@email.com', 5, 'PART-001', 'Particular', 'Femenino', CURRENT_DATE - INTERVAL '15 days', 'Esguince de tobillo izquierdo grado 2'),
    ('22345678', 'Tomás', 'Molina', '1978-01-14', 'España 789', 'Paraná', '3100', '0343-4667788', 'tomas.m@email.com', 3, 'PAMI-22345', 'PAMI', 'Masculino', CURRENT_DATE - INTERVAL '10 days', 'Artrosis de cadera bilateral'),
    ('38901234', 'Elena', 'Castro', '2003-12-08', 'Laprida 321', 'Paraná', '3100', '0343-4778899', 'elena.c@email.com', 1, '38901234-00', '210', 'Femenino', CURRENT_DATE - INTERVAL '5 days', 'Tendinitis rotuliana rodilla izquierda'),
    ('18765432', 'Pedro', 'Acosta', '1970-06-19', 'Cervantes 654', 'Paraná', '3100', '0343-4889900', 'pedro.a@email.com', 2, '18765432/00', 'IOMA', 'Masculino', CURRENT_DATE - INTERVAL '2 days', 'Hombro doloroso - Tendinopatía supraespinoso');

-- 6. Órdenes Médicas
INSERT INTO orden (fk_paciente, medico, sesiones, fecha, diagnostico, fk_os, sesionesreservadas, sesionespresentes)
VALUES
    (1, 'Dr. Roberto Martínez (Traumatología)', 10, CURRENT_DATE - INTERVAL '30 days', 'Lumbalgia crónica - Hernia L4-L5', 1, 5, 4),
    (2, 'Dr. Esteban Quirós (Ortopedia)', 20, CURRENT_DATE - INTERVAL '25 days', 'Post-operatorio plástica LCA rodilla der.', 2, 8, 3),
    (3, 'Dra. Marcela Godoy (Clínica)', 10, CURRENT_DATE - INTERVAL '15 days', 'Cervicobraquialgia compresiva', 1, 4, 1),
    (4, 'Dr. Fernando Rossi (Deportología)', 15, CURRENT_DATE - INTERVAL '12 days', 'Desgarro miotendinoso gemelo', 4, 6, 2),
    (5, 'Dr. Roberto Martínez (Traumatología)', 10, CURRENT_DATE - INTERVAL '10 days', 'Esguince ligamento lateral externo tobillo', 5, 3, 0),
    (6, 'Dr. Sergio Valenzuela (Reumatología)', 20, CURRENT_DATE - INTERVAL '8 days', 'Coxartrosis moderada - Plan analgésico', 3, 4, 0),
    (7, 'Dr. Fernando Rossi (Deportología)', 10, CURRENT_DATE - INTERVAL '5 days', 'Tendinopatía rotuliana insercional', 1, 2, 0),
    (8, 'Dra. Marcela Godoy (Clínica)', 15, CURRENT_DATE - INTERVAL '2 days', 'Sme. manguito rotador hombro der.', 2, 2, 0);

-- 7. Turnos para el DÍA DE HOY (CURRENT_DATE)
-- Turno 1 (08:00): Atendido (tiene evolución asociada abajo)
INSERT INTO turno (fecha, turnohora, fk_orden, presente, sobreturno, nota, secuencia, atendidopor, ausente, importe)
VALUES (CURRENT_DATE, '08:00', 1, TRUE, FALSE, 'Sesión 5/10 - Favorable', 1, 1, FALSE, 4500.00);

-- Turno 2 (09:00): Presente (en sala de espera, esperando atención)
INSERT INTO turno (fecha, turnohora, fk_orden, presente, sobreturno, nota, secuencia, atendidopor, ausente, importe, horapresente)
VALUES (CURRENT_DATE, '09:00', 2, TRUE, FALSE, 'Sesión 4/20 - Fortalecimiento', 2, 2, FALSE, 5200.00, '08:52:00');

-- Turno 3 (10:00): Pendiente (Próximo turno programado)
INSERT INTO turno (fecha, turnohora, fk_orden, presente, sobreturno, nota, secuencia, atendidopor, ausente, importe)
VALUES (CURRENT_DATE, '10:00', 3, FALSE, FALSE, 'Sesión 2/10 - Ejercicios posturales', 3, 1, FALSE, 4500.00);

-- Turno 4 (11:30): Pendiente
INSERT INTO turno (fecha, turnohora, fk_orden, presente, sobreturno, nota, secuencia, atendidopor, ausente, importe)
VALUES (CURRENT_DATE, '11:30', 4, FALSE, FALSE, 'Sesión 3/15 - Magneto y ultrasonido', 4, 3, FALSE, 6000.00);

-- Turno 5 (14:00): Pendiente
INSERT INTO turno (fecha, turnohora, fk_orden, presente, sobreturno, nota, secuencia, atendidopor, ausente, importe)
VALUES (CURRENT_DATE, '14:00', 5, FALSE, FALSE, 'Sesión 1/10 - Evaluación inicial', 5, 2, FALSE, 4000.00);

-- Turno 6 (16:00): Pendiente
INSERT INTO turno (fecha, turnohora, fk_orden, presente, sobreturno, nota, secuencia, atendidopor, ausente, importe)
VALUES (CURRENT_DATE, '16:00', 6, FALSE, FALSE, 'Sesión 1/20 - Movilidad articular', 6, 1, FALSE, 3800.00);

-- 8. Turnos para otros días del mes (para poblar Agenda semanal/mensual)
-- Días pasados
INSERT INTO turno (fecha, turnohora, fk_orden, presente, sobreturno, nota, secuencia, atendidopor, ausente, importe)
VALUES
    (CURRENT_DATE - INTERVAL '1 day', '09:00', 1, TRUE, FALSE, 'Sesión 4/10', 1, 1, FALSE, 4500.00),
    (CURRENT_DATE - INTERVAL '1 day', '11:00', 7, TRUE, FALSE, 'Sesión 1/10', 2, 3, FALSE, 4500.00),
    (CURRENT_DATE - INTERVAL '2 days', '10:00', 2, TRUE, FALSE, 'Sesión 3/20', 1, 2, FALSE, 5200.00),
    (CURRENT_DATE - INTERVAL '3 days', '15:00', 8, TRUE, FALSE, 'Sesión 1/15', 1, 1, FALSE, 4500.00);

-- Días futuros (mañana y resto de semana)
INSERT INTO turno (fecha, turnohora, fk_orden, presente, sobreturno, nota, secuencia, atendidopor, ausente, importe)
VALUES
    (CURRENT_DATE + INTERVAL '1 day', '08:30', 1, FALSE, FALSE, 'Sesión 6/10', 1, 1, FALSE, 4500.00),
    (CURRENT_DATE + INTERVAL '1 day', '10:00', 4, FALSE, FALSE, 'Sesión 4/15', 2, 3, FALSE, 6000.00),
    (CURRENT_DATE + INTERVAL '1 day', '15:00', 7, FALSE, FALSE, 'Sesión 2/10', 3, 2, FALSE, 4500.00),
    (CURRENT_DATE + INTERVAL '2 days', '09:00', 2, FALSE, FALSE, 'Sesión 5/20', 1, 2, FALSE, 5200.00),
    (CURRENT_DATE + INTERVAL '2 days', '11:00', 3, FALSE, FALSE, 'Sesión 3/10', 2, 1, FALSE, 4500.00),
    (CURRENT_DATE + INTERVAL '3 days', '08:00', 5, FALSE, FALSE, 'Sesión 2/10', 1, 2, FALSE, 4000.00),
    (CURRENT_DATE + INTERVAL '3 days', '10:30', 8, FALSE, FALSE, 'Sesión 2/15', 2, 1, FALSE, 4500.00),
    (CURRENT_DATE + INTERVAL '4 days', '09:30', 6, FALSE, FALSE, 'Sesión 2/20', 1, 1, FALSE, 3800.00),
    (CURRENT_DATE + INTERVAL '4 days', '16:00', 4, FALSE, FALSE, 'Sesión 5/15', 2, 3, FALSE, 6000.00);

-- 9. Evoluciones previas y la evolución del Turno 1 de hoy (para que figure "Atendido")
INSERT INTO evolucion (fk_paciente, fk_turno, fecha, fk_profesional, niveldoloreva, tecnicasaplicadas, comentariosevolucion)
VALUES
    (1, NULL, NOW() - INTERVAL '14 days', 1, 8, 'Magnetoterapia, Terapia Manual',
     'Primera sesión. Paciente refiere dolor intenso en zona lumbar. Se realizó evaluación inicial y aplicación de magnetoterapia. Toleró bien el tratamiento.'),
    (1, NULL, NOW() - INTERVAL '10 days', 1, 6, 'Magnetoterapia, Ultrasonido, Ejercicio Terapéutico',
     'Paciente refiere leve mejoría respecto a la sesión anterior. Se incorpora ultrasonido en zona paravertebral L4-L5. Se comienza plan de ejercicios de fortalecimiento de core.'),
    (1, NULL, NOW() - INTERVAL '6 days', 1, 5, 'Ultrasonido, Ejercicio Terapéutico, Terapia Manual',
     'Presenta menos dolor en zona lumbar. Se realizaron ejercicios con banda elástica y movilizaciones articulares. Paciente colabora correctamente con el plan de ejercicios.'),
    (1, NULL, NOW() - INTERVAL '2 days', 1, 4, 'Ejercicio Terapéutico, Terapia Manual',
     'Evolución favorable. Dolor reducido a EVA 4. Se refuerza ejercicio de estiramiento de piriforme y cadena posterior. Se indica continuar ejercicios en domicilio.'),
    -- Esta evolución está vinculada al Turno 1 (id=1, de hoy 08:00), convirtiéndolo automáticamente en "Atendido":
    (1, 1, NOW(), 1, 3, 'Magnetoterapia, Terapia Manual, Ejercicio Terapéutico',
     'Sesión de hoy. Paciente llega puntual a las 08:00. Refiere dolor muy leve (EVA 3). Se realiza terapia manual descontracturante y se agregan ejercicios de estabilización lumbopélvica.');
