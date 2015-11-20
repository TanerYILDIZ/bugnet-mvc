CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] UNIQUEIDENTIFIER NOT NULL,
	[RoleId] UNIQUEIDENTIFIER NOT NULL,
 CONSTRAINT [PK_IdentityUserRole<guid>] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF)
)
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserRole<guid>_ApplicationUser_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_IdentityUserRole<guid>_ApplicationUser_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_IdentityUserRole<guid>_IdentityRole_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_IdentityUserRole<guid>_IdentityRole_RoleId]