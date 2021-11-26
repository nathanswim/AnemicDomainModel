USE [OnlineTheatre]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 2021-11-26 8:56:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [bigint] NOT NULL IDENTITY(1,1),
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Status] [int] NOT NULL,
	[StatusExpirationDate] [datetime] NULL,
	[MoneySpent] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 2021-11-26 8:56:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[MovieID] [bigint] NOT NULL identity(1,1),
	[Name] [nvarchar](50) NOT NULL,
	[LicensingModel] [int] NOT NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[MovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchasedMovie]    Script Date: 2021-11-26 8:56:30 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchasedMovie](
	[PurchasedMovieID] [bigint] NOT NULL identity(1,1),
	[MovieID] [bigint] NOT NULL,
	[CustomerID] [bigint] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[PurchaseDate] [datetime] NOT NULL,
	[ExpirationDate] [datetime] NULL,
 CONSTRAINT [PK_PurchasedMovie] PRIMARY KEY CLUSTERED 
(
	[PurchasedMovieID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
 
 SET IDENTITY_INSERT cUSTOMER ON
 GO
INSERT [dbo].[Customer] ([CustomerID], [Name], [Email], [Status], [StatusExpirationDate], [MoneySpent]) 
VALUES (1, N'James Peterson', N'james.peterson@gmail.com', 1, NULL, CAST(0.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Customer] ([CustomerID], [Name], [Email], [Status], [StatusExpirationDate], [MoneySpent]) 
VALUES (2, N'Michal Samson', N'm.samson@yahoo.com', 2, CAST(N'2018-09-19T20:54:00.000' AS DateTime), CAST(9.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT cUSTOMER OFF
GO




SET IDENTITY_INSERT [Movie] ON
GO 
INSERT [dbo].[Movie] ([MovieID], [Name], [LicensingModel]) 
VALUES (1, N'The Great Gatsby', 1)
GO
INSERT [dbo].[Movie] ([MovieID], [Name], [LicensingModel]) 
VALUES (2, N'The Secret Life of Pets', 2)
GO
SET IDENTITY_INSERT [Movie] OFF
GO 


SET IDENTITY_INSERT [PurchasedMovie] ON
GO 
INSERT [dbo].[PurchasedMovie] ([PurchasedMovieID], [CustomerID], [MovieID], [Price], [PurchaseDate], [ExpirationDate]) 
VALUES (1, 2, 1, 5, N'2017-09-16T16:30:05', N'2017-09-18T00:00:00')
GO
INSERT [dbo].[PurchasedMovie] ([PurchasedMovieID], [CustomerID], [MovieID], [Price], [PurchaseDate], [ExpirationDate]) 
VALUES (2, 2, 2, 4, N'2017-09-15T15:30:05', null)
GO
SET IDENTITY_INSERT [PurchasedMovie] OFF
GO 
