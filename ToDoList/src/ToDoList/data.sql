﻿USE [master]
GO
/****** Object:  Database [ToDoList]    Script Date: 4/18/16 10:41:14 PM ******/
CREATE DATABASE [ToDoList]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ToDoList', FILENAME = N'C:\Users\MichaelSmith\ToDoList.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ToDoList_log', FILENAME = N'C:\Users\MichaelSmith\ToDoList_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ToDoList] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ToDoList].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ToDoList] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ToDoList] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ToDoList] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ToDoList] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ToDoList] SET ARITHABORT OFF 
GO
ALTER DATABASE [ToDoList] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ToDoList] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ToDoList] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ToDoList] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ToDoList] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ToDoList] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ToDoList] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ToDoList] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ToDoList] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ToDoList] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ToDoList] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ToDoList] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ToDoList] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ToDoList] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ToDoList] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ToDoList] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ToDoList] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ToDoList] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ToDoList] SET  MULTI_USER 
GO
ALTER DATABASE [ToDoList] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ToDoList] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ToDoList] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ToDoList] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ToDoList] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ToDoList]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 4/18/16 10:41:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Items]    Script Date: 4/18/16 10:41:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Items](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
	[Done] [bit] NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

GO
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (1, N'Home')
GO
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (2, N'Work')
GO
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (3, N'Personal')
GO
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (4, N'Excercising')
GO
INSERT [dbo].[Categories] ([CategoryId], [Name]) VALUES (6, N'Cleaning')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Items] ON 

GO
INSERT [dbo].[Items] ([ItemId], [Description], [Done], [CategoryId]) VALUES (1, N'Mop the floor', 1, 1)
GO
INSERT [dbo].[Items] ([ItemId], [Description], [Done], [CategoryId]) VALUES (2, N'Practice Recipes', 0, 1)
GO
INSERT [dbo].[Items] ([ItemId], [Description], [Done], [CategoryId]) VALUES (3, N'Learn .NET', 1, 2)
GO
INSERT [dbo].[Items] ([ItemId], [Description], [Done], [CategoryId]) VALUES (4, N'Make To Do List', 0, 2)
GO
INSERT [dbo].[Items] ([ItemId], [Description], [Done], [CategoryId]) VALUES (5, N'Write Novel', 1, 3)
GO
INSERT [dbo].[Items] ([ItemId], [Description], [Done], [CategoryId]) VALUES (6, N'Learn Salsa Dance', 0, 3)
GO
INSERT [dbo].[Items] ([ItemId], [Description], [Done], [CategoryId]) VALUES (8, N'60 min yoga routine', 1, 4)
GO
SET IDENTITY_INSERT [dbo].[Items] OFF
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_Categories]
GO
USE [master]
GO
ALTER DATABASE [ToDoList] SET  READ_WRITE 
GO
