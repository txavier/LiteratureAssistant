/****** Object:  Table [dbo].[item]    Script Date: 11/28/2014 12:21:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[item](
	[itemId] [int] IDENTITY(1,1) NOT NULL,
	[itemTemplateId] [int] NOT NULL,
	[parentItemId] [int] NULL,
	[childItemId] [int] NULL,
	[groupItemId] [int] NULL,
	[parentGroupItemId] [int] NULL,
	[processItemId] [int] NULL,
	[parentProcessItemId] [int] NULL,
 CONSTRAINT [PK_item] PRIMARY KEY CLUSTERED 
(
	[itemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[item]  WITH CHECK ADD  CONSTRAINT [FK_item_item_childItemId] FOREIGN KEY([childItemId])
REFERENCES [dbo].[item] ([itemId])
GO

ALTER TABLE [dbo].[item] CHECK CONSTRAINT [FK_item_item_childItemId]
GO

ALTER TABLE [dbo].[item]  WITH CHECK ADD  CONSTRAINT [FK_item_item_groupItemId] FOREIGN KEY([groupItemId])
REFERENCES [dbo].[item] ([itemId])
GO

ALTER TABLE [dbo].[item] CHECK CONSTRAINT [FK_item_item_groupItemId]
GO

ALTER TABLE [dbo].[item]  WITH CHECK ADD  CONSTRAINT [FK_item_item_parentItemId] FOREIGN KEY([parentItemId])
REFERENCES [dbo].[item] ([itemId])
GO

ALTER TABLE [dbo].[item] CHECK CONSTRAINT [FK_item_item_parentItemId]
GO

ALTER TABLE [dbo].[item]  WITH CHECK ADD  CONSTRAINT [FK_item_item_processItemId] FOREIGN KEY([processItemId])
REFERENCES [dbo].[item] ([itemId])
GO

ALTER TABLE [dbo].[item] CHECK CONSTRAINT [FK_item_item_processItemId]
GO

ALTER TABLE [dbo].[item]  WITH CHECK ADD  CONSTRAINT [FK_item_itemTemplate] FOREIGN KEY([itemTemplateId])
REFERENCES [dbo].[itemTemplate] ([itemTemplateId])
GO

ALTER TABLE [dbo].[item] CHECK CONSTRAINT [FK_item_itemTemplate]
GO


CREATE TABLE [dbo].[count](
	[countId] [int] IDENTITY(1,1) NOT NULL,
	[itemId] [int] NOT NULL,
	[received] [int] NULL,
	[receivedDate] [datetime2](7) NULL,
	[currentlyOnHand] [int] NULL,
	[currentlyOnHandDate] [datetime2](7) NULL,
 CONSTRAINT [PK_count] PRIMARY KEY CLUSTERED 
(
	[countId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[count]  WITH CHECK ADD  CONSTRAINT [FK_count_item] FOREIGN KEY([itemId])
REFERENCES [dbo].[item] ([itemId])
GO

ALTER TABLE [dbo].[count] CHECK CONSTRAINT [FK_count_item]
GO


CREATE TABLE [dbo].[user](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](50) NOT NULL,
	[lastName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[order](
	[orderId] [int] IDENTITY(1,1) NOT NULL,
	[itemId] [int] NOT NULL,
	[orderedForUserId] [int] NOT NULL,
	[orderedByUserId] [int] NULL,
	[date] [datetime2](7) NOT NULL,
	[pending] [bit] NULL,
	[received] [bit] NULL,
	[orderSent] [bit] NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[orderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_item] FOREIGN KEY([itemId])
REFERENCES [dbo].[item] ([itemId])
GO

ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_item]
GO

ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_user] FOREIGN KEY([orderedForUserId])
REFERENCES [dbo].[user] ([userId])
GO

ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_user]
GO

ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_user1] FOREIGN KEY([orderedByUserId])
REFERENCES [dbo].[user] ([userId])
GO

ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_user1]
GO


CREATE TABLE [dbo].[itemTemplate](
	[itemTemplateId] [int] IDENTITY(1,1) NOT NULL,
	[itemTemplateName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_itemTemplate] PRIMARY KEY CLUSTERED 
(
	[itemTemplateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[itemAttribute](
	[itemAttributeId] [int] IDENTITY(1,1) NOT NULL,
	[itemId] [int] NOT NULL,
	[templateAttributeId] [int] NOT NULL,
	[value] [nvarchar](50) NULL,
 CONSTRAINT [PK_itemAttribute] PRIMARY KEY CLUSTERED 
(
	[itemAttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[itemAttribute]  WITH CHECK ADD  CONSTRAINT [FK_itemAttribute_item] FOREIGN KEY([itemId])
REFERENCES [dbo].[item] ([itemId])
GO

ALTER TABLE [dbo].[itemAttribute] CHECK CONSTRAINT [FK_itemAttribute_item]
GO

ALTER TABLE [dbo].[itemAttribute]  WITH CHECK ADD  CONSTRAINT [FK_itemAttribute_templateAttribute] FOREIGN KEY([templateAttributeId])
REFERENCES [dbo].[templateAttribute] ([templateAttributeId])
GO

ALTER TABLE [dbo].[itemAttribute] CHECK CONSTRAINT [FK_itemAttribute_templateAttribute]
GO

CREATE TABLE [dbo].[templateAttribute](
	[templateAttributeId] [int] IDENTITY(1,1) NOT NULL,
	[itemTemplateId] [int] NOT NULL,
	[templateAttributeName] [nvarchar](50) NOT NULL,
	[required] [bit] NULL,
	[priority] [int] NULL,
 CONSTRAINT [PK_templateAttribute] PRIMARY KEY CLUSTERED 
(
	[templateAttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[templateAttribute]  WITH CHECK ADD  CONSTRAINT [FK_templateAttribute_itemTemplate] FOREIGN KEY([itemTemplateId])
REFERENCES [dbo].[itemTemplate] ([itemTemplateId])
GO

ALTER TABLE [dbo].[templateAttribute] CHECK CONSTRAINT [FK_templateAttribute_itemTemplate]
GO

