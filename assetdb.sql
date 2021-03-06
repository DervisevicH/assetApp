USE [master]
GO
/****** Object:  Database [AssetsTracker]    Script Date: 10/11/2020 10:22:20 PM ******/
CREATE DATABASE [AssetsTracker]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AssetsTracker', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AssetsTracker.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AssetsTracker_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\AssetsTracker_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AssetsTracker] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AssetsTracker].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AssetsTracker] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AssetsTracker] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AssetsTracker] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AssetsTracker] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AssetsTracker] SET ARITHABORT OFF 
GO
ALTER DATABASE [AssetsTracker] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AssetsTracker] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AssetsTracker] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AssetsTracker] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AssetsTracker] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AssetsTracker] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AssetsTracker] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AssetsTracker] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AssetsTracker] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AssetsTracker] SET  ENABLE_BROKER 
GO
ALTER DATABASE [AssetsTracker] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AssetsTracker] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AssetsTracker] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AssetsTracker] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AssetsTracker] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AssetsTracker] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AssetsTracker] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AssetsTracker] SET RECOVERY FULL 
GO
ALTER DATABASE [AssetsTracker] SET  MULTI_USER 
GO
ALTER DATABASE [AssetsTracker] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AssetsTracker] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AssetsTracker] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AssetsTracker] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AssetsTracker] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'AssetsTracker', N'ON'
GO
ALTER DATABASE [AssetsTracker] SET QUERY_STORE = OFF
GO
USE [AssetsTracker]
GO
/****** Object:  Table [dbo].[Administrator]    Script Date: 10/11/2020 10:22:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrator](
	[AdministratorID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](100) NULL,
	[Email] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[AdministratorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asset]    Script Date: 10/11/2020 10:22:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asset](
	[AssetID] [int] IDENTITY(1,1) NOT NULL,
	[AssetName] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[CategoryId] [int] NULL,
	[IsAvailable] [bit] NULL,
	[AssetNmb] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AssetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssignAsset]    Script Date: 10/11/2020 10:22:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignAsset](
	[AssignAssetId] [int] IDENTITY(1,1) NOT NULL,
	[AssetId] [int] NULL,
	[EmployeeId] [int] NULL,
	[DateFrom] [datetime] NULL,
	[DateTo] [datetime] NULL,
	[Comment] [nvarchar](max) NULL,
	[AdministratorID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AssignAssetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 10/11/2020 10:22:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 10/11/2020 10:22:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[Title] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Administrator] ON 

INSERT [dbo].[Administrator] ([AdministratorID], [Username], [Password], [Email]) VALUES (1, N'hadzira', N'hadzira123', N'hadzira@mail.com')
SET IDENTITY_INSERT [dbo].[Administrator] OFF
GO
SET IDENTITY_INSERT [dbo].[Asset] ON 

INSERT [dbo].[Asset] ([AssetID], [AssetName], [Description], [CategoryId], [IsAvailable], [AssetNmb]) VALUES (1, N'Laptop Dell Inspirion 17', N'RAM: 8gb, Intel Core i5-5200U', 1, 1, 1122)
INSERT [dbo].[Asset] ([AssetID], [AssetName], [Description], [CategoryId], [IsAvailable], [AssetNmb]) VALUES (2, N'Laptop Dell Inspirion 15', N'RAM: 8gb, Intel Core i5-5200U', 1, 1, 1133)
INSERT [dbo].[Asset] ([AssetID], [AssetName], [Description], [CategoryId], [IsAvailable], [AssetNmb]) VALUES (3, N'Sony ZX110A', N'Wired headset without mic', 3, 0, 1144)
INSERT [dbo].[Asset] ([AssetID], [AssetName], [Description], [CategoryId], [IsAvailable], [AssetNmb]) VALUES (4, N'Sony ZX110A', N'Wired headset without mic', 3, 0, 1155)
INSERT [dbo].[Asset] ([AssetID], [AssetName], [Description], [CategoryId], [IsAvailable], [AssetNmb]) VALUES (5, N'Logitech mouse', N'Wireless mouse', 2, 0, 1166)
INSERT [dbo].[Asset] ([AssetID], [AssetName], [Description], [CategoryId], [IsAvailable], [AssetNmb]) VALUES (6, N'Logitech mouse', N'Wireless mouse', 2, 0, 1177)
SET IDENTITY_INSERT [dbo].[Asset] OFF
GO
SET IDENTITY_INSERT [dbo].[AssignAsset] ON 

INSERT [dbo].[AssignAsset] ([AssignAssetId], [AssetId], [EmployeeId], [DateFrom], [DateTo], [Comment], [AdministratorID]) VALUES (16, 3, 1, CAST(N'2020-10-11T21:42:00.000' AS DateTime), NULL, N'', 1)
INSERT [dbo].[AssignAsset] ([AssignAssetId], [AssetId], [EmployeeId], [DateFrom], [DateTo], [Comment], [AdministratorID]) VALUES (17, 6, 1, CAST(N'2020-10-12T21:56:00.000' AS DateTime), NULL, N'', 1)
SET IDENTITY_INSERT [dbo].[AssignAsset] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'Computers')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'Mouse')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (3, N'Headphones')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [LastName], [Email], [Title]) VALUES (1, N'Ivan', N'Knezevic', N'ivan.knezevic@test.ba', N'Software developer')
INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [LastName], [Email], [Title]) VALUES (2, N'Almir', N'Karadza', N'almir.karadza@test.ba', N'Software developer')
INSERT [dbo].[Employee] ([EmployeeId], [FirstName], [LastName], [Email], [Title]) VALUES (3, N'Hadzira', N'Dervisevic', N'hadzira@test.ba', N'software developer')
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
ALTER TABLE [dbo].[Asset]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[AssignAsset]  WITH CHECK ADD FOREIGN KEY([AdministratorID])
REFERENCES [dbo].[Administrator] ([AdministratorID])
GO
ALTER TABLE [dbo].[AssignAsset]  WITH CHECK ADD FOREIGN KEY([AssetId])
REFERENCES [dbo].[Asset] ([AssetID])
GO
ALTER TABLE [dbo].[AssignAsset]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
/****** Object:  StoredProcedure [dbo].[AddEmployee]    Script Date: 10/11/2020 10:22:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddEmployee](
@firstName NVARCHAR(50),
@lastName NVARCHAR(50),
@email NVARCHAR(100),
@title NVARCHAR(50)
)
AS 
BEGIN 
INSERT INTO Employee(FirstName,LastName,Email,Title)
VALUES (@firstName, @lastName, @email, @title)
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllEmployee]    Script Date: 10/11/2020 10:22:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllEmployee]
AS
SELECT * FROM Employee
GO;
GO
USE [master]
GO
ALTER DATABASE [AssetsTracker] SET  READ_WRITE 
GO
