-- ============================================
-- Script 05: Insertar 50 productos reales
-- Proyecto: PizzeriaPOS
-- Nota: No afecta la tabla Usuarios
-- ============================================

USE PizzeriaPOS;
GO

SET NOCOUNT ON;
GO

IF EXISTS (SELECT 1 FROM dbo.Productos WHERE Nombre IN
(
    'Pizza Pepperoni', 'Pizza Hawaiana', 'Pizza Mexicana', 'Pizza Cuatro Quesos'
))
BEGIN
    PRINT 'Ya existen registros base en Productos. El script se ejecutara igual, evitando duplicados por nombre.';
END
GO

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
    ('Alitas BBQ', 'Alitas de pollo bañadas en salsa BBQ.', 129.00, 'Complemento', 1, SYSUTCDATETIME()),
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

    ('Pizza Mini Pepperoni', 'Pizza personal de pepperoni.', 129.00, 'Pizza', 1, SYSUTCDATETIME()),
    ('Pizza Mini Hawaiana', 'Pizza personal de hawaiana.', 129.00, 'Pizza', 1, SYSUTCDATETIME()),
    ('Pizza Suprema Personal', 'Pizza personal con ingredientes surtidos.', 149.00, 'Pizza', 1, SYSUTCDATETIME()),
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
GO

PRINT 'Se insertaron productos reales sin duplicar nombres existentes.';
GO
