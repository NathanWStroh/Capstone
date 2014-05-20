CREATE TABLE [dbo].[ControlsToRoles](
	[RoleID] [int] NOT NULL,
	[Form] [varchar](50) NOT NULL,
	[Control] [varchar](50) NOT NULL,
	[Visible] [bit] NOT NULL,
	[Disabled] [bit] NOT NULL,
 CONSTRAINT [PK_ControlsToRoles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC,
	[Form] ASC,
	[Control] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]