GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activity](
	[Id] [uniqueidentifier] NOT NULL,
	[ActivityId] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Client] [nvarchar](max) NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[DueDate] [datetime2](7) NOT NULL,
	[Duration] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[Id] [uniqueidentifier] NOT NULL,
	[ActivityId] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Status] [bit] NOT NULL,
	[CompletedDate] [datetime2](7) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Activity] ([Id], [ActivityId], [Description], [Client], [StartDate], [DueDate], [Duration], [CreatedDate], [ModifiedDate]) VALUES (N'be26ce39-0af4-4222-8cd3-18a1d3b48347', 3, N'Approve Limit Increase', N'Mr van der Spuy', CAST(N'2021/06/04 15:00:00' AS DateTime2), CAST(N'2021/06/07 09:30:00' AS DateTime2), 2, CAST(N'2021/05/23 16:46:39' AS DateTime2), CAST(N'2021/05/23 16:46:39' AS DateTime2))
INSERT [dbo].[Activity] ([Id], [ActivityId], [Description], [Client], [StartDate], [DueDate], [Duration], [CreatedDate], [ModifiedDate]) VALUES (N'd99f4246-97ee-4837-bfdc-808abac7fda9', 2, N'Check Application', N'Mrs Smith', CAST(N'2021/06/01 09:00:00' AS DateTime2), CAST(N'2021/06/02 09:30:00' AS DateTime2), 8, CAST(N'2021/05/23 16:46:39' AS DateTime2), CAST(N'2021/05/23 16:46:39' AS DateTime2))
INSERT [dbo].[Activity] ([Id], [ActivityId], [Description], [Client], [StartDate], [DueDate], [Duration], [CreatedDate], [ModifiedDate]) VALUES (N'5632e41c-57f5-4466-9994-fa7545e54383', 1, N'Check Application', N'Mr Ndlovu', CAST(N'2021/06/01 08:30:00' AS DateTime2), CAST(N'2021/06/01 09:30:00' AS DateTime2), 1, CAST(N'2021/05/23 16:46:37' AS DateTime2), CAST(N'2021/05/23 16:46:37' AS DateTime2))

GO
INSERT [dbo].[Task] ([Id], [ActivityId], [Description], [Status], [CompletedDate], [CreatedDate], [ModifiedDate]) VALUES (N'eae0c530-6f13-45f3-9486-6134368005d7', N'be26ce39-0af4-4222-8cd3-18a1d3b48347', N'Check Current facility', False, NULL, CAST(N'2021/05/23 16:46:39' AS DateTime2), CAST(N'2021/05/23 16:46:39' AS DateTime2))
INSERT [dbo].[Task] ([Id], [ActivityId], [Description], [Status], [CompletedDate], [CreatedDate], [ModifiedDate]) VALUES (N'5fa58b16-1f53-4d6f-9396-d4f11f46b505', N'be26ce39-0af4-4222-8cd3-18a1d3b48347', N'Check collateral', False, NULL, CAST(N'2021/05/23 16:46:39' AS DateTime2), CAST(N'2021/05/23 16:46:39' AS DateTime2))
INSERT [dbo].[Task] ([Id], [ActivityId], [Description], [Status], [CompletedDate], [CreatedDate], [ModifiedDate]) VALUES (N'8e38bc87-8642-4395-ada9-0a45152a9feb', N'd99f4246-97ee-4837-bfdc-808abac7fda9', N'Check within limits', False, NULL, CAST(N'2021/05/23 16:46:39' AS DateTime2), CAST(N'2021/05/23 16:46:39' AS DateTime2))
INSERT [dbo].[Task] ([Id], [ActivityId], [Description], [Status], [CompletedDate], [CreatedDate], [ModifiedDate]) VALUES (N'd1c90916-a8e4-4438-933a-3a0b2881875c', N'd99f4246-97ee-4837-bfdc-808abac7fda9', N'Check all fields completed', False, NULL, CAST(N'2021/05/23 16:46:39' AS DateTime2), CAST(N'2021/05/23 16:46:39' AS DateTime2))
INSERT [dbo].[Task] ([Id], [ActivityId], [Description], [Status], [CompletedDate], [CreatedDate], [ModifiedDate]) VALUES (N'23903623-83f6-4a34-8a33-46cc754e2e2a', N'd99f4246-97ee-4837-bfdc-808abac7fda9', N'Cross validate fields', False, NULL, CAST(N'2021/05/23 16:46:39' AS DateTime2), CAST(N'2021/05/23 16:46:39' AS DateTime2))
INSERT [dbo].[Task] ([Id], [ActivityId], [Description], [Status], [CompletedDate], [CreatedDate], [ModifiedDate]) VALUES (N'0418f526-eac5-416c-931c-a10c42a68e1a', N'd99f4246-97ee-4837-bfdc-808abac7fda9', N'Issue Cheque', False, NULL, CAST(N'2021/05/23 16:46:39' AS DateTime2), CAST(N'2021/05/23 16:46:39' AS DateTime2))
INSERT [dbo].[Task] ([Id], [ActivityId], [Description], [Status], [CompletedDate], [CreatedDate], [ModifiedDate]) VALUES (N'39ec3c06-091d-4752-994c-be950c06ee21', N'd99f4246-97ee-4837-bfdc-808abac7fda9', N'Post Cheque', False, NULL, CAST(N'2021/05/23 16:46:39' AS DateTime2), CAST(N'2021/05/23 16:46:39' AS DateTime2))
INSERT [dbo].[Task] ([Id], [ActivityId], [Description], [Status], [CompletedDate], [CreatedDate], [ModifiedDate]) VALUES (N'd018d7e2-0a86-4b12-b30a-302e0c8a422a', N'5632e41c-57f5-4466-9994-fa7545e54383', N'Post Cheque', False, NULL, CAST(N'2021/05/23 16:46:37' AS DateTime2), CAST(N'2021/05/23 16:46:37' AS DateTime2))
INSERT [dbo].[Task] ([Id], [ActivityId], [Description], [Status], [CompletedDate], [CreatedDate], [ModifiedDate]) VALUES (N'63180b44-0a1a-4bfa-b4e7-52d70517e666', N'5632e41c-57f5-4466-9994-fa7545e54383', N'Issue Cheque', False, NULL, CAST(N'2021/05/23 16:46:37' AS DateTime2), CAST(N'2021/05/23 16:46:37' AS DateTime2))
INSERT [dbo].[Task] ([Id], [ActivityId], [Description], [Status], [CompletedDate], [CreatedDate], [ModifiedDate]) VALUES (N'1117854d-0b09-41f2-a0c4-538768316d05', N'5632e41c-57f5-4466-9994-fa7545e54383', N'Cross validate fields', False, NULL, CAST(N'2021/05/23 16:46:37' AS DateTime2), CAST(N'2021/05/23 16:46:37' AS DateTime2))
INSERT [dbo].[Task] ([Id], [ActivityId], [Description], [Status], [CompletedDate], [CreatedDate], [ModifiedDate]) VALUES (N'7d0ab0d9-6a91-47c7-b86a-64a9f41e49df', N'5632e41c-57f5-4466-9994-fa7545e54383', N'Check all fields completed', False, NULL, CAST(N'2021/05/23 16:46:37' AS DateTime2), CAST(N'2021/05/23 16:46:37' AS DateTime2))
INSERT [dbo].[Task] ([Id], [ActivityId], [Description], [Status], [CompletedDate], [CreatedDate], [ModifiedDate]) VALUES (N'70afb5b8-3195-45a6-9803-8e23261dac0f', N'5632e41c-57f5-4466-9994-fa7545e54383', N'Check within limits', False, NULL, CAST(N'2021/05/23 16:46:37' AS DateTime2), CAST(N'2021/05/23 16:46:37' AS DateTime2))

GO
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Activity_ActivityId] FOREIGN KEY([ActivityId])
REFERENCES [dbo].[Activity] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Activity_ActivityId]
GO
