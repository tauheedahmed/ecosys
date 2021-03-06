USE [EPS]
GO
/****** Object:  Table [dbo].[BudOrgOutputsJunkIthnk]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudOrgOutputsJunkIthnk](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BudOrgsId] [int] NULL,
	[ResourceTypesId] [int] NULL,
	[Qty] [float] NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_BudOrgOutputs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BudOrgClients]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudOrgClients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BudOrgsId] [int] NULL,
	[ClientsId] [int] NULL,
	[Qty] [float] NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_BudOrgClients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BudOrgClientImpacts]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudOrgClientImpacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BudOrgClientsId] [int] NULL,
	[EventsId] [int] NULL,
	[Description] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BudOLServices]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudOLServices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BudOrgsId] [int] NULL,
	[LocationsId] [int] NULL,
	[ServiceTypesId] [int] NULL,
	[BudAmt] [int] NULL,
 CONSTRAINT [PK_BudOLServices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BudgetTypes]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudgetTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BudgetsId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
	[StartDate] [smalldatetime] NULL,
	[EndDate] [smalldatetime] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_BudgetTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'null=Active, 1=InActive' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BudgetTypes', @level2type=N'COLUMN',@level2name=N'Status'
GO
/****** Object:  Table [dbo].[Budgets]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Budgets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FundsId] [int] NULL,
	[FY] [int] NULL,
	[Status] [int] NULL,
	[OrgId] [int] NULL,
	[Amount] [float] NULL,
 CONSTRAINT [PK_Budgets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0=Active, 1=Inactive' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Budgets', @level2type=N'COLUMN',@level2name=N'Status'
GO
/****** Object:  Table [dbo].[BudgetPrices]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudgetPrices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BudgetsId] [int] NULL,
	[ServiceTypesId] [int] NULL,
	[Price] [float] NULL,
	[SGFlag] [int] NULL,
 CONSTRAINT [PK_BudgetPrices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BudgetOutputs]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudgetOutputs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BudgetsId] [int] NULL,
	[ResourcesTypesId] [int] NULL,
	[Qty] [nchar](10) NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_BudgetOutputs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BudgetClients]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudgetClients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BudgetsId] [int] NULL,
	[ClientProfilesId] [int] NULL,
	[Qty] [int] NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_BudgetClients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BudgetClientImpacts]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudgetClientImpacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BudgetClientsId] [int] NULL,
	[EventsId] [int] NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_BudgetClientEvents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BudFlags]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudFlags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BudgetsId] [int] NULL,
	[FlagTypesId] [int] NULL,
 CONSTRAINT [PK_BudFlags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BudAmts]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudAmts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UDate] [datetime] NULL,
	[Amount] [float] NULL,
	[Description] [nvarchar](500) NULL,
	[BudgetsId] [int] NULL,
 CONSTRAINT [PK_BudAmts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BOLocActPeriods]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BOLocActPeriods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BOLocsId] [int] NULL,
	[ActPeriodsId] [int] NULL,
 CONSTRAINT [PK_BOLocActPeriods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BOJournals]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BOJournals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UDate] [datetime] NULL,
	[BudgetsId] [int] NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_BOJournals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BOAmts]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BOAmts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BOJournalsId] [int] NULL,
	[BudOrgsId] [int] NULL,
	[Amount] [float] NULL,
 CONSTRAINT [PK_BOAmts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppNames]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppNames](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActTypes]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_ActTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActTransTypes]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActTransTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_ActTransTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActRules]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActRules](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransTypesId] [int] NULL,
	[AccountsId1] [int] NULL,
	[AccountsId2] [int] NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
 CONSTRAINT [PK_ActRules] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActPeriodsOrg]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActPeriodsOrg](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ActPeriodsId] [int] NULL,
	[OrgId] [int] NULL,
	[Status] [int] NULL,
	[Type] [int] NULL,
	[FiscalYearsId] [int] NULL,
 CONSTRAINT [PK_ActPeriodsOrg] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActPeriods]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActPeriods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
	[test] [nchar](10) NULL,
 CONSTRAINT [PK_ActPeriods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActLedgers]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActLedgers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[FiscalYearsId] [int] NULL,
	[CurrId] [int] NULL,
	[Status] [int] NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
 CONSTRAINT [PK_ActLedgers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActJournals]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActJournals](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](300) NULL,
	[ActsDr] [int] NULL,
	[ActsCr] [int] NULL,
	[SubActsDr] [int] NULL,
	[SubActsCr] [int] NULL,
	[ActLedgersId] [int] NULL,
	[OrgId] [int] NULL,
	[TransactionDate] [smalldatetime] NULL,
	[Amt] [float] NULL,
 CONSTRAINT [PK_ActJournals] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 02/21/2014 15:26:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
	[Type] [int] NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zips]    Script Date: 02/21/2014 15:26:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zips](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Zip] [int] NULL,
	[StatesId] [int] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Zips] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Visibility]    Script Date: 02/21/2014 15:26:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visibility](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [text] NULL,
 CONSTRAINT [PK_Visibility] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTypes]    Script Date: 02/21/2014 15:26:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [text] NULL,
	[StartForm] [nvarchar](50) NULL,
	[StatusUserTypes] [int] NULL,
 CONSTRAINT [PK_UserTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserIds]    Script Date: 02/21/2014 15:26:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserIds](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrgId] [int] NULL,
	[UserId] [nvarchar](50) NULL,
	[Password] [nvarchar](12) NULL,
	[Status] [nvarchar](50) NULL,
	[CreationDate] [datetime] NULL,
	[PeopleId] [int] NULL,
	[PasswordUpdate] [datetime] NULL,
	[Type] [int] NULL,
	[CreationOrg] [int] NULL,
	[UserLevel] [int] NULL,
 CONSTRAINT [PK_UserIds] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_UserId] UNIQUE NONCLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypesOfImpactMagnitude]    Script Date: 02/21/2014 15:26:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypesOfImpactMagnitude](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
 CONSTRAINT [PK_TypesOfImpactMagnitude] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypesOfImpact]    Script Date: 02/21/2014 15:26:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypesOfImpact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
 CONSTRAINT [PK_TypesOfImpact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypesOfDeadlines]    Script Date: 02/21/2014 15:26:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypesOfDeadlines](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
 CONSTRAINT [PK_TypesOfDeadlines] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Timetables]    Script Date: 02/21/2014 15:26:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Timetables](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NULL,
	[PSEPStepsId] [int] NULL,
	[CompletionDate] [smalldatetime] NULL,
	[Status] [varchar](50) NULL,
	[PSEPID] [int] NULL,
	[OrgId] [int] NULL,
	[LocationsId] [int] NULL,
 CONSTRAINT [PK_Timetables] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Timesheets]    Script Date: 02/21/2014 15:26:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Timesheets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StaffActionsId] [int] NULL,
	[ProcProcuresId] [int] NULL,
	[YrMth] [int] NULL,
	[TSDate] [smalldatetime] NULL,
	[Hours] [float] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Timesheets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskResourceBackups]    Script Date: 02/21/2014 15:26:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskResourceBackups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Seq] [int] NULL,
 CONSTRAINT [PK_TaskResourceBackups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskBudgets]    Script Date: 02/21/2014 15:26:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskBudgets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PSEPSPeopleId] [int] NULL,
	[BudgetsId] [int] NULL,
	[BudAmt] [float] NULL,
	[Qty] [float] NULL,
	[Price] [float] NULL,
	[TimeMeasure] [int] NULL,
 CONSTRAINT [PK_TaskBudgets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemBackups]    Script Date: 02/21/2014 15:26:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemBackups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Resource Name] [int] NULL,
	[Backup Location] [int] NULL,
	[Responsible Unit] [int] NULL,
	[ComputerSoftwareId] [int] NULL,
	[Timing] [nvarchar](25) NULL,
	[Backup Scope] [nvarchar](50) NULL,
	[Data Backup] [bit] NOT NULL,
	[System Backup] [bit] NOT NULL,
	[Retention Period] [nvarchar](50) NULL,
	[Storage Medium] [nvarchar](50) NULL,
	[Verification Method] [nvarchar](50) NULL,
	[Last Verification Date] [smalldatetime] NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_SystemBackups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StepSContracts]    Script Date: 02/21/2014 15:26:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StepSContracts](
	[Id] [int] NOT NULL,
	[PSEPSId] [int] NULL,
	[ContractsId] [int] NULL,
	[BkupFlag] [int] NULL,
 CONSTRAINT [PK_StepSContracts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StepRStaff]    Script Date: 02/21/2014 15:26:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StepRStaff](
	[Id] [int] NOT NULL,
	[PSEPSId] [int] NULL,
	[StaffActionsId] [int] NULL,
	[BkupFlag] [int] NULL,
 CONSTRAINT [PK_StepRStaff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StepRoles]    Script Date: 02/21/2014 15:26:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StepRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[StepId] [int] NULL,
 CONSTRAINT [PK_StepRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StateTypes]    Script Date: 02/21/2014 15:26:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StateTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
 CONSTRAINT [PK_StateTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[States]    Script Date: 02/21/2014 15:26:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountriesId] [int] NULL,
	[Name] [nvarchar](100) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StandardPrices]    Script Date: 02/21/2014 15:26:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StandardPrices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyId] [int] NULL,
	[Price] [decimal](18, 0) NULL,
	[OrgId] [int] NULL,
	[ResTypeId] [int] NULL,
 CONSTRAINT [PK_StandardPrices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stages]    Script Date: 02/21/2014 15:26:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
 CONSTRAINT [PK_Stages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffTypes]    Script Date: 02/21/2014 15:26:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StaffTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
 CONSTRAINT [PK_StaffTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Staffing]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staffing](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PeopleId] [int] NULL,
	[Description] [text] NULL,
	[OrgId] [int] NULL,
	[CallerId] [int] NULL,
	[RolesId] [int] NULL,
	[OrgConfirm] [nvarchar](3) NULL,
	[PeopleConfirm] [nvarchar](3) NULL,
	[BackupsId] [int] NULL,
	[OrgLocId] [int] NULL,
 CONSTRAINT [PK_Staffing] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StaffActions]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StaffActions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PeopleId] [int] NULL,
	[OrgId] [int] NULL,
	[LocId] [int] NULL,
	[TypeId] [int] NULL,
	[Status] [int] NULL,
	[Visibility] [int] NULL,
	[SOFId] [int] NULL,
	[PayMethod] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[Description] [varchar](300) NULL,
	[OrgIdSupplier] [int] NULL,
	[PayGradeId] [int] NULL,
	[Salary] [float] NULL,
	[RolesId] [int] NULL,
	[CurrId] [int] NULL,
	[FundsId] [int] NULL,
 CONSTRAINT [PK_StaffActions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SLocations]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SLocations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrgLocationsId] [int] NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_OrgLocationRooms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Skills]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [text] NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
 CONSTRAINT [PK_Skills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SkillCourses]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SkillCourses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SkillId] [int] NULL,
	[ProjectId] [int] NULL,
 CONSTRAINT [PK_SkillCourses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceTypes]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ServiceTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Description] [nvarchar](500) NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
	[ParentId] [int] NULL,
	[QtyMeasuresId] [int] NULL,
	[Price] [float] NULL,
	[ProjName] [nvarchar](20) NULL,
	[ProjNameS] [nvarchar](20) NULL,
	[TypeId] [int] NULL,
	[Seq] [int] NULL,
	[HouseholdFlag] [int] NULL,
 CONSTRAINT [PK_ServiceTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Services]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Services](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Visibility] [int] NULL,
	[Status] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
	[Type] [int] NULL,
	[SupplierOrganization] [int] NULL,
	[UnitPrice] [int] NULL,
	[Currency] [nvarchar](50) NULL,
	[QuantityAvailable] [int] NULL,
	[Url] [nvarchar](100) NULL,
	[StartupTime] [nvarchar](50) NULL,
	[ProbabilityOfFailure] [int] NULL,
	[RestoreTime] [int] NULL,
	[ContactPerson] [int] NULL,
 CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceEvents]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServicesId] [int] NULL,
	[EventsId] [int] NULL,
	[Seq] [int] NULL,
 CONSTRAINT [PK_ServiceEvents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SerContracts]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SerContracts](
	[Id] [int] NOT NULL,
	[PSEPSID] [int] NULL,
	[ContractsId] [int] NULL,
	[BkupFlag] [char](10) NULL,
 CONSTRAINT [PK_SerContracts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SEProcs]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEProcs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServiceEventsId] [int] NULL,
	[ProcsId] [int] NULL,
	[Seq] [int] NULL,
 CONSTRAINT [PK_SEProcs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SARevisions]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SARevisions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StaffActionsId] [int] NULL,
	[StartDate] [smalldatetime] NULL,
	[EndDate] [smalldatetime] NULL,
	[Salary] [float] NULL,
	[PayGradeId] [int] NULL,
	[Status] [int] NULL,
	[TimePerCent] [float] NULL,
	[BudgetsId] [int] NULL,
 CONSTRAINT [PK_StaffSalaries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1=latest, null = not latest' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SARevisions', @level2type=N'COLUMN',@level2name=N'Status'
GO
/****** Object:  Table [dbo].[RolesStaff]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolesStaff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PSEPSId] [int] NULL,
	[StaffActionsId] [int] NULL,
	[BkupFlag] [int] NULL,
 CONSTRAINT [PK_RolesStaff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleSkills]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleSkills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[SkillId] [int] NULL,
 CONSTRAINT [PK_RoleSkills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [text] NULL,
	[OrgId] [int] NULL,
	[ParentId] [int] NULL,
	[Visibility] [int] NULL,
	[Seq] [int] NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResourceTypes]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResourceTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
	[ParentId] [int] NULL,
	[QtyMeasuresId] [int] NULL,
	[Type] [int] NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_ResourceTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 = Other, 1=Service' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ResourceTypes', @level2type=N'COLUMN',@level2name=N'Type'
GO
/****** Object:  Table [dbo].[ResourceOutputDeadlines]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResourceOutputDeadlines](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServiceId] [int] NULL,
	[LocationId] [int] NULL,
	[Client] [nvarchar](50) NULL,
	[Deadline] [nvarchar](50) NULL,
	[TypeOfImpact] [nvarchar](50) NULL,
	[ImpactMagnitude] [nvarchar](50) NULL,
	[AcceptableDelay] [nvarchar](50) NULL,
	[ImpactValue] [nvarchar](50) NULL,
 CONSTRAINT [PK_ResourceOutputDeadlines] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResourceItems]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResourceItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
	[ResourceId] [int] NULL,
	[StartTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_ResourceItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResourceInputs]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ResourceInputs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ResourceOutput] [int] NULL,
	[ResourceInput] [int] NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_ResourceInputs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ResourceBackups]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ResourceBackups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Resource] [int] NULL,
	[BackupResource] [int] NULL,
	[Rank] [int] NULL,
	[Description] [ntext] NULL,
	[Frequency] [char](50) NULL,
	[RetentionPeriod] [char](50) NULL,
	[Scope] [char](50) NULL,
	[Timing] [char](50) NULL,
	[OrgResponsible] [int] NULL,
 CONSTRAINT [PK_ResourceBackups] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QtyMeasuresSer]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QtyMeasuresSer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[NamePlural] [nvarchar](50) NULL,
 CONSTRAINT [PK_QtyMeasuresSer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QtyMeasures]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QtyMeasures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[NamePlural] [nvarchar](50) NULL,
 CONSTRAINT [PK_QtyMeasures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PSEResources]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PSEResources](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ResourceTypesId] [int] NULL,
	[ProfilesId] [int] NULL,
	[ServiceTypesId] [int] NULL,
	[EventsId] [int] NULL,
	[LocTypesId] [int] NULL,
	[Description] [ntext] NULL,
	[ProfileServiceEventsId] [int] NULL,
 CONSTRAINT [PK_PSEResources] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PSEPSteps]    Script Date: 02/21/2014 15:26:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PSEPSteps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[jProfileSEProcsId] [int] NULL,
	[ProcsId] [int] NULL,
	[LocTypesId] [int] NULL,
	[Seq] [int] NULL,
	[Name] [nvarchar](80) NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_PSEPSteps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PSEPStaff]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PSEPStaff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProcsId] [int] NULL,
	[RolesId] [int] NULL,
	[Description] [nvarchar](1000) NULL,
 CONSTRAINT [PK_PSEPStaff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PSEPSPeopleResPossibleTable]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PSEPSPeopleResPossibleTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PSEPRId] [int] NULL,
	[OrgLocId] [int] NULL,
	[BudOrgsId] [int] NULL,
	[RId] [int] NULL,
	[Description] [ntext] NULL,
	[BackupSeq] [int] NULL,
	[ProjectsId] [int] NULL,
	[Qty] [float] NULL,
	[Price] [float] NULL,
	[ContractsId] [int] NULL,
	[TimeMeasureId] [int] NULL,
	[StartDate] [smalldatetime] NULL,
	[EndDate] [smalldatetime] NULL,
	[PayGrade] [nchar](10) NULL,
	[StaffType] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PSEPSPeople]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PSEPSPeople](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NULL,
	[PSEPSId] [int] NULL,
	[OrgId] [int] NULL,
	[LocationsId] [int] NULL,
	[ServiceTypesId] [int] NULL,
	[FundsId] [int] NULL,
	[FY] [int] NULL,
	[PeopleId] [int] NULL,
	[StaffActionsId] [int] NULL,
	[Description] [ntext] NULL,
	[BackupSeq] [int] NULL,
	[Qty] [float] NULL,
	[TimeMeasure] [int] NULL,
	[StartDate] [smalldatetime] NULL,
	[EndDate] [smalldatetime] NULL,
	[StaffType] [int] NULL,
	[PayGrade] [int] NULL,
 CONSTRAINT [PK_PSEPSPeople] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PSEPSer]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PSEPSer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[jPSEPID] [int] NULL,
	[ProcsId] [int] NULL,
	[ServiceTypesId] [int] NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_PSEPSer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PSEPResOutputs]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PSEPResOutputs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ResourceTypesId] [int] NULL,
	[PSEPID] [int] NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_PSEPRT] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PSEPResInventory]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PSEPResInventory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PSEPResId] [int] NULL,
	[OrgId] [int] NULL,
	[FundsId] [int] NULL,
	[LocationsId] [int] NULL,
	[ServiceTypesId] [int] NULL,
	[InventoryId] [int] NULL,
	[Description] [ntext] NULL,
	[BackupFlag] [int] NULL,
	[ProjectId] [int] NULL,
	[ContractsId] [int] NULL,
	[Qty] [float] NULL,
	[Price] [float] NULL,
	[StartDate] [smalldatetime] NULL,
	[EndDate] [smalldatetime] NULL,
 CONSTRAINT [PK_PSEPSInventory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PSEPRes]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PSEPRes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProcsId] [int] NULL,
	[ResTypesId] [int] NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_PSEPRes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PSEPClientsRT]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PSEPClientsRT](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ResourceTypesId] [int] NULL,
	[PSEPClients] [int] NULL,
	[QtyMeasuresId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PSEPClientEvents]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PSEPClientEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PSEPClientsId] [int] NULL,
	[EventsId] [int] NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_PSEPClientsImpact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PSEClients]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PSEClients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NULL,
	[ProfileServiceEventsId] [int] NULL,
	[TypesOfDeadlinesId] [int] NULL,
	[AcceptableSlip] [varchar](50) NULL,
	[TypesOfImpactId] [int] NULL,
	[TypesOfImpactMagnitudeId] [int] NULL,
	[DollarCostSlip] [int] NULL,
	[LocTypesId] [int] NULL,
	[ClientsId] [int] NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_PSEPClients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjTypesPSEP]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjTypesPSEP](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Seq] [int] NULL,
	[PSEPId] [int] NULL,
	[ProjectTypesId] [int] NULL,
	[ProfileId] [int] NULL,
 CONSTRAINT [PK_ProjTypesPSEP] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjOrgLoc]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjOrgLoc](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectsId] [int] NULL,
	[OrgId] [int] NULL,
	[LocationsId] [int] NULL,
 CONSTRAINT [PK_ProjOrgLoc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjOLPSEP]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjOLPSEP](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectsId] [int] NULL,
	[OrgId] [int] NULL,
	[LocationsId] [int] NULL,
	[ProfileSEProcsId] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[StartStatus] [int] NULL,
	[EndStatus] [int] NULL,
 CONSTRAINT [PK_ProjOLPSEP] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectTypes]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProjectTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
	[Seq] [int] NULL,
	[Nameshort] [varchar](50) NULL,
 CONSTRAINT [PK_ProjectTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjectsPeople]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectsPeople](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectsId] [int] NULL,
	[PeopleId] [int] NULL,
 CONSTRAINT [PK_ProjectsPeople] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PSEventsId] [int] NULL,
	[Name] [nvarchar](100) NULL,
	[Status] [nvarchar](10) NULL,
	[Visibility] [int] NULL,
	[junkType] [int] NULL,
	[StartTime] [smalldatetime] NULL,
	[EndTime] [smalldatetime] NULL,
	[Description] [nvarchar](500) NULL,
	[OrgId] [int] NULL,
	[LocationsId] [int] NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectClients]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectClients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NULL,
	[ClientsId] [int] NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_ProjectClients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjCPeople]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjCPeople](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NULL,
	[PSEPCID] [int] NULL,
	[OrgLocId] [int] NULL,
	[ClientActionsId] [int] NULL,
 CONSTRAINT [PK_ProjCPeople] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfilesUserIds]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfilesUserIds](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[ProfileId] [int] NOT NULL,
	[OrgId] [int] NOT NULL,
	[Visibility] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfileSPStaff]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileSPStaff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfileServiceProcId] [int] NULL,
	[RoleId] [int] NULL,
	[Description] [ntext] NULL,
	[Type] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProfileSPStaff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfileSPC]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileSPC](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfileServiceProcId] [int] NULL,
	[ContactTypeId] [int] NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_ProfileSPC] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfileSESResTypes]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileSESResTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfileSESId] [int] NULL,
	[ResTypeId] [int] NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_ProfileSESResTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[profileservicetypesn]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[profileservicetypesn](
	[profileservicetypesid] [int] NOT NULL,
	[resourcetypesid] [int] NOT NULL,
	[locid] [int] NOT NULL,
	[description] [varchar](200) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProfileServiceTypes]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileServiceTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfilesId] [int] NULL,
	[ServiceTypesId] [int] NULL,
	[Description] [ntext] NULL,
	[Seq] [int] NULL,
 CONSTRAINT [PK_ProfileServiceTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfileServiceResources]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileServiceResources](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfileServiceTypesId] [int] NULL,
	[ResourceTypesId] [int] NULL,
	[LocTypesId] [int] NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_ProfileServiceResources] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfileServiceProcs]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileServiceProcs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfileServiceLocsId] [int] NULL,
	[ProfileServicesId] [int] NULL,
	[ProcessId] [int] NULL,
	[Description] [ntext] NULL,
	[Type] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProfileServiceProcs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfileServiceEvents]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileServiceEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfileServicesId] [int] NULL,
	[EventsId] [int] NULL,
	[MapId] [int] NULL,
	[Seq] [int] NULL,
 CONSTRAINT [PK_ProfileServiceEvents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfileSEPSStaff]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProfileSEPSStaff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfileSEPStepTypesId] [int] NULL,
	[RolesId] [int] NULL,
	[Description] [varchar](200) NULL,
	[Type] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProfileSEPSStaff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProfileSEPSSer]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProfileSEPSSer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfileSEPStepTypesId] [int] NULL,
	[ServiceTypesId] [int] NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_ProfileSEPSSer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProfileSEPSRes]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProfileSEPSRes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfileSEPStepTypesId] [int] NULL,
	[ResTypesId] [int] NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_ProfileSEPSRes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProfileSEProcs]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProfileSEProcs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](300) NULL,
	[Description] [nvarchar](500) NULL,
	[ProfileSEventsId] [int] NULL,
	[ProcsId] [int] NULL,
	[Seq] [int] NULL,
	[TypesOfDeadlinesId] [int] NULL,
	[AcceptableSlip] [varchar](50) NULL,
	[TypesOfImpactId] [int] NULL,
	[TypesOfImpactMagnitudeId] [int] NULL,
	[DollarCostSlip] [int] NULL,
	[LocTypesId] [int] NULL,
	[Timetables] [int] NULL,
	[Costs] [int] NULL,
	[ProjectTypesId] [int] NULL,
	[RolesId] [int] NULL,
	[MapId] [int] NULL,
 CONSTRAINT [PK_ProfileSEProcs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Profiles]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
	[Type] [nvarchar](50) NULL,
	[PeopleId] [int] NULL,
	[Households] [int] NULL,
	[Status] [int] NULL,
	[Seq] [int] NULL,
 CONSTRAINT [PK_Profiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfileResourceTypes]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileResourceTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfilesId] [int] NULL,
	[ResourceTypesId] [int] NULL,
 CONSTRAINT [PK_ProfileResourceTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfileProjectTypes]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileProjectTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfilesId] [int] NULL,
	[ProjectTypesId] [int] NULL,
 CONSTRAINT [PK_ProfileProjectTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProfileOrg]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfileOrg](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfileId] [int] NULL,
	[OrgId] [int] NULL,
 CONSTRAINT [PK_ProfileOrg] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcurementTypes]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcurementTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
	[Type] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProcurementTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcurementStatus]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcurementStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Seq] [int] NULL,
 CONSTRAINT [PK_ProcurementStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcurementMethods]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcurementMethods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
 CONSTRAINT [PK_ProcurementMethods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcureInventory]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcureInventory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProcurementsId] [int] NULL,
	[InventoryId] [int] NULL,
 CONSTRAINT [PK_ProcureInventory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcureBuds]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcureBuds](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProProcuresId] [int] NULL,
	[BudId] [int] NULL,
	[CurrId] [int] NULL,
	[Amount] [float] NULL,
 CONSTRAINT [PK_ProcureBuds] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcSteps]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcSteps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProcsId] [int] NULL,
	[LocTypesId] [int] NULL,
	[Seq] [int] NULL,
	[Name] [nvarchar](80) NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_ProcSteps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcStaff]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcStaff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProcsId] [int] NULL,
	[RolesId] [int] NULL,
	[Description] [nvarchar](1000) NULL,
 CONSTRAINT [PK_ProcsStaff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Procs]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Procs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](300) NULL,
	[Description] [nvarchar](500) NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
	[PSEPId] [int] NULL,
	[ServiceTypesId] [int] NULL,
	[PeopleId] [int] NULL,
	[Status] [int] NULL,
	[StepsFlag] [int] NULL,
	[StaffFlag] [int] NULL,
	[ResFlag] [int] NULL,
 CONSTRAINT [PK_Procs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcResOutputs]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcResOutputs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ResTypesId] [int] NULL,
	[ProcsId] [int] NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_ProcRT] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcRes]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcRes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProcsId] [int] NULL,
	[ResTypesId] [int] NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_ProcsRes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcProcures]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ProcProcures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrgLocId] [int] NULL,
	[TypeId] [int] NULL,
	[PSEPSID] [int] NULL,
	[PSEPID] [int] NULL,
	[ProjectId] [int] NULL,
	[BkupFlagOLD] [int] NULL,
	[ContractIdOLD] [int] NULL,
	[SGFlagOLD] [int] NULL,
	[StatusIdOLD] [int] NULL,
	[RequestIdOLD] [int] NULL,
	[DescriptionOLD] [varchar](300) NULL,
	[ProcureMethodId] [int] NULL,
	[BudgetsId] [int] NULL,
	[BudAmount] [float] NULL,
	[ReqAmount] [float] NULL,
	[Visibility] [int] NULL,
	[Qty] [float] NULL,
	[Price] [float] NULL,
	[TimeMeasure] [int] NULL,
 CONSTRAINT [PK_ProcProcures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProcClients]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcClients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProcsId] [int] NULL,
	[ProfilesId] [int] NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_ProcClients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProcClientEvents]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcClientEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProcClientsId] [int] NULL,
	[EventsId] [int] NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_ProcClientEvents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Performance Indicators]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Performance Indicators](
	[Id] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PeopleSkills]    Script Date: 02/21/2014 15:26:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeopleSkills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PeopleId] [int] NULL,
	[SkillsId] [int] NULL,
 CONSTRAINT [PK_PeopleSkills] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PeopleServiceTypes]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeopleServiceTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PeopleId] [int] NULL,
	[ServiceTypesId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PeopleRoles]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PeopleRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PeopleId] [int] NULL,
	[RoleId] [int] NULL,
 CONSTRAINT [PK_PeopleRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[People]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FName] [nvarchar](50) NULL,
	[LName] [nvarchar](50) NULL,
	[OrgId] [int] NULL,
	[WorkPhone] [nvarchar](50) NULL,
	[HomePhone] [nvarchar](50) NULL,
	[CellPhone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[UPI] [int] NULL,
	[Address] [ntext] NULL,
	[Birthdate] [smalldatetime] NULL,
	[Password] [nvarchar](50) NULL,
	[Visibility] [int] NULL,
	[UserLevel] [int] NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PayMethods]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PayMethods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[OrgId] [int] NULL,
 CONSTRAINT [PK_PayMethods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PaymentTerms]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentTerms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
	[Seq] [int] NULL,
 CONSTRAINT [PK_PaymentTerms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProcProcuresId] [int] NULL,
	[Description] [nvarchar](300) NULL,
	[Status] [int] NULL,
	[CurrId] [int] NULL,
	[PaymentAmount] [float] NULL,
	[Qty] [float] NULL,
	[ReqDate] [datetime] NULL,
	[PayeeId] [int] NULL,
	[PayeeType] [int] NULL,
	[PaymentMethodsId] [int] NULL,
	[LastUpdate] [timestamp] NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgSTPayGrades]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgSTPayGrades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrgStaffTypesId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Status] [int] NULL,
	[Seq] [int] NULL,
	[CurrId] [int] NULL,
	[SalaryMax] [float] NULL,
	[SalaryMin] [float] NULL,
	[SalaryAve] [float] NULL,
	[SalaryPeriod] [int] NULL,
	[OvertimeRate] [float] NULL,
 CONSTRAINT [PK_OrgSTPayGrades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgStaffTypes]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgStaffTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrgId] [int] NULL,
	[StaffTypesId] [int] NULL,
	[Visibility] [int] NULL,
	[CurrId] [int] NULL,
	[SalaryPeriod] [int] NULL,
	[Seq] [int] NULL,
	[PaymentBasis] [int] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_OrgStaffTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgServiceTypes]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgServiceTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrgId] [int] NULL,
	[PSTId] [int] NULL,
 CONSTRAINT [PK_OrgServiceTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgResTypes]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgResTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ResourceTypeId] [int] NULL,
	[OrgId] [int] NULL,
	[Type] [nvarchar](50) NULL,
 CONSTRAINT [PK_OrgResTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgResources]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgResources](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrgId] [int] NULL,
	[Name] [int] NULL,
	[Description] [ntext] NULL,
	[URL] [nvarchar](300) NULL,
 CONSTRAINT [PK_HHOrgResources] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgPSEvents]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgPSEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfileServiceEventsId] [int] NULL,
	[OrgId] [int] NULL,
 CONSTRAINT [PK_OrgPSEvents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgPSEPStaff]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgPSEPStaff](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrgId] [int] NULL,
	[PSEPStaffId] [int] NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_OrgRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgPSEPRes]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgPSEPRes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrgId] [int] NULL,
	[PSEPResId] [int] NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_OrgPSEPRDesc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgLocSEvents]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgLocSEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfileServiceEventsId] [int] NULL,
	[OrgLocId] [int] NULL,
 CONSTRAINT [PK_OrgLocSEvents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgLocServiceTypes]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgLocServiceTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrgLocId] [int] NULL,
	[ServiceTypesId] [int] NULL,
 CONSTRAINT [PK_OrgLocServiceTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgLocServices]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgLocServices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrgLocationsId] [int] NULL,
	[ServicesId] [int] NULL,
 CONSTRAINT [PK_OrgLocServices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgLocPSEPClientsST]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgLocPSEPClientsST](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PSEPClientsSTId] [int] NULL,
	[OrgId] [int] NULL,
	[LocId] [int] NULL,
	[ProjectsId] [int] NULL,
	[Amount] [float] NULL,
 CONSTRAINT [PK_OrgLocPSEPClientsST] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgLocMgrs]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgLocMgrs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrgLocId] [int] NULL,
	[StaffActionsId] [int] NULL,
 CONSTRAINT [PK_OrgLocMgrs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgLocations]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgLocations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LocId] [int] NULL,
	[OrgId] [int] NULL,
 CONSTRAINT [PK_OrgLocations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgFlags]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgFlags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrgId] [int] NULL,
	[FlagTypesId] [int] NULL,
 CONSTRAINT [PK_OrgFlags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrganizationTypes]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationTypes](
	[Organization Type] [nvarchar](50) NOT NULL,
	[Generic Terms of Reference] [ntext] NULL,
	[SuperType] [nvarchar](50) NULL,
	[List Order] [int] NULL,
 CONSTRAINT [PK_OrganizationTypes] PRIMARY KEY CLUSTERED 
(
	[Organization Type] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organizations]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organizations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](70) NULL,
	[BudgetsId] [int] NULL,
	[OrgType] [nvarchar](50) NULL,
	[ProfileId] [int] NULL,
	[CreatorOrg] [int] NULL,
	[UserIdOrig] [nvarchar](50) NULL,
	[LicenseId] [int] NULL,
	[BudMod] [int] NULL,
	[ParentOrg] [int] NULL,
	[Description] [ntext] NULL,
	[Fname] [nvarchar](50) NULL,
	[Lname] [nvarchar](50) NULL,
	[Seq] [int] NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[Url] [nvarchar](50) NULL,
	[Address] [ntext] NULL,
	[LocId] [int] NULL,
	[PeopleId] [int] NULL,
	[CreatorService] [int] NULL,
	[Status] [nvarchar](50) NULL,
	[Visibility] [int] NULL,
	[FYStartMonth] [int] NULL,
	[FYStartDay] [int] NULL,
	[CurrId] [int] NULL,
 CONSTRAINT [PK_Organizations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrgActivities]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrgActivities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Orgid] [int] NULL,
	[Activity] [nvarchar](70) NULL,
 CONSTRAINT [PK_OrgActivities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OLSEProcClients]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OLSEProcClients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfileServicesId] [int] NULL,
	[BudgetsId] [int] NULL,
	[OrgLocationsId] [int] NULL,
	[ProjectId] [int] NULL,
	[Description] [nvarchar](500) NULL,
	[ClientProfilesId] [int] NULL,
 CONSTRAINT [PK_OLPSEPClientsImpacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OLSEPOutputQty]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OLSEPOutputQty](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PSEPResOutputsId] [int] NULL,
	[Qty] [float] NULL,
 CONSTRAINT [PK_OLSEPOutputQty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OLPPSer]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OLPPSer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OLPSerPID] [int] NULL,
	[ProjectId] [int] NULL,
	[BkupFlag] [int] NULL,
 CONSTRAINT [PK_OLPPSer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OLPProjects]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OLPProjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NULL,
	[PSEPID] [int] NULL,
	[OrgLocId] [int] NULL,
 CONSTRAINT [PK_OLPProjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OLPPRes]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OLPPRes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OLPRPID] [int] NULL,
	[ProjectId] [int] NULL,
	[BkupFlag] [int] NULL,
 CONSTRAINT [PK_OLPPRes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OLPPPeople]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OLPPPeople](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProcSARsId] [int] NULL,
	[ProjectId] [int] NULL,
	[StartDate] [smalldatetime] NULL,
	[EndDate] [smalldatetime] NULL,
	[StartStatus] [int] NULL,
	[EndStatus] [int] NULL,
	[BkupFlag] [int] NULL,
 CONSTRAINT [PK_OLPPPeople] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OLPCPeople]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OLPCPeople](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PSEPCID] [int] NULL,
	[OrgLocId] [int] NULL,
	[ClientActionsId] [int] NULL,
 CONSTRAINT [PK_OLPCPeople] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OLPCOrgs]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OLPCOrgs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContractsId] [int] NULL,
	[OrgLocId] [int] NULL,
	[PSEPCID] [int] NULL,
 CONSTRAINT [PK_OLPCOrgs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuMessage]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuMessage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [ntext] NULL,
 CONSTRAINT [PK_MenuMessage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LocTypes]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LocTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[OrgId] [int] NULL,
	[Seq] [int] NULL,
	[Visibility] [int] NULL,
	[Description] [varchar](300) NULL,
 CONSTRAINT [PK_LocTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Locations]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [ntext] NULL,
	[Address] [ntext] NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
	[LocTypeId] [int] NULL,
	[Seq] [int] NULL,
	[StatesId] [int] NULL,
	[CountriesId] [int] NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LicenseUserTypes]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LicenseUserTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LicenseId] [int] NULL,
	[UserTypeId] [int] NULL,
	[UserTypeMax] [int] NULL,
 CONSTRAINT [PK_LicenseUserTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LicenseTerms]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LicenseTerms](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [char](10) NULL,
	[Description] [nvarchar](50) NULL,
	[Status] [nchar](10) NULL,
	[EULA] [text] NULL,
	[StartDate] [smalldatetime] NULL,
	[EndDate] [smalldatetime] NULL,
 CONSTRAINT [PK_LicenseTerms] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Licenses]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Licenses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ActId] [int] NULL,
	[EulaId] [int] NULL,
	[PeopleId] [int] NULL,
	[OrgId] [int] NULL,
	[LicenseStatus] [nvarchar](50) NULL,
	[LicenseDate] [datetime] NULL,
	[LicensePeriodDays] [int] NULL,
	[AccessLevel] [char](10) NULL,
	[DomainId] [int] NULL,
	[UserInput] [char](10) NULL,
	[UserInputDate] [char](10) NULL,
	[UserCreator] [int] NULL,
	[Visibility] [int] NULL,
 CONSTRAINT [PK_Licenses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[junkProcResourceTypes]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[junkProcResourceTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ResourceTypeId] [int] NULL,
	[ProcsId] [int] NULL,
	[Type] [nvarchar](50) NULL,
	[Comments] [ntext] NULL,
 CONSTRAINT [PK_ProcResourceTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[junkEventSteps]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[junkEventSteps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EventId] [int] NULL,
	[StepId] [int] NULL,
	[Seq] [int] NULL,
	[Description] [ntext] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryStatus]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Seq] [int] NULL,
 CONSTRAINT [PK_InventoryStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[ResTypeId] [int] NULL,
	[OrgId] [int] NULL,
	[SLocId] [int] NULL,
	[Description] [nvarchar](300) NULL,
	[StatusId] [int] NULL,
	[Visibility] [int] NULL,
	[ReceiptDate] [smalldatetime] NULL,
	[DisposalDate] [smalldatetime] NULL,
	[Qty] [float] NULL,
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FundStatus]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FundStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
 CONSTRAINT [PK_FundStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Funds]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Funds](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Status] [int] NULL,
	[OrgIdProvider] [int] NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
	[Amount] [float] NULL,
	[CurrenciesId] [int] NULL,
	[ActChartsId] [int] NULL,
	[Seq] [int] NULL,
	[StartDate] [smalldatetime] NULL,
	[EndDate] [smalldatetime] NULL,
 CONSTRAINT [PK_Funds] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0=Active, 1=InActive' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Funds', @level2type=N'COLUMN',@level2name=N'Status'
GO
/****** Object:  Table [dbo].[FundOrgs]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FundOrgs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FundsId] [int] NULL,
	[OrgId] [int] NULL,
 CONSTRAINT [PK_FundOrgs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FundCurrencies]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FundCurrencies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FundsId] [int] NULL,
	[CurrId] [int] NULL,
	[ExchangeRate] [float] NULL,
	[FY] [int] NULL,
	[OrgId] [int] NULL,
 CONSTRAINT [PK_BudgetCurrencies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Functions]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Functions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Seq] [int] NULL,
	[description] [nvarchar](500) NULL,
 CONSTRAINT [PK_Functions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FlagTypes]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FlagTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Code] [nvarchar](50) NULL,
	[SeqA] [int] NULL,
	[SeqB] [int] NULL,
	[Type] [int] NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_FlagTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FiscalYears]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FiscalYears](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FY] [int] NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
 CONSTRAINT [PK_FiscalYears] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventTypesJunk]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventTypesJunk](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [text] NULL,
 CONSTRAINT [PK_EventTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventTypeRoles]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventTypeRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NULL,
	[EventTypeId] [int] NULL,
	[ClientSupp] [nvarchar](50) NULL,
 CONSTRAINT [PK_EventTypeRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
	[OrgId] [int] NULL,
	[Type] [int] NULL,
	[Visibility] [int] NULL,
	[ServicesId] [int] NULL,
	[HouseholdFlag] [int] NULL,
	[Seq] [int] NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1=General Emergency Preparedness Measures - not related to any Hazardous Event' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Events', @level2type=N'COLUMN',@level2name=N'Type'
GO
/****** Object:  Table [dbo].[EventProcs]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventProcs](
	[Id] [int] NOT NULL,
	[EventsId] [int] NULL,
	[ProcsId] [int] NULL,
 CONSTRAINT [PK_EventProcs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Domains]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Domains](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_Domains] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DomainManagers]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DomainManagers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsersId] [int] NULL,
	[ProfilesId] [int] NULL,
	[Households] [int] NULL,
 CONSTRAINT [PK_DomainManagers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Currencies]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Currencies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[NamePlural] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
	[Code] [char](10) NULL,
	[Status] [int] NULL,
	[OrgId] [int] NULL,
 CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Seq] [int] NULL,
	[Status] [int] NULL,
	[StateTypesId] [int] NULL,
	[LocsFlag] [int] NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 =Locations tied to States/Provinces in country, null = Locations are tied to country.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Countries', @level2type=N'COLUMN',@level2name=N'LocsFlag'
GO
/****** Object:  Table [dbo].[ContractSuppliesStates]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractSuppliesStates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContractSuppliesId] [int] NULL,
	[StatesId] [int] NULL,
	[LocsFlag] [int] NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_ContractSuppliesStates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContractSuppliesLocs]    Script Date: 02/21/2014 15:26:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractSuppliesLocs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContractSuppliesId] [int] NULL,
	[LocsId] [int] NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_ContractSuppliesLocs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContractSuppliesCountries]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractSuppliesCountries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContractSuppliesId] [int] NULL,
	[CountriesId] [int] NULL,
	[StatesFlag] [int] NULL,
	[Description] [ntext] NULL,
 CONSTRAINT [PK_ContractSuppliesCountries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContractSupplies]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractSupplies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContractsId] [int] NULL,
	[ResourceTypesId] [int] NULL,
	[Description] [nvarchar](500) NULL,
	[URL] [nvarchar](100) NULL,
	[LocationsFlag] [int] NULL,
 CONSTRAINT [PK_Resources] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1=selected locations only' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ContractSupplies', @level2type=N'COLUMN',@level2name=N'LocationsFlag'
GO
/****** Object:  Table [dbo].[ContractsStatus]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractsStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Seq] [int] NULL,
 CONSTRAINT [PK_ContractsStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contracts]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contracts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](1000) NULL,
	[ContractType] [int] NULL,
	[Visibility] [int] NULL,
	[OrgIdSupplier] [int] NULL,
	[OrgIdClient] [int] NULL,
	[OrgId] [int] NULL,
	[ProcureMethodId] [int] NULL,
	[StatusId] [int] NULL,
	[CurrId] [int] NULL,
	[PayTerms] [int] NULL,
	[OrgIndFlag] [int] NULL,
	[HHFlag] [int] NULL,
	[CommitmentDate] [smalldatetime] NULL,
	[ClosingDate] [smalldatetime] NULL,
	[ServiceTypesId] [int] NULL,
 CONSTRAINT [PK_Contracts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0=organization, 1=people' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contracts', @level2type=N'COLUMN',@level2name=N'OrgIndFlag'
GO
/****** Object:  Table [dbo].[ContractProcures]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractProcures](
	[Id] [int] NOT NULL,
	[ContractId] [int] NULL,
	[ProcurementsId] [int] NULL,
 CONSTRAINT [PK_ContractProcures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactTypes]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [ntext] NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
 CONSTRAINT [PK_ContactTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CellPhone] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[RegularPhone] [nvarchar](50) NULL,
	[ResourceType] [int] NULL,
	[OrgId] [int] NULL,
	[ProfileId] [int] NULL,
	[CancelFlag] [int] NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientTypes]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_ClientTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientActions]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ClientActions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PeopleId] [int] NULL,
	[Status] [varchar](50) NULL,
	[OrgId] [int] NULL,
 CONSTRAINT [PK_ClientActions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BudVersions]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudVersions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
 CONSTRAINT [PK_BudVersions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BudStatus]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[OrgId] [int] NULL,
	[Visibility] [int] NULL,
 CONSTRAINT [PK_BudStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BudProjProcs]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudProjProcs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BudOLServicesId] [int] NULL,
	[ProjectsId] [int] NULL,
	[ProfileSEProcsId] [int] NULL,
	[BudAmt] [float] NULL,
	[OrgId] [int] NULL,
	[LocationsId] [int] NULL,
 CONSTRAINT [PK_BudProjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BudOrgsOutputs]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudOrgsOutputs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ResTypesId] [int] NULL,
	[BudOrgsId] [int] NULL,
	[Description] [nvarchar](500) NULL,
	[Qty] [float] NULL,
 CONSTRAINT [PK_BudOrgsOutputs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BudOrgs]    Script Date: 02/21/2014 15:26:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BudOrgs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrgId] [int] NULL,
	[BudgetsId] [int] NULL,
	[OrigAmt] [float] NULL,
	[AmtChange] [float] NULL,
	[Status] [int] NULL,
	[FY] [int] NULL,
 CONSTRAINT [PK_BudOrgs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'null = Active, 1 = InActive' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BudOrgs', @level2type=N'COLUMN',@level2name=N'Status'
GO
/****** Object:  Default [DF_Budgets_Status]    Script Date: 02/21/2014 15:26:37 ******/
ALTER TABLE [dbo].[Budgets] ADD  CONSTRAINT [DF_Budgets_Status]  DEFAULT ((0)) FOR [Status]
GO
/****** Object:  Default [DF_Funds_Status]    Script Date: 02/21/2014 15:26:38 ******/
ALTER TABLE [dbo].[Funds] ADD  CONSTRAINT [DF_Funds_Status]  DEFAULT ((0)) FOR [Status]
GO
/****** Object:  Default [DF_Organizations_FYStartMonth]    Script Date: 02/21/2014 15:26:38 ******/
ALTER TABLE [dbo].[Organizations] ADD  CONSTRAINT [DF_Organizations_FYStartMonth]  DEFAULT ((7)) FOR [FYStartMonth]
GO
/****** Object:  Default [DF_Organizations_FYStartDay]    Script Date: 02/21/2014 15:26:38 ******/
ALTER TABLE [dbo].[Organizations] ADD  CONSTRAINT [DF_Organizations_FYStartDay]  DEFAULT ((1)) FOR [FYStartDay]
GO
/****** Object:  Default [DF_OrgStaffTypes_CurrId]    Script Date: 02/21/2014 15:26:38 ******/
ALTER TABLE [dbo].[OrgStaffTypes] ADD  CONSTRAINT [DF_OrgStaffTypes_CurrId]  DEFAULT ((1)) FOR [CurrId]
GO
/****** Object:  Default [DF_OrgStaffTypes_SalaryPeriod]    Script Date: 02/21/2014 15:26:38 ******/
ALTER TABLE [dbo].[OrgStaffTypes] ADD  CONSTRAINT [DF_OrgStaffTypes_SalaryPeriod]  DEFAULT ((1)) FOR [SalaryPeriod]
GO
/****** Object:  Default [DF_OrgStaffTypes_Seq]    Script Date: 02/21/2014 15:26:38 ******/
ALTER TABLE [dbo].[OrgStaffTypes] ADD  CONSTRAINT [DF_OrgStaffTypes_Seq]  DEFAULT ((9)) FOR [Seq]
GO
/****** Object:  Default [DF_OrgStaffTypes_PaymentBasis]    Script Date: 02/21/2014 15:26:38 ******/
ALTER TABLE [dbo].[OrgStaffTypes] ADD  CONSTRAINT [DF_OrgStaffTypes_PaymentBasis]  DEFAULT ((1)) FOR [PaymentBasis]
GO
/****** Object:  Default [DF_ProfilesUserIds_OrgId]    Script Date: 02/21/2014 15:26:39 ******/
ALTER TABLE [dbo].[ProfilesUserIds] ADD  CONSTRAINT [DF_ProfilesUserIds_OrgId]  DEFAULT ((2)) FOR [OrgId]
GO
/****** Object:  Default [DF_ProfilesUserIds_Visibility]    Script Date: 02/21/2014 15:26:39 ******/
ALTER TABLE [dbo].[ProfilesUserIds] ADD  CONSTRAINT [DF_ProfilesUserIds_Visibility]  DEFAULT ((1)) FOR [Visibility]
GO
/****** Object:  Default [DF_SARevisions_TimePerCent]    Script Date: 02/21/2014 15:26:40 ******/
ALTER TABLE [dbo].[SARevisions] ADD  CONSTRAINT [DF_SARevisions_TimePerCent]  DEFAULT ((1)) FOR [TimePerCent]
GO
/****** Object:  ForeignKey [FK_BudOrgs_Budgets]    Script Date: 02/21/2014 15:26:37 ******/
ALTER TABLE [dbo].[BudOrgs]  WITH CHECK ADD  CONSTRAINT [FK_BudOrgs_Budgets] FOREIGN KEY([BudgetsId])
REFERENCES [dbo].[Budgets] ([Id])
GO
ALTER TABLE [dbo].[BudOrgs] CHECK CONSTRAINT [FK_BudOrgs_Budgets]
GO
