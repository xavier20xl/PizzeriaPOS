-- ============================================
-- Script 02: Crear todas las tablas del sistema
-- Proyecto: PizzeriaPOS
-- ============================================

USE PizzeriaPOS;
GO

-- ============================================
-- 1. Tabla de Productos
-- ============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Productos]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Productos](
        [Id] INT IDENTITY(1,1) NOT NULL,
        [Nombre] NVARCHAR(150) NOT NULL,
        [Descripcion] NVARCHAR(500) NULL,
        [Precio] DECIMAL(18,2) NOT NULL,
        [Categoria] NVARCHAR(100) NULL,
        [EstaActivo] BIT NOT NULL DEFAULT 1,
        [FechaCreacion] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
        CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED ([Id] ASC),
        CONSTRAINT [CK_Productos_Precio_Positive] CHECK ([Precio] >= 0)
    );
    PRINT 'Tabla Productos creada.';
END
GO

-- ============================================
-- 2. Tabla de Clientes
-- ============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clientes]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Clientes](
        [Id] INT IDENTITY(1,1) NOT NULL,
        [Nombre] NVARCHAR(200) NOT NULL,
        [Telefono] NVARCHAR(20) NULL,
        [Email] NVARCHAR(200) NULL,
        [EstaActivo] BIT NOT NULL DEFAULT 1,
        [FechaCreacion] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
        CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED ([Id] ASC)
    );
    PRINT 'Tabla Clientes creada.';
END
GO

-- ============================================
-- 3. Tabla de Direcciones
-- ============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Direcciones]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Direcciones](
        [Id] INT IDENTITY(1,1) NOT NULL,
        [Calle] NVARCHAR(200) NOT NULL,
        [Numero] NVARCHAR(20) NULL,
        [Colonia] NVARCHAR(200) NULL,
        [Ciudad] NVARCHAR(100) NULL,
        [CodigoPostal] NVARCHAR(10) NULL,
        [Referencia] NVARCHAR(500) NULL,
        [EsPrincipal] BIT NOT NULL DEFAULT 0,
        [EstaActivo] BIT NOT NULL DEFAULT 1,
        [FechaCreacion] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
        [ClienteId] INT NOT NULL,
        CONSTRAINT [PK_Direcciones] PRIMARY KEY CLUSTERED ([Id] ASC),
        CONSTRAINT [FK_Direcciones_Clientes] FOREIGN KEY ([ClienteId]) 
            REFERENCES [dbo].[Clientes] ([Id])
    );
    PRINT 'Tabla Direcciones creada.';
END
GO

-- ============================================
-- 4. Tabla de Pedidos
-- ============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Pedidos]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Pedidos](
        [Id] INT IDENTITY(1,1) NOT NULL,
        [FechaPedido] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
        [Total] DECIMAL(18,2) NOT NULL DEFAULT 0,
        [Estado] NVARCHAR(50) NULL DEFAULT 'Pendiente',
        [Notas] NVARCHAR(500) NULL,
        [EstaActivo] BIT NOT NULL DEFAULT 1,
        [FechaCreacion] DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
        [ClienteId] INT NOT NULL,
        [DireccionId] INT NULL,
        CONSTRAINT [PK_Pedidos] PRIMARY KEY CLUSTERED ([Id] ASC),
        CONSTRAINT [FK_Pedidos_Clientes] FOREIGN KEY ([ClienteId]) 
            REFERENCES [dbo].[Clientes] ([Id]),
        CONSTRAINT [FK_Pedidos_Direcciones] FOREIGN KEY ([DireccionId]) 
            REFERENCES [dbo].[Direcciones] ([Id])
    );
    PRINT 'Tabla Pedidos creada.';
END
GO

-- ============================================
-- 5. Tabla de PedidoDetalles
-- ============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PedidoDetalles]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[PedidoDetalles](
        [Id] INT IDENTITY(1,1) NOT NULL,
        [Cantidad] INT NOT NULL DEFAULT 1,
        [PrecioUnitario] DECIMAL(18,2) NOT NULL,
        [Subtotal] DECIMAL(18,2) NOT NULL,
        [Notas] NVARCHAR(300) NULL,
        [PedidoId] INT NOT NULL,
        [ProductoId] INT NOT NULL,
        CONSTRAINT [PK_PedidoDetalles] PRIMARY KEY CLUSTERED ([Id] ASC),
        CONSTRAINT [FK_PedidoDetalles_Pedidos] FOREIGN KEY ([PedidoId]) 
            REFERENCES [dbo].[Pedidos] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_PedidoDetalles_Productos] FOREIGN KEY ([ProductoId]) 
            REFERENCES [dbo].[Productos] ([Id]),
        CONSTRAINT [CK_PedidoDetalles_Cantidad_Positive] CHECK ([Cantidad] > 0)
    );
    PRINT 'Tabla PedidoDetalles creada.';
END
GO

-- ============================================
-- 6. Datos iniciales (Seed)
-- ============================================
IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[Productos])
BEGIN
    INSERT INTO [dbo].[Productos] ([Nombre], [Descripcion], [Precio], [Categoria])
    VALUES 
        ('Pizza Pepperoni', 'Pizza mediana con pepperoni y queso mozzarella.', 249.00, 'Pizza'),
        ('Pizza Hawaiana', 'Pizza mediana con jamon, pina y queso mozzarella.', 239.00, 'Pizza'),
        ('Refresco 2L Coca-Cola', 'Refresco Coca-Cola de dos litros.', 65.00, 'Bebida');
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[Clientes])
BEGIN
    INSERT INTO [dbo].[Clientes] ([Nombre], [Telefono], [Email])
    VALUES 
        ('Juan Perez', '555-1001', 'juan.perez@correo.hn'),
        ('Maria Garcia', '555-1002', 'maria.garcia@correo.hn'),
        ('Carlos Lopez', '555-1003', 'carlos.lopez@correo.hn');
END
GO

IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[Direcciones])
BEGIN
    INSERT INTO [dbo].[Direcciones] ([Calle], [Numero], [Colonia], [Ciudad], [CodigoPostal], [Referencia], [EsPrincipal], [ClienteId])
    VALUES 
        ('Avenida Juan Pablo II', '123', 'Centro', 'Tegucigalpa', '11101', 'Frente al parque central', 1, 1),
        ('Boulevard Suyapa', '456', 'Lomas del Guijarro', 'Tegucigalpa', '11102', 'Casa color crema', 0, 1),
        ('Colonia Kennedy', '789', 'Kennedy', 'Tegucigalpa', '11103', 'Cerca de la escuela', 1, 2);
END
GO

PRINT 'Base de datos configurada correctamente.';
GO
