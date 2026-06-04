-- ============================================
-- Script 05: Insertar 50 registros extra por tabla
-- Proyecto: PizzeriaPOS
-- Nota: No afecta la tabla Usuarios
-- ============================================

USE PizzeriaPOS;
GO

SET NOCOUNT ON;
GO

-- ============================================
-- 1. 50 Productos extra
-- ============================================
DECLARE @i INT = 1;
WHILE @i <= 50
BEGIN
    INSERT INTO dbo.Productos (Nombre, Descripcion, Precio, Categoria, EstaActivo, FechaCreacion)
    VALUES (
        CONCAT('Producto Extra ', @i),
        CONCAT('Descripcion generada para producto extra numero ', @i),
        CAST(50 + (@i * 3.5) AS DECIMAL(18,2)),
        CASE
            WHEN @i % 4 = 0 THEN 'Pizza'
            WHEN @i % 4 = 1 THEN 'Bebida'
            WHEN @i % 4 = 2 THEN 'Complemento'
            ELSE 'Postre'
        END,
        1,
        SYSUTCDATETIME()
    );

    SET @i += 1;
END
GO

-- ============================================
-- 2. 50 Clientes extra
-- ============================================
DECLARE @iClientes INT = 1;
WHILE @iClientes <= 50
BEGIN
    INSERT INTO dbo.Clientes (Nombre, Telefono, Email, EstaActivo, FechaCreacion)
    VALUES (
        CONCAT('Cliente Extra ', @iClientes),
        CONCAT('555-2', RIGHT(CONCAT('000', @iClientes), 3)),
        CONCAT('cliente.extra', @iClientes, '@email.com'),
        1,
        SYSUTCDATETIME()
    );

    SET @iClientes += 1;
END
GO

-- ============================================
-- 3. 50 Direcciones extra
--    Se asignan a clientes existentes
-- ============================================
DECLARE @iDirecciones INT = 1;
WHILE @iDirecciones <= 50
BEGIN
    INSERT INTO dbo.Direcciones
    (
        Calle, Numero, Colonia, Ciudad, CodigoPostal, Referencia,
        EsPrincipal, EstaActivo, FechaCreacion, ClienteId
    )
    VALUES
    (
        CONCAT('Calle Extra ', @iDirecciones),
        CAST(@iDirecciones AS NVARCHAR(20)),
        CONCAT('Colonia ', @iDirecciones),
        'Tegucigalpa',
        CONCAT('10', RIGHT(CONCAT('000', @iDirecciones), 3)),
        CONCAT('Referencia generada ', @iDirecciones),
        CASE WHEN @iDirecciones % 5 = 0 THEN 1 ELSE 0 END,
        1,
        SYSUTCDATETIME(),
        ((@iDirecciones - 1) % 53) + 1
    );

    SET @iDirecciones += 1;
END
GO

-- ============================================
-- 4. 50 Pedidos extra
--    Se asignan a clientes existentes
-- ============================================
DECLARE @iPedidos INT = 1;
WHILE @iPedidos <= 50
BEGIN
    INSERT INTO dbo.Pedidos
    (
        FechaPedido, Total, Estado, Notas, EstaActivo, FechaCreacion, ClienteId, DireccionId
    )
    VALUES
    (
        DATEADD(MINUTE, -@iPedidos, SYSUTCDATETIME()),
        0,
        CASE
            WHEN @iPedidos % 4 = 0 THEN 'Entregado'
            WHEN @iPedidos % 4 = 1 THEN 'Pendiente'
            WHEN @iPedidos % 4 = 2 THEN 'En preparación'
            ELSE 'Cancelado'
        END,
        CONCAT('Notas del pedido extra ', @iPedidos),
        1,
        SYSUTCDATETIME(),
        ((@iPedidos - 1) % 53) + 1,
        CASE WHEN @iPedidos % 2 = 0 THEN ((@iPedidos - 1) % 50) + 1 ELSE NULL END
    );

    SET @iPedidos += 1;
END
GO

-- ============================================
-- 5. 50 PedidoDetalles extra
--    Un detalle por pedido creado arriba
-- ============================================
DECLARE @iDetalles INT = 1;
DECLARE @pedidoId INT;
DECLARE @productoId INT;
DECLARE @cantidad INT;
DECLARE @precio DECIMAL(18,2);

WHILE @iDetalles <= 50
BEGIN
    SET @pedidoId = (SELECT MAX(Id) - (50 - @iDetalles) FROM dbo.Pedidos);
    SET @productoId = ((@iDetalles - 1) % 53) + 1;
    SET @cantidad = CASE WHEN @iDetalles % 3 = 0 THEN 3 WHEN @iDetalles % 3 = 1 THEN 1 ELSE 2 END;
    SET @precio = (SELECT Precio FROM dbo.Productos WHERE Id = @productoId);

    INSERT INTO dbo.PedidoDetalles
    (
        Cantidad, PrecioUnitario, Subtotal, Notas, PedidoId, ProductoId
    )
    VALUES
    (
        @cantidad,
        @precio,
        @precio * @cantidad,
        CONCAT('Detalle extra ', @iDetalles),
        @pedidoId,
        @productoId
    );

    UPDATE dbo.Pedidos
    SET Total = (
        SELECT ISNULL(SUM(Subtotal), 0)
        FROM dbo.PedidoDetalles
        WHERE PedidoId = @pedidoId
    )
    WHERE Id = @pedidoId;

    SET @iDetalles += 1;
END
GO

PRINT 'Se insertaron 50 registros extra por tabla principal, excepto Usuarios.';
GO
