USE [master]
GO
/****** Object:  Database [RecruitmentManagement]    Script Date: 2/23/2025 10:18:37 AM ******/
CREATE DATABASE [RecruitmentManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RecruitmentManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\RecruitmentManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RecruitmentManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\RecruitmentManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [RecruitmentManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RecruitmentManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RecruitmentManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RecruitmentManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RecruitmentManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RecruitmentManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RecruitmentManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [RecruitmentManagement] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [RecruitmentManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RecruitmentManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RecruitmentManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RecruitmentManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RecruitmentManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RecruitmentManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RecruitmentManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RecruitmentManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RecruitmentManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [RecruitmentManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RecruitmentManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RecruitmentManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RecruitmentManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RecruitmentManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RecruitmentManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RecruitmentManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RecruitmentManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RecruitmentManagement] SET  MULTI_USER 
GO
ALTER DATABASE [RecruitmentManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RecruitmentManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RecruitmentManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RecruitmentManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RecruitmentManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RecruitmentManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [RecruitmentManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [RecruitmentManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [RecruitmentManagement]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/23/2025 10:18:37 AM ******/
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
/****** Object:  Table [dbo].[Applications]    Script Date: 2/23/2025 10:18:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Applications](
	[ApplicationID] [int] IDENTITY(1,1) NOT NULL,
	[CV] [nvarchar](max) NULL,
	[CoverLetter] [nvarchar](max) NULL,
	[ApplicationDate] [datetime] NULL,
	[JobID] [int] NULL,
	[UserID] [int] NULL,
	[StatusID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ApplicationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApplicationStatus]    Script Date: 2/23/2025 10:18:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationStatus](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 2/23/2025 10:18:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](255) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](11) NULL,
	[EmailCompanies] [nvarchar](255) NULL,
	[Website] [nvarchar](max) NULL,
	[AvartarCompanies] [nvarchar](max) NULL,
	[FieldID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CompanyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedbacks]    Script Date: 2/23/2025 10:18:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedbacks](
	[FeedbackID] [int] IDENTITY(1,1) NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[Rating] [int] NULL,
	[FeedbackDate] [datetime] NULL,
	[InterviewID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[FeedbackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fields]    Script Date: 2/23/2025 10:18:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fields](
	[FieldID] [int] IDENTITY(1,1) NOT NULL,
	[FieldName] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FieldID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Interviews]    Script Date: 2/23/2025 10:18:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interviews](
	[InterviewID] [int] IDENTITY(1,1) NOT NULL,
	[InterviewDate] [datetime] NULL,
	[InterviewLocation] [nvarchar](255) NULL,
	[InterviewType] [nvarchar](50) NULL,
	[ApplicationID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[InterviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jobs]    Script Date: 2/23/2025 10:18:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jobs](
	[JobID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[SalaryRange] [nvarchar](100) NULL,
	[PostedDate] [datetime] NULL,
	[ExperienceLevel] [nvarchar](50) NULL,
	[JobTypeID] [int] NULL,
	[CompanyID] [int] NULL,
	[ProfessionID] [int] NULL,
	[LocationID] [int] NULL,
	[Status] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[JobID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobTypes]    Script Date: 2/23/2025 10:18:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobTypes](
	[JobTypeID] [int] IDENTITY(1,1) NOT NULL,
	[JobTypeName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[JobTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 2/23/2025 10:18:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[LocationID] [int] IDENTITY(1,1) NOT NULL,
	[LocationName] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Professions]    Script Date: 2/23/2025 10:18:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professions](
	[ProfessionID] [int] IDENTITY(1,1) NOT NULL,
	[ProfessionName] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProfessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 2/23/2025 10:18:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/23/2025 10:18:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[FullName] [nvarchar](255) NULL,
	[Email] [nvarchar](255) NULL,
	[RoleID] [int] NULL,
	[DateOfBirth] [date] NULL,
	[PhoneNumber] [nvarchar](15) NULL,
	[IsActive] [bit] NULL,
	[AvatarURL] [nvarchar](max) NULL,
	[CompanyID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Applications] ON 

INSERT [dbo].[Applications] ([ApplicationID], [CV], [CoverLetter], [ApplicationDate], [JobID], [UserID], [StatusID]) VALUES (14, NULL, NULL, CAST(N'2024-11-18T01:41:42.283' AS DateTime), 12, 2, 5)
INSERT [dbo].[Applications] ([ApplicationID], [CV], [CoverLetter], [ApplicationDate], [JobID], [UserID], [StatusID]) VALUES (16, N'/uploads/35bd6ab7-27cb-40db-97b8-0695636e21f4.doc', N'/uploads/d33b8f1d-0ae0-4901-94ae-cb1811a11c91.doc', CAST(N'2024-11-18T02:29:38.357' AS DateTime), 12, 2, 5)
SET IDENTITY_INSERT [dbo].[Applications] OFF
GO
SET IDENTITY_INSERT [dbo].[ApplicationStatus] ON 

INSERT [dbo].[ApplicationStatus] ([StatusID], [StatusName]) VALUES (4, N'Accepted')
INSERT [dbo].[ApplicationStatus] ([StatusID], [StatusName]) VALUES (6, N'Pending')
INSERT [dbo].[ApplicationStatus] ([StatusID], [StatusName]) VALUES (5, N'Rejected')
SET IDENTITY_INSERT [dbo].[ApplicationStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Companies] ON 

INSERT [dbo].[Companies] ([CompanyID], [CompanyName], [Address], [Phone], [EmailCompanies], [Website], [AvartarCompanies], [FieldID]) VALUES (2, N'DXC Technology', N'364 Cộng Hòa, Phường 13, Quận Tân Bình, Thành phố Hồ Chí Minh	', NULL, N'DXC_Vietnam_Recruitment@dxc.com', N'https://dxc.com/vn/en	', N'dc915461-e82c-43e2-a787-39b1a250fb66_DXC.png', 108)
INSERT [dbo].[Companies] ([CompanyID], [CompanyName], [Address], [Phone], [EmailCompanies], [Website], [AvartarCompanies], [FieldID]) VALUES (12, N'Microsoft', N'Albuquerque, New Mexico, Hoa Kỳ', NULL, N'support@microsoft.com', N'mwww.microsoft.com', N'3ce89c52-9c04-48b5-b4d5-332eeb9ad583_ms.png', 108)
INSERT [dbo].[Companies] ([CompanyID], [CompanyName], [Address], [Phone], [EmailCompanies], [Website], [AvartarCompanies], [FieldID]) VALUES (13, N'Công ty cổ phần xe khách Phương Trang - FUTA Bus Lines', N'Số 01 Tô Hiến Thành, Phường 3, Thành phố Đà Lạt, Tỉnh Lâm Đồng, Việt Nam.', NULL, N'hotro@futa.vn', N'https://futabus.vn', N'2f71df1e-99cc-4327-af02-0ccf82a049f2_futa.png', 110)
SET IDENTITY_INSERT [dbo].[Companies] OFF
GO
SET IDENTITY_INSERT [dbo].[Fields] ON 

INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (92, N'Agency (Marketing/Advertising)')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (93, N'Bán lẻ - Hàng tiêu dùng - FMCG')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (94, N'Bảo hiểm')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (95, N'Bảo trì / Sửa chữa')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (96, N'Bất động sản')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (97, N'Chứng khoán')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (98, N'Cơ khí')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (99, N'Cơ quan nhà nước')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (102, N'Điện tử / Điện lạnh')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (100, N'Du lịch')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (101, N'Dược phẩm / Y tế / Công nghệ sinh học')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (103, N'Giải trí')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (104, N'Giáo dục / Đào tạo')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (105, N'In ấn / Xuất bản')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (106, N'Internet / Online')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (107, N'IT - Phần cứng')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (108, N'IT - Phần mềm')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (109, N'Kế toán / Kiểm toán')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (110, N'Logistics - Vận tải')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (111, N'Luật')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (112, N'Marketing / Truyền thông / Quảng cáo')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (113, N'Môi trường')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (114, N'Năng lượng')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (115, N'Ngân hàng')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (116, N'Nhà hàng / Khách sạn')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (117, N'Nhân sự')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (118, N'Nông Lâm Ngư nghiệp')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (119, N'Sản xuất')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (120, N'Tài chính')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (121, N'Thiết kế / kiến trúc')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (122, N'Thời trang')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (123, N'Thương mại điện tử')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (124, N'Tổ chức phi lợi nhuận')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (125, N'Tự động hóa')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (126, N'Tư vấn')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (127, N'Viễn thông')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (128, N'Xây dựng')
INSERT [dbo].[Fields] ([FieldID], [FieldName]) VALUES (129, N'Xuất nhập khẩu')
SET IDENTITY_INSERT [dbo].[Fields] OFF
GO
SET IDENTITY_INSERT [dbo].[Jobs] ON 

INSERT [dbo].[Jobs] ([JobID], [Title], [Description], [SalaryRange], [PostedDate], [ExperienceLevel], [JobTypeID], [CompanyID], [ProfessionID], [LocationID], [Status]) VALUES (12, N'Lập trình viên Backend', N'Có kiến thức tốt về Java', N'2000$', CAST(N'2024-11-16T18:55:24.067' AS DateTime), N'Senior', 1, 2, 26, 2, N'Approved')
INSERT [dbo].[Jobs] ([JobID], [Title], [Description], [SalaryRange], [PostedDate], [ExperienceLevel], [JobTypeID], [CompanyID], [ProfessionID], [LocationID], [Status]) VALUES (13, N'Lập trình viên Frontend', N'Thông thạo các framework và library', N'1000$-1500$', CAST(N'2024-11-16T18:57:11.700' AS DateTime), N'Senior', 1, 2, 26, 2, N'Pending')
INSERT [dbo].[Jobs] ([JobID], [Title], [Description], [SalaryRange], [PostedDate], [ExperienceLevel], [JobTypeID], [CompanyID], [ProfessionID], [LocationID], [Status]) VALUES (14, N'Tài xế xe khách', N'Có kinh nghiệm lái xe', N'20000000VNĐ', CAST(N'2024-11-18T13:58:20.237' AS DateTime), N'5 năm', 5, 13, 23, 34, N'Approved')
INSERT [dbo].[Jobs] ([JobID], [Title], [Description], [SalaryRange], [PostedDate], [ExperienceLevel], [JobTypeID], [CompanyID], [ProfessionID], [LocationID], [Status]) VALUES (15, N'Kế toán trưởng', N'Kế toán tốt nghiệp loại giỏi từ các trường thuộc Đại học Quốc gia TPHCM và Hà Nội', N'30000000VNĐ', CAST(N'2024-11-18T14:14:34.900' AS DateTime), N'Không yêu cầu kinh nghiệm', 1, 13, 28, 2, N'Approved')
INSERT [dbo].[Jobs] ([JobID], [Title], [Description], [SalaryRange], [PostedDate], [ExperienceLevel], [JobTypeID], [CompanyID], [ProfessionID], [LocationID], [Status]) VALUES (16, N'Tester', N'Biết Test', N'2000$', CAST(N'2024-11-20T08:59:14.457' AS DateTime), N'Senior', 1, 2, 26, 1, N'Pending')
SET IDENTITY_INSERT [dbo].[Jobs] OFF
GO
SET IDENTITY_INSERT [dbo].[JobTypes] ON 

INSERT [dbo].[JobTypes] ([JobTypeID], [JobTypeName]) VALUES (5, N'Contract')
INSERT [dbo].[JobTypes] ([JobTypeID], [JobTypeName]) VALUES (4, N'Freelance')
INSERT [dbo].[JobTypes] ([JobTypeID], [JobTypeName]) VALUES (1, N'Full-time')
INSERT [dbo].[JobTypes] ([JobTypeID], [JobTypeName]) VALUES (8, N'Hybrid')
INSERT [dbo].[JobTypes] ([JobTypeID], [JobTypeName]) VALUES (3, N'Internship')
INSERT [dbo].[JobTypes] ([JobTypeID], [JobTypeName]) VALUES (2, N'Part-time')
INSERT [dbo].[JobTypes] ([JobTypeID], [JobTypeName]) VALUES (7, N'Remote')
INSERT [dbo].[JobTypes] ([JobTypeID], [JobTypeName]) VALUES (6, N'Temporary')
SET IDENTITY_INSERT [dbo].[JobTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Locations] ON 

INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (1, N'Hà Nội')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (2, N'Hồ Chí Minh')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (3, N'Hải Phòng')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (4, N'Đà Nẵng')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (5, N'Cần Thơ')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (6, N'An Giang')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (7, N'Bà Rịa - Vũng Tàu')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (8, N'Bắc Giang')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (9, N'Bắc Kạn')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (10, N'Bạc Liêu')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (11, N'Bắc Ninh')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (12, N'Bình Dương')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (13, N'Bình Định')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (14, N'Bình Phước')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (15, N'Bình Thuận')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (16, N'Cà Mau')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (17, N'Cao Bằng')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (18, N'Đắk Lắk')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (19, N'Đắk Nông')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (20, N'Điện Biên')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (21, N'Dồng Nai')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (22, N'Dồng Tháp')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (23, N'Gia Lai')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (24, N'Hà Giang')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (25, N'Hà Nam')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (26, N'Hà Tĩnh')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (27, N'Hậu Giang')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (28, N'Hòa Bình')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (29, N'Hưng Yên')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (30, N'Khánh Hòa')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (31, N'Kiên Giang')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (32, N'Kon Tum')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (33, N'Lai Châu')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (34, N'Lâm Đồng')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (35, N'Long An')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (36, N'Lào Cai')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (37, N'Nam Định')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (38, N'Nghệ An')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (39, N'Ninh Bình')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (40, N'Ninh Thuận')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (41, N'Phú Thọ')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (42, N'Phú Yên')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (43, N'Quảng Bình')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (44, N'Quảng Nam')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (45, N'Quảng Ngãi')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (46, N'Quảng Ninh')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (47, N'Quảng Trị')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (48, N'Sóc Trăng')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (49, N'Sơn La')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (50, N'Tây Ninh')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (51, N'Thái Bình')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (52, N'Thái Nguyên')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (53, N'Thanh Hóa')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (54, N'Thừa Thiên Huế')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (55, N'Tiền Giang')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (56, N'Trà Vinh')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (57, N'Tuyên Quang')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (58, N'Vĩnh Long')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (59, N'Vĩnh Phúc')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (60, N'Yên Bái')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (61, N'Lai Châu')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (62, N'Bến Tre')
INSERT [dbo].[Locations] ([LocationID], [LocationName]) VALUES (63, N'Lạng Sơn')
SET IDENTITY_INSERT [dbo].[Locations] OFF
GO
SET IDENTITY_INSERT [dbo].[Professions] ON 

INSERT [dbo].[Professions] ([ProfessionID], [ProfessionName]) VALUES (31, N'Bán lẻ/Dịch vụ đời sống')
INSERT [dbo].[Professions] ([ProfessionID], [ProfessionName]) VALUES (27, N'Bất động sản/Xây dựng')
INSERT [dbo].[Professions] ([ProfessionID], [ProfessionName]) VALUES (26, N'Công nghệ Thông tin')
INSERT [dbo].[Professions] ([ProfessionID], [ProfessionName]) VALUES (23, N'Dịch vụ khách hàng/Vận hành')
INSERT [dbo].[Professions] ([ProfessionID], [ProfessionName]) VALUES (33, N'Điện/Điện tử/Viễn thông')
INSERT [dbo].[Professions] ([ProfessionID], [ProfessionName]) VALUES (36, N'Dược/Y tế/Sức khoẻ/Công nghệ sinh học')
INSERT [dbo].[Professions] ([ProfessionID], [ProfessionName]) VALUES (30, N'Giáo dục/Đào tạo')
INSERT [dbo].[Professions] ([ProfessionID], [ProfessionName]) VALUES (28, N'Kế toán/Kiểm toán/Thuế')
INSERT [dbo].[Professions] ([ProfessionID], [ProfessionName]) VALUES (21, N'Kinh doanh/Bán hàng')
INSERT [dbo].[Professions] ([ProfessionID], [ProfessionName]) VALUES (34, N'Logistics/Thu mua/Kho/Tài xế')
INSERT [dbo].[Professions] ([ProfessionID], [ProfessionName]) VALUES (22, N'Marketing/PR/Quảng cáo')
INSERT [dbo].[Professions] ([ProfessionID], [ProfessionName]) VALUES (39, N'Năng lượng/Môi trường/Nông nghiệp')
INSERT [dbo].[Professions] ([ProfessionID], [ProfessionName]) VALUES (38, N'Nhà hàng/Khách sạn/Du lịch')
INSERT [dbo].[Professions] ([ProfessionID], [ProfessionName]) VALUES (24, N'Nhân sự/Hành chính/Pháp chế')
INSERT [dbo].[Professions] ([ProfessionID], [ProfessionName]) VALUES (40, N'Nhóm nghề khác')
INSERT [dbo].[Professions] ([ProfessionID], [ProfessionName]) VALUES (32, N'Phim và truyền hình/Báo chí/Xuất bản')
INSERT [dbo].[Professions] ([ProfessionID], [ProfessionName]) VALUES (29, N'Sản xuất')
INSERT [dbo].[Professions] ([ProfessionID], [ProfessionName]) VALUES (25, N'Tài chính/Ngân hàng/Bảo hiểm')
INSERT [dbo].[Professions] ([ProfessionID], [ProfessionName]) VALUES (37, N'Thiết kế')
INSERT [dbo].[Professions] ([ProfessionID], [ProfessionName]) VALUES (35, N'Tư vấn chuyên môn/Luật/Biên phiên dịch')
SET IDENTITY_INSERT [dbo].[Professions] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (3, N'Admin')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (1, N'Applicant')
INSERT [dbo].[Roles] ([RoleID], [RoleName]) VALUES (2, N'Recruiter')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [RoleID], [DateOfBirth], [PhoneNumber], [IsActive], [AvatarURL], [CompanyID]) VALUES (2, N'vinhle123', N'123456789', N'Lê Thành Vinh', N'vinhle@gmail.com', 1, CAST(N'2004-11-17' AS Date), N'0909090908', 1, N'20aff5c4-540f-4ff2-9d08-53b08c0f8171_z4657821443384_34c8e61d4c7748712f392ab176d2b58d.jpg', NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [RoleID], [DateOfBirth], [PhoneNumber], [IsActive], [AvatarURL], [CompanyID]) VALUES (3, N'tuanha2912', N'12345789', N'Hà Diêm Tuấn', N'hatuan@gmail.com', 1, CAST(N'2004-12-29' AS Date), N'0909090904', 1, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [RoleID], [DateOfBirth], [PhoneNumber], [IsActive], [AvatarURL], [CompanyID]) VALUES (4, N'thongnguyen', N'123456789', N'Nguyễn Hoàng Thông', N'thong@gmail.com', 2, CAST(N'2004-10-02' AS Date), N'0909090905', 1, NULL, 12)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [RoleID], [DateOfBirth], [PhoneNumber], [IsActive], [AvatarURL], [CompanyID]) VALUES (5, N'tuongpham', N'123456789', N'Phạm Ngọc Tưởng', N'tuongpham@gmai.com', 1, CAST(N'2004-11-10' AS Date), N'0909090903', 1, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [RoleID], [DateOfBirth], [PhoneNumber], [IsActive], [AvatarURL], [CompanyID]) VALUES (7, N'jobconnect@hotro.vn', N'admin123', N'jobconnect', N'jobconnect@hotro.vn', 3, NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [FullName], [Email], [RoleID], [DateOfBirth], [PhoneNumber], [IsActive], [AvatarURL], [CompanyID]) VALUES (14, N'thongnguyen123', N'123456789', N'Nguyễn Hoàng Thông', N'thongnguyen@gmail.com', 2, CAST(N'2004-11-18' AS Date), N'0909090901', 1, NULL, 13)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Applicat__05E7698A227D0D7F]    Script Date: 2/23/2025 10:18:37 AM ******/
ALTER TABLE [dbo].[ApplicationStatus] ADD UNIQUE NONCLUSTERED 
(
	[StatusName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Companie__B805C4A49331EDEE]    Script Date: 2/23/2025 10:18:37 AM ******/
ALTER TABLE [dbo].[Companies] ADD UNIQUE NONCLUSTERED 
(
	[EmailCompanies] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Fields__A88707A67B87F19A]    Script Date: 2/23/2025 10:18:37 AM ******/
ALTER TABLE [dbo].[Fields] ADD UNIQUE NONCLUSTERED 
(
	[FieldName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__JobTypes__2C951EA8F78FD137]    Script Date: 2/23/2025 10:18:37 AM ******/
ALTER TABLE [dbo].[JobTypes] ADD UNIQUE NONCLUSTERED 
(
	[JobTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Professi__704E62FB9BBFA128]    Script Date: 2/23/2025 10:18:37 AM ******/
ALTER TABLE [dbo].[Professions] ADD UNIQUE NONCLUSTERED 
(
	[ProfessionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Roles__8A2B61609449FD77]    Script Date: 2/23/2025 10:18:37 AM ******/
ALTER TABLE [dbo].[Roles] ADD UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__536C85E4615D8EE7]    Script Date: 2/23/2025 10:18:37 AM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__A9D10534E7FD123C]    Script Date: 2/23/2025 10:18:37 AM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Jobs] ADD  DEFAULT ('Pending') FOR [Status]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD FOREIGN KEY([JobID])
REFERENCES [dbo].[Jobs] ([JobID])
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD FOREIGN KEY([StatusID])
REFERENCES [dbo].[ApplicationStatus] ([StatusID])
GO
ALTER TABLE [dbo].[Applications]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Companies]  WITH CHECK ADD FOREIGN KEY([FieldID])
REFERENCES [dbo].[Fields] ([FieldID])
GO
ALTER TABLE [dbo].[Feedbacks]  WITH CHECK ADD FOREIGN KEY([InterviewID])
REFERENCES [dbo].[Interviews] ([InterviewID])
GO
ALTER TABLE [dbo].[Interviews]  WITH CHECK ADD FOREIGN KEY([ApplicationID])
REFERENCES [dbo].[Applications] ([ApplicationID])
GO
ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Companies] ([CompanyID])
GO
ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD FOREIGN KEY([JobTypeID])
REFERENCES [dbo].[JobTypes] ([JobTypeID])
GO
ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD FOREIGN KEY([ProfessionID])
REFERENCES [dbo].[Professions] ([ProfessionID])
GO
ALTER TABLE [dbo].[Jobs]  WITH CHECK ADD  CONSTRAINT [FK_Jobs_Locations] FOREIGN KEY([LocationID])
REFERENCES [dbo].[Locations] ([LocationID])
GO
ALTER TABLE [dbo].[Jobs] CHECK CONSTRAINT [FK_Jobs_Locations]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([CompanyID])
REFERENCES [dbo].[Companies] ([CompanyID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Roles] ([RoleID])
GO
ALTER TABLE [dbo].[Feedbacks]  WITH CHECK ADD CHECK  (([Rating]>=(1) AND [Rating]<=(5)))
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [CK_Users_OnlyRecruiterCanHaveCompany] CHECK  (([RoleID]=(2) OR [CompanyID] IS NULL))
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [CK_Users_OnlyRecruiterCanHaveCompany]
GO
USE [master]
GO
ALTER DATABASE [RecruitmentManagement] SET  READ_WRITE 
GO
