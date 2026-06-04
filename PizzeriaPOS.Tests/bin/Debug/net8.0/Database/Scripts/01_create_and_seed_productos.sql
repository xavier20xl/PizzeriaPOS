IF DB_ID(N'PizzeriaPOS') IS NULL
BEGIN
    CREATE DATABASE PizzeriaPOS;
END
GO

USE PizzeriaPOS;
GO

IF OBJECT_ID(N'dbo.Productos', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Productos
    (
        Id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Productos PRIMARY KEY,
        Nombre NVARCHAR(150) NOT NULL,
        Descripcion NVARCHAR(500) NULL,
        Precio DECIMAL(18,2) NOT NULL,
        Categoria NVARCHAR(100) NULL,
        EstaActivo BIT NOT NULL CONSTRAINT DF_Productos_EstaActivo DEFAULT (1),
        FechaCreacion DATETIME2 NOT NULL CONSTRAINT DF_Productos_FechaCreacion DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT CK_Productos_Precio_Positive CHECK (Precio >= 0)
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Productos)
BEGIN
    INSERT INTO dbo.Productos (Nombre, Descripcion, Precio, Categoria)
    VALUES
        (N'Pizza Pepperoni', N'Pizza mediana con pepperoni y queso mozzarella.', 249.00, N'Pizza'),
        (N'Pizza Hawaiana', N'Pizza mediana con jamon, pina y queso mozzarella.', 239.00, N'Pizza'),
        (N'Refresco 2L', N'Bebida gaseosa de dos litros.', 55.00, N'Bebida');
END
GO
