CREATE TABLE [dbo].[LOOKUP_TYPE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CODE] [varchar](3) NOT NULL,
	[NAME] [varchar](30) NOT NULL,
	[CREATED_BY] [varchar](20) NOT NULL,
	[CREATED_DATE_TIME] [datetime] NOT NULL,
	[LAST_UPDATED_BY] [varchar](20) NOT NULL,
	[LAST_UPDATED_DATE_TIME] [datetime] NOT NULL,
	[RECORD_STATUS] [int] NULL,
	[GUID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_LOOKUP_TYPE] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LOOKUP_TYPE] ADD  CONSTRAINT [DF_LOOKUP_TYPE_CREATED_DATE_TIME]  DEFAULT (getdate()) FOR [CREATED_DATE_TIME]
GO

ALTER TABLE [dbo].[LOOKUP_TYPE] ADD  CONSTRAINT [DF_LOOKUP_TYPE_LAST_UPDATED_DATE_TIME]  DEFAULT (getdate()) FOR [LAST_UPDATED_DATE_TIME]
GO

ALTER TABLE [dbo].[LOOKUP_TYPE] ADD  CONSTRAINT [DF_LOOKUP_TYPE_RECORD_STATUS]  DEFAULT ((0)) FOR [RECORD_STATUS]
GO

ALTER TABLE [dbo].[LOOKUP_TYPE] ADD  CONSTRAINT [DF_LOOKUP_TYPE_GUID]  DEFAULT (newid()) FOR [GUID]
GO



CREATE TABLE [dbo].[LOOKUP_TYPE_VALUE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LOOKUP_TYPE_ID] [uniqueidentifier] NOT NULL,
	[CODE] [varchar](5) NOT NULL,
	[NAME] [varchar](50) NOT NULL,
	[CREATED_BY] [varchar](20) NOT NULL,
	[CREATED_DATE_TIME] [datetime] NOT NULL,
	[LAST_UPDATED_BY] [varchar](20) NOT NULL,
	[LAST_UPDATED_DATE_TIME] [datetime] NOT NULL,
	[RECORD_STATUS] [int] NULL,
	[GUID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_LOOKUP_TYPE_VALUE] PRIMARY KEY CLUSTERED 
(
	[GUID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LOOKUP_TYPE_VALUE] ADD  CONSTRAINT [DF_LOOKUP_TYPE_VALUE_CREATED_DATE_TIME]  DEFAULT (getdate()) FOR [CREATED_DATE_TIME]
GO

ALTER TABLE [dbo].[LOOKUP_TYPE_VALUE] ADD  CONSTRAINT [DF_LOOKUP_TYPE_VALUE_LAST_UPDATED_DATE_TIME]  DEFAULT (getdate()) FOR [LAST_UPDATED_DATE_TIME]
GO

ALTER TABLE [dbo].[LOOKUP_TYPE_VALUE] ADD  CONSTRAINT [DF_LOOKUP_TYPE_VALUE_RECORD_STATUS]  DEFAULT ((0)) FOR [RECORD_STATUS]
GO

ALTER TABLE [dbo].[LOOKUP_TYPE_VALUE] ADD  CONSTRAINT [DF_LOOKUP_TYPE_VALUE_GUID]  DEFAULT (newid()) FOR [GUID]
GO

ALTER TABLE [dbo].[LOOKUP_TYPE_VALUE]  WITH CHECK ADD  CONSTRAINT [FK_LOOKUP_TYPE_VALUE_LOOKUP_TYPE] FOREIGN KEY([LOOKUP_TYPE_ID])
REFERENCES [dbo].[LOOKUP_TYPE] ([GUID])
GO

ALTER TABLE [dbo].[LOOKUP_TYPE_VALUE] CHECK CONSTRAINT [FK_LOOKUP_TYPE_VALUE_LOOKUP_TYPE]
GO