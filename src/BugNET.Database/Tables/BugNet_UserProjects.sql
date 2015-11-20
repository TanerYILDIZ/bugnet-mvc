CREATE TABLE [dbo].[BugNet_UserProjects] (
    [UserId]               UNIQUEIDENTIFIER NOT NULL,
    [ProjectId]            INT              NOT NULL,
    CONSTRAINT [PK_BugNet_UserProjects] PRIMARY KEY CLUSTERED ([UserId] ASC, [ProjectId] ASC),
    CONSTRAINT [FK_BugNet_UserProjects_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BugNet_UserProjects_BugNet_Projects] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[BugNet_Projects] ([ProjectId]) ON DELETE CASCADE
);

