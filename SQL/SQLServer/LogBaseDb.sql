USE [master]
GO
/****** Object:  Database [LogBaseDb]    Script Date: 2020-6-4 18:13:31 ******/
CREATE DATABASE [LogBaseDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LogBaseDb', FILENAME = N'E:\DB\LogBaseDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LogBaseDb_log', FILENAME = N'E:\DB\LogBaseDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [LogBaseDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LogBaseDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LogBaseDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LogBaseDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LogBaseDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LogBaseDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LogBaseDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [LogBaseDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LogBaseDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LogBaseDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LogBaseDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LogBaseDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LogBaseDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LogBaseDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LogBaseDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LogBaseDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LogBaseDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LogBaseDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LogBaseDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LogBaseDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LogBaseDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LogBaseDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LogBaseDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LogBaseDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LogBaseDb] SET RECOVERY FULL 
GO
ALTER DATABASE [LogBaseDb] SET  MULTI_USER 
GO
ALTER DATABASE [LogBaseDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LogBaseDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LogBaseDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LogBaseDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LogBaseDb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'LogBaseDb', N'ON'
GO
ALTER DATABASE [LogBaseDb] SET QUERY_STORE = OFF
GO
USE [LogBaseDb]
GO
/****** Object:  Table [dbo].[LogLevel]    Script Date: 2020-6-4 18:13:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LevelName] [nvarchar](50) NOT NULL,
	[LevelRemarks] [nvarchar](255) NULL,
	[Status] [bit] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_LogLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogRecord]    Script Date: 2020-6-4 18:13:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogRecord](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TypeId] [int] NOT NULL,
	[LevelId] [int] NOT NULL,
	[LogDetail] [nvarchar](max) NULL,
	[LogRemarks] [nvarchar](max) NULL,
	[LogUrl] [nvarchar](255) NULL,
	[LogCreatorId] [int] NOT NULL,
	[LogCreatorIP] [varchar](50) NOT NULL,
	[OperateTime] [datetime] NOT NULL,
	[DateCode] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_LogRecord] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogType]    Script Date: 2020-6-4 18:13:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](50) NOT NULL,
	[TypeRemarks] [nvarchar](255) NULL,
	[ClassId] [int] NOT NULL,
	[LevelId] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_LogType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogTypeClass]    Script Date: 2020-6-4 18:13:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogTypeClass](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](50) NOT NULL,
	[ClassRemarks] [nvarchar](255) NULL,
	[ParentId] [int] NOT NULL,
	[RootId] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[UpdateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_LogTypeClass] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LogLevel] ON 

INSERT [dbo].[LogLevel] ([Id], [LevelName], [LevelRemarks], [Status], [CreateTime], [UpdateTime]) VALUES (1, N'ERROR', N'引起系统错误的问题', 1, CAST(N'2020-05-25T23:28:13.080' AS DateTime), CAST(N'2020-05-25T23:28:13.080' AS DateTime))
INSERT [dbo].[LogLevel] ([Id], [LevelName], [LevelRemarks], [Status], [CreateTime], [UpdateTime]) VALUES (2, N'WARN', N'可疑的错误', 1, CAST(N'2020-05-25T23:30:03.227' AS DateTime), CAST(N'2020-05-25T23:30:03.227' AS DateTime))
INSERT [dbo].[LogLevel] ([Id], [LevelName], [LevelRemarks], [Status], [CreateTime], [UpdateTime]) VALUES (3, N'INFO', N'正常信息', 1, CAST(N'2020-05-25T23:30:11.287' AS DateTime), CAST(N'2020-05-25T23:30:11.287' AS DateTime))
INSERT [dbo].[LogLevel] ([Id], [LevelName], [LevelRemarks], [Status], [CreateTime], [UpdateTime]) VALUES (4, N'DEBUG', N'Debug信息', 1, CAST(N'2020-05-25T23:31:07.473' AS DateTime), CAST(N'2020-05-25T23:31:07.473' AS DateTime))
INSERT [dbo].[LogLevel] ([Id], [LevelName], [LevelRemarks], [Status], [CreateTime], [UpdateTime]) VALUES (5, N'CUSTOM', N'自定义信息', 1, CAST(N'2020-06-02T01:14:00.070' AS DateTime), CAST(N'2020-06-02T01:14:00.070' AS DateTime))
SET IDENTITY_INSERT [dbo].[LogLevel] OFF
GO
SET IDENTITY_INSERT [dbo].[LogRecord] ON 

SET IDENTITY_INSERT [dbo].[LogRecord] OFF
GO
SET IDENTITY_INSERT [dbo].[LogType] ON 

INSERT [dbo].[LogType] ([Id], [TypeName], [TypeRemarks], [ClassId], [LevelId], [Status], [CreateTime], [UpdateTime]) VALUES (1, N'系统错误', NULL, 1, 1, 1, CAST(N'2020-06-03T23:40:00.000' AS DateTime), CAST(N'2020-06-03T23:40:00.000' AS DateTime))
INSERT [dbo].[LogType] ([Id], [TypeName], [TypeRemarks], [ClassId], [LevelId], [Status], [CreateTime], [UpdateTime]) VALUES (2, N'请求SQL记录', NULL, 1, 3, 1, CAST(N'2020-06-04T00:06:54.000' AS DateTime), CAST(N'2020-06-04T00:06:54.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[LogType] OFF
GO
SET IDENTITY_INSERT [dbo].[LogTypeClass] ON 

INSERT [dbo].[LogTypeClass] ([Id], [ClassName], [ClassRemarks], [ParentId], [RootId], [CreateTime], [UpdateTime]) VALUES (1, N'系统默认', NULL, 0, 1, CAST(N'2020-06-03T23:38:50.303' AS DateTime), CAST(N'2020-06-03T23:38:50.303' AS DateTime))
SET IDENTITY_INSERT [dbo].[LogTypeClass] OFF
GO
ALTER TABLE [dbo].[LogLevel] ADD  CONSTRAINT [DF_LogLevel_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[LogLevel] ADD  CONSTRAINT [DF_LogLevel_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[LogLevel] ADD  CONSTRAINT [DF_LogLevel_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[LogRecord] ADD  CONSTRAINT [DF_LogRecord_OperateTime]  DEFAULT (getdate()) FOR [OperateTime]
GO
ALTER TABLE [dbo].[LogType] ADD  CONSTRAINT [DF_LogType_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[LogType] ADD  CONSTRAINT [DF_LogName_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[LogType] ADD  CONSTRAINT [DF_LogName_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
ALTER TABLE [dbo].[LogTypeClass] ADD  CONSTRAINT [DF_LogClass_Pid]  DEFAULT ((0)) FOR [ParentId]
GO
ALTER TABLE [dbo].[LogTypeClass] ADD  CONSTRAINT [DF_LogClass_RootId]  DEFAULT ((0)) FOR [RootId]
GO
ALTER TABLE [dbo].[LogTypeClass] ADD  CONSTRAINT [DF_LogClass_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[LogTypeClass] ADD  CONSTRAINT [DF_LogClass_UpdateTime]  DEFAULT (getdate()) FOR [UpdateTime]
GO
/****** Object:  StoredProcedure [dbo].[UP_GetRecordByPage]    Script Date: 2020-6-4 18:13:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



create PROCEDURE [dbo].[UP_GetRecordByPage]
    @tblName      varchar(255),       -- 表名
    @fldName      varchar(255),       -- 主键字段名
    @PageSize     int = 10,           -- 页尺寸
    @PageIndex    int = 1,            -- 页码
    @IsReCount    bit = 0,            -- 返回记录总数, 非 0 值则返回
    @OrderType    bit = 0,            -- 设置排序类型, 非 0 值则降序
    @strWhere     varchar(5000) = '', -- 查询条件 (注意: 不要加 where)
	@showFName	  varchar(5000) = '*'  -- 显示字段
AS

declare @strSQL   varchar(6000)       -- 主语句
declare @strTmp   varchar(2000)        -- 临时变量(查询条件过长时可能会出错，可修改100为1000)
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
ALTER DATABASE [LogBaseDb] SET  READ_WRITE 
GO
