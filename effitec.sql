USE [master]
GO
/****** Object:  Database [effitec]    Script Date: 14/09/2022 9:51:57:a. m. ******/
CREATE DATABASE [effitec]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'effitec', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\effitec.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'effitec_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\effitec_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [effitec] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [effitec].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [effitec] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [effitec] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [effitec] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [effitec] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [effitec] SET ARITHABORT OFF 
GO
ALTER DATABASE [effitec] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [effitec] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [effitec] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [effitec] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [effitec] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [effitec] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [effitec] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [effitec] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [effitec] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [effitec] SET  DISABLE_BROKER 
GO
ALTER DATABASE [effitec] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [effitec] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [effitec] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [effitec] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [effitec] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [effitec] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [effitec] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [effitec] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [effitec] SET  MULTI_USER 
GO
ALTER DATABASE [effitec] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [effitec] SET DB_CHAINING OFF 
GO
ALTER DATABASE [effitec] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [effitec] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [effitec] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [effitec] SET QUERY_STORE = OFF
GO
USE [effitec]
GO
/****** Object:  Table [dbo].[producto]    Script Date: 14/09/2022 9:51:57:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[precio] [numeric](18, 2) NULL,
	[estado] [int] NULL,
 CONSTRAINT [PK_producto] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[producto_detalle]    Script Date: 14/09/2022 9:51:57:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[producto_detalle](
	[iddet] [int] IDENTITY(1,1) NOT NULL,
	[id] [int] NULL,
	[cantidad] [int] NULL,
	[total] [numeric](18, 2) NULL,
	[fecharegistro] [datetime] NULL,
	[estado] [int] NULL,
 CONSTRAINT [PK_producto_detalle] PRIMARY KEY CLUSTERED 
(
	[iddet] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[producto] ON 

INSERT [dbo].[producto] ([id], [descripcion], [precio], [estado]) VALUES (1, N'Mesa', CAST(100.00 AS Numeric(18, 2)), 1)
INSERT [dbo].[producto] ([id], [descripcion], [precio], [estado]) VALUES (2, N'Laptop', CAST(1800.00 AS Numeric(18, 2)), 1)
INSERT [dbo].[producto] ([id], [descripcion], [precio], [estado]) VALUES (3, N'Celular', CAST(900.00 AS Numeric(18, 2)), 1)
INSERT [dbo].[producto] ([id], [descripcion], [precio], [estado]) VALUES (4, N'Silla', CAST(12.00 AS Numeric(18, 2)), 1)
INSERT [dbo].[producto] ([id], [descripcion], [precio], [estado]) VALUES (5, N'Espejo', CAST(5.00 AS Numeric(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[producto] OFF
GO
SET IDENTITY_INSERT [dbo].[producto_detalle] ON 

INSERT [dbo].[producto_detalle] ([iddet], [id], [cantidad], [total], [fecharegistro], [estado]) VALUES (1, 1, 10, CAST(1000.00 AS Numeric(18, 2)), CAST(N'2022-09-13T20:52:19.133' AS DateTime), 1)
INSERT [dbo].[producto_detalle] ([iddet], [id], [cantidad], [total], [fecharegistro], [estado]) VALUES (2, 1, 5, CAST(500.00 AS Numeric(18, 2)), CAST(N'2022-09-13T20:55:05.033' AS DateTime), 1)
INSERT [dbo].[producto_detalle] ([iddet], [id], [cantidad], [total], [fecharegistro], [estado]) VALUES (3, 2, 2, CAST(3600.00 AS Numeric(18, 2)), CAST(N'2022-09-13T20:55:16.333' AS DateTime), 1)
INSERT [dbo].[producto_detalle] ([iddet], [id], [cantidad], [total], [fecharegistro], [estado]) VALUES (4, 3, 4, CAST(3600.00 AS Numeric(18, 2)), CAST(N'2022-09-13T20:55:30.687' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[producto_detalle] OFF
GO
ALTER TABLE [dbo].[producto_detalle] ADD  CONSTRAINT [DF_producto_detalle_fecharegistro]  DEFAULT (getdate()) FOR [fecharegistro]
GO
ALTER TABLE [dbo].[producto_detalle]  WITH CHECK ADD  CONSTRAINT [FK_producto_detalle_producto] FOREIGN KEY([id])
REFERENCES [dbo].[producto] ([id])
GO
ALTER TABLE [dbo].[producto_detalle] CHECK CONSTRAINT [FK_producto_detalle_producto]
GO
/****** Object:  StoredProcedure [dbo].[ListarProductosPorId]    Script Date: 14/09/2022 9:51:57:a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListarProductosPorId] 
	@id int = 0
AS
BEGIN
	SET NOCOUNT ON;

	--SELECT * FROM producto;
	SELECT a.iddet,b.descripcion,b.precio,a.cantidad,a.total,a.fecharegistro,a.estado  
	FROM producto_detalle a 
	INNER JOIN producto b ON b.id=a.id 
	WHERE a.id= case @id when 0 then a.id else @id end;
END
GO
USE [master]
GO
ALTER DATABASE [effitec] SET  READ_WRITE 
GO
