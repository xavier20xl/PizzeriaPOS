-- ============================================
-- Script: Usuario administrador por defecto
-- Proyecto: PizzeriaPOS
-- Credenciales: admin / admin123
-- ============================================

USE PizzeriaPOS;
GO

-- Insertar usuario admin si no existe
IF NOT EXISTS (SELECT TOP 1 1 FROM [dbo].[Usuarios] WHERE [NombreUsuario] = 'admin')
BEGIN
    -- Hash BCrypt de 'admin123'
    INSERT INTO [dbo].[Usuarios] ([NombreUsuario], [PasswordHash], [NombreCompleto])
    VALUES ('admin', '\$2a\$11$NqCY2JqHCvYqPxO8QvZqEeX0zF2u5G9b3Z0ZyK8XHcL1sRmYjK0Wy', 'Administrador del Sistema');
    
    PRINT 'Usuario admin creado exitosamente.';
    PRINT 'Credenciales: admin / admin123';
END
ELSE
BEGIN
    PRINT 'El usuario admin ya existe.';
END
GO
