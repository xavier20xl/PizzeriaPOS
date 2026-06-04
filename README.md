# PizzeriaPOS

Sistema de punto de venta para una pizzería, construido con .NET 8. Combina una API segura con JWT, una capa de datos basada en Entity Framework Core y una aplicación de escritorio WinForms.

---

## Requisitos

- Visual Studio 2022 o superior
- .NET 8 SDK
- SQL Server local

---

## Tecnologías

- .NET 8
- ASP.NET Core
- Entity Framework Core
- SQL Server
- WinForms
- JWT Bearer Authentication
- BCrypt.Net-Next
- Swagger / Swashbuckle
- xUnit

---

## Arquitectura

La solución está organizada en cuatro proyectos:

| Proyecto | Descripción |
|---|---|
| `PizzeriaPOS.Data` | Entidades, `DbContext` y repositorios |
| `PizzeriaPOS.API` | Backend ASP.NET Core con endpoints y seguridad JWT |
| `PizzeriaPOS.WinForms` | Cliente de escritorio conectado a la API |
| `PizzeriaPOS.Tests` | Pruebas unitarias de la capa de datos con EF Core InMemory |

```text
PizzeriaPOS/
├─ Database/
│  └─ Scripts/
├─ PizzeriaPOS.Data/
├─ PizzeriaPOS.API/
├─ PizzeriaPOS.WinForms/
└─ PizzeriaPOS.Tests/
```

---

## Cómo ejecutar

### 1. Abrir la solución

Abre `PizzeriaPOS.slnx` en Visual Studio 2022 o superior.

### 2. Proyectos de inicio

La solución está configurada para ejecutar al mismo tiempo:

- `PizzeriaPOS.API`
- `PizzeriaPOS.WinForms`

Los siguientes proyectos no se ejecutan directamente:

- `PizzeriaPOS.Data`
- `PizzeriaPOS.Tests`

### 3. Configurar la base de datos

Ejecuta los scripts de `Database/Scripts` en este orden:

1. `01_create_and_seed_productos.sql`
2. `02_create_tables_complete.sql`
3. `03_create_usuarios_table.sql`
4. `04_seed_usuario_admin.sql`

### 4. Revisar la cadena de conexión

Verifica la configuración en `PizzeriaPOS.API/appsettings.json` y ajusta el nombre del servidor si es necesario.

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=PizzeriaPOS;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 5. Ejecutar la solución

Inicia la solución desde Visual Studio y espera a que arranquen la API y la aplicación de escritorio.

La API quedará disponible en:

- `https://localhost:7057`
- `http://localhost:5161`

La documentación Swagger estará en `https://localhost:7057/swagger`.

### 6. Iniciar sesión

Abre la app WinForms y accede con un usuario registrado. Si no existe uno, usa la pantalla de registro.

---

## Pruebas

```bash
dotnet test
```

El proyecto de pruebas valida el comportamiento de los repositorios de `Producto`, `Cliente` y `Pedido` usando base de datos en memoria.

---

## Notas

- La API usa JWT para proteger todos los endpoints excepto `register` y `login`.
- Los productos usan baja lógica mediante `EstaActivo`.
- Los pedidos recalculan su total automáticamente cuando cambian sus detalles.
- La UI de WinForms consume la API directamente via `HttpClient`.

---

> *"Funciona en mi máquina"* 🤷

![works on my machine](https://media.giphy.com/media/13FrpeVH09Zrb2/giphy.gif)

## Autor

Proyecto de laboratorio desarrollado para evaluación técnica — Albatros.
