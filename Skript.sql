USE [master]
GO
/****** Object:  Database [BD_DKuznetsov]    Script Date: 25.06.2023 22:48:56 ******/
CREATE DATABASE [BD_DKuznetsov]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD_DKuznetsov', FILENAME = N'E:\sql\MSSQL15.SQLEXPRESS\MSSQL\DATA\BD_DKuznetsov.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BD_DKuznetsov_log', FILENAME = N'E:\sql\MSSQL15.SQLEXPRESS\MSSQL\DATA\BD_DKuznetsov_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BD_DKuznetsov] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD_DKuznetsov].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BD_DKuznetsov] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BD_DKuznetsov] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BD_DKuznetsov] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BD_DKuznetsov] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BD_DKuznetsov] SET ARITHABORT OFF 
GO
ALTER DATABASE [BD_DKuznetsov] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BD_DKuznetsov] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BD_DKuznetsov] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BD_DKuznetsov] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BD_DKuznetsov] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BD_DKuznetsov] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BD_DKuznetsov] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BD_DKuznetsov] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BD_DKuznetsov] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BD_DKuznetsov] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BD_DKuznetsov] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BD_DKuznetsov] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BD_DKuznetsov] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BD_DKuznetsov] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BD_DKuznetsov] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BD_DKuznetsov] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BD_DKuznetsov] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BD_DKuznetsov] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BD_DKuznetsov] SET  MULTI_USER 
GO
ALTER DATABASE [BD_DKuznetsov] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BD_DKuznetsov] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BD_DKuznetsov] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BD_DKuznetsov] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BD_DKuznetsov] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BD_DKuznetsov] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BD_DKuznetsov] SET QUERY_STORE = OFF
GO
USE [BD_DKuznetsov]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 25.06.2023 22:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id_Role] [int] IDENTITY(1,1) NOT NULL,
	[Nazvanie] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id_Role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Strahovoi_agent]    Script Date: 25.06.2023 22:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Strahovoi_agent](
	[Id_agent] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [nvarchar](max) NOT NULL,
	[Telefon] [nvarchar](50) NOT NULL,
	[Adres] [nvarchar](max) NOT NULL,
	[Id_user] [int] NOT NULL,
 CONSTRAINT [PK_Strahovoi_agent] PRIMARY KEY CLUSTERED 
(
	[Id_agent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 25.06.2023 22:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id_User] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Id_Role] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vidi_strahovki]    Script Date: 25.06.2023 22:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vidi_strahovki](
	[Id_Strahovki] [int] IDENTITY(1,1) NOT NULL,
	[Nazvanie] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Money] [money] NOT NULL,
	[Date_deistvia] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Vidi_strahovki] PRIMARY KEY CLUSTERED 
(
	[Id_Strahovki] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zayavki]    Script Date: 25.06.2023 22:48:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zayavki](
	[Id_Zayavki] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [nvarchar](max) NOT NULL,
	[Telefon] [nvarchar](50) NOT NULL,
	[DR] [nvarchar](50) NOT NULL,
	[Adres] [nvarchar](max) NOT NULL,
	[Id_Strahovki] [int] NOT NULL,
	[Id_agent] [int] NOT NULL,
 CONSTRAINT [PK_Zayavki] PRIMARY KEY CLUSTERED 
(
	[Id_Zayavki] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id_Role], [Nazvanie]) VALUES (1, N'Агент')
INSERT [dbo].[Role] ([Id_Role], [Nazvanie]) VALUES (2, N'Клиент')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Strahovoi_agent] ON 

INSERT [dbo].[Strahovoi_agent] ([Id_agent], [FIO], [Telefon], [Adres], [Id_user]) VALUES (1, N'Иванов Иван Иванович', N'89149876545', N'пр.Победы', 1)
SET IDENTITY_INSERT [dbo].[Strahovoi_agent] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id_User], [Login], [Password], [Id_Role]) VALUES (1, N'Admin', N'admin', 1)
INSERT [dbo].[User] ([Id_User], [Login], [Password], [Id_Role]) VALUES (2, N'User', N'user', 2)
INSERT [dbo].[User] ([Id_User], [Login], [Password], [Id_Role]) VALUES (3, N'User1', N'user1', 2)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Vidi_strahovki] ON 

INSERT [dbo].[Vidi_strahovki] ([Id_Strahovki], [Nazvanie], [Description], [Money], [Date_deistvia]) VALUES (1, N'Медицинское', N'-', 10.0000, N'12 месяцев')
INSERT [dbo].[Vidi_strahovki] ([Id_Strahovki], [Nazvanie], [Description], [Money], [Date_deistvia]) VALUES (2, N'Юридическая', N'-', 23.0000, N'24 месяцев')
INSERT [dbo].[Vidi_strahovki] ([Id_Strahovki], [Nazvanie], [Description], [Money], [Date_deistvia]) VALUES (3, N'Страхование ответственности', N'в качестве объекта страхования выступает имущественный интерес', 10.0000, N'2 месяца')
SET IDENTITY_INSERT [dbo].[Vidi_strahovki] OFF
GO
SET IDENTITY_INSERT [dbo].[Zayavki] ON 

INSERT [dbo].[Zayavki] ([Id_Zayavki], [FIO], [Telefon], [DR], [Adres], [Id_Strahovki], [Id_agent]) VALUES (5, N'Сапрыгина Ирина Анатольевна', N'89142987876', N'20.01.1998', N'г.Хабаровск', 2, 1)
SET IDENTITY_INSERT [dbo].[Zayavki] OFF
GO
ALTER TABLE [dbo].[Strahovoi_agent]  WITH CHECK ADD  CONSTRAINT [FK_Strahovoi_agent_User] FOREIGN KEY([Id_user])
REFERENCES [dbo].[User] ([Id_User])
GO
ALTER TABLE [dbo].[Strahovoi_agent] CHECK CONSTRAINT [FK_Strahovoi_agent_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([Id_Role])
REFERENCES [dbo].[Role] ([Id_Role])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[Zayavki]  WITH CHECK ADD  CONSTRAINT [FK_Zayavki_Strahovoi_agent1] FOREIGN KEY([Id_agent])
REFERENCES [dbo].[Strahovoi_agent] ([Id_agent])
GO
ALTER TABLE [dbo].[Zayavki] CHECK CONSTRAINT [FK_Zayavki_Strahovoi_agent1]
GO
ALTER TABLE [dbo].[Zayavki]  WITH CHECK ADD  CONSTRAINT [FK_Zayavki_Vidi_strahovki1] FOREIGN KEY([Id_Strahovki])
REFERENCES [dbo].[Vidi_strahovki] ([Id_Strahovki])
GO
ALTER TABLE [dbo].[Zayavki] CHECK CONSTRAINT [FK_Zayavki_Vidi_strahovki1]
GO
USE [master]
GO
ALTER DATABASE [BD_DKuznetsov] SET  READ_WRITE 
GO
