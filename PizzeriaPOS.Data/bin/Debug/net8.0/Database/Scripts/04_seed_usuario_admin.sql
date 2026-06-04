-- ============================================
-- Script 04: Usuario administrador
-- Proyecto: PizzeriaPOS
-- IMPORTANTE: Ejecutar después de registrar admin desde Swagger
--             o usar este script para reiniciar
-- ============================================

USE PizzeriaPOS;
GO

-- Eliminar usuario admin si existe (para recrear)
IF EXISTS (SELECT TOP 1 1 FROM [dbo].[Usuarios] WHERE [NombreUsuario] = 'admin')
BEGIN
    DELETE FROM [dbo].[Usuarios] WHERE [NombreUsuario] = 'admin';
    PRINT 'Usuario admin anterior eliminado.';
END
GO

-- NOTA: El password debe generarse desde la aplicación
-- Después de ejecutar este script, registra el usuario desde Swagger:
-- POST /api/auth/register
-- {
--   "nombreUsuario": "admin",
--   "password": "admin123",
--   "nombreCompleto": "Administrador del Sistema"
-- }

PRINT 'Script ejecutado. Ahora registra el usuario admin desde Swagger o la aplicación.';
GO
