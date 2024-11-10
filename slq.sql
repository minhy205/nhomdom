USE [master]
GO
/****** Object:  Database [CaKoi_Store]    Script Date: 09/11/2024 2:13:29 CH ******/
CREATE DATABASE [CaKoi_Store]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CaKoi_Store', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\CaKoi_Store.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CaKoi_Store_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\CaKoi_Store_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [CaKoi_Store] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CaKoi_Store].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CaKoi_Store] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CaKoi_Store] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CaKoi_Store] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CaKoi_Store] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CaKoi_Store] SET ARITHABORT OFF 
GO
ALTER DATABASE [CaKoi_Store] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CaKoi_Store] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CaKoi_Store] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CaKoi_Store] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CaKoi_Store] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CaKoi_Store] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CaKoi_Store] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CaKoi_Store] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CaKoi_Store] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CaKoi_Store] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CaKoi_Store] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CaKoi_Store] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CaKoi_Store] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CaKoi_Store] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CaKoi_Store] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CaKoi_Store] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CaKoi_Store] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CaKoi_Store] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CaKoi_Store] SET  MULTI_USER 
GO
ALTER DATABASE [CaKoi_Store] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CaKoi_Store] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CaKoi_Store] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CaKoi_Store] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CaKoi_Store] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CaKoi_Store] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CaKoi_Store] SET QUERY_STORE = ON
GO
ALTER DATABASE [CaKoi_Store] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [CaKoi_Store]
GO
/****** Object:  Table [dbo].[Consignment]    Script Date: 09/11/2024 2:13:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consignment](
	[Consignment_id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_id] [int] NULL,
	[Koi_id] [int] NULL,
	[Consignment_date] [datetime] NULL,
	[Status] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Consignment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 09/11/2024 2:13:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Customer_id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[Phone] [varchar](20) NULL,
	[Address] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[Customer_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dashboard_Reports]    Script Date: 09/11/2024 2:13:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dashboard_Reports](
	[Report_id] [int] IDENTITY(1,1) NOT NULL,
	[Report_date] [datetime] NULL,
	[Total_sales] [decimal](10, 2) NULL,
	[Total_customers] [int] NULL,
	[Total_koi_sold] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Report_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FAQs]    Script Date: 09/11/2024 2:13:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAQs](
	[FAQ_id] [int] IDENTITY(1,1) NOT NULL,
	[Question] [text] NULL,
	[Answer] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[FAQ_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 09/11/2024 2:13:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[Feedback_id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_id] [int] NULL,
	[Koi_id] [int] NULL,
	[Feedback_text] [text] NULL,
	[Rating] [int] NULL,
	[Response] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[Feedback_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Koi]    Script Date: 09/11/2024 2:13:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Koi](
	[Koi_id] [int] IDENTITY(1,1) NOT NULL,
	[Breed] [varchar](100) NULL,
	[Origin] [varchar](100) NULL,
	[Gender] [varchar](10) NULL,
	[Age] [int] NULL,
	[Size] [decimal](5, 2) NULL,
	[Personality] [text] NULL,
	[Food_per_day] [decimal](5, 2) NULL,
	[Screening_rate] [decimal](5, 2) NULL,
	[Price] [decimal](10, 2) NULL,
	[Status] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Koi_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Managers]    Script Date: 09/11/2024 2:13:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Managers](
	[Manager_id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[Phone] [varchar](20) NULL,
	[Hire_date] [datetime] NULL,
	[Role] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Manager_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Comments]    Script Date: 09/11/2024 2:13:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Comments](
	[Comment_id] [int] IDENTITY(1,1) NOT NULL,
	[Order_id] [int] NOT NULL,
	[Customer_id] [int] NOT NULL,
	[Comment_text] [text] NOT NULL,
	[Rating] [int] NULL,
	[Comment_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Comment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Details]    Script Date: 09/11/2024 2:13:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Details](
	[Order_detail_id] [int] IDENTITY(1,1) NOT NULL,
	[Order_id] [int] NULL,
	[Koi_id] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Order_detail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 09/11/2024 2:13:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Order_id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_id] [int] NULL,
	[Order_date] [datetime] NULL,
	[Total_amount] [decimal](10, 2) NULL,
	[Status] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment_History]    Script Date: 09/11/2024 2:13:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment_History](
	[Payment_id] [int] IDENTITY(1,1) NOT NULL,
	[Customer_id] [int] NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[Payment_method] [varchar](50) NULL,
	[Payment_date] [datetime] NULL,
	[Status] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Payment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promotions]    Script Date: 09/11/2024 2:13:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotions](
	[Promotion_id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NULL,
	[Discount_percentage] [decimal](5, 2) NULL,
	[Start_date] [datetime] NULL,
	[End_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Promotion_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 09/11/2024 2:13:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[Staff_id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[Phone] [varchar](20) NULL,
	[Hire_date] [datetime] NULL,
	[Role] [varchar](100) NULL,
	[Manager_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Staff_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 09/11/2024 2:13:29 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Customer__A9D1053434BDE341]    Script Date: 09/11/2024 2:13:29 CH ******/
ALTER TABLE [dbo].[Customers] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Managers__A9D1053465A5F11C]    Script Date: 09/11/2024 2:13:29 CH ******/
ALTER TABLE [dbo].[Managers] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Staff__A9D10534E73CE7C6]    Script Date: 09/11/2024 2:13:29 CH ******/
ALTER TABLE [dbo].[Staff] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__F3DBC572DF6B43DC]    Script Date: 09/11/2024 2:13:29 CH ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Order_Comments] ADD  DEFAULT (getdate()) FOR [Comment_date]
GO
ALTER TABLE [dbo].[Payment_History] ADD  DEFAULT (getdate()) FOR [Payment_date]
GO
ALTER TABLE [dbo].[Consignment]  WITH CHECK ADD FOREIGN KEY([Customer_id])
REFERENCES [dbo].[Customers] ([Customer_id])
GO
ALTER TABLE [dbo].[Consignment]  WITH CHECK ADD FOREIGN KEY([Koi_id])
REFERENCES [dbo].[Koi] ([Koi_id])
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([Customer_id])
REFERENCES [dbo].[Customers] ([Customer_id])
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([Koi_id])
REFERENCES [dbo].[Koi] ([Koi_id])
GO
ALTER TABLE [dbo].[Order_Comments]  WITH CHECK ADD FOREIGN KEY([Customer_id])
REFERENCES [dbo].[Customers] ([Customer_id])
GO
ALTER TABLE [dbo].[Order_Comments]  WITH CHECK ADD FOREIGN KEY([Order_id])
REFERENCES [dbo].[Orders] ([Order_id])
GO
ALTER TABLE [dbo].[Order_Details]  WITH CHECK ADD FOREIGN KEY([Koi_id])
REFERENCES [dbo].[Koi] ([Koi_id])
GO
ALTER TABLE [dbo].[Order_Details]  WITH CHECK ADD FOREIGN KEY([Order_id])
REFERENCES [dbo].[Orders] ([Order_id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([Customer_id])
REFERENCES [dbo].[Customers] ([Customer_id])
GO
ALTER TABLE [dbo].[Payment_History]  WITH CHECK ADD FOREIGN KEY([Customer_id])
REFERENCES [dbo].[Customers] ([Customer_id])
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD FOREIGN KEY([Manager_id])
REFERENCES [dbo].[Managers] ([Manager_id])
GO
ALTER TABLE [dbo].[Consignment]  WITH CHECK ADD CHECK  (([Status]='cancelled' OR [Status]='completed' OR [Status]='pending'))
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD CHECK  (([Rating]>=(1) AND [Rating]<=(5)))
GO
ALTER TABLE [dbo].[Koi]  WITH CHECK ADD CHECK  (([Status]='for_sale' OR [Status]='in_care' OR [Status]='sold' OR [Status]='available'))
GO
ALTER TABLE [dbo].[Order_Comments]  WITH CHECK ADD CHECK  (([Rating]>=(1) AND [Rating]<=(5)))
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD CHECK  (([Status]='cancelled' OR [Status]='completed' OR [Status]='pending'))
GO
ALTER TABLE [dbo].[Payment_History]  WITH CHECK ADD CHECK  (([Status]='failed' OR [Status]='pending' OR [Status]='completed'))
GO
USE [master]
GO
ALTER DATABASE [CaKoi_Store] SET  READ_WRITE 
GO
