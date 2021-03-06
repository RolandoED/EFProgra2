USE [master]
GO
/****** Object:  Database [bd_colegio]    Script Date: 08/19/2016 19:45:50 ******/
CREATE DATABASE [bd_colegio] ON  PRIMARY 
( NAME = N'bd_colegio', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\bd_colegio.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'bd_colegio_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\bd_colegio_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [bd_colegio] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bd_colegio].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bd_colegio] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [bd_colegio] SET ANSI_NULLS OFF
GO
ALTER DATABASE [bd_colegio] SET ANSI_PADDING OFF
GO
ALTER DATABASE [bd_colegio] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [bd_colegio] SET ARITHABORT OFF
GO
ALTER DATABASE [bd_colegio] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [bd_colegio] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [bd_colegio] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [bd_colegio] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [bd_colegio] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [bd_colegio] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [bd_colegio] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [bd_colegio] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [bd_colegio] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [bd_colegio] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [bd_colegio] SET  DISABLE_BROKER
GO
ALTER DATABASE [bd_colegio] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [bd_colegio] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [bd_colegio] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [bd_colegio] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [bd_colegio] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [bd_colegio] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [bd_colegio] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [bd_colegio] SET  READ_WRITE
GO
ALTER DATABASE [bd_colegio] SET RECOVERY SIMPLE
GO
ALTER DATABASE [bd_colegio] SET  MULTI_USER
GO
ALTER DATABASE [bd_colegio] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [bd_colegio] SET DB_CHAINING OFF
GO
USE [bd_colegio]
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 08/19/2016 19:45:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor](
	[id_profesor] [bigint] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[apellido] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Profesor] PRIMARY KEY CLUSTERED 
(
	[id_profesor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materia]    Script Date: 08/19/2016 19:45:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Materia](
	[id_materia] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[id_profesor] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Estudiante]    Script Date: 08/19/2016 19:45:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estudiante](
	[id_estudiante] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NULL,
	[direccion] [varchar](50) NULL,
	[edad] [int] NULL,
	[id_materia] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
