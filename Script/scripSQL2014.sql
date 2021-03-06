USE [master]
GO
/****** Object:  Database [DBAutoLavado]    Script Date: 11/03/2018 10:56:47 p.m. ******/
CREATE DATABASE [DBAutoLavado]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'__DBAutoLavado_fisico', FILENAME = N'D:\10mo Cuatrimestres\Ingenieria de software\DbAutoLavado\Script\DBAutoLavado.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 3072KB )
 LOG ON 
( NAME = N'DBAutoLavado_logica', FILENAME = N'D:\10mo Cuatrimestres\Ingenieria de software\DbAutoLavado\Script\DBAutoLavado.ldf' , SIZE = 5120KB , MAXSIZE = 2048GB , FILEGROWTH = 3072KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBAutoLavado].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBAutoLavado] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBAutoLavado] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBAutoLavado] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBAutoLavado] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBAutoLavado] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBAutoLavado] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBAutoLavado] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBAutoLavado] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBAutoLavado] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBAutoLavado] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBAutoLavado] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBAutoLavado] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBAutoLavado] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBAutoLavado] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBAutoLavado] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DBAutoLavado] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBAutoLavado] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBAutoLavado] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBAutoLavado] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBAutoLavado] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBAutoLavado] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBAutoLavado] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBAutoLavado] SET RECOVERY FULL 
GO
ALTER DATABASE [DBAutoLavado] SET  MULTI_USER 
GO
ALTER DATABASE [DBAutoLavado] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBAutoLavado] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBAutoLavado] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBAutoLavado] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBAutoLavado] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBAutoLavado', N'ON'
GO
USE [DBAutoLavado]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [DBAutoLavado]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 11/03/2018 10:56:50 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [nvarchar](120) NOT NULL,
	[apellido] [nvarchar](120) NOT NULL,
	[cedula] [nvarchar](16) NOT NULL,
	[correo] [nvarchar](80) NOT NULL,
	[celular] [int] NULL,
	[estado] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[compra]    Script Date: 11/03/2018 10:56:50 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compra](
	[fechaCompra] [datetime] NULL,
	[idCompra] [int] IDENTITY(1,1) NOT NULL,
	[idProveedor] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[empleado]    Script Date: 11/03/2018 10:56:50 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empleado](
	[fechaNac] [datetime] NOT NULL,
	[celular] [int] NULL,
	[direccion] [nvarchar](90) NOT NULL,
	[idEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[cedula] [nvarchar](16) NOT NULL,
	[apellidos] [nvarchar](120) NOT NULL,
	[nombres] [nvarchar](80) NOT NULL,
	[salario] [money] NOT NULL,
	[estado] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[lavado]    Script Date: 11/03/2018 10:56:50 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lavado](
	[idLavado] [int] IDENTITY(1,1) NOT NULL,
	[total] [money] NOT NULL,
	[fecha] [datetime] NULL,
	[placa] [nvarchar](10) NOT NULL,
	[idVehiculoLavado] [int] NULL,
	[cedulaEmpleado] [nvarchar](16) NULL,
PRIMARY KEY CLUSTERED 
(
	[idLavado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[mantenimiento]    Script Date: 11/03/2018 10:56:50 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mantenimiento](
	[idMantenimiento] [int] IDENTITY(1,1) NOT NULL,
	[total] [money] NOT NULL,
	[fecha] [datetime] NULL,
	[placa] [nvarchar](10) NOT NULL,
	[idVehiculoMantenimiento] [int] NULL,
	[cedulaEmpleado] [nvarchar](16) NULL,
PRIMARY KEY CLUSTERED 
(
	[idMantenimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[permiso]    Script Date: 11/03/2018 10:56:50 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[permiso](
	[usuario] [nvarchar](100) NULL,
	[venta] [bit] NULL,
	[mantenimiento] [bit] NULL,
	[lavado] [bit] NULL,
	[compra] [bit] NULL,
	[empleado] [bit] NULL,
	[Tusuario] [bit] NULL,
	[producto] [bit] NULL,
	[proveedor] [bit] NULL,
	[Password] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[productoCompra]    Script Date: 11/03/2018 10:56:50 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productoCompra](
	[cantidad] [int] NOT NULL,
	[precio] [money] NOT NULL,
	[idCompra] [int] NULL,
	[idProducto] [int] NULL,
	[total] [money] NOT NULL,
	[subTotal] [money] NOT NULL,
	[iva] [decimal](18, 0) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[productos]    Script Date: 11/03/2018 10:56:50 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productos](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[marca] [nvarchar](50) NULL,
	[nombre] [nvarchar](50) NULL,
	[existencia] [int] NULL,
	[precioUnidad] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[productoVenta]    Script Date: 11/03/2018 10:56:50 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[productoVenta](
	[cantidad] [int] NULL,
	[precio] [money] NULL,
	[idVenta] [int] NULL,
	[idProducto] [int] NULL,
	[precioUnidad] [money] NULL,
	[total] [money] NULL,
	[iva] [money] NULL,
	[subTotal] [money] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 11/03/2018 10:56:50 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proveedor](
	[apellidos] [nvarchar](120) NULL,
	[nombres] [nvarchar](80) NOT NULL,
	[direccion] [nvarchar](150) NOT NULL,
	[cedula] [nvarchar](16) NOT NULL,
	[idProveedor] [int] IDENTITY(1,1) NOT NULL,
	[telefono] [int] NULL,
	[correo] [nvarchar](80) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[servicioLavado]    Script Date: 11/03/2018 10:56:50 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[servicioLavado](
	[precio] [money] NULL,
	[idServicioLavado] [int] IDENTITY(1,1) NOT NULL,
	[servicioLavado] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idServicioLavado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[servicioMantenimiento]    Script Date: 11/03/2018 10:56:50 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[servicioMantenimiento](
	[precio] [money] NULL,
	[idServicioMantenimiento] [int] IDENTITY(1,1) NOT NULL,
	[servicioMantenimiento] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idServicioMantenimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tipoVehiculoLavado]    Script Date: 11/03/2018 10:56:50 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoVehiculoLavado](
	[idVehiculoLavado] [int] IDENTITY(1,1) NOT NULL,
	[vehiculoLavado] [nvarchar](50) NULL,
	[idServicioLavado] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idVehiculoLavado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tipoVehiculoMantenimiento]    Script Date: 11/03/2018 10:56:50 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipoVehiculoMantenimiento](
	[idVehiculoMantenimiento] [int] IDENTITY(1,1) NOT NULL,
	[vehiculoMantenimiento] [nvarchar](50) NULL,
	[idServicioMantenimiento] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idVehiculoMantenimiento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 11/03/2018 10:56:50 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[usuario] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[cedula] [nvarchar](16) NULL,
PRIMARY KEY CLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venta]    Script Date: 11/03/2018 10:56:50 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venta](
	[idVenta] [int] IDENTITY(1,1) NOT NULL,
	[fechaFac] [datetime] NULL,
	[cedulaCliente] [nvarchar](16) NULL,
	[cedulaEmpleado] [nvarchar](16) NULL,
PRIMARY KEY CLUSTERED 
(
	[idVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[compra]  WITH CHECK ADD FOREIGN KEY([idProveedor])
REFERENCES [dbo].[proveedor] ([idProveedor])
GO
ALTER TABLE [dbo].[lavado]  WITH CHECK ADD FOREIGN KEY([cedulaEmpleado])
REFERENCES [dbo].[empleado] ([cedula])
GO
ALTER TABLE [dbo].[lavado]  WITH CHECK ADD FOREIGN KEY([idVehiculoLavado])
REFERENCES [dbo].[tipoVehiculoLavado] ([idVehiculoLavado])
GO
ALTER TABLE [dbo].[mantenimiento]  WITH CHECK ADD FOREIGN KEY([cedulaEmpleado])
REFERENCES [dbo].[empleado] ([cedula])
GO
ALTER TABLE [dbo].[mantenimiento]  WITH CHECK ADD FOREIGN KEY([idVehiculoMantenimiento])
REFERENCES [dbo].[tipoVehiculoMantenimiento] ([idVehiculoMantenimiento])
GO
ALTER TABLE [dbo].[permiso]  WITH CHECK ADD FOREIGN KEY([usuario])
REFERENCES [dbo].[Usuario] ([usuario])
GO
ALTER TABLE [dbo].[productoCompra]  WITH CHECK ADD FOREIGN KEY([idCompra])
REFERENCES [dbo].[compra] ([idCompra])
GO
ALTER TABLE [dbo].[productoCompra]  WITH CHECK ADD FOREIGN KEY([idProducto])
REFERENCES [dbo].[productos] ([idProducto])
GO
ALTER TABLE [dbo].[productoVenta]  WITH CHECK ADD FOREIGN KEY([idProducto])
REFERENCES [dbo].[productos] ([idProducto])
GO
ALTER TABLE [dbo].[productoVenta]  WITH CHECK ADD FOREIGN KEY([idVenta])
REFERENCES [dbo].[venta] ([idVenta])
GO
ALTER TABLE [dbo].[tipoVehiculoLavado]  WITH CHECK ADD FOREIGN KEY([idServicioLavado])
REFERENCES [dbo].[servicioLavado] ([idServicioLavado])
GO
ALTER TABLE [dbo].[tipoVehiculoMantenimiento]  WITH CHECK ADD FOREIGN KEY([idServicioMantenimiento])
REFERENCES [dbo].[servicioMantenimiento] ([idServicioMantenimiento])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([cedula])
REFERENCES [dbo].[empleado] ([cedula])
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD FOREIGN KEY([cedulaCliente])
REFERENCES [dbo].[clientes] ([cedula])
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD FOREIGN KEY([cedulaEmpleado])
REFERENCES [dbo].[empleado] ([cedula])
GO
/****** Object:  StoredProcedure [dbo].[sp_Usuario]    Script Date: 11/03/2018 10:56:50 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_Usuario]
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
	select empleado.nombres + ' ' + empleado.apellidos as Empleado, permiso.usuario,
	permiso.venta, permiso.mantenimiento, permiso.lavado, permiso.compra, permiso.empleado,
	permiso.Tusuario,permiso.producto,permiso.proveedor from empleado inner join usuario on 
	empleado.cedula = usuario.cedula inner join permiso on usuario.usuario = permiso.usuario 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_validarUsuario]    Script Date: 11/03/2018 10:56:50 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_validarUsuario]
(
	@usuario nvarchar(max),
	@password nvarchar(max)
)
as
begin
/*declare @usuario nvarchar(max), @password nvarchar(max)
select @usuario = permiso.usuario from permiso
select @password = Usuario.Password from Usuario*/
select empleado.nombres, Usuario.Password,
               permiso.usuario,permiso.venta, permiso.mantenimiento, permiso.lavado,
               permiso.compra, permiso.empleado,permiso.Tusuario,permiso.producto,permiso.proveedor
                from empleado inner join usuario on empleado.cedula = usuario.cedula inner join
               permiso on usuario.usuario = permiso.usuario where permiso.usuario = @usuario and usuario.Password = @password
end

GO
USE [master]
GO
ALTER DATABASE [DBAutoLavado] SET  READ_WRITE 
GO
