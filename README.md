# PizzeriaPOS

PizzeriaPOS es un sistema de punto de venta para una pizzería, construido con .NET 8. Combina una API segura con JWT, una capa de datos basada en Entity Framework Core y una aplicación de escritorio WinForms para administrar productos, clientes, direcciones y pedidos.

## Lo que hace

- Autenticación de usuarios con registro e inicio de sesión.
- Gestión de productos con baja lógica.
- Gestión de clientes y sus direcciones.
- Creación y consulta de pedidos con detalles.
- Interfaz de escritorio para operar el sistema de forma visual.
- Pruebas automatizadas para repositorios con EF Core InMemory.

## Arquitectura

La solución está organizada en cuatro proyectos:

- `PizzeriaPOS.API`: backend ASP.NET Core con endpoints y seguridad JWT.
- `PizzeriaPOS.Data`: entidades, `DbContext` y repositorios.
- `PizzeriaPOS.WinForms`: cliente de escritorio conectado a la API.
- `PizzeriaPOS.Tests`: pruebas unitarias de la capa de datos.

## Tecnologías

- .NET 8
- ASP.NET Core Minimal APIs
- Entity Framework Core
- SQL Server
- WinForms
- JWT Bearer Authentication
- BCrypt.Net-Next
- Swagger / Swashbuckle
- xUnit

## Estructura principal

```text
PizzeriaPOS/
├─ Database/
│  └─ Scripts/
├─ PizzeriaPOS.API/
├─ PizzeriaPOS.Data/
├─ PizzeriaPOS.Tests/
└─ PizzeriaPOS.WinForms/
```

## Módulos principales

### API

La API expone endpoints para:

- Autenticación: `register` y `login`
- Productos: CRUD y consulta de categorías
- Clientes: CRUD
- Direcciones: CRUD por cliente
- Pedidos: CRUD, manejo de detalles y estado

### Datos

La capa de datos incluye estas entidades:

- `Producto`
- `Cliente`
- `Direccion`
- `Pedido`
- `PedidoDetalle`
- `Usuario`

También incluye repositorios para abstraer el acceso a SQL Server.

### WinForms

La aplicación de escritorio permite:

- Iniciar sesión y registrarse
- Administrar productos
- Administrar clientes y direcciones
- Crear pedidos con sus detalles
- Consultar la información desde una interfaz visual

### Pruebas

El proyecto de pruebas valida el comportamiento de:

- Productos
- Clientes
- Pedidos

usando base de datos en memoria.

## Base de datos

Los scripts SQL están en `Database/Scripts` y permiten crear la base, tablas y datos iniciales.

## Requisitos

- Visual Studio 2022 o superior
- .NET 8 SDK
- SQL Server local

## Configuración

La cadena de conexión se encuentra en:

`PizzeriaPOS.API/appsettings.json`

## Ejecución

1. Ejecuta los scripts SQL en `Database/Scripts`.
2. Configura la cadena de conexión si tu SQL Server usa otra instancia.
3. Inicia `PizzeriaPOS.API`.
4. Inicia `PizzeriaPOS.WinForms`.
5. Regístrate o inicia sesión desde la app de escritorio.

## Pruebas

Para correr las pruebas:

```bash
dotnet test
```

## Notas

- La API usa JWT para proteger la mayoría de operaciones.
- Los productos usan baja lógica mediante `EstaActivo`.
- Los pedidos recalculan su total cuando cambian sus detalles.
- La UI de WinForms consume la API directamente.

## Autor

Proyecto de laboratorio desarrollado para evaluación técnica.
