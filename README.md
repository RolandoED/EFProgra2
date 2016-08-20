#Examen Final Programación 2

8/19/2016 6:30:18 PM 

---

<p align="center">
 <img src="https://github.com/fluidicon.png" width="60">
</p>

###Rolando Esp

	USE [master]
	GO

	GO
	USE [bd_colegio]
	GO
	/****** Object:  Table [dbo].[Profesor]    Script Date: 08/19/2016 11:52:10 ******/
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
	/****** Object:  Table [dbo].[Materia]    Script Date: 08/19/2016 11:52:10 ******/
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
	/****** Object:  Table [dbo].[Estudiante]    Script Date: 08/19/2016 11:52:10 ******/
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
