-- ============================================
-- Script 01: Crear tabla Productos con datos iniciales
-- Proyecto: PizzeriaPOS
-- ============================================

-- Crear base de datos si no existe
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'PizzeriaPOS')
BEGIN
    CREATE DATABASE PizzeriaPOS;
END
GO

USE PizzeriaPOS;
GO

-- Crear tabla Productos
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
ELSE
BEGIN
    PRINT 'La tabla Productos ya existe.';
END
GO

-- Insertar datos iniciales
IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[Productos])
BEGIN
    INSERT INTO [dbo].[Productos] ([Nombre], [Descripcion], [Precio], [Categoria])
    VALUES 
        ('Pizza Pepperoni', 'Pizza mediana con pepperoni y queso mozzarella.', 249.00, 'Pizza'),
        ('Pizza Hawaiana', 'Pizza mediana con jamón, piña y queso mozzarella.', 239.00, 'Pizza'),
        ('Refresco 2L', 'Bebida gaseosa de dos litros.', 55.00, 'Bebida');
    PRINT 'Datos iniciales insertados.';
END
ELSE
BEGIN
    PRINT 'Ya existen datos en Productos.';
END
GO
