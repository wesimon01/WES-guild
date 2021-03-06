USE [master]
GO
/****** Object:  Database [BlogEngine]    Script Date: 8/4/2016 3:23:04 PM ******/
CREATE DATABASE [BlogEngine]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BlogEngine', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BlogEngine.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BlogEngine_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BlogEngine_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BlogEngine] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BlogEngine].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BlogEngine] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BlogEngine] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BlogEngine] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BlogEngine] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BlogEngine] SET ARITHABORT OFF 
GO
ALTER DATABASE [BlogEngine] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BlogEngine] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BlogEngine] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BlogEngine] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BlogEngine] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BlogEngine] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BlogEngine] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BlogEngine] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BlogEngine] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BlogEngine] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BlogEngine] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BlogEngine] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BlogEngine] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BlogEngine] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BlogEngine] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BlogEngine] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BlogEngine] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BlogEngine] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BlogEngine] SET  MULTI_USER 
GO
ALTER DATABASE [BlogEngine] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BlogEngine] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BlogEngine] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BlogEngine] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BlogEngine] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BlogEngine]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 8/4/2016 3:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Author](
	[AuthorID] [int] IDENTITY(1,1) NOT NULL,
	[AuthorName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Hashtag]    Script Date: 8/4/2016 3:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Hashtag](
	[HashtagID] [int] IDENTITY(1,1) NOT NULL,
	[HashtagName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Hashtag] PRIMARY KEY CLUSTERED 
(
	[HashtagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Page]    Script Date: 8/4/2016 3:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Page](
	[PageID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[PageContent] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Page] PRIMARY KEY CLUSTERED 
(
	[PageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Post]    Script Date: 8/4/2016 3:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Post](
	[PostID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[AuthorID] [int] NOT NULL,
	[PublishDate] [date] NOT NULL,
	[ExpireDate] [date] NULL,
	[IsApproved] [bit] NOT NULL,
	[PostContent] [varchar](max) NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[PostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PostHash]    Script Date: 8/4/2016 3:23:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostHash](
	[PostID] [int] NOT NULL,
	[HashtagID] [int] NOT NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([AuthorID], [AuthorName]) VALUES (1, N'Joey')
INSERT [dbo].[Author] ([AuthorID], [AuthorName]) VALUES (2, N'Malik')
INSERT [dbo].[Author] ([AuthorID], [AuthorName]) VALUES (3, N'Jason')
SET IDENTITY_INSERT [dbo].[Author] OFF
SET IDENTITY_INSERT [dbo].[Hashtag] ON 

INSERT [dbo].[Hashtag] ([HashtagID], [HashtagName]) VALUES (1, N'louisville')
INSERT [dbo].[Hashtag] ([HashtagID], [HashtagName]) VALUES (2, N'food')
INSERT [dbo].[Hashtag] ([HashtagID], [HashtagName]) VALUES (3, N'drinks')
SET IDENTITY_INSERT [dbo].[Hashtag] OFF
SET IDENTITY_INSERT [dbo].[Page] ON 

INSERT [dbo].[Page] ([PageID], [Title], [PageContent]) VALUES (1, N'About Me', N'Truffaut farm-to-table PBR&B artisan fashion axe, kogi mumblecore thundercats blog. Irony plaid ethical selfies, affogato everyday carry vice blog roof party umami hoodie narwhal kickstarter. Thundercats locavore organic lo-fi vinyl. Disrupt freegan bicycle rights DIY, single-origin coffee you probably haven''t heard of them occupy mumblecore typewriter drinking vinegar. Green juice mixtape authentic fixie, direct trade tousled hashtag microdosing freegan chartreuse tofu. Salvia messenger bag mumblecore pabst, semiotics slow-carb flexitarian pinterest scenester affogato listicle pug roof party. Asymmetrical dreamcatcher typewriter knausgaard meh.')
INSERT [dbo].[Page] ([PageID], [Title], [PageContent]) VALUES (2, N'Contact', N'Vegan beard portland brooklyn offal. Try-hard typewriter irony, sriracha wayfarers mlkshk gentrify scenester godard celiac kale chips post-ironic. Franzen celiac bitters pork belly sriracha. ')
SET IDENTITY_INSERT [dbo].[Page] OFF
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([PostID], [Title], [AuthorID], [PublishDate], [ExpireDate], [IsApproved], [PostContent]) VALUES (1, N'I still got it', 1, CAST(N'2016-08-04' AS Date), CAST(N'2016-09-04' AS Date), 1, N'ads;flajssjwennas;oiaansdeaklsdjfo alsjowae')
INSERT [dbo].[Post] ([PostID], [Title], [AuthorID], [PublishDate], [ExpireDate], [IsApproved], [PostContent]) VALUES (2, N'Grand Opening', 2, CAST(N'2016-08-03' AS Date), NULL, 0, N'as;ldfkja;sfoiaweasoifo')
INSERT [dbo].[Post] ([PostID], [Title], [AuthorID], [PublishDate], [ExpireDate], [IsApproved], [PostContent]) VALUES (3, N'I like to kickbox', 3, CAST(N'2016-08-06' AS Date), NULL, 1, N'a;sdlfjaoifwf,nfafwq wn qc qcq ecnqer')
SET IDENTITY_INSERT [dbo].[Post] OFF
INSERT [dbo].[PostHash] ([PostID], [HashtagID]) VALUES (1, 1)
INSERT [dbo].[PostHash] ([PostID], [HashtagID]) VALUES (2, 2)
INSERT [dbo].[PostHash] ([PostID], [HashtagID]) VALUES (3, 3)
INSERT [dbo].[PostHash] ([PostID], [HashtagID]) VALUES (2, 1)
INSERT [dbo].[PostHash] ([PostID], [HashtagID]) VALUES (3, 2)
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_Author] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Author] ([AuthorID])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_Author]
GO
USE [master]
GO
ALTER DATABASE [BlogEngine] SET  READ_WRITE 
GO
