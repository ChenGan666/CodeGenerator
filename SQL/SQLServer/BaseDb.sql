USE [master]
GO
/****** Object:  Database [BaseDb]    Script Date: 2020-6-24 12:38:33 ******/
CREATE DATABASE [BaseDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BaseDb', FILENAME = N'E:\DB\BaseDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BaseDb_log', FILENAME = N'E:\DB\BaseDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BaseDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BaseDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BaseDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BaseDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BaseDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BaseDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BaseDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [BaseDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BaseDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BaseDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BaseDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BaseDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BaseDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BaseDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BaseDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BaseDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BaseDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BaseDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BaseDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BaseDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BaseDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BaseDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BaseDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BaseDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BaseDb] SET RECOVERY FULL 
GO
ALTER DATABASE [BaseDb] SET  MULTI_USER 
GO
ALTER DATABASE [BaseDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BaseDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BaseDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BaseDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BaseDb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BaseDb', N'ON'
GO
ALTER DATABASE [BaseDb] SET QUERY_STORE = OFF
GO
USE [BaseDb]
GO
/****** Object:  Table [dbo].[BaseBranchInfo]    Script Date: 2020-6-24 12:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaseBranchInfo](
	[BranchID] [int] IDENTITY(1,1) NOT NULL,
	[SystemID] [int] NOT NULL,
	[bItemID] [varchar](50) NULL,
	[bCode] [varchar](50) NOT NULL,
	[bName] [varchar](250) NOT NULL,
	[bLinkMan] [varchar](50) NULL,
	[bTel] [varchar](50) NULL,
	[bFax] [varchar](50) NULL,
	[bEmail] [varchar](50) NULL,
	[bNote] [varchar](128) NULL,
	[bAppendTime] [datetime] NOT NULL,
	[bState] [bit] NOT NULL,
 CONSTRAINT [PK_BaseBranchInfo] PRIMARY KEY CLUSTERED 
(
	[BranchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaseCodeIndexInfo]    Script Date: 2020-6-24 12:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaseCodeIndexInfo](
	[CodeIndexID] [int] IDENTITY(1,1) NOT NULL,
	[SystemID] [int] NOT NULL,
	[CodeType] [int] NOT NULL,
	[CodeIndex] [int] NOT NULL,
	[cUpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_BaseCodeIndexInfo] PRIMARY KEY CLUSTERED 
(
	[CodeIndexID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaseDepartmentInfo]    Script Date: 2020-6-24 12:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaseDepartmentInfo](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[SystemID] [int] NOT NULL,
	[BranchID] [int] NOT NULL,
	[dItemID] [varchar](50) NOT NULL,
	[dName] [varchar](50) NOT NULL,
	[dDirector] [varchar](50) NULL,
	[dNote] [varchar](128) NULL,
	[dState] [bit] NOT NULL,
	[dAppendTime] [datetime] NOT NULL,
 CONSTRAINT [PK_BaseDepartmentInfo] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaseDictionaryInfo]    Script Date: 2020-6-24 12:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaseDictionaryInfo](
	[DicId] [int] IDENTITY(1,1) NOT NULL,
	[DicName] [nvarchar](255) NOT NULL,
	[DicTitle] [nvarchar](255) NULL,
	[DicValue] [nvarchar](255) NULL,
	[DicRemark] [nvarchar](255) NULL,
	[Status] [bit] NOT NULL,
	[Sort] [int] NOT NULL,
	[Pid] [int] NOT NULL,
	[Cid] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_DictionaryInfo] PRIMARY KEY CLUSTERED 
(
	[DicId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaseEmployeeInfo]    Script Date: 2020-6-24 12:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaseEmployeeInfo](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[SystemID] [int] NOT NULL,
	[BranchID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[eItemID] [varchar](50) NOT NULL,
	[eName] [varchar](50) NULL,
	[eSex] [varchar](50) NULL,
	[eMarry] [varchar](50) NULL,
	[eBirthday] [varchar](50) NULL,
	[DepartmentID] [int] NOT NULL,
	[JobPositionID] [int] NOT NULL,
	[JPName] [varchar](50) NOT NULL,
	[IsManager] [bit] NOT NULL,
	[IsCheckManager] [bit] NOT NULL,
	[IsSelf] [bit] NOT NULL,
	[eEntry] [varchar](50) NULL,
	[eEmail] [varchar](50) NULL,
	[eTel] [varchar](50) NULL,
	[eQQ] [varchar](50) NULL,
	[eMob] [varchar](50) NULL,
	[ePhotoImage] [image] NULL,
	[eState] [bit] NOT NULL,
	[eAppendTime] [datetime] NOT NULL,
 CONSTRAINT [PK_BaseEmployeeInfo] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaseJobPositionInfo]    Script Date: 2020-6-24 12:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaseJobPositionInfo](
	[JobPositionID] [int] IDENTITY(1,1) NOT NULL,
	[SystemID] [int] NOT NULL,
	[BranchID] [int] NOT NULL,
	[BranchName] [varchar](50) NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[DepartmentName] [varchar](50) NOT NULL,
	[JPItemID] [varchar](50) NOT NULL,
	[JPName] [varchar](50) NOT NULL,
	[JPPermissions] [ntext] NOT NULL,
	[JobLevel] [int] NOT NULL,
	[JPRemark] [varchar](256) NOT NULL,
	[JState] [bit] NOT NULL,
	[JPAppendTime] [datetime] NOT NULL,
	[JPUpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_BaseJobPositionInfo] PRIMARY KEY CLUSTERED 
(
	[JobPositionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BasePermissionInfo]    Script Date: 2020-6-24 12:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BasePermissionInfo](
	[PermissionID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NOT NULL,
	[PermissionName] [varchar](100) NOT NULL,
	[PermissionValue] [varchar](100) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsUse] [bit] NOT NULL,
	[pAppendTime] [datetime] NOT NULL,
	[pUpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_BasePermissionInfo] PRIMARY KEY CLUSTERED 
(
	[PermissionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaseUserInfo]    Script Date: 2020-6-24 12:38:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaseUserInfo](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[SystemID] [int] NOT NULL,
	[BranchID] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[uName] [varchar](50) NOT NULL,
	[uPWD] [char](32) NOT NULL,
	[uCode] [char](32) NOT NULL,
	[uAppendTime] [datetime] NOT NULL,
	[uUpAppendTime] [datetime] NOT NULL,
	[uLastIP] [varchar](50) NOT NULL,
	[uType] [int] NOT NULL,
	[uState] [bit] NOT NULL,
	[olTime] [int] NOT NULL,
 CONSTRAINT [PK_BaseUserInfo] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BaseBranchInfo] ON 

INSERT [dbo].[BaseBranchInfo] ([BranchID], [SystemID], [bItemID], [bCode], [bName], [bLinkMan], [bTel], [bFax], [bEmail], [bNote], [bAppendTime], [bState]) VALUES (3, 3, N'3', N'ZSN', N'知数能', N'陈淦', N'', N'', N'', N'', CAST(N'2024-06-01T10:20:40.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[BaseBranchInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[BaseCodeIndexInfo] ON 

INSERT [dbo].[BaseCodeIndexInfo] ([CodeIndexID], [SystemID], [CodeType], [CodeIndex], [cUpdateTime]) VALUES (1, 0, 100, 13, CAST(N'2020-05-22T14:28:55.990' AS DateTime))
INSERT [dbo].[BaseCodeIndexInfo] ([CodeIndexID], [SystemID], [CodeType], [CodeIndex], [cUpdateTime]) VALUES (2, 0, 101, 11, CAST(N'2020-05-21T14:58:44.563' AS DateTime))
INSERT [dbo].[BaseCodeIndexInfo] ([CodeIndexID], [SystemID], [CodeType], [CodeIndex], [cUpdateTime]) VALUES (3, 0, 105, 10, CAST(N'2020-05-22T10:33:16.423' AS DateTime))
INSERT [dbo].[BaseCodeIndexInfo] ([CodeIndexID], [SystemID], [CodeType], [CodeIndex], [cUpdateTime]) VALUES (4, 0, 102, 2, CAST(N'2020-05-25T15:22:16.003' AS DateTime))
SET IDENTITY_INSERT [dbo].[BaseCodeIndexInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[BaseDepartmentInfo] ON 

INSERT [dbo].[BaseDepartmentInfo] ([DepartmentID], [SystemID], [BranchID], [dItemID], [dName], [dDirector], [dNote], [dState], [dAppendTime]) VALUES (11, 0, 3, N'11', N'研发部', NULL, NULL, 1, CAST(N'2020-05-21T14:58:44.557' AS DateTime))
SET IDENTITY_INSERT [dbo].[BaseDepartmentInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[BaseDictionaryInfo] ON 

INSERT [dbo].[BaseDictionaryInfo] ([DicId], [DicName], [DicTitle], [DicValue], [DicRemark], [Status], [Sort], [Pid], [Cid], [CreateTime], [UpdateTime]) VALUES (1, N'后台菜单', N'AdminMenu', N'', N'', 1, 1, 0, 0, CAST(N'2020-05-20T17:30:52.000' AS DateTime), CAST(N'2020-05-21T15:04:55.860' AS DateTime))
INSERT [dbo].[BaseDictionaryInfo] ([DicId], [DicName], [DicTitle], [DicValue], [DicRemark], [Status], [Sort], [Pid], [Cid], [CreateTime], [UpdateTime]) VALUES (2, N'组织机构', NULL, N'OrganizationManagement', NULL, 1, 0, 1, 0, CAST(N'2020-05-20T15:37:46.000' AS DateTime), CAST(N'2020-05-28T10:58:46.553' AS DateTime))
INSERT [dbo].[BaseDictionaryInfo] ([DicId], [DicName], [DicTitle], [DicValue], [DicRemark], [Status], [Sort], [Pid], [Cid], [CreateTime], [UpdateTime]) VALUES (3, N'系统设置', NULL, N'SystemManagement', NULL, 1, 0, 1, 0, CAST(N'2020-05-20T15:38:16.000' AS DateTime), CAST(N'2020-05-28T10:58:42.893' AS DateTime))
INSERT [dbo].[BaseDictionaryInfo] ([DicId], [DicName], [DicTitle], [DicValue], [DicRemark], [Status], [Sort], [Pid], [Cid], [CreateTime], [UpdateTime]) VALUES (4, N'分支机构', N'Branch', N'Branch/BranchList', NULL, 1, 0, 2, 0, CAST(N'2020-05-20T16:37:55.000' AS DateTime), CAST(N'2020-05-28T11:04:17.907' AS DateTime))
INSERT [dbo].[BaseDictionaryInfo] ([DicId], [DicName], [DicTitle], [DicValue], [DicRemark], [Status], [Sort], [Pid], [Cid], [CreateTime], [UpdateTime]) VALUES (5, N'部门管理', N'Department', N'Department/DepartmentList', NULL, 1, 0, 2, 0, CAST(N'2020-05-20T16:38:11.000' AS DateTime), CAST(N'2020-05-28T11:04:07.433' AS DateTime))
INSERT [dbo].[BaseDictionaryInfo] ([DicId], [DicName], [DicTitle], [DicValue], [DicRemark], [Status], [Sort], [Pid], [Cid], [CreateTime], [UpdateTime]) VALUES (6, N'岗位管理', N'JobPosition', N'JobPosition/JobPositionList', NULL, 1, 0, 2, 0, CAST(N'2020-05-20T16:39:34.000' AS DateTime), CAST(N'2020-05-28T11:03:55.710' AS DateTime))
INSERT [dbo].[BaseDictionaryInfo] ([DicId], [DicName], [DicTitle], [DicValue], [DicRemark], [Status], [Sort], [Pid], [Cid], [CreateTime], [UpdateTime]) VALUES (7, N'人员管理', N'Employee', N'Employee/EmployeeList', NULL, 1, 0, 2, 0, CAST(N'2020-05-20T16:39:57.000' AS DateTime), CAST(N'2020-05-28T11:03:40.623' AS DateTime))
INSERT [dbo].[BaseDictionaryInfo] ([DicId], [DicName], [DicTitle], [DicValue], [DicRemark], [Status], [Sort], [Pid], [Cid], [CreateTime], [UpdateTime]) VALUES (8, N'操作账户', N'UserAccount', N'UserAccount/UserAccountList', NULL, 1, 0, 2, 0, CAST(N'2020-05-20T16:40:16.000' AS DateTime), CAST(N'2020-05-28T11:03:23.317' AS DateTime))
INSERT [dbo].[BaseDictionaryInfo] ([DicId], [DicName], [DicTitle], [DicValue], [DicRemark], [Status], [Sort], [Pid], [Cid], [CreateTime], [UpdateTime]) VALUES (9, N'字典管理', N'Dictionary', N'Dictionary/DictionaryList', NULL, 1, 0, 3, 0, CAST(N'2020-05-20T16:41:08.000' AS DateTime), CAST(N'2020-05-28T11:02:47.877' AS DateTime))
INSERT [dbo].[BaseDictionaryInfo] ([DicId], [DicName], [DicTitle], [DicValue], [DicRemark], [Status], [Sort], [Pid], [Cid], [CreateTime], [UpdateTime]) VALUES (10, N'地区管理', N'Area', N'Area/AreaList', NULL, 0, 0, 3, 0, CAST(N'2020-05-20T16:41:27.000' AS DateTime), CAST(N'2020-05-28T11:02:38.973' AS DateTime))
INSERT [dbo].[BaseDictionaryInfo] ([DicId], [DicName], [DicTitle], [DicValue], [DicRemark], [Status], [Sort], [Pid], [Cid], [CreateTime], [UpdateTime]) VALUES (11, N'权限管理', N'Permission', N'Permission/PermissionList', NULL, 1, 0, 3, 0, CAST(N'2020-05-20T16:43:00.000' AS DateTime), CAST(N'2020-05-28T11:02:29.053' AS DateTime))
INSERT [dbo].[BaseDictionaryInfo] ([DicId], [DicName], [DicTitle], [DicValue], [DicRemark], [Status], [Sort], [Pid], [Cid], [CreateTime], [UpdateTime]) VALUES (1001, N'系统日志', NULL, N'SystemLog', NULL, 1, 0, 1, 0, CAST(N'2020-06-04T17:02:59.000' AS DateTime), CAST(N'2020-06-04T17:09:18.767' AS DateTime))
INSERT [dbo].[BaseDictionaryInfo] ([DicId], [DicName], [DicTitle], [DicValue], [DicRemark], [Status], [Sort], [Pid], [Cid], [CreateTime], [UpdateTime]) VALUES (1002, N'日志等级', NULL, N'/SystemLog/LogLevelList', NULL, 1, 0, 1001, 0, CAST(N'2020-06-04T17:10:21.000' AS DateTime), CAST(N'2020-06-04T17:45:47.007' AS DateTime))
INSERT [dbo].[BaseDictionaryInfo] ([DicId], [DicName], [DicTitle], [DicValue], [DicRemark], [Status], [Sort], [Pid], [Cid], [CreateTime], [UpdateTime]) VALUES (1003, N'日志记录', NULL, N'/SystemLog/LogRecordList', NULL, 1, 0, 1001, 0, CAST(N'2020-06-04T17:11:03.747' AS DateTime), CAST(N'2020-06-04T17:11:03.747' AS DateTime))
INSERT [dbo].[BaseDictionaryInfo] ([DicId], [DicName], [DicTitle], [DicValue], [DicRemark], [Status], [Sort], [Pid], [Cid], [CreateTime], [UpdateTime]) VALUES (1004, N'日志锚点', NULL, N'/SystemLog/LogTypeList', NULL, 1, 0, 1001, 0, CAST(N'2020-06-04T17:11:40.487' AS DateTime), CAST(N'2020-06-04T17:11:40.487' AS DateTime))
INSERT [dbo].[BaseDictionaryInfo] ([DicId], [DicName], [DicTitle], [DicValue], [DicRemark], [Status], [Sort], [Pid], [Cid], [CreateTime], [UpdateTime]) VALUES (1005, N'日志锚点分类', NULL, N'/SystemLog/LogTypeClassList', NULL, 1, 0, 1001, 0, CAST(N'2020-06-04T17:12:05.207' AS DateTime), CAST(N'2020-06-04T17:12:05.207' AS DateTime))
SET IDENTITY_INSERT [dbo].[BaseDictionaryInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[BaseEmployeeInfo] ON 

INSERT [dbo].[BaseEmployeeInfo] ([EmployeeID], [SystemID], [BranchID], [UserID], [eItemID], [eName], [eSex], [eMarry], [eBirthday], [DepartmentID], [JobPositionID], [JPName], [IsManager], [IsCheckManager], [IsSelf], [eEntry], [eEmail], [eTel], [eQQ], [eMob], [ePhotoImage], [eState], [eAppendTime]) VALUES (1, 0, 3, 0, N'1', N'测试', N'男', N'未婚', N'1992-03-12', 11, 10, N'测试', 1, 1, 1, N'2016-03-01', N'11111111@qq.com', N'8937122544', N'332934295', N'18084730922', NULL, 1, CAST(N'2020-05-25T15:24:04.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[BaseEmployeeInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[BaseJobPositionInfo] ON 

INSERT [dbo].[BaseJobPositionInfo] ([JobPositionID], [SystemID], [BranchID], [BranchName], [DepartmentID], [DepartmentName], [JPItemID], [JPName], [JPPermissions], [JobLevel], [JPRemark], [JState], [JPAppendTime], [JPUpdateTime]) VALUES (10, 0, 3, N'达塔科技', 11, N'研发部', N'10', N'测试', N'4,6,34,35,37,38,36,7,39,40,41,42,43,8,44,45,46,47,48,9,49,50,53,10,12,24,25,26,27,28,29,15,17,19,20,23,21,58,59,74,60,61,62,63,64,65,66,67,68,69,70,71,72,73', 0, N'', 1, CAST(N'2020-05-22T10:33:16.000' AS DateTime), CAST(N'2020-06-04T17:46:35.650' AS DateTime))
SET IDENTITY_INSERT [dbo].[BaseJobPositionInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[BasePermissionInfo] ON 

INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (4, 0, N'组织机构', N'OrganizationManagement', 0, 1, CAST(N'2020-05-26T17:04:04.000' AS DateTime), CAST(N'2020-05-28T10:49:44.987' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (5, 4, N'分支机构', N'Branch', 0, 1, CAST(N'2020-05-26T17:04:17.000' AS DateTime), CAST(N'2020-05-28T11:06:37.423' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (6, 4, N'部门管理', N'Department', 0, 1, CAST(N'2020-05-26T17:04:25.000' AS DateTime), CAST(N'2020-05-28T11:06:26.743' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (7, 4, N'岗位管理', N'JobPosition', 0, 1, CAST(N'2020-05-26T17:04:36.000' AS DateTime), CAST(N'2020-05-28T11:06:19.257' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (8, 4, N'人员管理', N'Employee', 0, 1, CAST(N'2020-05-26T17:04:46.000' AS DateTime), CAST(N'2020-05-28T11:06:08.950' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (9, 4, N'操作账户', N'UserAccount', 0, 1, CAST(N'2020-05-26T17:04:54.000' AS DateTime), CAST(N'2020-05-28T11:06:01.360' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (10, 0, N'系统设置', N'SystemManagement', 0, 1, CAST(N'2020-05-26T17:16:11.000' AS DateTime), CAST(N'2020-05-28T10:49:28.117' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (12, 10, N'字典管理', N'Dictionary', 0, 1, CAST(N'2020-05-26T17:16:28.000' AS DateTime), CAST(N'2020-05-28T11:05:34.690' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (15, 10, N'权限管理', N'Permission', 0, 1, CAST(N'2020-05-26T17:18:16.000' AS DateTime), CAST(N'2020-05-28T11:05:21.797' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (17, 15, N'查看页面', N'/Permission/PermissionEdit', 0, 1, CAST(N'2020-05-26T17:18:36.000' AS DateTime), CAST(N'2020-05-27T16:59:21.523' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (19, 15, N'编辑', N'/Permission/PermissionSave', 0, 1, CAST(N'2020-05-26T17:19:21.000' AS DateTime), CAST(N'2020-05-27T16:58:46.110' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (20, 15, N'删除', N'/Permission/PermissionDel', 0, 1, CAST(N'2020-05-26T17:19:27.000' AS DateTime), CAST(N'2020-05-27T16:58:01.270' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (21, 15, N'状态开关', N'/Permission/PermissionStatus', 0, 1, CAST(N'2020-05-27T15:49:20.000' AS DateTime), CAST(N'2020-05-27T16:57:50.100' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (22, 5, N'查看列表', N'/Branch/BranchList', 0, 1, CAST(N'2020-05-27T16:35:02.277' AS DateTime), CAST(N'2020-05-27T16:35:02.277' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (23, 15, N'查看列表', N'/Permission/PermissionList', 0, 1, CAST(N'2020-05-27T16:59:44.000' AS DateTime), CAST(N'2020-05-27T16:59:44.000' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (24, 12, N'查看列表', N'/Dictionary/DictionaryList', 0, 1, CAST(N'2020-05-27T17:00:10.457' AS DateTime), CAST(N'2020-05-27T17:00:10.457' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (25, 12, N'查看详情页', N'/Dictionary/DictionaryEdit', 0, 1, CAST(N'2020-05-27T17:00:28.307' AS DateTime), CAST(N'2020-05-27T17:00:28.307' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (26, 12, N'编辑', N'/Dictionary/DictionarySave', 0, 1, CAST(N'2020-05-27T17:00:56.570' AS DateTime), CAST(N'2020-05-27T17:00:56.570' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (27, 12, N'排序', N'/Dictionary/DictionarySort', 0, 1, CAST(N'2020-05-27T17:01:08.483' AS DateTime), CAST(N'2020-05-27T17:01:08.483' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (28, 12, N'状态开关', N'/Dictionary/DictionaryStatus', 0, 1, CAST(N'2020-05-27T17:01:24.297' AS DateTime), CAST(N'2020-05-27T17:01:24.297' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (29, 12, N'删除', N'/Dictionary/DictionaryDel', 0, 1, CAST(N'2020-05-27T17:01:42.547' AS DateTime), CAST(N'2020-05-27T17:01:42.547' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (30, 5, N'查看详情', N'/Branch/BranchEdit', 0, 1, CAST(N'2020-05-27T17:02:24.857' AS DateTime), CAST(N'2020-05-27T17:02:24.857' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (31, 5, N'编辑', N'/Branch/BranchSave', 0, 1, CAST(N'2020-05-27T17:03:51.233' AS DateTime), CAST(N'2020-05-27T17:03:51.233' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (32, 5, N'删除', N'/Branch/BranchDel', 0, 1, CAST(N'2020-05-27T17:04:02.537' AS DateTime), CAST(N'2020-05-27T17:04:02.537' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (33, 5, N'状态开关', N'/Branch/BranchStatus', 0, 1, CAST(N'2020-05-27T17:04:12.127' AS DateTime), CAST(N'2020-05-27T17:04:12.127' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (34, 6, N'查看列表', N'/Department/DepartmentList', 0, 1, CAST(N'2020-05-27T17:04:30.473' AS DateTime), CAST(N'2020-05-27T17:04:30.473' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (35, 6, N'查看详情', N'/Department/DepartmentEdit', 0, 1, CAST(N'2020-05-27T17:04:44.743' AS DateTime), CAST(N'2020-05-27T17:04:44.743' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (36, 6, N'编辑', N'/Department/DepartmentSave', 0, 1, CAST(N'2020-05-27T17:05:03.793' AS DateTime), CAST(N'2020-05-27T17:05:03.793' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (37, 6, N'删除', N'/Department/DepartmentDel', 0, 1, CAST(N'2020-05-27T17:05:13.927' AS DateTime), CAST(N'2020-05-27T17:05:13.927' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (38, 6, N'状态开关', N'/Department/DepartmentStatus', 0, 1, CAST(N'2020-05-27T17:05:24.813' AS DateTime), CAST(N'2020-05-27T17:05:24.813' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (39, 7, N'查看列表', N'/JobPosition/JobPositionList', 0, 1, CAST(N'2020-05-27T17:05:43.393' AS DateTime), CAST(N'2020-05-27T17:05:43.393' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (40, 7, N'查看详情', N'/JobPosition/JobPositionEdit', 0, 1, CAST(N'2020-05-27T17:05:55.433' AS DateTime), CAST(N'2020-05-27T17:05:55.433' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (41, 7, N'编辑', N'/JobPosition/JobPositionSave', 0, 1, CAST(N'2020-05-27T17:06:04.907' AS DateTime), CAST(N'2020-05-27T17:06:04.907' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (42, 7, N'删除', N'/JobPosition/JobPositionDel', 0, 1, CAST(N'2020-05-27T17:06:14.847' AS DateTime), CAST(N'2020-05-27T17:06:14.847' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (43, 7, N'状态开关', N'/JobPosition/JobPositionStatus', 0, 1, CAST(N'2020-05-27T17:06:26.187' AS DateTime), CAST(N'2020-05-27T17:06:26.187' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (44, 8, N'查看列表', N'/Employee/EmployeeList', 0, 1, CAST(N'2020-05-27T17:06:52.267' AS DateTime), CAST(N'2020-05-27T17:06:52.267' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (45, 8, N'查看详情', N'/Employee/EmployeeEdit', 0, 1, CAST(N'2020-05-27T17:07:04.127' AS DateTime), CAST(N'2020-05-27T17:07:04.127' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (46, 8, N'编辑', N'/Employee/EmployeeSave', 0, 1, CAST(N'2020-05-27T17:07:17.543' AS DateTime), CAST(N'2020-05-27T17:07:17.543' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (47, 8, N'删除', N'/Employee/EmployeeDel', 0, 1, CAST(N'2020-05-27T17:07:26.623' AS DateTime), CAST(N'2020-05-27T17:07:26.623' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (48, 8, N'状态开关', N'/Employee/EmployeeStatus', 0, 1, CAST(N'2020-05-27T17:07:35.673' AS DateTime), CAST(N'2020-05-27T17:07:35.673' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (49, 9, N'查看列表', N'/UserAccount/UserAccountList', 0, 1, CAST(N'2020-05-27T17:08:01.813' AS DateTime), CAST(N'2020-05-27T17:08:01.813' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (50, 9, N'查看详情', N'/UserAccount/UserAccountEdit', 0, 1, CAST(N'2020-05-27T17:08:14.007' AS DateTime), CAST(N'2020-05-27T17:08:14.007' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (51, 9, N'编辑', N'/UserAccount/UserAccountSave', 0, 1, CAST(N'2020-05-27T17:08:23.817' AS DateTime), CAST(N'2020-05-27T17:08:23.817' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (52, 9, N'删除', N'/UserAccount/UserAccountDel', 0, 1, CAST(N'2020-05-27T17:08:33.913' AS DateTime), CAST(N'2020-05-27T17:08:33.913' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (53, 9, N'状态开关', N'/UserAccount/UserAccountStatus', 0, 1, CAST(N'2020-05-27T17:08:44.350' AS DateTime), CAST(N'2020-05-27T17:08:44.350' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (58, 0, N'系统日志', N'SystemLog', 0, 1, CAST(N'2020-06-04T17:22:30.110' AS DateTime), CAST(N'2020-06-04T17:22:30.110' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (59, 58, N'LogLevelList', N'/SystemLog/LogLevelList', 0, 1, CAST(N'2020-06-04T17:30:43.000' AS DateTime), CAST(N'2020-06-04T17:31:06.553' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (60, 58, N'LogLevelEdit', N'/SystemLog/LogLevelEdit', 0, 1, CAST(N'2020-06-04T17:32:08.690' AS DateTime), CAST(N'2020-06-04T17:32:08.690' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (61, 58, N'LogLevelSave', N'/SystemLog/LogLevelSave', 0, 1, CAST(N'2020-06-04T17:32:19.287' AS DateTime), CAST(N'2020-06-04T17:32:19.287' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (62, 58, N'LogLevelDel', N'/SystemLog/LogLevelDel', 0, 1, CAST(N'2020-06-04T17:32:34.907' AS DateTime), CAST(N'2020-06-04T17:32:34.907' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (63, 58, N'LogLevelStatus', N'/SystemLog/LogLevelStatus', 0, 1, CAST(N'2020-06-04T17:32:50.160' AS DateTime), CAST(N'2020-06-04T17:32:50.160' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (64, 58, N'LogRecordList', N'/SystemLog/LogRecordList', 0, 1, CAST(N'2020-06-04T17:33:03.070' AS DateTime), CAST(N'2020-06-04T17:33:03.070' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (65, 58, N'LogRecordDel', N'/SystemLog/LogRecordDel', 0, 1, CAST(N'2020-06-04T17:33:13.957' AS DateTime), CAST(N'2020-06-04T17:33:13.957' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (66, 58, N'LogTypeList', N'/SystemLog/LogTypeList', 0, 1, CAST(N'2020-06-04T17:35:37.900' AS DateTime), CAST(N'2020-06-04T17:35:37.900' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (67, 58, N'LogTypeEdit', N'/SystemLog/LogTypeEdit', 0, 1, CAST(N'2020-06-04T17:35:53.650' AS DateTime), CAST(N'2020-06-04T17:35:53.650' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (68, 58, N'LogTypeSave', N'/SystemLog/LogTypeSave', 0, 1, CAST(N'2020-06-04T17:36:10.757' AS DateTime), CAST(N'2020-06-04T17:36:10.757' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (69, 58, N'LogTypeDel', N'/SystemLog/LogTypeDel', 0, 1, CAST(N'2020-06-04T17:36:32.737' AS DateTime), CAST(N'2020-06-04T17:36:32.737' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (70, 58, N'LogTypeStatus', N'/SystemLog/LogTypeStatus', 0, 1, CAST(N'2020-06-04T17:36:46.077' AS DateTime), CAST(N'2020-06-04T17:36:46.077' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (71, 58, N'LogTypeClassList', N'/SystemLog/LogTypeClassList', 0, 1, CAST(N'2020-06-04T17:37:01.840' AS DateTime), CAST(N'2020-06-04T17:37:01.840' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (72, 58, N'LogTypeClassEdit', N'/SystemLog/LogTypeClassEdit', 0, 1, CAST(N'2020-06-04T17:37:12.593' AS DateTime), CAST(N'2020-06-04T17:37:12.593' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (73, 58, N'LogTypeClassSave', N'/SystemLog/LogTypeClassSave', 0, 1, CAST(N'2020-06-04T17:37:22.377' AS DateTime), CAST(N'2020-06-04T17:37:22.377' AS DateTime))
INSERT [dbo].[BasePermissionInfo] ([PermissionID], [ParentID], [PermissionName], [PermissionValue], [IsDeleted], [IsUse], [pAppendTime], [pUpdateTime]) VALUES (74, 58, N'LogTypeClassDel', N'/SystemLog/LogTypeClassDel', 0, 1, CAST(N'2020-06-04T17:37:43.090' AS DateTime), CAST(N'2020-06-04T17:37:43.090' AS DateTime))
SET IDENTITY_INSERT [dbo].[BasePermissionInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[BaseUserInfo] ON 

INSERT [dbo].[BaseUserInfo] ([UserID], [SystemID], [BranchID], [DepartmentID], [EmployeeID], [uName], [uPWD], [uCode], [uAppendTime], [uUpAppendTime], [uLastIP], [uType], [uState], [olTime]) VALUES (4, 0, 3, 11, 1, N'chenfr', N'e10adc3949ba59abbe56e057f20f883e', N'                                ', CAST(N'2020-05-25T18:04:12.000' AS DateTime), CAST(N'2020-06-04T23:59:45.067' AS DateTime), N'127.0.0.1', 0, 1, 2)
SET IDENTITY_INSERT [dbo].[BaseUserInfo] OFF
GO
ALTER TABLE [dbo].[BaseBranchInfo] ADD  CONSTRAINT [DF_tbBranchInfo_SystemID]  DEFAULT ((0)) FOR [SystemID]
GO
ALTER TABLE [dbo].[BaseBranchInfo] ADD  CONSTRAINT [DF_tbBranchInfo_bAppendTime]  DEFAULT (getdate()) FOR [bAppendTime]
GO
ALTER TABLE [dbo].[BaseBranchInfo] ADD  CONSTRAINT [DF_tbBranchInfo_bState]  DEFAULT ((0)) FOR [bState]
GO
ALTER TABLE [dbo].[BaseCodeIndexInfo] ADD  CONSTRAINT [DF_tbCodeIndexInfo_SystemID]  DEFAULT ((0)) FOR [SystemID]
GO
ALTER TABLE [dbo].[BaseDepartmentInfo] ADD  CONSTRAINT [DF_tbDepartmentInfo_SystemID]  DEFAULT ((0)) FOR [SystemID]
GO
ALTER TABLE [dbo].[BaseDepartmentInfo] ADD  CONSTRAINT [DF_tbDepartmentInfo_dDirector]  DEFAULT ('') FOR [dDirector]
GO
ALTER TABLE [dbo].[BaseDepartmentInfo] ADD  CONSTRAINT [DF_tbDepartmentInfo_dNote]  DEFAULT ('') FOR [dNote]
GO
ALTER TABLE [dbo].[BaseDepartmentInfo] ADD  CONSTRAINT [DF_tbDepartmentInfo_dState]  DEFAULT ((0)) FOR [dState]
GO
ALTER TABLE [dbo].[BaseDepartmentInfo] ADD  CONSTRAINT [DF_tbDepartmentInfo_dAppendTime]  DEFAULT (getdate()) FOR [dAppendTime]
GO
ALTER TABLE [dbo].[BaseEmployeeInfo] ADD  CONSTRAINT [DF_tbEmployeeInfo_SystemID]  DEFAULT ((0)) FOR [SystemID]
GO
ALTER TABLE [dbo].[BaseEmployeeInfo] ADD  CONSTRAINT [DF_tbEmployeeInfo_UserID]  DEFAULT ((0)) FOR [UserID]
GO
ALTER TABLE [dbo].[BaseEmployeeInfo] ADD  CONSTRAINT [DF_tbEmployeeInfo_JobPositionID]  DEFAULT ((0)) FOR [JobPositionID]
GO
ALTER TABLE [dbo].[BaseEmployeeInfo] ADD  CONSTRAINT [DF_tbEmployeeInfo_IsManager]  DEFAULT ((0)) FOR [IsManager]
GO
ALTER TABLE [dbo].[BaseEmployeeInfo] ADD  CONSTRAINT [DF_tbEmployeeInfo_IsCheckManager]  DEFAULT ((0)) FOR [IsCheckManager]
GO
ALTER TABLE [dbo].[BaseEmployeeInfo] ADD  CONSTRAINT [DF_tbEmployeeInfo_IsSelf]  DEFAULT ((0)) FOR [IsSelf]
GO
ALTER TABLE [dbo].[BaseEmployeeInfo] ADD  CONSTRAINT [DF_tbEmployeeInfo_eAppendTime]  DEFAULT (getdate()) FOR [eAppendTime]
GO
ALTER TABLE [dbo].[BaseJobPositionInfo] ADD  CONSTRAINT [DF_tbJobPositionInfo_JobLevel]  DEFAULT ((0)) FOR [JobLevel]
GO
ALTER TABLE [dbo].[BaseJobPositionInfo] ADD  CONSTRAINT [DF_tbJobPositionInfo_JState]  DEFAULT ((0)) FOR [JState]
GO
ALTER TABLE [dbo].[BaseJobPositionInfo] ADD  CONSTRAINT [DF_tbJobPositionInfo_JPAppendTime]  DEFAULT (getdate()) FOR [JPAppendTime]
GO
ALTER TABLE [dbo].[BaseJobPositionInfo] ADD  CONSTRAINT [DF_Table_1_]  DEFAULT (getdate()) FOR [JPUpdateTime]
GO
ALTER TABLE [dbo].[BasePermissionInfo] ADD  CONSTRAINT [DF_tbPermissionInfo_ParentID]  DEFAULT ((0)) FOR [ParentID]
GO
ALTER TABLE [dbo].[BasePermissionInfo] ADD  CONSTRAINT [DF_tbPermissionInfo_PermissionName]  DEFAULT ('') FOR [PermissionName]
GO
ALTER TABLE [dbo].[BasePermissionInfo] ADD  CONSTRAINT [DF_tbPermissionInfo_PermissionValue]  DEFAULT ('') FOR [PermissionValue]
GO
ALTER TABLE [dbo].[BasePermissionInfo] ADD  CONSTRAINT [DF_tbPermissionInfo_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[BasePermissionInfo] ADD  CONSTRAINT [DF_tbPermissionInfo_IsUse]  DEFAULT ((1)) FOR [IsUse]
GO
ALTER TABLE [dbo].[BasePermissionInfo] ADD  CONSTRAINT [DF_Table_1_PAppendTime]  DEFAULT (getdate()) FOR [pAppendTime]
GO
ALTER TABLE [dbo].[BasePermissionInfo] ADD  CONSTRAINT [DF_tbPermissionInfo_pUpdateTime]  DEFAULT (getdate()) FOR [pUpdateTime]
GO
ALTER TABLE [dbo].[BaseUserInfo] ADD  CONSTRAINT [DF_tbUserInfo_SystemID]  DEFAULT ((0)) FOR [SystemID]
GO
ALTER TABLE [dbo].[BaseUserInfo] ADD  CONSTRAINT [DF_tbUserInfo_DepartmentID]  DEFAULT ((0)) FOR [DepartmentID]
GO
ALTER TABLE [dbo].[BaseUserInfo] ADD  CONSTRAINT [DF_tbUserInfo_uAppendTime]  DEFAULT (getdate()) FOR [uAppendTime]
GO
ALTER TABLE [dbo].[BaseUserInfo] ADD  CONSTRAINT [DF_tbUserInfo_olTime]  DEFAULT ((0)) FOR [olTime]
GO
/****** Object:  StoredProcedure [dbo].[UP_GetRecordByPage]    Script Date: 2020-6-24 12:38:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[UP_GetRecordByPage]
    @tblName      varchar(255),       -- 表名
    @fldName      varchar(255),       -- 主键字段名
    @PageSize     int = 10,           -- 页尺寸
    @PageIndex    int = 1,            -- 页码
    @IsReCount    bit = 0,            -- 返回记录总数, 非 0 值则返回
    @OrderType    bit = 0,            -- 设置排序类型, 非 0 值则降序
    @strWhere     varchar(max) = '', -- 查询条件 (注意: 不要加 where)
	@showFName	  varchar(max) = '*'  -- 显示字段
AS

declare @strSQL   varchar(max)       -- 主语句
declare @strTmp   varchar(max)        -- 临时变量(查询条件过长时可能会出错，可修改100为1000)
declare @strOrder varchar(400)        -- 排序类型

if @OrderType != 0
begin
    set @strTmp = '<(select min'
    set @strOrder = ' order by ' + @fldName +' desc'
end
else
begin
    set @strTmp = '>(select max'
    set @strOrder = ' order by ' + @fldName +' asc'
end

set @strSQL = 'select top ' + str(@PageSize) + ' '+ @showFName +' from '
    + @tblName + ' where ' + @fldName + '' + @strTmp + '('
    + @fldName + ') from (select top ' + str((@PageIndex-1)*@PageSize) + ' '
    + @fldName + ' from ' + @tblName + '' + @strOrder + ') as tblTmp)'
    + @strOrder

if @strWhere != ''
    set @strSQL = 'select top ' + str(@PageSize) + ' '+ @showFName +' from '
        + @tblName + ' where ' + @fldName + '' + @strTmp + '('
        + @fldName + ') from (select top ' + str((@PageIndex-1)*@PageSize) + ' '
        + @fldName + ' from ' + @tblName + ' where ' + @strWhere + ' '
        + @strOrder + ') as tblTmp) and ' + @strWhere + ' ' + @strOrder

if @PageIndex = 1
begin
    set @strTmp =''
    if @strWhere != ''
        set @strTmp = ' where ' + @strWhere

    set @strSQL = 'select top ' + str(@PageSize) + ' '+ @showFName +' from '
        + @tblName + '' + @strTmp + ' ' + @strOrder
end

if @IsReCount != 0
begin
if @strWhere != ''
	set @strWhere = ' where '+@strWhere;
    exec('select count(*) as Total from ' + @tblName + ''+ @strWhere);
end
--select @strSQL
exec (@strSQL)



GO
USE [master]
GO
ALTER DATABASE [BaseDb] SET  READ_WRITE 
GO
