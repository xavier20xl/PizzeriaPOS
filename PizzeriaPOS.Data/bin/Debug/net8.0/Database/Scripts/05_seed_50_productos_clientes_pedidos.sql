-- ============================================
-- Script 05: Productos, 50 clientes reales y pedidos reales
-- Proyecto: PizzeriaPOS
-- Nota: No afecta la tabla Usuarios
-- ============================================

USE PizzeriaPOS;
SET NOCOUNT ON;

-- ============================================
-- 1. Productos reales
-- ============================================
INSERT INTO dbo.Productos (Nombre, Descripcion, Precio, Categoria, EstaActivo, FechaCreacion)
SELECT *
FROM (VALUES
    ('Pizza Pepperoni', 'Pizza mediana con pepperoni y queso mozzarella.', 249.00, 'Pizza', 1, SYSUTCDATETIME()),
    ('Pizza Hawaiana', 'Pizza mediana con jamon, pina y queso mozzarella.', 239.00, 'Pizza', 1, SYSUTCDATETIME()),
    ('Pizza Mexicana', 'Pizza con carne molida, jalapenos, cebolla y queso.', 259.00, 'Pizza', 1, SYSUTCDATETIME()),
    ('Pizza Cuatro Quesos', 'Combinacion de mozzarella, cheddar, parmesano y gouda.', 269.00, 'Pizza', 1, SYSUTCDATETIME()),
    ('Pizza Suprema', 'Pizza con pepperoni, champinones, jamon, pimiento y cebolla.', 279.00, 'Pizza', 1, SYSUTCDATETIME()),
    ('Pizza Vegetariana', 'Pizza con vegetales frescos y queso mozzarella.', 249.00, 'Pizza', 1, SYSUTCDATETIME()),
    ('Pizza BBQ Pollo', 'Pizza con pollo, salsa BBQ y cebolla morada.', 279.00, 'Pizza', 1, SYSUTCDATETIME()),
    ('Pizza Italiana', 'Pizza con salami, aceitunas negras y albahaca.', 269.00, 'Pizza', 1, SYSUTCDATETIME()),
    ('Pizza Carnes Frias', 'Pizza con jamon, pepperoni, salami y chorizo.', 289.00, 'Pizza', 1, SYSUTCDATETIME()),
    ('Pizza Familiar Pepperoni', 'Pizza familiar de pepperoni para compartir.', 399.00, 'Pizza', 1, SYSUTCDATETIME()),
    ('Refresco 2L Coca-Cola', 'Refresco Coca-Cola de 2 litros.', 65.00, 'Bebida', 1, SYSUTCDATETIME()),
    ('Refresco 2L Pepsi', 'Refresco Pepsi de 2 litros.', 60.00, 'Bebida', 1, SYSUTCDATETIME()),
    ('Agua Natural', 'Botella de agua natural.', 25.00, 'Bebida', 1, SYSUTCDATETIME()),
    ('Agua Mineral', 'Agua mineral con gas.', 30.00, 'Bebida', 1, SYSUTCDATETIME()),
    ('Te Helado', 'Te helado frio en vaso grande.', 35.00, 'Bebida', 1, SYSUTCDATETIME()),
    ('Limonada', 'Limonada natural preparada al momento.', 40.00, 'Bebida', 1, SYSUTCDATETIME()),
    ('Jugo de Naranja', 'Jugo de naranja natural.', 45.00, 'Bebida', 1, SYSUTCDATETIME()),
    ('Cafe Americano', 'Cafe americano caliente.', 30.00, 'Bebida', 1, SYSUTCDATETIME()),
    ('Milkshake de Vainilla', 'Milkshake cremoso de vainilla.', 55.00, 'Bebida', 1, SYSUTCDATETIME()),
    ('Malteada de Chocolate', 'Malteada espesa de chocolate.', 55.00, 'Bebida', 1, SYSUTCDATETIME()),
    ('Pan de Ajo', 'Pan horneado con mantequilla y ajo.', 55.00, 'Complemento', 1, SYSUTCDATETIME()),
    ('Pan de Ajo con Queso', 'Pan de ajo gratinado con queso.', 69.00, 'Complemento', 1, SYSUTCDATETIME()),
    ('Alitas BBQ', 'Alitas de pollo banadas en salsa BBQ.', 129.00, 'Complemento', 1, SYSUTCDATETIME()),
    ('Alitas Buffalo', 'Alitas de pollo estilo buffalo picante.', 129.00, 'Complemento', 1, SYSUTCDATETIME()),
    ('Boneless BBQ', 'Bocaditos de pollo empanizados con salsa BBQ.', 119.00, 'Complemento', 1, SYSUTCDATETIME()),
    ('Boneless Buffalo', 'Bocaditos de pollo empanizados con salsa buffalo.', 119.00, 'Complemento', 1, SYSUTCDATETIME()),
    ('Palitos de Queso', 'Palitos de queso empanizados.', 99.00, 'Complemento', 1, SYSUTCDATETIME()),
    ('Papas Fritas', 'Papas fritas crujientes.', 79.00, 'Complemento', 1, SYSUTCDATETIME()),
    ('Aros de Cebolla', 'Aros de cebolla empanizados.', 89.00, 'Complemento', 1, SYSUTCDATETIME()),
    ('Nachos con Queso', 'Totopos con queso fundido.', 95.00, 'Complemento', 1, SYSUTCDATETIME()),
    ('Brownie con Helado', 'Brownie caliente con helado de vainilla.', 75.00, 'Postre', 1, SYSUTCDATETIME()),
    ('Pastel de Chocolate', 'Porcion de pastel de chocolate.', 70.00, 'Postre', 1, SYSUTCDATETIME()),
    ('Churros con Cajeta', 'Churros espolvoreados con canela y cajeta.', 65.00, 'Postre', 1, SYSUTCDATETIME()),
    ('Helado de Vainilla', 'Bola doble de helado de vainilla.', 60.00, 'Postre', 1, SYSUTCDATETIME()),
    ('Helado de Chocolate', 'Bola doble de helado de chocolate.', 60.00, 'Postre', 1, SYSUTCDATETIME()),
    ('Pay de Queso', 'Rebanada de pay de queso cremoso.', 68.00, 'Postre', 1, SYSUTCDATETIME()),
    ('Crepa de Nutella', 'Crepa rellena de Nutella y fruta.', 80.00, 'Postre', 1, SYSUTCDATETIME()),
    ('Flan Napolitano', 'Flan casero estilo napolitano.', 55.00, 'Postre', 1, SYSUTCDATETIME()),
    ('Galleta con Chispas', 'Galleta grande con chispas de chocolate.', 35.00, 'Postre', 1, SYSUTCDATETIME()),
    ('Tiramisu', 'Postre clasico de cafe y cacao.', 85.00, 'Postre', 1, SYSUTCDATETIME()),
    ('Combo Familiar 1', 'Pizza familiar + refresco 2L + pan de ajo.', 499.00, 'Promocion', 1, SYSUTCDATETIME()),
    ('Combo Familiar 2', '2 pizzas medianas + 2 refrescos.', 549.00, 'Promocion', 1, SYSUTCDATETIME()),
    ('Combo Pareja', '2 pizzas personales + 2 bebidas.', 259.00, 'Promocion', 1, SYSUTCDATETIME()),
    ('Combo Infantil', 'Pizza personal + jugo + postre pequeno.', 189.00, 'Promocion', 1, SYSUTCDATETIME()),
    ('Extra Queso', 'Porcion extra de queso mozzarella.', 25.00, 'Extra', 1, SYSUTCDATETIME()),
    ('Extra Pepperoni', 'Porcion extra de pepperoni.', 30.00, 'Extra', 1, SYSUTCDATETIME()),
    ('Extra Champinones', 'Porcion extra de champinones.', 20.00, 'Extra', 1, SYSUTCDATETIME()),
    ('Extra Jamon', 'Porcion extra de jamon.', 25.00, 'Extra', 1, SYSUTCDATETIME())
) AS Datos (Nombre, Descripcion, Precio, Categoria, EstaActivo, FechaCreacion)
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.Productos p
    WHERE p.Nombre = Datos.Nombre
);

-- ============================================
-- 2. 50 clientes reales
-- ============================================
DECLARE @Clientes TABLE
(
    Orden INT IDENTITY(1,1),
    ClienteId INT NOT NULL
);

DECLARE @Nombres TABLE
(
    Orden INT IDENTITY(1,1),
    NombreCompleto NVARCHAR(200) NOT NULL,
    Telefono NVARCHAR(20) NOT NULL,
    Email NVARCHAR(200) NOT NULL
);

INSERT INTO @Nombres (NombreCompleto, Telefono, Email)
VALUES
('Carlos Alberto Mejia', '555-3001', 'carlos.mejia@email.com'),
('Mariana Sofia Lopez', '555-3002', 'mariana.lopez@email.com'),
('Jose David Hernandez', '555-3003', 'jose.hernandez@email.com'),
('Andrea Paola Castillo', '555-3004', 'andrea.castillo@email.com'),
('Luis Fernando Rivera', '555-3005', 'luis.rivera@email.com'),
('Karla Patricia Flores', '555-3006', 'karla.flores@email.com'),
('Mario Alejandro Santos', '555-3007', 'mario.santos@email.com'),
('Diana Carolina Pineda', '555-3008', 'diana.pineda@email.com'),
('Oscar Eduardo Cabrera', '555-3009', 'oscar.cabrera@email.com'),
('Natalia Gabriela Morales', '555-3010', 'natalia.morales@email.com'),
('Juan Manuel Diaz', '555-3011', 'juan.diaz@email.com'),
('Sofia Valeria Moreno', '555-3012', 'sofia.moreno@email.com'),
('Daniel Esteban Aguilar', '555-3013', 'daniel.aguilar@email.com'),
('Paola Andrea Vega', '555-3014', 'paola.vega@email.com'),
('Ricardo Javier Romero', '555-3015', 'ricardo.romero@email.com'),
('Fernanda Isabel Alvarez', '555-3016', 'fernanda.alvarez@email.com'),
('Hector Daniel Cruz', '555-3017', 'hector.cruz@email.com'),
('Gabriela Ruiz', '555-3018', 'gabriela.ruiz@email.com'),
('Erick Josue Mendoza', '555-3019', 'erick.mendoza@email.com'),
('Valeria Jimenez', '555-3020', 'valeria.jimenez@email.com'),
('Miguel Angel Ortiz', '555-3021', 'miguel.ortiz@email.com'),
('Camila Torres', '555-3022', 'camila.torres@email.com'),
('Jorge Luis Navarro', '555-3023', 'jorge.navarro@email.com'),
('Daniela Patricia Ramos', '555-3024', 'daniela.ramos@email.com'),
('Andres Felipe Reyes', '555-3025', 'andres.reyes@email.com'),
('Adriana Lizeth Flores', '555-3026', 'adriana.flores@email.com'),
('Fernando Castro', '555-3027', 'fernando.castro@email.com'),
('Paola Milena Gutierrez', '555-3028', 'paola.gutierrez@email.com'),
('Sergio Mauricio Ochoa', '555-3029', 'sergio.ochoa@email.com'),
('Claudia Andrea Serrano', '555-3030', 'claudia.serrano@email.com'),
('Roberto Carlos Lara', '555-3031', 'roberto.lara@email.com'),
('Marta Lucia Ponce', '555-3032', 'marta.ponce@email.com'),
('Kevin Estuardo Chacon', '555-3033', 'kevin.chacon@email.com'),
('Lorena Elizabeth Paz', '555-3034', 'lorena.paz@email.com'),
('Alberto Moncada', '555-3035', 'alberto.moncada@email.com'),
('Julissa Romero', '555-3036', 'julissa.romero@email.com'),
('Francisco Javier Herrera', '555-3037', 'francisco.herrera@email.com'),
('Silvia Patricia Ramos', '555-3038', 'silvia.ramos@email.com'),
('Edwin Josue Palma', '555-3039', 'edwin.palma@email.com'),
('Nadia Elena Flores', '555-3040', 'nadia.flores@email.com'),
('Ramiro Alberto Caceres', '555-3041', 'ramiro.caceres@email.com'),
('Melissa Andrea Aguilar', '555-3042', 'melissa.aguilar@email.com'),
('Diego Armando Juarez', '555-3043', 'diego.juarez@email.com'),
('Cristina Valeria Mendoza', '555-3044', 'cristina.mendoza@email.com'),
('Henry Alexander Fuentes', '555-3045', 'henry.fuentes@email.com'),
('Alicia Beatriz Molina', '555-3046', 'alicia.molina@email.com'),
('Brayan Esteban Rojas', '555-3047', 'brayan.rojas@email.com'),
('Patricia Elena Hernandez', '555-3048', 'patricia.hernandez@email.com'),
('Victor Manuel Solis', '555-3049', 'victor.solis@email.com'),
('Rosa Maria Castillo', '555-3050', 'rosa.castillo@email.com');

DECLARE @i INT = 1;
WHILE @i <= 50
BEGIN
    DECLARE @nombre NVARCHAR(200) = (SELECT NombreCompleto FROM @Nombres WHERE Orden = @i);
    DECLARE @telefono NVARCHAR(20) = (SELECT Telefono FROM @Nombres WHERE Orden = @i);
    DECLARE @correo NVARCHAR(200) = (SELECT Email FROM @Nombres WHERE Orden = @i);

    IF NOT EXISTS (SELECT 1 FROM dbo.Clientes WHERE Nombre = @nombre)
    BEGIN
        INSERT INTO dbo.Clientes (Nombre, Telefono, Email, EstaActivo, FechaCreacion)
        VALUES (@nombre, @telefono, @correo, 1, SYSUTCDATETIME());

        INSERT INTO @Clientes (ClienteId)
        VALUES (SCOPE_IDENTITY());
    END
    ELSE
    BEGIN
        INSERT INTO @Clientes (ClienteId)
        SELECT TOP 1 Id
        FROM dbo.Clientes
        WHERE Nombre = @nombre;
    END

    SET @i += 1;
END

-- ============================================
-- 3. Direcciones reales/plausibles
-- ============================================
DECLARE @Direcciones TABLE
(
    Orden INT IDENTITY(1,1),
    Calle NVARCHAR(200) NOT NULL,
    Numero NVARCHAR(20) NOT NULL,
    Colonia NVARCHAR(200) NOT NULL,
    Ciudad NVARCHAR(100) NOT NULL,
    CodigoPostal NVARCHAR(10) NOT NULL,
    Referencia NVARCHAR(500) NOT NULL
);

INSERT INTO @Direcciones (Calle, Numero, Colonia, Ciudad, CodigoPostal, Referencia)
VALUES
('Boulevard Suyapa', '1204', 'Las Minitas', 'Tegucigalpa', '11101', 'Casa color crema junto a la farmacia'),
('Colonia Lomas del Guijarro', '45', 'Lomas', 'Tegucigalpa', '11102', 'Porton negro, segunda casa'),
('Avenida La Paz', '88', 'Centro', 'Tegucigalpa', '11103', 'Edificio frente al parque'),
('Colonia Kennedy', '210', 'Kennedy', 'Tegucigalpa', '11104', 'Casa de esquina con rejas blancas'),
('Boulevard Morazan', '301', 'Centro', 'Tegucigalpa', '11105', 'Local comercial en planta baja'),
('Colonia Miraflores', '14', 'Miraflores', 'Tegucigalpa', '11106', 'Casa azul con porton blanco'),
('Residencial Las Uvas', '9', 'Las Uvas', 'Tegucigalpa', '11107', 'Apartamento 3B'),
('Colonia Humuya', '17', 'Humuya', 'Tegucigalpa', '11108', 'Casa amarilla con jardin'),
('Barrio La Granja', '63', 'La Granja', 'Tegucigalpa', '11109', 'Cerca de la escuela'),
('Colonia El Trapiche', '27', 'El Trapiche', 'Tegucigalpa', '11110', 'Casa con verja verde'),
('Residencial El Dorado', '104', 'El Dorado', 'Tegucigalpa', '11111', 'Casa con garage al frente'),
('Colonia San Miguel', '56', 'San Miguel', 'Tegucigalpa', '11112', 'Porton cafe, al lado del parque'),
('Colonia Las Acacias', '41', 'Las Acacias', 'Tegucigalpa', '11113', 'Tercer porton blanco'),
('Residencial Santa Monica', '7', 'Santa Monica', 'Tegucigalpa', '11114', 'Apartamento 1A'),
('Colonia El Pedregal', '122', 'El Pedregal', 'Tegucigalpa', '11115', 'Casa de dos pisos'),
('Colonia Loma Linda', '18', 'Loma Linda', 'Tegucigalpa', '11116', 'Frente a la pulperia'),
('Colonia Cerro Grande', '90', 'Cerro Grande', 'Tegucigalpa', '11117', 'Casa con techo rojo'),
('Residencial Florida', '33', 'Florida', 'Tegucigalpa', '11118', 'Apartamento 2C'),
('Barrio Abajo', '11', 'Barrio Abajo', 'Tegucigalpa', '11119', 'Cerca de la cancha'),
('Colonia Alameda', '215', 'Alameda', 'Tegucigalpa', '11120', 'Casa blanca con arboles al frente');

DECLARE @j INT = 1;
WHILE @j <= 50
BEGIN
    DECLARE @clienteId INT = (SELECT ClienteId FROM @Clientes WHERE Orden = @j);
    DECLARE @dirOrden INT = ((@j - 1) % 20) + 1;

    DECLARE @calle NVARCHAR(200) = (SELECT Calle FROM @Direcciones WHERE Orden = @dirOrden);
    DECLARE @numero NVARCHAR(20) = (SELECT Numero FROM @Direcciones WHERE Orden = @dirOrden);
    DECLARE @colonia NVARCHAR(200) = (SELECT Colonia FROM @Direcciones WHERE Orden = @dirOrden);
    DECLARE @ciudad NVARCHAR(100) = (SELECT Ciudad FROM @Direcciones WHERE Orden = @dirOrden);
    DECLARE @cp NVARCHAR(10) = (SELECT CodigoPostal FROM @Direcciones WHERE Orden = @dirOrden);
    DECLARE @ref NVARCHAR(500) = (SELECT Referencia FROM @Direcciones WHERE Orden = @dirOrden);

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.Direcciones
        WHERE ClienteId = @clienteId
          AND Calle = @calle
          AND Numero = @numero
    )
    BEGIN
        INSERT INTO dbo.Direcciones
        (Calle, Numero, Colonia, Ciudad, CodigoPostal, Referencia, EsPrincipal, EstaActivo, FechaCreacion, ClienteId)
        VALUES
        (@calle, @numero, @colonia, @ciudad, @cp, @ref, CASE WHEN @j % 3 = 0 THEN 1 ELSE 0 END, 1, SYSUTCDATETIME(), @clienteId);
    END

    SET @j += 1;
END

-- ============================================
-- 4. Pedidos reales
-- ============================================
DECLARE @k INT = 1;
WHILE @k <= 50
BEGIN
    DECLARE @clientePedidoId INT = (SELECT ClienteId FROM @Clientes WHERE Orden = @k);
    DECLARE @direccionPedidoId INT = (
        SELECT TOP 1 d.Id
        FROM dbo.Direcciones d
        WHERE d.ClienteId = @clientePedidoId
        ORDER BY d.Id DESC
    );

    DECLARE @productoBase INT = ((@k - 1) % 10) + 1;
    DECLARE @productoExtra INT = ((@k - 1) % 20) + 11;
    DECLARE @precioBase DECIMAL(18,2) = (SELECT Precio FROM dbo.Productos WHERE Id = @productoBase);
    DECLARE @precioExtra DECIMAL(18,2) = (SELECT Precio FROM dbo.Productos WHERE Id = @productoExtra);
    DECLARE @estado NVARCHAR(50) =
        CASE (@k % 4)
            WHEN 1 THEN 'Pendiente'
            WHEN 2 THEN 'En preparacion'
            WHEN 3 THEN 'Entregado'
            ELSE 'Cancelado'
        END;

    INSERT INTO dbo.Pedidos
    (FechaPedido, Total, Estado, Notas, EstaActivo, FechaCreacion, ClienteId, DireccionId)
    VALUES
    (
        DATEADD(MINUTE, -(@k * 12), SYSUTCDATETIME()),
        0,
        @estado,
        CASE
            WHEN @k % 5 = 0 THEN 'Llamar al llegar'
            WHEN @k % 5 = 1 THEN 'Sin cebolla'
            WHEN @k % 5 = 2 THEN 'A domicilio'
            WHEN @k % 5 = 3 THEN 'Pagar con efectivo'
            ELSE 'Tocar timbre dos veces'
        END,
        1,
        SYSUTCDATETIME(),
        @clientePedidoId,
        @direccionPedidoId
    );

    DECLARE @pedidoId INT = SCOPE_IDENTITY();

    IF @precioBase IS NOT NULL
    BEGIN
        INSERT INTO dbo.PedidoDetalles (Cantidad, PrecioUnitario, Subtotal, Notas, PedidoId, ProductoId)
        VALUES
        (
            CASE WHEN @k % 3 = 0 THEN 2 ELSE 1 END,
            @precioBase,
            @precioBase * CASE WHEN @k % 3 = 0 THEN 2 ELSE 1 END,
            'Producto principal del pedido',
            @pedidoId,
            @productoBase
        );
    END

    IF @precioExtra IS NOT NULL
    BEGIN
        INSERT INTO dbo.PedidoDetalles (Cantidad, PrecioUnitario, Subtotal, Notas, PedidoId, ProductoId)
        VALUES
        (
            CASE WHEN @k % 2 = 0 THEN 2 ELSE 1 END,
            @precioExtra,
            @precioExtra * CASE WHEN @k % 2 = 0 THEN 2 ELSE 1 END,
            'Complemento o bebida del pedido',
            @pedidoId,
            @productoExtra
        );
    END

    UPDATE dbo.Pedidos
    SET Total = (
        SELECT ISNULL(SUM(Subtotal), 0)
        FROM dbo.PedidoDetalles
        WHERE PedidoId = @pedidoId
    )
    WHERE Id = @pedidoId;

    SET @k += 1;
END

PRINT 'Se insertaron productos reales, 50 clientes reales y pedidos reales.';
