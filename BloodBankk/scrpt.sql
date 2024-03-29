USE [master]
GO
/****** Object:  Database [BloodBank]    Script Date: 18.01.2022 17:32:41 ******/
CREATE DATABASE [BloodBank]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BloodBank', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BloodBank.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BloodBank_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BloodBank_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BloodBank] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BloodBank].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BloodBank] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BloodBank] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BloodBank] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BloodBank] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BloodBank] SET ARITHABORT OFF 
GO
ALTER DATABASE [BloodBank] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BloodBank] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BloodBank] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BloodBank] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BloodBank] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BloodBank] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BloodBank] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BloodBank] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BloodBank] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BloodBank] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BloodBank] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BloodBank] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BloodBank] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BloodBank] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BloodBank] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BloodBank] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BloodBank] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BloodBank] SET RECOVERY FULL 
GO
ALTER DATABASE [BloodBank] SET  MULTI_USER 
GO
ALTER DATABASE [BloodBank] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BloodBank] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BloodBank] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BloodBank] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BloodBank] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BloodBank] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BloodBank', N'ON'
GO
ALTER DATABASE [BloodBank] SET QUERY_STORE = OFF
GO
USE [BloodBank]
GO
/****** Object:  Table [dbo].[Donor]    Script Date: 18.01.2022 17:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donor](
	[DonorId] [int] IDENTITY(1,1) NOT NULL,
	[TcNo] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[PhoneNum] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[BloodGroupId] [int] NOT NULL,
 CONSTRAINT [PK_Donor] PRIMARY KEY CLUSTERED 
(
	[DonorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BloodGroup]    Script Date: 18.01.2022 17:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BloodGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BloodGroup] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BloodGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vDonors]    Script Date: 18.01.2022 17:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vDonors]
AS 
SELECT       dbo.Donor.TcNo, dbo.Donor.Name, dbo.Donor.Surname, dbo.Donor.Age, dbo.Donor.Gender, dbo.Donor.PhoneNum, dbo.Donor.Address, dbo.BloodGroup.BloodGroup
FROM            dbo.Donor INNER JOIN
                         dbo.BloodGroup ON dbo.Donor.BloodGroupId = dbo.BloodGroup.Id
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 18.01.2022 17:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[TcNo] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[PhoneNum] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[BloodGroupId] [int] NOT NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[vPatients]    Script Date: 18.01.2022 17:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vPatients]
AS
SELECT dbo.Patient.TcNo, dbo.Patient.Name, dbo.Patient.Surname, dbo.Patient.Age, dbo.Patient.Gender, dbo.Patient.PhoneNum, dbo.Patient.Address, dbo.BloodGroup.BloodGroup
FROM dbo.Patient INNER JOIN dbo.BloodGroup ON dbo.Patient.BloodGroupId = dbo.BloodGroup.Id
GO
/****** Object:  Table [dbo].[BloodStock]    Script Date: 18.01.2022 17:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BloodStock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BloodGroupId] [int] NOT NULL,
	[Stock] [int] NOT NULL,
 CONSTRAINT [PK_BloodStock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[BloodST]    Script Date: 18.01.2022 17:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[BloodST]
AS
SELECT dbo.BloodGroup.BloodGroup, dbo.BloodStock.Stock 
FROM dbo.BloodStock INNER JOIN dbo.BloodGroup ON dbo.BloodStock.BloodGroupId = dbo.BloodGroup.Id
GO
/****** Object:  Table [dbo].[BloodTransfer]    Script Date: 18.01.2022 17:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BloodTransfer](
	[TransferId] [int] IDENTITY(1,1) NOT NULL,
	[BloodGroup] [nvarchar](50) NOT NULL,
	[GivenBlood] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BloodTransfer] PRIMARY KEY CLUSTERED 
(
	[TransferId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 18.01.2022 17:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Gender] [nvarchar](50) NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemUser]    Script Date: 18.01.2022 17:32:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TcNo] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SystemUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BloodGroup] ON 

INSERT [dbo].[BloodGroup] ([Id], [BloodGroup]) VALUES (1, N'A+')
INSERT [dbo].[BloodGroup] ([Id], [BloodGroup]) VALUES (2, N'B+')
INSERT [dbo].[BloodGroup] ([Id], [BloodGroup]) VALUES (3, N'AB+')
INSERT [dbo].[BloodGroup] ([Id], [BloodGroup]) VALUES (4, N'0+')
INSERT [dbo].[BloodGroup] ([Id], [BloodGroup]) VALUES (5, N'A-')
INSERT [dbo].[BloodGroup] ([Id], [BloodGroup]) VALUES (6, N'B-')
INSERT [dbo].[BloodGroup] ([Id], [BloodGroup]) VALUES (7, N'AB-')
INSERT [dbo].[BloodGroup] ([Id], [BloodGroup]) VALUES (8, N'0-')
SET IDENTITY_INSERT [dbo].[BloodGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[BloodStock] ON 

INSERT [dbo].[BloodStock] ([Id], [BloodGroupId], [Stock]) VALUES (1, 1, 0)
INSERT [dbo].[BloodStock] ([Id], [BloodGroupId], [Stock]) VALUES (2, 2, 0)
INSERT [dbo].[BloodStock] ([Id], [BloodGroupId], [Stock]) VALUES (3, 3, 4)
INSERT [dbo].[BloodStock] ([Id], [BloodGroupId], [Stock]) VALUES (4, 4, 1)
INSERT [dbo].[BloodStock] ([Id], [BloodGroupId], [Stock]) VALUES (5, 5, 0)
INSERT [dbo].[BloodStock] ([Id], [BloodGroupId], [Stock]) VALUES (6, 6, 1)
INSERT [dbo].[BloodStock] ([Id], [BloodGroupId], [Stock]) VALUES (7, 7, 0)
INSERT [dbo].[BloodStock] ([Id], [BloodGroupId], [Stock]) VALUES (8, 8, 0)
SET IDENTITY_INSERT [dbo].[BloodStock] OFF
GO
SET IDENTITY_INSERT [dbo].[BloodTransfer] ON 

INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (1, N'A+', N'A+')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (2, N'A+', N'A-')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (3, N'A+', N'0+')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (4, N'A+', N'0-')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (5, N'B+', N'B+')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (6, N'B+', N'B-')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (7, N'B+', N'0+')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (8, N'B+', N'0-')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (9, N'AB+', N'AB+')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (10, N'AB+', N'B+')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (11, N'AB+', N'A+')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (12, N'AB+', N'0+')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (13, N'AB+', N'A-')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (14, N'AB+', N'B-')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (15, N'AB+', N'AB-')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (16, N'AB+', N'0-')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (17, N'0+', N'0+')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (18, N'0+', N'0-')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (19, N'A-', N'A-')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (21, N'A-', N'0-')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (22, N'B-', N'B-')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (23, N'B-', N'0-')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (24, N'AB-', N'AB-')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (25, N'AB-', N'A-')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (26, N'AB-', N'B-')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (27, N'AB-', N'0-')
INSERT [dbo].[BloodTransfer] ([TransferId], [BloodGroup], [GivenBlood]) VALUES (28, N'0-', N'0-')
SET IDENTITY_INSERT [dbo].[BloodTransfer] OFF
GO
SET IDENTITY_INSERT [dbo].[Donor] ON 

INSERT [dbo].[Donor] ([DonorId], [TcNo], [Name], [Surname], [Age], [Gender], [PhoneNum], [Address], [BloodGroupId]) VALUES (10, N'53326263556', N'Kadir', N'Kartal', 21, N'Erkek', N'5435761266', N'Basaksehir', 3)
INSERT [dbo].[Donor] ([DonorId], [TcNo], [Name], [Surname], [Age], [Gender], [PhoneNum], [Address], [BloodGroupId]) VALUES (11, N'15935725812', N'Emir Muhammet', N'Aydemir ', 20, N'Erkek', N'5481542121', N'Metrokent', 4)
INSERT [dbo].[Donor] ([DonorId], [TcNo], [Name], [Surname], [Age], [Gender], [PhoneNum], [Address], [BloodGroupId]) VALUES (12, N'12345678988', N'Mertcan', N'Tombak', 19, N'Erkek', N'5354561258', N'Maltepe', 6)
INSERT [dbo].[Donor] ([DonorId], [TcNo], [Name], [Surname], [Age], [Gender], [PhoneNum], [Address], [BloodGroupId]) VALUES (13, N'12389049902', N'Batikan Cagri', N'Savci', 20, N'Erkek', N'5364581525', N'Maltepe', 6)
INSERT [dbo].[Donor] ([DonorId], [TcNo], [Name], [Surname], [Age], [Gender], [PhoneNum], [Address], [BloodGroupId]) VALUES (14, N'18439505592', N'Fatih Mehmet', N'Bilgin', 21, N'Erkek', N'5395424518', N'Cerkezkoy', 4)
SET IDENTITY_INSERT [dbo].[Donor] OFF
GO
SET IDENTITY_INSERT [dbo].[Gender] ON 

INSERT [dbo].[Gender] ([Id], [Gender]) VALUES (1, N'Kadin')
INSERT [dbo].[Gender] ([Id], [Gender]) VALUES (2, N'Erkek')
SET IDENTITY_INSERT [dbo].[Gender] OFF
GO
SET IDENTITY_INSERT [dbo].[Patient] ON 

INSERT [dbo].[Patient] ([PatientId], [TcNo], [Name], [Surname], [Age], [Gender], [PhoneNum], [Address], [BloodGroupId]) VALUES (5, N'55495701512', N'Recep ', N'Kartal', 18, N'Erkek', N'05435891532', N'Guvercintepe', 1)
INSERT [dbo].[Patient] ([PatientId], [TcNo], [Name], [Surname], [Age], [Gender], [PhoneNum], [Address], [BloodGroupId]) VALUES (6, N'24516598215', N'Selvi', N'Uzun', 18, N'Kadin', N'5422981624', N'Bagcilar', 4)
INSERT [dbo].[Patient] ([PatientId], [TcNo], [Name], [Surname], [Age], [Gender], [PhoneNum], [Address], [BloodGroupId]) VALUES (7, N'12546325608', N'Nergis', N'Lale', 20, N'Kadin', N'5366251249', N'Alibeykoy', 7)
INSERT [dbo].[Patient] ([PatientId], [TcNo], [Name], [Surname], [Age], [Gender], [PhoneNum], [Address], [BloodGroupId]) VALUES (8, N'19382949284', N'Ahmet', N'Kisa', 24, N'Erkek', N'5485896325', N'Sancaktepe', 5)
SET IDENTITY_INSERT [dbo].[Patient] OFF
GO
SET IDENTITY_INSERT [dbo].[SystemUser] ON 

INSERT [dbo].[SystemUser] ([Id], [TcNo], [Name], [Surname], [Password]) VALUES (1, N'12', N'Emir', N'Aydemir', N'123')
SET IDENTITY_INSERT [dbo].[SystemUser] OFF
GO
USE [master]
GO
ALTER DATABASE [BloodBank] SET  READ_WRITE 
GO
