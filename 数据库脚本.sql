USE [WorkManage]
GO

/****** Object:  Table [dbo].[Works]    Script Date: 04/29/2016 15:37:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Works](
	[WorkId] [INT] IDENTITY(1,1) NOT NULL,
	[WorkName] [NVARCHAR](50) NULL,
	[WorkProgress] [BIT] NULL,
	[Description] [NVARCHAR](1000) NULL,
	[WorkMark] [NVARCHAR](100) NULL,
	[CompletionTime] [DATETIME] NOT NULL,
	[CreateDate] [DATETIME] NOT NULL,
 CONSTRAINT [PK__Works__2DE6D5F507020F21] PRIMARY KEY CLUSTERED 
(
	[WorkId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Works] ADD  CONSTRAINT [DF__Works__WorkName__09DE7BCC]  DEFAULT ('') FOR [WorkName]
GO

ALTER TABLE [dbo].[Works] ADD  CONSTRAINT [DF__Works__WorkProgr__0AD2A005]  DEFAULT ((0)) FOR [WorkProgress]
GO

ALTER TABLE [dbo].[Works] ADD  CONSTRAINT [DF__Works__Descripti__0BC6C43E]  DEFAULT ('') FOR [Description]
GO

ALTER TABLE [dbo].[Works] ADD  CONSTRAINT [DF__Works__WorkMark__08EA5793]  DEFAULT ('') FOR [WorkMark]
GO

ALTER TABLE [dbo].[Works] ADD  CONSTRAINT [DF__Works__CreateDat__0CBAE877]  DEFAULT (GETDATE()) FOR [CreateDate]
GO


