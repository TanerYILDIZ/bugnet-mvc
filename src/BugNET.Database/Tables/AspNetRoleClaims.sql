CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] INT IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
	[RoleId] UNIQUEIDENTIFIER NOT NULL,
 CONSTRAINT [PK_IdentityRoleClaim<guid>] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_IdentityRoleClaim<guid>_IdentityRole_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_IdentityRoleClaim<guid>_IdentityRole_RoleId]