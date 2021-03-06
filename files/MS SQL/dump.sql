USE [PGUTI_faculty]
GO
ALTER TABLE [dbo].[Training_dates] DROP CONSTRAINT [Training_dates_fk1]
GO
ALTER TABLE [dbo].[Teachers] DROP CONSTRAINT [Faculty_Job_title_fk]
GO
ALTER TABLE [dbo].[Teachers] DROP CONSTRAINT [Faculty_fk2]
GO
ALTER TABLE [dbo].[Teachers] DROP CONSTRAINT [Faculty_fk1]
GO
ALTER TABLE [dbo].[Teachers] DROP CONSTRAINT [Faculty_Cairs_fk]
GO
ALTER TABLE [dbo].[Record_Teachers] DROP CONSTRAINT [Faculty_Job_title_1fk]
GO
ALTER TABLE [dbo].[Record_Teachers] DROP CONSTRAINT [Faculty_Cairs_1fk]
GO
ALTER TABLE [dbo].[Record_Teachers] DROP CONSTRAINT [Faculty_1fk2]
GO
ALTER TABLE [dbo].[Record_Teachers] DROP CONSTRAINT [Faculty_1fk1]
GO
/****** Object:  Table [dbo].[Working_positions]    Script Date: 03.06.2016 13:44:49 ******/
DROP TABLE [dbo].[Working_positions]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 03.06.2016 13:44:49 ******/
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[Training_dates]    Script Date: 03.06.2016 13:44:49 ******/
DROP TABLE [dbo].[Training_dates]
GO
/****** Object:  Table [dbo].[Titles]    Script Date: 03.06.2016 13:44:49 ******/
DROP TABLE [dbo].[Titles]
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 03.06.2016 13:44:49 ******/
DROP TABLE [dbo].[Teachers]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 03.06.2016 13:44:49 ******/
DROP TABLE [dbo].[Roles]
GO
/****** Object:  Table [dbo].[Records]    Script Date: 03.06.2016 13:44:49 ******/
DROP TABLE [dbo].[Records]
GO
/****** Object:  Table [dbo].[Record_Teachers]    Script Date: 03.06.2016 13:44:49 ******/
DROP TABLE [dbo].[Record_Teachers]
GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 03.06.2016 13:44:49 ******/
DROP TABLE [dbo].[Faculties]
GO
/****** Object:  Table [dbo].[Degrees]    Script Date: 03.06.2016 13:44:49 ******/
DROP TABLE [dbo].[Degrees]
GO
/****** Object:  Table [dbo].[Cairs]    Script Date: 03.06.2016 13:44:49 ******/
DROP TABLE [dbo].[Cairs]
GO
/****** Object:  Table [dbo].[Cairs]    Script Date: 03.06.2016 13:44:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cairs](
	[id] [int] NOT NULL,
	[name] [varchar](100) NULL,
	[second_name] [varchar](50) NULL,
 CONSTRAINT [PK_Chairs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Degrees]    Script Date: 03.06.2016 13:44:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Degrees](
	[id] [int] NOT NULL,
	[name] [varchar](50) NULL,
	[second_name] [varchar](50) NULL,
 CONSTRAINT [PK_ACADEMIC_TITLES] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 03.06.2016 13:44:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Faculties](
	[id] [int] NOT NULL,
	[name] [varchar](100) NULL,
	[second_name] [varchar](50) NULL,
 CONSTRAINT [PK_Faculties] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Record_Teachers]    Script Date: 03.06.2016 13:44:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Record_Teachers](
	[id] [int] NOT NULL,
	[Cairs] [int] NULL,
	[Job_title] [int] NULL,
	[surname] [varchar](50) NULL,
	[name] [varchar](50) NULL,
	[middlename] [varchar](50) NULL,
	[gender] [varchar](5) NULL,
	[birthday] [date] NULL,
	[passport_serial] [int] NULL,
	[passport_number] [bigint] NULL,
	[passport_gives] [text] NULL,
	[passport_create] [date] NULL,
	[registration] [varchar](50) NULL,
	[telephone] [varchar](50) NULL,
	[educational_institution] [varchar](50) NULL,
	[specialty_of_diplom] [varchar](50) NULL,
	[titles_id] [int] NULL,
	[titles_date] [date] NULL,
	[degrees_id] [int] NULL,
	[degress_date] [date] NULL,
	[terms_of_work] [varchar](200) NULL,
	[competitive_selection_start_date] [date] NULL,
	[competitive_selection_end_date] [date] NULL,
	[experience_date] [date] NULL,
	[total_experience_date] [date] NULL,
	[Dekan_Faculties] [int] NULL,
	[rate] [float] NULL,
	[Training_dates] [date] NULL,
	[education_date] [date] NULL,
	[enable] [bit] NULL,
	[start_date] [date] NULL,
	[end_date] [date] NULL,
	[Training_dates_end] [date] NULL,
	[Training_place] [text] NULL,
	[Teacher_id] [int] NULL,
 CONSTRAINT [PK_Faculty1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Records]    Script Date: 03.06.2016 13:44:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Records](
	[id] [int] NOT NULL,
	[Cairs] [int] NULL,
	[Job_title] [int] NULL,
	[surname] [varchar](50) NULL,
	[name] [varchar](50) NULL,
	[middlename] [varchar](50) NULL,
	[titles_id] [int] NULL,
	[titles_date] [datetime] NULL,
	[degrees_id] [int] NULL,
	[degress_date] [datetime] NULL,
	[terms_of_work] [text] NULL,
	[date] [datetime] NULL,
 CONSTRAINT [PK_RECORDS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 03.06.2016 13:44:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roles](
	[id] [int] NOT NULL,
	[role] [varchar](50) NOT NULL,
	[login] [varchar](100) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 03.06.2016 13:44:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teachers](
	[id] [int] NOT NULL,
	[Cairs] [int] NULL,
	[Job_title] [int] NULL,
	[surname] [varchar](50) NULL,
	[name] [varchar](50) NULL,
	[middlename] [varchar](50) NULL,
	[gender] [varchar](5) NULL,
	[birthday] [date] NULL,
	[passport_serial] [int] NULL,
	[passport_number] [bigint] NULL,
	[passport_gives] [text] NULL,
	[passport_create] [date] NULL,
	[registration] [varchar](50) NULL,
	[telephone] [varchar](50) NULL,
	[educational_institution] [varchar](50) NULL,
	[specialty_of_diplom] [varchar](50) NULL,
	[titles_id] [int] NULL,
	[titles_date] [date] NULL,
	[degrees_id] [int] NULL,
	[degress_date] [date] NULL,
	[terms_of_work] [varchar](200) NULL,
	[competitive_selection_start_date] [date] NULL,
	[competitive_selection_end_date] [date] NULL,
	[experience_date] [date] NULL,
	[total_experience_date] [date] NULL,
	[Dekan_Faculties] [int] NULL,
	[rate] [float] NULL,
	[Training_dates] [date] NULL,
	[education_date] [date] NULL,
	[enable] [bit] NULL,
	[start_date] [date] NULL,
	[end_date] [date] NULL,
	[Training_dates_end] [date] NULL,
	[Training_place] [text] NULL,
 CONSTRAINT [PK_Faculty] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Titles]    Script Date: 03.06.2016 13:44:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Titles](
	[id] [int] NOT NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_SCIENTIFIC_DEGREES] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Training_dates]    Script Date: 03.06.2016 13:44:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Training_dates](
	[id] [int] NOT NULL,
	[date] [datetime] NULL,
	[prepod_id] [int] NULL,
	[info] [text] NULL,
 CONSTRAINT [PK_TRAINING_DATES] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 03.06.2016 13:44:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[login] [varchar](100) NOT NULL,
	[password] [varchar](100) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Working_positions]    Script Date: 03.06.2016 13:44:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Working_positions](
	[id] [int] NOT NULL,
	[name] [varchar](50) NULL,
 CONSTRAINT [PK_WORKING_POSITIONS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (1, N'Кафедра высшей математики', N'Кафедра высшей математики')
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (2, N'Кафедра физики', N'Кафедра физики')
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (3, N'Кафедра философии', N'Кафедра философии')
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (4, N'Кафедра физвоспитания', N'Кафедра физвоспитания')
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (5, N'Кафедра электродинамики и антенн', N'(Э и А)')
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (6, N'Кафедра теоретических основ радиотехники и связи', N'(ТОРС)')
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (7, N'Кафедра информатики и вычислительной техники', N'(ИВТ)')
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (8, N'Кафедра программного обеспечения и управления в технических системах', N'(ПОУТС)')
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (9, N'Кафедра инженерий знаний', N'(ИЗ)')
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (10, N'Кафедра иностранных языков', N'Кафедра иностранных языков')
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (11, N'Кафедра информационных систем и технологий', N'(ИСТ)')
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (12, N'Кафедра экономических и информационных систем', N'(ЭИС)')
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (13, N'Кафедра электронной коммерции', N'(ЭК)')
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (14, N'Кафедра связей с общественностью', N'(СО)')
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (15, N'Кафедра автоматической электросвязи', N'(АЭС)')
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (16, N'Кафедра систем связи', N'(СС)')
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (17, N'Кафедра мультисервисных сетей и информационной безопасности', N'(МСИБ)')
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (18, N'Кафедра экономики и организации производства', N'(Э и ОП)')
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (19, N'Кафедра линий связи и измерений в технике связи', N'(ЛС и ИТС)')
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (20, N'Кафедра радиосвязи, радиовещания и телевидения', N'(РРТ)')
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (21, N'Кафедра основы конструирования и технологий радиотехнических систем', N'(ОК и Т РТС)')
INSERT [dbo].[Cairs] ([id], [name], [second_name]) VALUES (22, N'Кафедра инновационных технологий телекоммуникаций', N'(ИТТ)')
INSERT [dbo].[Degrees] ([id], [name], [second_name]) VALUES (1, N'Младший научный сотрудник', N'мл. науч. сотр.')
INSERT [dbo].[Degrees] ([id], [name], [second_name]) VALUES (2, N'Научный сотрудник', N'науч. сотр.')
INSERT [dbo].[Degrees] ([id], [name], [second_name]) VALUES (3, N'Старший научный сотрудник', N'ст. науч. сотр.')
INSERT [dbo].[Degrees] ([id], [name], [second_name]) VALUES (4, N'Академик', N'акад.')
INSERT [dbo].[Degrees] ([id], [name], [second_name]) VALUES (5, N'Кандидат юридических наук', N'канд. юрид. наук')
INSERT [dbo].[Degrees] ([id], [name], [second_name]) VALUES (6, N'Кандидат экономических наук', N'канд. экон. наук')
INSERT [dbo].[Degrees] ([id], [name], [second_name]) VALUES (7, N'Кандидат философских наук', N'канд. филос. наук')
INSERT [dbo].[Degrees] ([id], [name], [second_name]) VALUES (8, N'Кандидат физико-математических наук', N'канд. физ.-мат. наук')
INSERT [dbo].[Degrees] ([id], [name], [second_name]) VALUES (9, N'Кандидат технических наук', N'канд. техн. наук')
INSERT [dbo].[Degrees] ([id], [name], [second_name]) VALUES (10, N'Кандидат социологических наук', N'канд. социол. наук')
INSERT [dbo].[Degrees] ([id], [name], [second_name]) VALUES (11, N'Доктор экономических наук', N'д-р экон. наук')
INSERT [dbo].[Degrees] ([id], [name], [second_name]) VALUES (12, N'Доктор философских наук', N'д-р филос. наук')
INSERT [dbo].[Degrees] ([id], [name], [second_name]) VALUES (13, N'Доктор физико-математических наук', N'д-р физ.-мат. наук')
INSERT [dbo].[Degrees] ([id], [name], [second_name]) VALUES (14, N'Доктор технических наук', N'д-р техн. наук')
INSERT [dbo].[Degrees] ([id], [name], [second_name]) VALUES (15, N'Доктор социологических наук', N'д-р социол. наук')
INSERT [dbo].[Degrees] ([id], [name], [second_name]) VALUES (16, NULL, NULL)
INSERT [dbo].[Faculties] ([id], [name], [second_name]) VALUES (1, N'Факультет Базового телекоммуникационного Образования', N'ФБТО')
INSERT [dbo].[Faculties] ([id], [name], [second_name]) VALUES (2, N'Факультет информационных систем и технологий', N'ФИСТ')
INSERT [dbo].[Faculties] ([id], [name], [second_name]) VALUES (3, N'Факультет телекоммуникаций и радиотехники', N'ФТР')
INSERT [dbo].[Faculties] ([id], [name], [second_name]) VALUES (4, N'Факультет заочного обучения', N'ФЗО')
INSERT [dbo].[Record_Teachers] ([id], [Cairs], [Job_title], [surname], [name], [middlename], [gender], [birthday], [passport_serial], [passport_number], [passport_gives], [passport_create], [registration], [telephone], [educational_institution], [specialty_of_diplom], [titles_id], [titles_date], [degrees_id], [degress_date], [terms_of_work], [competitive_selection_start_date], [competitive_selection_end_date], [experience_date], [total_experience_date], [Dekan_Faculties], [rate], [Training_dates], [education_date], [enable], [start_date], [end_date], [Training_dates_end], [Training_place], [Teacher_id]) VALUES (0, 1, 2, N'2', N'1', N'1', N'Муж', CAST(N'2016-06-01' AS Date), 1, 1, N'1', CAST(N'2016-06-01' AS Date), N'1', N'1', N'1', N'1', 1, CAST(N'2016-06-01' AS Date), 15, CAST(N'2016-06-01' AS Date), N'Штатный сотрудник-1-Приняли(1.6.2016)', CAST(N'2016-06-01' AS Date), CAST(N'2016-06-01' AS Date), CAST(N'2016-06-01' AS Date), CAST(N'2016-06-02' AS Date), NULL, 0.5, CAST(N'2016-06-01' AS Date), CAST(N'2016-01-06' AS Date), 1, CAST(N'2016-06-01' AS Date), CAST(N'2016-06-02' AS Date), CAST(N'2016-06-01' AS Date), N'1', 0)
INSERT [dbo].[Record_Teachers] ([id], [Cairs], [Job_title], [surname], [name], [middlename], [gender], [birthday], [passport_serial], [passport_number], [passport_gives], [passport_create], [registration], [telephone], [educational_institution], [specialty_of_diplom], [titles_id], [titles_date], [degrees_id], [degress_date], [terms_of_work], [competitive_selection_start_date], [competitive_selection_end_date], [experience_date], [total_experience_date], [Dekan_Faculties], [rate], [Training_dates], [education_date], [enable], [start_date], [end_date], [Training_dates_end], [Training_place], [Teacher_id]) VALUES (1, 1, 2, N'2', N'1', N'1', N'Муж', CAST(N'2016-06-01' AS Date), 1, 1, N'1', CAST(N'2016-06-01' AS Date), N'1', N'1', N'1', N'1', 2, CAST(N'2016-06-01' AS Date), 15, CAST(N'2016-06-01' AS Date), N'Штатный сотрудник-1-Приняли(1.6.2016)', CAST(N'2016-06-01' AS Date), CAST(N'2016-06-01' AS Date), CAST(N'2016-06-01' AS Date), CAST(N'2016-06-02' AS Date), NULL, 1, CAST(N'2016-06-01' AS Date), CAST(N'2016-06-01' AS Date), 1, CAST(N'2016-06-02' AS Date), NULL, CAST(N'2016-06-01' AS Date), N'1', 0)
INSERT [dbo].[Records] ([id], [Cairs], [Job_title], [surname], [name], [middlename], [titles_id], [titles_date], [degrees_id], [degress_date], [terms_of_work], [date]) VALUES (1, 1, 1, N'1', N'1', N'1', 1, CAST(N'2016-01-06 00:00:00.000' AS DateTime), 1, CAST(N'2016-01-06 00:00:00.000' AS DateTime), N'Штатный сотрудник-1-Приняли(1.6.2016)', CAST(N'2016-01-06 00:00:00.000' AS DateTime))
INSERT [dbo].[Records] ([id], [Cairs], [Job_title], [surname], [name], [middlename], [titles_id], [titles_date], [degrees_id], [degress_date], [terms_of_work], [date]) VALUES (2, 1, 1, N'1', N'1', N'1', 1, CAST(N'2016-01-06 00:00:00.000' AS DateTime), 1, CAST(N'2016-01-06 00:00:00.000' AS DateTime), N'Штатный сотрудник-1-Приняли(1.6.2016)', CAST(N'2016-01-06 00:00:00.000' AS DateTime))
INSERT [dbo].[Records] ([id], [Cairs], [Job_title], [surname], [name], [middlename], [titles_id], [titles_date], [degrees_id], [degress_date], [terms_of_work], [date]) VALUES (3, 1, 1, N'1', N'1', N'1', 1, CAST(N'2016-01-06 00:00:00.000' AS DateTime), 1, CAST(N'2016-01-06 00:00:00.000' AS DateTime), N'Штатный сотрудник-1-Приняли(1.6.2016)', CAST(N'2016-01-06 00:00:00.000' AS DateTime))
INSERT [dbo].[Records] ([id], [Cairs], [Job_title], [surname], [name], [middlename], [titles_id], [titles_date], [degrees_id], [degress_date], [terms_of_work], [date]) VALUES (4, NULL, NULL, N'2', N'2', N'2', 1, CAST(N'2016-02-06 00:00:00.000' AS DateTime), 1, CAST(N'2016-02-06 00:00:00.000' AS DateTime), N'Штатный сотрудник-2-Приняли(2.6.2016)', CAST(N'2016-02-06 00:00:00.000' AS DateTime))
INSERT [dbo].[Records] ([id], [Cairs], [Job_title], [surname], [name], [middlename], [titles_id], [titles_date], [degrees_id], [degress_date], [terms_of_work], [date]) VALUES (5, 1, 1, N'1', N'1', N'11', 1, CAST(N'2016-01-06 00:00:00.000' AS DateTime), 1, CAST(N'2016-01-06 00:00:00.000' AS DateTime), N'Штатный сотрудник-1-Приняли(1.6.2016)', CAST(N'2016-01-06 00:00:00.000' AS DateTime))
INSERT [dbo].[Records] ([id], [Cairs], [Job_title], [surname], [name], [middlename], [titles_id], [titles_date], [degrees_id], [degress_date], [terms_of_work], [date]) VALUES (6, NULL, NULL, N'22', N'22', N'22', 1, CAST(N'2016-02-06 00:00:00.000' AS DateTime), 1, CAST(N'2016-01-06 00:00:00.000' AS DateTime), N'Штатный сотрудник-2-Приняли(2.6.2016)', CAST(N'2016-02-06 00:00:00.000' AS DateTime))
INSERT [dbo].[Roles] ([id], [role], [login]) VALUES (5, N'ADMIN', N'a')
INSERT [dbo].[Roles] ([id], [role], [login]) VALUES (6, N'USER', N'2')
INSERT [dbo].[Roles] ([id], [role], [login]) VALUES (7, N'ADMIN', N'1')
INSERT [dbo].[Roles] ([id], [role], [login]) VALUES (4, N'ADMIN', N'admin')
INSERT [dbo].[Teachers] ([id], [Cairs], [Job_title], [surname], [name], [middlename], [gender], [birthday], [passport_serial], [passport_number], [passport_gives], [passport_create], [registration], [telephone], [educational_institution], [specialty_of_diplom], [titles_id], [titles_date], [degrees_id], [degress_date], [terms_of_work], [competitive_selection_start_date], [competitive_selection_end_date], [experience_date], [total_experience_date], [Dekan_Faculties], [rate], [Training_dates], [education_date], [enable], [start_date], [end_date], [Training_dates_end], [Training_place]) VALUES (0, 1, 1, N'1', N'1', N'1', N'Муж', CAST(N'2016-06-01' AS Date), 1, 1, N'1', CAST(N'2016-06-01' AS Date), N'1', N'1', N'1', N'1', 2, CAST(N'2016-06-01' AS Date), 1, CAST(N'2016-06-01' AS Date), N'Штатный сотрудник-1-Приняли(1.6.2016)', CAST(N'2016-06-01' AS Date), CAST(N'2016-06-01' AS Date), CAST(N'2016-06-01' AS Date), CAST(N'2016-06-02' AS Date), NULL, 1, CAST(N'2016-06-01' AS Date), CAST(N'2016-06-01' AS Date), 1, CAST(N'2016-06-01' AS Date), NULL, CAST(N'2016-06-01' AS Date), N'1')
INSERT [dbo].[Titles] ([id], [name]) VALUES (1, N'Профессор')
INSERT [dbo].[Titles] ([id], [name]) VALUES (2, N'Доцент')
INSERT [dbo].[Titles] ([id], [name]) VALUES (3, NULL)
INSERT [dbo].[Users] ([login], [password]) VALUES (N'a', N'4144e195f46de78a3623da7364d04f11')
INSERT [dbo].[Users] ([login], [password]) VALUES (N'1', N'06d49632c9dc9bcb62aeaef99612ba6b')
INSERT [dbo].[Users] ([login], [password]) VALUES (N'2', N'6d5ababb65e9ff214b73e891b4afe6e8')
INSERT [dbo].[Users] ([login], [password]) VALUES (N'admin', N'e3c787484c1372f594df70bebdbd3744')
INSERT [dbo].[Working_positions] ([id], [name]) VALUES (1, N'Зав. кафедрой')
INSERT [dbo].[Working_positions] ([id], [name]) VALUES (2, N'Профессор')
INSERT [dbo].[Working_positions] ([id], [name]) VALUES (3, N'Доцент')
INSERT [dbo].[Working_positions] ([id], [name]) VALUES (4, N'Старший преподаватель')
INSERT [dbo].[Working_positions] ([id], [name]) VALUES (5, N'Преподаватель')
INSERT [dbo].[Working_positions] ([id], [name]) VALUES (6, N'Ассистент')
INSERT [dbo].[Working_positions] ([id], [name]) VALUES (7, N'Почасовик')
ALTER TABLE [dbo].[Record_Teachers]  WITH CHECK ADD  CONSTRAINT [Faculty_1fk1] FOREIGN KEY([titles_id])
REFERENCES [dbo].[Titles] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Record_Teachers] CHECK CONSTRAINT [Faculty_1fk1]
GO
ALTER TABLE [dbo].[Record_Teachers]  WITH CHECK ADD  CONSTRAINT [Faculty_1fk2] FOREIGN KEY([degrees_id])
REFERENCES [dbo].[Degrees] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Record_Teachers] CHECK CONSTRAINT [Faculty_1fk2]
GO
ALTER TABLE [dbo].[Record_Teachers]  WITH CHECK ADD  CONSTRAINT [Faculty_Cairs_1fk] FOREIGN KEY([Cairs])
REFERENCES [dbo].[Cairs] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Record_Teachers] CHECK CONSTRAINT [Faculty_Cairs_1fk]
GO
ALTER TABLE [dbo].[Record_Teachers]  WITH CHECK ADD  CONSTRAINT [Faculty_Job_title_1fk] FOREIGN KEY([Job_title])
REFERENCES [dbo].[Working_positions] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Record_Teachers] CHECK CONSTRAINT [Faculty_Job_title_1fk]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [Faculty_Cairs_fk] FOREIGN KEY([Cairs])
REFERENCES [dbo].[Cairs] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [Faculty_Cairs_fk]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [Faculty_fk1] FOREIGN KEY([titles_id])
REFERENCES [dbo].[Titles] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [Faculty_fk1]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [Faculty_fk2] FOREIGN KEY([degrees_id])
REFERENCES [dbo].[Degrees] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [Faculty_fk2]
GO
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [Faculty_Job_title_fk] FOREIGN KEY([Job_title])
REFERENCES [dbo].[Working_positions] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [Faculty_Job_title_fk]
GO
ALTER TABLE [dbo].[Training_dates]  WITH CHECK ADD  CONSTRAINT [Training_dates_fk1] FOREIGN KEY([prepod_id])
REFERENCES [dbo].[Teachers] ([id])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Training_dates] CHECK CONSTRAINT [Training_dates_fk1]
GO
