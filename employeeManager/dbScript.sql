CREATE DATABASE nogaDB
GO

USE [nogaDB]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 12/17/2022 3:27:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[Id] [nvarchar](150) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Street] [nvarchar](50) NOT NULL,
	[CustomerId] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 12/17/2022 3:27:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [nvarchar](150) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[OfficeNumber] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[CustomerId] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/17/2022 3:27:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [nvarchar](150) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CustomerNumber] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Addresses] ([Id], [IsDeleted], [Created], [City], [Street], [CustomerId]) VALUES (N'0lM7X3Q4oFXf6PtoIsIQ7', 0, CAST(N'2022-12-16T22:02:11.573' AS DateTime), N'new Jerzy', N'alora dance', N'q1tm1nWQbNAB9YvrZliWt')
INSERT [dbo].[Addresses] ([Id], [IsDeleted], [Created], [City], [Street], [CustomerId]) VALUES (N'4fLEsgPuRJiU-llIryKGk', 0, CAST(N'2022-12-17T01:32:33.003' AS DateTime), N'sleepland', N'sleppy', N'sJdW30JwCsrZAmKMOJVc-')
INSERT [dbo].[Addresses] ([Id], [IsDeleted], [Created], [City], [Street], [CustomerId]) VALUES (N'6FhIFszC6ttlnvPrBSDlR', 0, CAST(N'2022-12-17T01:29:32.647' AS DateTime), N'zqar', N'kjir', N'57mOWjJwwWaBcztPSVVhR')
INSERT [dbo].[Addresses] ([Id], [IsDeleted], [Created], [City], [Street], [CustomerId]) VALUES (N'972kWSTl_VnB-CST5X0Fd', 0, CAST(N'2022-12-17T01:19:31.883' AS DateTime), N'ziara', N'fitter', N'cfy4FrAdCqJEsgSQmswa_')
INSERT [dbo].[Addresses] ([Id], [IsDeleted], [Created], [City], [Street], [CustomerId]) VALUES (N'd3QqpGHiR5PFKU-vwHISL', 0, CAST(N'2022-12-17T01:31:13.380' AS DateTime), N'okaaha', N'kokalaca', N'KFUIUgO4GULH7klc1mh4M')
INSERT [dbo].[Addresses] ([Id], [IsDeleted], [Created], [City], [Street], [CustomerId]) VALUES (N'F6H_QqjfYozHkK_CjZR9y', 1, CAST(N'2022-12-16T16:09:42.710' AS DateTime), N'new york', N'holim', N'Epq7B-KocVGncZ_3VaDZE')
INSERT [dbo].[Addresses] ([Id], [IsDeleted], [Created], [City], [Street], [CustomerId]) VALUES (N'PayrxvFbtFOIJpn_zg6Ov', 1, CAST(N'2022-12-16T21:58:13.923' AS DateTime), N'new ziland', N'tetris99', N'q1tm1nWQbNAB9YvrZliWt')
INSERT [dbo].[Addresses] ([Id], [IsDeleted], [Created], [City], [Street], [CustomerId]) VALUES (N'yeI-Bw2ivEmB5jKFYTrs1', 0, CAST(N'2022-12-17T13:31:10.700' AS DateTime), N'haifa', N'abonum', N'BtuIjuy8R98l3SNwMV9QC')
GO
INSERT [dbo].[Contacts] ([Id], [IsDeleted], [Created], [FullName], [OfficeNumber], [Email], [CustomerId]) VALUES (N'00xF4gmjCSV2cwEgORmV5', 0, CAST(N'2022-12-17T01:29:32.647' AS DateTime), N'loran', N'+9124949494', N'loran@gmail.com', N'57mOWjJwwWaBcztPSVVhR')
INSERT [dbo].[Contacts] ([Id], [IsDeleted], [Created], [FullName], [OfficeNumber], [Email], [CustomerId]) VALUES (N'6WGLb6qps_DcOwCLSIDe8', 0, CAST(N'2022-12-16T21:58:13.923' AS DateTime), N'mia xeri', N'+567-4717403', N'kover@gmail.com', N'q1tm1nWQbNAB9YvrZliWt')
INSERT [dbo].[Contacts] ([Id], [IsDeleted], [Created], [FullName], [OfficeNumber], [Email], [CustomerId]) VALUES (N'8lxmGWfiqFEeN2fzfHuhi', 0, CAST(N'2022-12-16T16:17:47.167' AS DateTime), N'Heim hamilir', N'+152-432432443', N'hes.as@gmail.com', N'Epq7B-KocVGncZ_3VaDZE')
INSERT [dbo].[Contacts] ([Id], [IsDeleted], [Created], [FullName], [OfficeNumber], [Email], [CustomerId]) VALUES (N'8YibSJhcr0M51Y1SHP-KA', 0, CAST(N'2022-12-17T01:31:13.380' AS DateTime), N'oke waka', N'+512333939', N'waka@gmail.com', N'KFUIUgO4GULH7klc1mh4M')
INSERT [dbo].[Contacts] ([Id], [IsDeleted], [Created], [FullName], [OfficeNumber], [Email], [CustomerId]) VALUES (N'Ai5z6HU5R3RoLrW8kW9AJ', 0, CAST(N'2022-12-17T01:32:33.003' AS DateTime), N'sleep now', N'+15151515', N'sleepwhen@gmail.com', N'sJdW30JwCsrZAmKMOJVc-')
INSERT [dbo].[Contacts] ([Id], [IsDeleted], [Created], [FullName], [OfficeNumber], [Email], [CustomerId]) VALUES (N'bAicUwZOdqE7BIfoHhbOw', 0, CAST(N'2022-12-16T16:22:16.290' AS DateTime), N'zari hembur', N'+517-4777443', N'kissnlove@gmail.com', N'q1tm1nWQbNAB9YvrZliWt')
INSERT [dbo].[Contacts] ([Id], [IsDeleted], [Created], [FullName], [OfficeNumber], [Email], [CustomerId]) VALUES (N'BohwluUz_KrBeYZPD0DXX', 0, CAST(N'2022-12-16T16:22:16.293' AS DateTime), N'miar almoni', N'+315-12435447', N'miar.almoni@gmail.com', N'q1tm1nWQbNAB9YvrZliWt')
INSERT [dbo].[Contacts] ([Id], [IsDeleted], [Created], [FullName], [OfficeNumber], [Email], [CustomerId]) VALUES (N'FopY-B23UC0Gg3wuroKKG', 0, CAST(N'2022-12-17T13:31:10.700' AS DateTime), N'ambrose finally', N'041-4444444', N'ambf@gmail.com', N'JlZYO1EpezG3AtTi7xrVY')
INSERT [dbo].[Contacts] ([Id], [IsDeleted], [Created], [FullName], [OfficeNumber], [Email], [CustomerId]) VALUES (N'GRj0ooRb02_gRik1tPy_M', 0, CAST(N'2022-12-17T01:19:31.007' AS DateTime), N'madax', N'044444444', N'mad@gma.co', N'cfy4FrAdCqJEsgSQmswa_')
INSERT [dbo].[Contacts] ([Id], [IsDeleted], [Created], [FullName], [OfficeNumber], [Email], [CustomerId]) VALUES (N'HKFksKOoYGF3gWVFYawqh', 0, CAST(N'2022-12-16T22:02:11.573' AS DateTime), N'shior', N'+514-999511', N'shir.lior@gmail.com', N'q1tm1nWQbNAB9YvrZliWt')
INSERT [dbo].[Contacts] ([Id], [IsDeleted], [Created], [FullName], [OfficeNumber], [Email], [CustomerId]) VALUES (N'i3rZk-q96_Lej1TVa8bDc', 0, CAST(N'2022-12-16T16:09:42.710' AS DateTime), N'mo dyer', N'013-23232542323', N'mos@gmail.com', N'Epq7B-KocVGncZ_3VaDZE')
INSERT [dbo].[Contacts] ([Id], [IsDeleted], [Created], [FullName], [OfficeNumber], [Email], [CustomerId]) VALUES (N'QJFkHwwPHIVHgriJDSE4T', 0, CAST(N'2022-12-16T22:02:11.573' AS DateTime), N'miachael', N'+567-4711113', N'michale@gmail.com', N'q1tm1nWQbNAB9YvrZliWt')
INSERT [dbo].[Contacts] ([Id], [IsDeleted], [Created], [FullName], [OfficeNumber], [Email], [CustomerId]) VALUES (N'sPbZtGLyxI3O3xz8WhFzO', 0, CAST(N'2022-12-17T13:31:10.700' AS DateTime), N'ambrose finally', N'041-4444444', N'ambf@gmail.com', N'BtuIjuy8R98l3SNwMV9QC')
INSERT [dbo].[Contacts] ([Id], [IsDeleted], [Created], [FullName], [OfficeNumber], [Email], [CustomerId]) VALUES (N'tXvseIw7F7EfzPeIpOysZ', 0, CAST(N'2022-12-16T21:58:13.923' AS DateTime), N'miarani', N'+314-1243511', N'shi.almon@gmail.com', N'q1tm1nWQbNAB9YvrZliWt')
GO
INSERT [dbo].[Customers] ([Id], [IsDeleted], [Created], [Name], [CustomerNumber]) VALUES (N'57mOWjJwwWaBcztPSVVhR', 0, CAST(N'2022-12-17T01:29:32.647' AS DateTime), N'lora', N'132123451')
INSERT [dbo].[Customers] ([Id], [IsDeleted], [Created], [Name], [CustomerNumber]) VALUES (N'BtuIjuy8R98l3SNwMV9QC', 0, CAST(N'2022-12-17T13:31:10.693' AS DateTime), N'kierra neitly', N'965123123')
INSERT [dbo].[Customers] ([Id], [IsDeleted], [Created], [Name], [CustomerNumber]) VALUES (N'cfy4FrAdCqJEsgSQmswa_', 0, CAST(N'2022-12-17T01:19:22.540' AS DateTime), N'mada', N'449494944')
INSERT [dbo].[Customers] ([Id], [IsDeleted], [Created], [Name], [CustomerNumber]) VALUES (N'Epq7B-KocVGncZ_3VaDZE', 0, CAST(N'2022-12-16T16:09:42.697' AS DateTime), N'moshe', N'513123123')
INSERT [dbo].[Customers] ([Id], [IsDeleted], [Created], [Name], [CustomerNumber]) VALUES (N'KFUIUgO4GULH7klc1mh4M', 0, CAST(N'2022-12-17T01:31:13.380' AS DateTime), N'okar', N'49696966')
INSERT [dbo].[Customers] ([Id], [IsDeleted], [Created], [Name], [CustomerNumber]) VALUES (N'q1tm1nWQbNAB9YvrZliWt', 0, CAST(N'2022-12-16T16:22:16.283' AS DateTime), N'arold', N'5178787777')
INSERT [dbo].[Customers] ([Id], [IsDeleted], [Created], [Name], [CustomerNumber]) VALUES (N'sJdW30JwCsrZAmKMOJVc-', 0, CAST(N'2022-12-17T01:32:33.003' AS DateTime), N'sleep', N'54050554')
GO
