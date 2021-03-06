/*USE [DBAutoLavado]
GO
/****** Object:  StoredProcedure [dbo].[sp_Usuario]    Script Date: 11/03/2018 06:09:35 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[sp_Usuario]
(
	@i_usuario nvarchar(100),
	@i_password nvarchar(max),
	@i_cedula nvarchar(16) = '',
	@i_Pusuario nvarchar(100),
	@i_venta bit,
	@i_mantenimiento bit,
	@i_lavado bit,
	@i_compra bit,
	@i_empleado bit,
	@i_Tusuario bit,
	@i_producto bit,
	@i_proveedor bit,
	@i_operacion char(1)
)
as
if @i_operacion = 'I'
begin
	insert into DBAutoLavado..usuario([usuario],Password,[cedula])
	values(@i_usuario,@i_password,@i_cedula)

	insert into DBAutoLavado..permiso(usuario,venta,mantenimiento,
	lavado,compra,empleado,Tusuario,producto,proveedor) values
	(@i_Pusuario,@i_venta,@i_mantenimiento,@i_lavado,
	@i_compra,@i_empleado,@i_Tusuario,@i_producto,@i_proveedor)
end

if @i_operacion = 'U'
begin
	update DBAutoLavado..usuario set Password = @i_password where usuario = @i_usuario
	update DBAutoLavado..permiso set venta = @i_venta, mantenimiento = @i_mantenimiento,
	lavado = @i_lavado, compra = @i_compra, empleado = @i_empleado, Tusuario = @i_Tusuario,
	producto = @i_producto, proveedor = @i_proveedor where usuario = @i_Pusuario
end

if @i_operacion = 'S'
begin
	select empleado.nombres + ' ' + empleado.apellidos as 
	Empleado, permiso.usuario,
	permiso.venta, permiso.mantenimiento, permiso.lavado, 
	permiso.compra, permiso.empleado,
	permiso.Tusuario,permiso.producto,permiso.proveedor 
	from empleado inner join usuario on 
	empleado.cedula = usuario.cedula inner join 
	permiso on usuario.usuario = permiso.usuario 
end*/

alter proc sp_validarUsuario
(
	@usuario nvarchar(max),
	@password nvarchar(max)
)
as
begin
select empleado.nombres, Usuario.Password,
               permiso.usuario,permiso.venta, permiso.mantenimiento, permiso.lavado,
               permiso.compra, permiso.empleado,permiso.Tusuario,permiso.producto,permiso.proveedor
                from empleado inner join usuario on empleado.cedula = usuario.cedula inner join
               permiso on usuario.usuario = permiso.usuario where permiso.usuario = @usuario and usuario.Password = @password
end

exec sp_validarUsuario
@usuario = 'jocsel',
@password = 'jocsel'