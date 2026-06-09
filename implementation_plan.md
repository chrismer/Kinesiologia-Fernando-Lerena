# Plan de Implementación — Sistema de Gestión de Cooperadoras Escolares

Sistema de escritorio en Python con interfaz gráfica moderna, diseñado para la Práctica
Profesionalizante II. Gestiona socios, cuotas, finanzas y reportes de una cooperadora escolar.
Duración estimada: **3 meses** (15 junio → 15 septiembre).

---

## User Review Required

> [!IMPORTANT]
> El PDF describe un **Sistema de Gestión de Cooperadoras Escolares**, no un sistema de kinesiología. Todo este plan está basado en ese dominio. Si el proyecto real es diferente, avisame antes de ejecutar.

> [!WARNING]
> Se descartaron Twilio, psycopg2 y SQLAlchemy para no exceder el tiempo disponible. Si el docente exige alguna de estas tecnologías, hay que ajustar el plan.

---

## Stack Tecnológico

| Necesidad | Librería | Motivo |
|---|---|---|
| UI moderna | `customtkinter` | Wrapper de Tkinter con modo oscuro/claro nativo |
| Base de datos | `sqlite3` | Viene con Python, cero configuración, perfecto para escritorio |
| Seguridad | `hashlib` (nativo) | Hash SHA-256 para contraseñas, sin dependencias extra |
| Exportar datos | `openpyxl` | Genera archivos `.xlsx` reales para los reportes financieros |
| Emails | `smtplib` (nativo) | Notificaciones de cuotas vencidas vía Gmail |
| Fechas en UI | `tkcalendar` | Widget de calendario para selección de fechas |
| Config segura | `python-dotenv` | Credenciales de email fuera del código |
| Gráficos | `matplotlib` | Gráficos de barras para el dashboard financiero |

**`requirements.txt` resultante:**
```
customtkinter>=5.2.0
openpyxl>=3.1.0
tkcalendar>=1.6.1
python-dotenv>=1.0.0
matplotlib>=3.8.0
```

---

## Estructura de Carpetas

```
src/
├── main.py                    # Punto de entrada
├── .env                       # Credenciales (NO commitear)
├── .env.example               # Template para el equipo
├── cooperadora.db             # Base de datos SQLite (auto-generada)
│
├── database/
│   ├── __init__.py
│   ├── connection.py          # Singleton de conexión SQLite
│   └── schema.sql             # DDL de las tablas
│
├── models/                    # Capa de datos (M en MVC)
│   ├── __init__.py
│   ├── usuario.py
│   ├── socio.py
│   ├── cuota.py
│   ├── movimiento.py          # Ingresos y egresos
│   └── categoria.py
│
├── views/                     # Capa visual (V en MVC)
│   ├── __init__.py
│   ├── app.py                 # Ventana principal (CTk root)
│   ├── login_view.py
│   ├── dashboard_view.py
│   ├── socios_view.py
│   ├── cuotas_view.py
│   ├── finanzas_view.py
│   └── reportes_view.py
│
├── controllers/               # Capa lógica (C en MVC)
│   ├── __init__.py
│   ├── auth_controller.py
│   ├── socios_controller.py
│   ├── cuotas_controller.py
│   ├── finanzas_controller.py
│   └── reportes_controller.py
│
└── utils/
    ├── __init__.py
    ├── export.py              # Exportar a Excel/CSV
    ├── notificaciones.py      # Envío de emails con smtplib
    └── validators.py          # Validación de campos
```

---

## Esquema de Base de Datos

### Tabla `usuarios`
```sql
CREATE TABLE usuarios (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    username    TEXT    NOT NULL UNIQUE,
    password_hash TEXT  NOT NULL,
    rol         TEXT    NOT NULL DEFAULT 'consulta',  -- 'admin' | 'consulta'
    activo      INTEGER NOT NULL DEFAULT 1,
    created_at  TEXT    NOT NULL DEFAULT (datetime('now'))
);
```

### Tabla `socios`
```sql
CREATE TABLE socios (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    nombre      TEXT    NOT NULL,
    apellido    TEXT    NOT NULL,
    dni         TEXT    UNIQUE,
    email       TEXT,
    telefono    TEXT,
    direccion   TEXT,
    estado      TEXT    NOT NULL DEFAULT 'activo',  -- 'activo' | 'inactivo'
    fecha_ingreso TEXT  NOT NULL DEFAULT (date('now')),
    created_at  TEXT    NOT NULL DEFAULT (datetime('now'))
);
```

### Tabla `cuotas`
```sql
CREATE TABLE cuotas (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    socio_id    INTEGER NOT NULL REFERENCES socios(id),
    periodo     TEXT    NOT NULL,  -- ej: '2025-07'
    monto       REAL    NOT NULL,
    estado      TEXT    NOT NULL DEFAULT 'pendiente',  -- 'pendiente' | 'pagada' | 'vencida'
    fecha_vencimiento TEXT NOT NULL,
    fecha_pago  TEXT,
    observaciones TEXT,
    created_at  TEXT    NOT NULL DEFAULT (datetime('now'))
);
```

### Tabla `categorias`
```sql
CREATE TABLE categorias (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    nombre      TEXT    NOT NULL UNIQUE,
    tipo        TEXT    NOT NULL  -- 'ingreso' | 'egreso'
);
```

### Tabla `movimientos`
```sql
CREATE TABLE movimientos (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    tipo        TEXT    NOT NULL,  -- 'ingreso' | 'egreso'
    categoria_id INTEGER REFERENCES categorias(id),
    descripcion TEXT    NOT NULL,
    monto       REAL    NOT NULL,
    fecha       TEXT    NOT NULL DEFAULT (date('now')),
    usuario_id  INTEGER REFERENCES usuarios(id),
    created_at  TEXT    NOT NULL DEFAULT (datetime('now'))
);
```

---

## Fases de Desarrollo

### FASE 1 — Fundación (Semana 1–3, Junio)
*Relevamiento, análisis, base técnica del proyecto.*

#### [NEW] `src/database/connection.py`
Singleton de conexión SQLite. Inicializa la BD y ejecuta el schema si no existe.

#### [NEW] `src/database/schema.sql`
DDL completo con las 5 tablas y datos semilla (categorías por defecto, usuario admin inicial).

#### [NEW] `src/models/usuario.py`
Modelo con métodos: `crear()`, `buscar_por_username()`, `verificar_password()`.

#### [NEW] `src/views/login_view.py`
Ventana inicial con campos username/password y botón de acceso. Bloquea la app si las credenciales fallan.

#### [NEW] `src/controllers/auth_controller.py`
Recibe credenciales de la Vista, llama al Modelo, devuelve resultado.

#### [NEW] `src/main.py`
Punto de entrada. Instancia la app CTk, aplica modo oscuro/claro, abre LoginView.

---

### FASE 2 — Módulos Principales (Semana 4–7, Julio)
*Desarrollo de los tres módulos centrales del sistema.*

#### [NEW] `src/models/socio.py`
CRUD completo: `crear()`, `listar()`, `buscar()`, `actualizar()`, `cambiar_estado()`.

#### [NEW] `src/views/socios_view.py`
- Tabla (`CTkTreeview`) con lista de socios, buscador en tiempo real.
- Formulario modal para Alta/Modificación.
- Botón "Desactivar" para baja lógica (no elimina el registro).

#### [NEW] `src/models/cuota.py`
Métodos: `registrar_pago()`, `listar_pendientes()`, `listar_vencidas()`, `historial_por_socio()`.

#### [NEW] `src/views/cuotas_view.py`
- Lista filtrable por estado (pendiente / pagada / vencida).
- Widget `tkcalendar` para fecha de vencimiento.
- Alerta visual (color rojo) en cuotas vencidas.
- Modal "Registrar Pago" con monto y fecha.

#### [NEW] `src/models/movimiento.py` + `src/models/categoria.py`
CRUD de ingresos y egresos, clasificados por categoría.

#### [NEW] `src/views/finanzas_view.py`
- Dos listas paralelas: Ingresos / Egresos.
- Formulario de nuevo movimiento con selector de categoría.
- Saldo neto visible en tiempo real.

---

### FASE 3 — Reportes y Dashboard (Semana 8–10, Agosto)
*Implementación de reportes, testing y mejoras de usabilidad.*

#### [NEW] `src/views/dashboard_view.py`
- Tarjetas con indicadores: total socios activos, cuotas vencidas, saldo del mes.
- Gráfico de barras mensual con `matplotlib` embebido en CTk.
- Alertas destacadas de socios con 2+ cuotas vencidas.

#### [NEW] `src/controllers/reportes_controller.py`
Lógica de consultas agregadas: balance mensual, deudores, socios activos/inactivos.

#### [NEW] `src/views/reportes_view.py`
- Reporte: Estado financiero general (por período).
- Reporte: Socios con deuda.
- Reporte: Balance mensual.
- Botón "Exportar a Excel" en cada reporte.

#### [NEW] `src/utils/export.py`
Genera `.xlsx` con `openpyxl` con formato básico (encabezados en negrita, anchos de columna).

#### [NEW] `src/utils/notificaciones.py`
Envío de email a socios con cuotas vencidas usando `smtplib` + `python-dotenv`. Se ejecuta manualmente desde la UI.

---

### FASE 4 — Cierre y Entrega (Semana 11–12, Septiembre)
*Documentación, pruebas finales y presentación.*

#### [MODIFY] Todos los módulos
- Agregar bloques `try/except` en todas las operaciones de BD y de red.
- Mensajes de error amigables con `CTkMessagebox` en lugar de crashes.
- Validadores en `utils/validators.py` para campos obligatorios.

#### [NEW] `README.md`
Manual de instalación y uso básico (requisito de documentación técnica).

#### [NEW] `.env.example`
```env
EMAIL_SENDER=tu_email@gmail.com
EMAIL_PASSWORD=app_password_de_gmail
```

---

## Estrategia Git

```
main             ← producción estable
└── develop      ← integración
    ├── feature/login
    ├── feature/socios
    ├── feature/cuotas
    ├── feature/finanzas
    ├── feature/reportes
    └── feature/dashboard
```

**Reglas:**
- Commits en inglés o español, pero consistente. Ej: `feat: agregar modal de nuevo socio`
- No commitear nunca el archivo `.env` (está en `.gitignore`)
- Merge a `develop` con Pull Request, revisado por al menos un compañero
- Tag `v1.0` al cierre de la Fase 3 antes de la Fase 4

---

## Criterios de Evaluación (mapeados al PDF)

| Ítem del PDF | Puntaje | Cómo lo cubrimos |
|---|---|---|
| **Desarrollo del sistema** | 3 pts | Funcionalidades de socios, cuotas, finanzas y reportes completas y estables |
| **Uso de Git y GitHub** | 2 pts | Ramas por feature, commits frecuentes, historial limpio |
| **Trabajo colaborativo** | 1.5 pts | División por módulos entre compañeros, revisión cruzada de código |
| **Cumplimiento de plazos** | 1.5 pts | Fases alineadas al cronograma de junio–septiembre del PDF |
| **Reportes e informes** | 1 pt | Informes de proceso del proyecto + exportación Excel |
| **Documentación técnica** | 1 pt | README.md + docstrings en clases y métodos |
| **Total** | **10 pts** | |

---

## Open Questions

> [!IMPORTANT]
> **¿Trabajan en equipo o es individual?** Si son varios, hay que dividir los módulos entre personas desde la Fase 1.

> [!IMPORTANT]
> **¿Hay reunión de relevamiento con una cooperadora real?** El PDF lo menciona como actividad. Si hay un referente real (director/tesorero), los modelos de datos pueden necesitar ajustes.

> [!NOTE]
> **¿El docente pide diagrama de clases o diagrama ER?** Si sí, los generamos antes de empezar a codear para que quede como documentación inicial del proyecto.

---

## Plan de Verificación

### Pruebas manuales por módulo
- [ ] Login: credenciales válidas → accede; inválidas → muestra error (no crashea)
- [ ] Socios: CRUD completo sin dejar registros huérfanos en cuotas
- [ ] Cuotas: estado cambia correctamente al registrar pago
- [ ] Finanzas: saldo neto = suma ingresos − suma egresos
- [ ] Reportes: el Excel exportado se abre sin errores en LibreOffice/Excel
- [ ] Dashboard: las alertas de vencimiento son correctas

### Prueba de robustez
- Desconectar el archivo `.db` mientras la app corre → debe mostrar error amigable
- Ingresar texto en campo numérico → validador debe bloquear antes de llegar a la BD
- Enviar email sin conexión a Internet → debe mostrar mensaje, no cerrar la app

