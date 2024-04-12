USE [master]
GO
/****** Object:  Database [JobPortalApplication]    Script Date: 08-04-2024 16:46:03 ******/
CREATE DATABASE [JobPortalApplication]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JobPortalApplication', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\JobPortalApplication.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JobPortalApplication_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\JobPortalApplication_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [JobPortalApplication] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JobPortalApplication].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JobPortalApplication] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JobPortalApplication] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JobPortalApplication] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JobPortalApplication] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JobPortalApplication] SET ARITHABORT OFF 
GO
ALTER DATABASE [JobPortalApplication] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [JobPortalApplication] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JobPortalApplication] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JobPortalApplication] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JobPortalApplication] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JobPortalApplication] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JobPortalApplication] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JobPortalApplication] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JobPortalApplication] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JobPortalApplication] SET  ENABLE_BROKER 
GO
ALTER DATABASE [JobPortalApplication] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JobPortalApplication] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JobPortalApplication] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JobPortalApplication] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JobPortalApplication] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JobPortalApplication] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [JobPortalApplication] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JobPortalApplication] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [JobPortalApplication] SET  MULTI_USER 
GO
ALTER DATABASE [JobPortalApplication] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JobPortalApplication] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JobPortalApplication] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JobPortalApplication] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [JobPortalApplication] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [JobPortalApplication] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [JobPortalApplication] SET QUERY_STORE = ON
GO
ALTER DATABASE [JobPortalApplication] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [JobPortalApplication]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 08-04-2024 16:46:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblJob]    Script Date: 08-04-2024 16:46:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblJob](
	[JobId] [int] IDENTITY(1,1) NOT NULL,
	[JobTitle] [nvarchar](max) NOT NULL,
	[JobDescription] [nvarchar](max) NOT NULL,
	[JobProviderEmailId] [nvarchar](max) NOT NULL,
	[Deadline] [datetime2](7) NOT NULL,
	[Company] [nvarchar](max) NOT NULL,
	[InterviewDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_tblJob] PRIMARY KEY CLUSTERED 
(
	[JobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblJobApply]    Script Date: 08-04-2024 16:46:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblJobApply](
	[JobApplicationId] [int] IDENTITY(1,1) NOT NULL,
	[JobId] [int] NOT NULL,
	[JobSeekerEmailId] [nvarchar](max) NOT NULL,
	[Applied_Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_tblJobApply] PRIMARY KEY CLUSTERED 
(
	[JobApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblJobProviders]    Script Date: 08-04-2024 16:46:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblJobProviders](
	[EmailId] [nvarchar](450) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[CompanyName] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_tblJobProviders] PRIMARY KEY CLUSTERED 
(
	[EmailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblJobSeekers]    Script Date: 08-04-2024 16:46:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblJobSeekers](
	[EmailId] [nvarchar](450) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[DOB] [date] NOT NULL,
	[ResumePath] [nvarchar](max) NOT NULL,
	[Experience] [int] NOT NULL,
	[Skills] [nvarchar](max) NOT NULL,
	[Education] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tblJobSeekers] PRIMARY KEY CLUSTERED 
(
	[EmailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240402055444_initial', N'8.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240404114805_after', N'8.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240406055851_later', N'8.0.3')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240406175945_last', N'8.0.3')
GO
SET IDENTITY_INSERT [dbo].[tblJob] ON 
GO
INSERT [dbo].[tblJob] ([JobId], [JobTitle], [JobDescription], [JobProviderEmailId], [Deadline], [Company], [InterviewDate]) VALUES (2, N'UI/UX designer', N'1+ years of experience', N'aziz_infosys@gmail.com', CAST(N'2024-04-10T00:00:00.0000000' AS DateTime2), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[tblJob] ([JobId], [JobTitle], [JobDescription], [JobProviderEmailId], [Deadline], [Company], [InterviewDate]) VALUES (4, N'Laravel developer', N'Good knowledge of laravel with hands-on experience', N'suman_accenture@gmail.com', CAST(N'2024-04-08T00:00:00.0000000' AS DateTime2), N'', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[tblJob] ([JobId], [JobTitle], [JobDescription], [JobProviderEmailId], [Deadline], [Company], [InterviewDate]) VALUES (5, N'React Developer', N'Remote', N'suman_accenture@gmail.com', CAST(N'2024-04-10T00:00:00.0000000' AS DateTime2), N'Accenture', CAST(N'2024-04-20T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[tblJob] ([JobId], [JobTitle], [JobDescription], [JobProviderEmailId], [Deadline], [Company], [InterviewDate]) VALUES (6, N'MERN Developer', N'Remote', N'suman_accenture@gmail.com', CAST(N'2024-04-20T00:00:00.0000000' AS DateTime2), N'Google', CAST(N'2024-05-03T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[tblJob] OFF
GO
SET IDENTITY_INSERT [dbo].[tblJobApply] ON 
GO
INSERT [dbo].[tblJobApply] ([JobApplicationId], [JobId], [JobSeekerEmailId], [Applied_Date]) VALUES (1, 4, N'sanajaved@gmail.com', CAST(N'2024-04-06T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[tblJobApply] ([JobApplicationId], [JobId], [JobSeekerEmailId], [Applied_Date]) VALUES (2, 5, N'sanajaved@gmail.com', CAST(N'2024-04-06T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[tblJobApply] ([JobApplicationId], [JobId], [JobSeekerEmailId], [Applied_Date]) VALUES (3, 6, N'sanajaved@gmail.com', CAST(N'2024-04-06T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[tblJobApply] OFF
GO
INSERT [dbo].[tblJobProviders] ([EmailId], [Password], [FirstName], [LastName], [CompanyName], [Address]) VALUES (N'aziz_infosys@gmail.com', N'$2a$11$1iRKSKznI/aQ2ytwRtvDGu0WlelT.5/OkkrOFXnaTrg.PjtqzHU2e', N'Md', N'Aziz', N' Infosys', N'Kolkata NewTown')
GO
INSERT [dbo].[tblJobProviders] ([EmailId], [Password], [FirstName], [LastName], [CompanyName], [Address]) VALUES (N'rajib_godrej@gmail.com', N'$2a$11$N16SiyGdjlDF/mPWG4Mz6eNRiKP3pxtwQ.9gUzhOb3bIv12eeWqZu', N'Rajib', N'Sen', N'Godrej', N'Kolkata EcoSpace')
GO
INSERT [dbo].[tblJobProviders] ([EmailId], [Password], [FirstName], [LastName], [CompanyName], [Address]) VALUES (N'suman_accenture@gmail.com', N'$2a$11$95JE/PJEeffggMqimmmEjOHkcSsJPH5v1P0Y84g8C2Xpwdw5wuOZ2', N'Suman', N'Bose', N'Accenture', N'Kolkata Salt Lake Sector V')
GO
INSERT [dbo].[tblJobProviders] ([EmailId], [Password], [FirstName], [LastName], [CompanyName], [Address]) VALUES (N'sumon_tata@gmail.com', N'$2a$11$dXnUesEr4x23XZi6w6fstuK.LteQJ9kQLBjBMrncTTVdpl9jUR3g6', N'Sumon', N'Bose', N'Tata', N'Jamshedpur')
GO
INSERT [dbo].[tblJobProviders] ([EmailId], [Password], [FirstName], [LastName], [CompanyName], [Address]) VALUES (N'sumona_deloitte@gmail.com', N'sumona@deloitte', N'Sumona', N'Sen', N'Deloitte', N'Mumbai')
GO
INSERT [dbo].[tblJobSeekers] ([EmailId], [Password], [FirstName], [LastName], [Address], [PhoneNumber], [DOB], [ResumePath], [Experience], [Skills], [Education]) VALUES (N'sanajaved@gmail.com', N'$2a$11$Mwks7hKF9jRwJj/you7CR.xV7U2Pg2s5ie3U.SnOArZIsxT4IihuW', N'Sana', N'Javed', N'Bongaon', N'9123648497', CAST(N'2000-02-10' AS Date), N'defg', 2, N'Python,Java', N'B.Tech in CSE')
GO
ALTER TABLE [dbo].[tblJob] ADD  DEFAULT (N'') FOR [Company]
GO
ALTER TABLE [dbo].[tblJob] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [InterviewDate]
GO
ALTER TABLE [dbo].[tblJobApply] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [Applied_Date]
GO
USE [master]
GO
ALTER DATABASE [JobPortalApplication] SET  READ_WRITE 
GO
