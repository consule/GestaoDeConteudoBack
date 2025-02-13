USE [master]
GO
/****** Object:  Database [ControleDeConteudo]    Script Date: 19/11/2020 16:21:42 ******/
CREATE DATABASE [ControleDeConteudo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ControleDeSalas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ControleDeSalas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ControleDeSalas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ControleDeSalas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ControleDeConteudo] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ControleDeConteudo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ControleDeConteudo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ControleDeConteudo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ControleDeConteudo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ControleDeConteudo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ControleDeConteudo] SET ARITHABORT OFF 
GO
ALTER DATABASE [ControleDeConteudo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ControleDeConteudo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ControleDeConteudo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ControleDeConteudo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ControleDeConteudo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ControleDeConteudo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ControleDeConteudo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ControleDeConteudo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ControleDeConteudo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ControleDeConteudo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ControleDeConteudo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ControleDeConteudo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ControleDeConteudo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ControleDeConteudo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ControleDeConteudo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ControleDeConteudo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ControleDeConteudo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ControleDeConteudo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ControleDeConteudo] SET  MULTI_USER 
GO
ALTER DATABASE [ControleDeConteudo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ControleDeConteudo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ControleDeConteudo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ControleDeConteudo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ControleDeConteudo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ControleDeConteudo] SET QUERY_STORE = OFF
GO
USE [ControleDeConteudo]
GO
/****** Object:  Table [dbo].[BannerDestaque]    Script Date: 19/11/2020 16:21:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BannerDestaque](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](150) NULL,
	[Chamada] [varchar](max) NULL,
	[Link] [varchar](max) NULL,
	[Imagem] [varchar](max) NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_BannerDestaque] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BannerPrincipal]    Script Date: 19/11/2020 16:21:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BannerPrincipal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PrimeiroTitulo] [varchar](150) NOT NULL,
	[SegundoTitulo] [varchar](150) NOT NULL,
	[Subtitulo] [varchar](150) NOT NULL,
	[Chamada] [varchar](max) NOT NULL,
	[Link] [varchar](max) NOT NULL,
	[Imagem] [varchar](max) NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_BannerPrincipal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 19/11/2020 16:21:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PostCategoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DuvidasFrequentes]    Script Date: 19/11/2020 16:21:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DuvidasFrequentes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pergunta] [varchar](255) NOT NULL,
	[Resposta] [varchar](max) NOT NULL,
 CONSTRAINT [PK_DuvidasFrequentes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExAlunos]    Script Date: 19/11/2020 16:21:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExAlunos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeAluno] [varchar](255) NOT NULL,
	[Ano] [varchar](10) NOT NULL,
	[Sala] [varchar](255) NULL,
	[AprovadoEm] [varchar](255) NULL,
	[Testemunho] [varchar](max) NULL,
	[Imagem] [varchar](max) NULL,
	[Ativo] [bit] NULL,
 CONSTRAINT [PK_ExAlunos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Noticias]    Script Date: 19/11/2020 16:21:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Noticias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoriaId] [int] NOT NULL,
	[LinkYoutube] [varchar](max) NULL,
	[Chamada] [varchar](max) NULL,
	[TextoPrincipal] [varchar](max) NULL,
	[Publicado] [datetime] NULL,
	[Ativo] [bit] NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PerguntasFrequentes]    Script Date: 19/11/2020 16:21:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PerguntasFrequentes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pergunta] [varchar](255) NOT NULL,
	[Resposta] [varchar](max) NOT NULL,
 CONSTRAINT [PK_PerguntasFrequentes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 19/11/2020 16:21:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeCompleto] [varchar](150) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BannerDestaque] ADD  CONSTRAINT [DF_BannerDestaque_Ativo]  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[BannerPrincipal] ADD  CONSTRAINT [DF_BannerPrincipal_Link]  DEFAULT ((1)) FOR [Link]
GO
ALTER TABLE [dbo].[BannerPrincipal] ADD  CONSTRAINT [DF_BannerPrincipal_Ativo]  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[ExAlunos] ADD  CONSTRAINT [DF_ExAlunos_Ativo]  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Noticias] ADD  CONSTRAINT [DF_Post_Ativo]  DEFAULT ((1)) FOR [Ativo]
GO
ALTER TABLE [dbo].[Noticias]  WITH CHECK ADD  CONSTRAINT [FK_Post_PostCategoria] FOREIGN KEY([CategoriaId])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Noticias] CHECK CONSTRAINT [FK_Post_PostCategoria]
GO
USE [master]
GO
ALTER DATABASE [ControleDeConteudo] SET  READ_WRITE 
GO
