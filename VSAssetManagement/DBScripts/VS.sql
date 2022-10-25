USE [VISWASAMUDRA]
GO
/****** Object:  Table [dbo].[ASSET]    Script Date: 14-10-2022 04:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASSET](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CODE] [varchar](20) NOT NULL,
	[NAME] [varchar](30) NOT NULL,
	[COMPANY_NAME] [varchar](20) NULL,
	[CREATED_BY] [varchar](20) NOT NULL,
	[CREATED_DATE_TIME] [datetime] NOT NULL,
	[LAST_UPDATED_BY] [varchar](20) NOT NULL,
	[LAST_UPDATED_DATE_TIME] [datetime] NOT NULL,
	[RECORD_STATUS] [int] NOT NULL,
	[guid] [uniqueidentifier] NOT NULL,
	[PROJECT_GUID] [uniqueidentifier] NOT NULL,
	[STORE_GUID] [uniqueidentifier] NOT NULL,
	[BATCH_GUID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_ASSET_1] PRIMARY KEY CLUSTERED 
(
	[guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ASSET_HISTORY]    Script Date: 14-10-2022 04:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASSET_HISTORY](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TAG_ID] [int] NOT NULL,
	[ASSET_STATUS] [varchar](30) NULL,
	[CREATED_BY] [varchar](20) NOT NULL,
	[CREATED_DATE_TIME] [datetime] NOT NULL,
	[LAST_UPDATED_BY] [varchar](20) NOT NULL,
	[LAST_UPDATED_DATE_TIME] [datetime] NOT NULL,
	[RECORD_STATUS] [int] NOT NULL,
	[ASSET_GUID] [uniqueidentifier] NOT NULL,
	[GUID] [uniqueidentifier] NOT NULL,
	[COMPANY_CODE] [varchar](10) NULL,
	[DEPT_CODE] [varchar](10) NULL,
	[USER_CODE] [varchar](10) NULL,
 CONSTRAINT [PK_ASSET_HISTORY] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ASSET_OPERATIONS]    Script Date: 14-10-2022 04:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ASSET_OPERATIONS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OPERATION_STATUS] [varchar](1) NULL,
	[CREATED_BY] [varchar](20) NOT NULL,
	[CREATED_DATE_TIME] [datetime] NOT NULL,
	[LAST_UDATED_BY] [varchar](20) NOT NULL,
	[LAST_UPDATED_TIME] [datetime] NOT NULL,
	[RECORD_STATUS] [int] NOT NULL,
	[GUID] [uniqueidentifier] NOT NULL,
	[ASSET_GUID] [uniqueidentifier] NOT NULL,
	[TAG_GUID] [uniqueidentifier] NOT NULL,
	[COMPANY_CODE] [varchar](10) NULL,
	[DEPT_CODE] [varchar](10) NULL,
	[INITIATER] [varchar](20) NULL,
 CONSTRAINT [PK_ASSET_OPERATIONS] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BATCH]    Script Date: 14-10-2022 04:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BATCH](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BATCH_NO] [varchar](30) NULL,
	[BATCH_NAME] [varchar](30) NULL,
	[QUANTITY] [int] NULL,
	[ASSET_TYPE] [varchar](30) NULL,
	[ASSET_SIZE] [varchar](30) NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE_TIME] [datetime] NULL,
	[LAST_UPDATED_BY] [varchar](20) NULL,
	[LAST_UPDATED_DATE_TIME] [datetime] NULL,
	[RECORD_STATUS] [int] NOT NULL,
	[GUID] [uniqueidentifier] NOT NULL,
	[PURCHASE_BATCH_MASTER_GUID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_PURCHASE_REFERENCE_BATCH_DETAILS] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROJECT]    Script Date: 14-10-2022 04:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROJECT](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CODE] [varchar](15) NOT NULL,
	[NAME] [varchar](30) NOT NULL,
	[TYPE] [varchar](30) NULL,
	[CLIENT_NAME] [varchar](30) NULL,
	[START_DATE] [date] NULL,
	[END_DATE] [date] NULL,
	[PROJECT_SITE_HEAD] [varchar](50) NULL,
	[SITE_HEAD_MOBILE] [varchar](12) NULL,
	[GSTIN_NO] [varchar](30) NULL,
	[CITY_TOWN] [varchar](30) NULL,
	[ADDRESS_LINE_1] [varchar](50) NULL,
	[ADDRESS_LINE_2] [varchar](50) NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATE_DATE_TIME] [datetime] NULL,
	[LAST_UPDATED_BY] [varchar](20) NULL,
	[LAST_UPDATED_DATE_TIME] [datetime] NULL,
	[RECORD_STATUS] [int] NOT NULL,
	[GUID] [uniqueidentifier] NOT NULL,
	[COMPANY_CODE] [varchar](10) NULL,
	[DEPT_CODE] [varchar](10) NULL,
	[PROJECT_HEAD] [varchar](50) NULL,
	[USER_CODE] [varchar](10) NULL,
 CONSTRAINT [PK_PROJECT_1] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PURCHASE_ORDER]    Script Date: 14-10-2022 04:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PURCHASE_ORDER](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PURCHASE_ORDER_NO] [varchar](30) NULL,
	[PURCHASE_ORDER_DATE] [date] NULL,
	[RECEIVED_BY] [varchar](20) NULL,
	[RECEIVED_DATE] [date] NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE_TIME] [datetime] NULL,
	[LAST_UPDATED_BY] [varchar](20) NULL,
	[LAST_UPDATED_DATE_TIME] [datetime] NULL,
	[RECORD_STATUS] [int] NOT NULL,
	[GUID] [uniqueidentifier] NOT NULL,
	[COMPANY_CODE] [varchar](10) NULL,
	[DEPT_CODE] [varchar](10) NULL,
	[USER_CODE] [varchar](10) NULL,
 CONSTRAINT [PK_PURCHASE_REFERENCE_BATCH_MASTER] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STATUS]    Script Date: 14-10-2022 04:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STATUS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPTION] [varchar](20) NOT NULL,
	[TYPE] [varchar](20) NULL,
 CONSTRAINT [PK_STATUS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STORE]    Script Date: 14-10-2022 04:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STORE](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [varchar](50) NULL,
	[MAIN_STORE_ID] [int] NOT NULL,
	[RECORD_STATUS] [int] NOT NULL,
	[GUID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_STORE] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TAG]    Script Date: 14-10-2022 04:02:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CODE] [varchar](30) NOT NULL,
	[NAME] [varchar](30) NOT NULL,
	[STATUS] [varchar](15) NULL,
	[CREATED_BY] [varchar](20) NOT NULL,
	[CREATED_DATE_TIME] [datetime] NOT NULL,
	[LAST_UPDATED_BY] [varchar](20) NOT NULL,
	[LAST_UPDATED_DATE_TIME] [datetime] NOT NULL,
	[RECORD_STATUS] [int] NOT NULL,
	[GUID] [uniqueidentifier] NOT NULL,
	[COMPANY_CODE] [varchar](10) NULL,
	[DEPT_CODE] [varchar](10) NULL,
	[USER_CODE] [varchar](10) NULL,
 CONSTRAINT [PK_TAG] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ASSET] ADD  CONSTRAINT [DF_ASSET_CREATED_DATE_TIME]  DEFAULT (getdate()) FOR [CREATED_DATE_TIME]
GO
ALTER TABLE [dbo].[ASSET] ADD  CONSTRAINT [DF_ASSET_LAST_UPDATED_DATE_TIME]  DEFAULT (getdate()) FOR [LAST_UPDATED_DATE_TIME]
GO
ALTER TABLE [dbo].[ASSET] ADD  CONSTRAINT [DF_ASSET_RECORD_STATUS]  DEFAULT ((0)) FOR [RECORD_STATUS]
GO
ALTER TABLE [dbo].[ASSET] ADD  CONSTRAINT [DF_ASSET_guid]  DEFAULT (newid()) FOR [guid]
GO
ALTER TABLE [dbo].[ASSET_HISTORY] ADD  CONSTRAINT [DF_ASSET_HISTORY_CREATED_DATE_TIME]  DEFAULT (getdate()) FOR [CREATED_DATE_TIME]
GO
ALTER TABLE [dbo].[ASSET_HISTORY] ADD  CONSTRAINT [DF_ASSET_HISTORY_LAST_UPDATED_DATE_TIME]  DEFAULT (getdate()) FOR [LAST_UPDATED_DATE_TIME]
GO
ALTER TABLE [dbo].[ASSET_HISTORY] ADD  CONSTRAINT [DF_ASSET_HISTORY_RECORD_STATUS]  DEFAULT ((0)) FOR [RECORD_STATUS]
GO
ALTER TABLE [dbo].[ASSET_HISTORY] ADD  CONSTRAINT [DF_ASSET_HISTORY_GUID]  DEFAULT (newid()) FOR [GUID]
GO
ALTER TABLE [dbo].[ASSET_OPERATIONS] ADD  CONSTRAINT [DF_ASSET_OPERATIONS_CREATED_DATE_TIME]  DEFAULT (getdate()) FOR [CREATED_DATE_TIME]
GO
ALTER TABLE [dbo].[ASSET_OPERATIONS] ADD  CONSTRAINT [DF_ASSET_OPERATIONS_LAST_UPDATED_TIME]  DEFAULT (getdate()) FOR [LAST_UPDATED_TIME]
GO
ALTER TABLE [dbo].[ASSET_OPERATIONS] ADD  CONSTRAINT [DF_ASSET_OPERATIONS_RECORD_STATUS]  DEFAULT ((0)) FOR [RECORD_STATUS]
GO
ALTER TABLE [dbo].[BATCH] ADD  CONSTRAINT [DF_BATCH_CREATED_DATE_TIME]  DEFAULT (getdate()) FOR [CREATED_DATE_TIME]
GO
ALTER TABLE [dbo].[BATCH] ADD  CONSTRAINT [DF_BATCH_LAST_UPDATED_DATE_TIME]  DEFAULT (getdate()) FOR [LAST_UPDATED_DATE_TIME]
GO
ALTER TABLE [dbo].[BATCH] ADD  CONSTRAINT [DF_PURCHASE_REFERENCE_BATCH_DETAILS_RECORD_STATUS]  DEFAULT ((0)) FOR [RECORD_STATUS]
GO
ALTER TABLE [dbo].[BATCH] ADD  CONSTRAINT [DF_BATCH_GUID]  DEFAULT (newid()) FOR [GUID]
GO
ALTER TABLE [dbo].[PROJECT] ADD  CONSTRAINT [DF_PROJECT_CREATE_DATE_TIME]  DEFAULT (getdate()) FOR [CREATE_DATE_TIME]
GO
ALTER TABLE [dbo].[PROJECT] ADD  CONSTRAINT [DF_PROJECT_LAST_UPDATED_DATE_TIME]  DEFAULT (getdate()) FOR [LAST_UPDATED_DATE_TIME]
GO
ALTER TABLE [dbo].[PROJECT] ADD  CONSTRAINT [DF_PROJECT_RECORD_STATUS]  DEFAULT ((0)) FOR [RECORD_STATUS]
GO
ALTER TABLE [dbo].[PROJECT] ADD  CONSTRAINT [DF_PROJECT_GUID]  DEFAULT (newid()) FOR [GUID]
GO
ALTER TABLE [dbo].[PURCHASE_ORDER] ADD  CONSTRAINT [DF_PURCHASE_ORDER_CREATED_DATE_TIME]  DEFAULT (getdate()) FOR [CREATED_DATE_TIME]
GO
ALTER TABLE [dbo].[PURCHASE_ORDER] ADD  CONSTRAINT [DF_PURCHASE_ORDER_LAST_UPDATED_DATE_TIME]  DEFAULT (getdate()) FOR [LAST_UPDATED_DATE_TIME]
GO
ALTER TABLE [dbo].[PURCHASE_ORDER] ADD  CONSTRAINT [DF_PURCHASE_REFERENCE_BATCH_MASTER_RECORD_STATUS]  DEFAULT ((0)) FOR [RECORD_STATUS]
GO
ALTER TABLE [dbo].[PURCHASE_ORDER] ADD  CONSTRAINT [DF_PURCHASE_ORDER_GUID]  DEFAULT (newid()) FOR [GUID]
GO
ALTER TABLE [dbo].[STORE] ADD  CONSTRAINT [DF_STORE_RECORD_STATUS]  DEFAULT ((0)) FOR [RECORD_STATUS]
GO
ALTER TABLE [dbo].[STORE] ADD  CONSTRAINT [DF_STORE_GUID]  DEFAULT (newid()) FOR [GUID]
GO
ALTER TABLE [dbo].[TAG] ADD  CONSTRAINT [DF_TAG_CREATED_DATE_TIME]  DEFAULT (getdate()) FOR [CREATED_DATE_TIME]
GO
ALTER TABLE [dbo].[TAG] ADD  CONSTRAINT [DF_TAG_LAST_UPDATED_DATE_TIME]  DEFAULT (getdate()) FOR [LAST_UPDATED_DATE_TIME]
GO
ALTER TABLE [dbo].[TAG] ADD  CONSTRAINT [DF_TAG_RECORD_STATUS]  DEFAULT ((0)) FOR [RECORD_STATUS]
GO
ALTER TABLE [dbo].[TAG] ADD  CONSTRAINT [DF_TAG_GUID]  DEFAULT (newid()) FOR [GUID]
GO
ALTER TABLE [dbo].[ASSET]  WITH CHECK ADD  CONSTRAINT [FK_ASSET_BATCH] FOREIGN KEY([BATCH_GUID])
REFERENCES [dbo].[BATCH] ([GUID])
GO
ALTER TABLE [dbo].[ASSET] CHECK CONSTRAINT [FK_ASSET_BATCH]
GO
ALTER TABLE [dbo].[ASSET]  WITH CHECK ADD  CONSTRAINT [FK_ASSET_PROJECT] FOREIGN KEY([PROJECT_GUID])
REFERENCES [dbo].[PROJECT] ([GUID])
GO
ALTER TABLE [dbo].[ASSET] CHECK CONSTRAINT [FK_ASSET_PROJECT]
GO
ALTER TABLE [dbo].[ASSET]  WITH CHECK ADD  CONSTRAINT [FK_ASSET_STORE] FOREIGN KEY([STORE_GUID])
REFERENCES [dbo].[STORE] ([GUID])
GO
ALTER TABLE [dbo].[ASSET] CHECK CONSTRAINT [FK_ASSET_STORE]
GO
ALTER TABLE [dbo].[ASSET_HISTORY]  WITH CHECK ADD  CONSTRAINT [FK_ASSET_HISTORY_ASSET] FOREIGN KEY([ASSET_GUID])
REFERENCES [dbo].[ASSET] ([guid])
GO
ALTER TABLE [dbo].[ASSET_HISTORY] CHECK CONSTRAINT [FK_ASSET_HISTORY_ASSET]
GO
ALTER TABLE [dbo].[ASSET_OPERATIONS]  WITH CHECK ADD  CONSTRAINT [FK_ASSET_OPERATIONS_ASSET] FOREIGN KEY([ASSET_GUID])
REFERENCES [dbo].[ASSET] ([guid])
GO
ALTER TABLE [dbo].[ASSET_OPERATIONS] CHECK CONSTRAINT [FK_ASSET_OPERATIONS_ASSET]
GO
ALTER TABLE [dbo].[ASSET_OPERATIONS]  WITH CHECK ADD  CONSTRAINT [FK_ASSET_OPERATIONS_TAG] FOREIGN KEY([TAG_GUID])
REFERENCES [dbo].[TAG] ([GUID])
GO
ALTER TABLE [dbo].[ASSET_OPERATIONS] CHECK CONSTRAINT [FK_ASSET_OPERATIONS_TAG]
GO
ALTER TABLE [dbo].[BATCH]  WITH CHECK ADD  CONSTRAINT [FK_BATCH_PURCHASE_ORDER] FOREIGN KEY([PURCHASE_BATCH_MASTER_GUID])
REFERENCES [dbo].[PURCHASE_ORDER] ([GUID])
GO
ALTER TABLE [dbo].[BATCH] CHECK CONSTRAINT [FK_BATCH_PURCHASE_ORDER]
GO
