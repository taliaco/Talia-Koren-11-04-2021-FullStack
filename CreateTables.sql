USE [Talia_Weather]
GO
/****** Object:  Table [dbo].[CityWeather]    Script Date: 11/04/2021 11:35:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CityWeather](
	[Key] [varchar](50) NOT NULL,
	[LocalizedName] [varchar](250) NOT NULL,
	[TemperatureC] [float] NOT NULL,
	[WeatherText] [varchar](250) NOT NULL,
 CONSTRAINT [PK_CityWeather] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favorite]    Script Date: 11/04/2021 11:35:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favorite](
	[Key] [varchar](50) NOT NULL,
	[LocalizedName] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Favorites] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CityWeather] ([Key], [LocalizedName], [TemperatureC], [WeatherText]) VALUES (N'300558', N'Telok Blangah New Town', 12.2, N'text from DB')
GO
INSERT [dbo].[Favorite] ([Key], [LocalizedName]) VALUES (N'170137', N'Eil')
GO
INSERT [dbo].[Favorite] ([Key], [LocalizedName]) VALUES (N'213225', N'Jerusalem')
GO
INSERT [dbo].[Favorite] ([Key], [LocalizedName]) VALUES (N'215854', N'Tel Aviv')
GO
INSERT [dbo].[Favorite] ([Key], [LocalizedName]) VALUES (N'300558', N'Telok Blangah New Town')
GO
INSERT [dbo].[Favorite] ([Key], [LocalizedName]) VALUES (N'3453754', N'Telaga Asih')
GO
INSERT [dbo].[Favorite] ([Key], [LocalizedName]) VALUES (N'3453755', N'Telagamurni')
GO
