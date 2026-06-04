# PizzeriaPOS

Sistema de punto de venta (POS) para una pizzería, desarrollado con **.NET 8**. Permite al personal del negocio gestionar productos, clientes, direcciones y pedidos desde una aplicación de escritorio, respaldada por una API segura con autenticación JWT.

---

## Requisitos

Antes de ejecutar el proyecto asegúrate de tener instalado:

- [Visual Studio 2022](https://visualstudio.microsoft.com/) o superior (con los workloads **ASP.NET and web development** y **.NET desktop development**)
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/sql-server) (local, cualquier edición)
- [SQL Server Management Studio](https://learn.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms) para ejecutar los scripts

---

## Tecnologías

| Tecnología | Uso |
|---|---|
| .NET 8 | Plataforma base |
| ASP.NET Core | API RESTful |
| Entity Framework Core | Acceso a datos (ORM) |
| SQL Server | Base de datos relacional |
| WinForms | Interfaz de escritorio |
| JWT Bearer Authentication | Seguridad de la API |
| BCrypt.Net-Next | Hash de contraseñas |
| Swagger / Swashbuckle | Documentación de la API |
| xUnit | Pruebas unitarias |

---

## Arquitectura

La solución está dividida en cuatro proyectos con responsabilidades separadas:

| Proyecto | Descripción |
|---|---|
| `PizzeriaPOS.Data` | Entidades, `DbContext` y repositorios. Es la capa de acceso a datos compartida por el resto. |
| `PizzeriaPOS.API` | Backend ASP.NET Core. Expone todos los endpoints REST y maneja la autenticación con JWT. |
| `PizzeriaPOS.WinForms` | Aplicación de escritorio. Se conecta a la API mediante `HttpClient` y presenta la interfaz visual al operador. |
| `PizzeriaPOS.Tests` | Pruebas unitarias con xUnit y EF Core InMemory. Valida la lógica de los repositorios sin necesidad de base de datos real. |

```text
PizzeriaPOS/
├─ Database/
│  └─ Scripts/           ← Scripts SQL para crear y poblar la base de datos
├─ PizzeriaPOS.Data/     ← Capa de datos
├─ PizzeriaPOS.API/      ← Backend
├─ PizzeriaPOS.WinForms/ ← Frontend de escritorio
└─ PizzeriaPOS.Tests/    ← Pruebas unitarias
```

---

## Cómo ejecutar

### 1. Abrir la solución

Abre `PizzeriaPOS.slnx` en Visual Studio 2022 o superior.

### 2. Proyectos de inicio

La solución está configurada para arrancar dos proyectos al mismo tiempo:

- `PizzeriaPOS.API` — el backend
- `PizzeriaPOS.WinForms` — la aplicación de escritorio

Los siguientes proyectos **no se ejecutan directamente**, son bibliotecas:

- `PizzeriaPOS.Data`
- `PizzeriaPOS.Tests`

### 3. Configurar la base de datos

Abre SQL Server Management Studio, conéctate a tu instancia local y ejecuta los scripts de la carpeta `Database/Scripts` **en este orden**:

| # | Archivo | Qué hace |
|---|---|---|
| 1 | `01_create_and_seed_productos.sql` | Crea la base de datos `PizzeriaPOS` y la tabla `Productos` con datos básicos iniciales |
| 2 | `02_create_tables_complete.sql` | Crea todas las tablas del sistema: `Clientes`, `Direcciones`, `Pedidos` y `PedidoDetalles` con sus relaciones |
| 3 | `03_create_usuarios_table.sql` | Crea la tabla `Usuarios` para autenticación con contraseñas hasheadas |
| 4 | `04_seed_50_productos_clientes_pedidos.sql` | Inserta datos de prueba: productos reales, 50 clientes con direcciones y pedidos de ejemplo |

### 4. Revisar la cadena de conexión

Abre `PizzeriaPOS.API/appsettings.json` y verifica que el nombre del servidor coincida con tu instancia de SQL Server:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=PizzeriaPOS;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Reemplaza `TU_SERVIDOR` con el nombre de tu instancia, por ejemplo `localhost`, `.\SQLEXPRESS` o el nombre de tu equipo.

### 5. Ejecutar la solución

Presiona **F5** o haz clic en **Iniciar** en Visual Studio. Ambos proyectos arrancarán simultáneamente.

La API quedará disponible en:

- `https://localhost:7057`
- `http://localhost:5161`

La documentación interactiva de Swagger estará en:

- `https://localhost:7057/swagger`

### 6. Iniciar sesión

La aplicación WinForms abrirá la pantalla de login automáticamente. Si no tienes un usuario creado, usa la opción **Registrarse** para crear uno nuevo. Las contraseñas se almacenan con hash BCrypt.

---

## Funcionalidades

### Productos
- Listar, crear, editar y eliminar productos (baja lógica mediante `EstaActivo`)
- Filtrar por nombre y categoría en tiempo real

### Clientes
- Gestión completa de clientes con múltiples direcciones de entrega por cliente
- Búsqueda por nombre en tiempo real

### Pedidos
- Crear pedidos asociados a un cliente y dirección de entrega
- Agregar múltiples productos con cantidad a cada pedido
- Cambiar el estado del pedido: **Pendiente**, **En preparación**, **Entregado**, **Cancelado**
- Ver el detalle completo al seleccionar un pedido de la lista

---

## Pruebas

Para ejecutar las pruebas unitarias desde la terminal:

```bash
dotnet test
```

O desde Visual Studio: **Prueba → Ejecutar todas las pruebas** (`Ctrl+R, A`).

Las pruebas validan el comportamiento de los repositorios de `Producto`, `Cliente` y `Pedido` usando una base de datos en memoria, sin necesidad de SQL Server.

---

## Notas

- La API protege todos los endpoints con JWT excepto `/api/auth/register` y `/api/auth/login`.
- Las contraseñas se almacenan usando BCrypt, nunca en texto plano.
- Los productos eliminados usan baja lógica (`EstaActivo = false`) para conservar el historial de pedidos.
- Los pedidos recalculan su total automáticamente al agregar o modificar detalles.
- La aplicación WinForms consume la API directamente mediante `HttpClient` con el token JWT en el encabezado `Authorization`.

---

## Autor

Proyecto de laboratorio desarrollado para evaluación técnica — Albatros.

---

## Humor

> *"Funciona en mi máquina"* 

![works on my machine](https://media.giphy.com/media/13FrpeVH09Zrb2/giphy.gif)
