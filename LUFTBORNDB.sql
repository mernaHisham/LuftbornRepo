/****** For creating DB ******/
use master
create database [LuftbornDB]
/******   Table [dbo].[Items]    ******/
USE [LuftbornDB]
GO

CREATE TABLE [dbo].[Items](
	[item_id] [int] IDENTITY(1,1) NOT NULL,
	[item_name] [nvarchar](50) NOT NULL,
	[price] [float] NOT NULL,
	[quantity] [int] NOT NULL,
	[status] [bit] NOT NULL,
	[description] [nvarchar](500) NULL,
	[created_by] [nvarchar](50) NOT NULL,
	[created_date] [datetime] NOT NULL,
	[updated_by] [nvarchar](50) NULL,
	[updated_date] [datetime] NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
	[item_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Items] ADD  CONSTRAINT [DF_Items_status]  DEFAULT ((1)) FOR [status]
GO

/*** or you can use this comman to migrate the database   ***/
/********
PM> Scaffold-DbContext "Server={serverName}\SQLEXPRESS;Database=LuftbornDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
******/
