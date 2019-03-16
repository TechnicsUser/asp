CREATE TABLE [dbo].[AspNetUserClaims] (
[Id] INT IDENTITY (1, 1) NOT NULL,
[ClaimType] NVARCHAR (MAX) NULL,
[ClaimValue] NVARCHAR (MAX) NULL,
[User_Id] NVARCHAR (128) NOT NULL,
CONSTRAINT [PK_dbo.AspNetUserClaims]
PRIMARY KEY CLUSTERED ([Id] ASC),
CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id]
FOREIGN KEY ([User_Id]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE );
GO
CREATE NONCLUSTERED INDEX [IX_User_Id] ON [dbo].[AspNetUserClaims]([User_Id] ASC);
CREATE TABLE [dbo].[AspNetUserLogins] (
[UserId] NVARCHAR (128) NOT NULL,
[LoginProvider] NVARCHAR (128) NOT NULL,
[ProviderKey] NVARCHAR (128) NOT NULL,
CONSTRAINT [PK_dbo.AspNetUserLogins]
PRIMARY KEY CLUSTERED ([UserId] ASC, [LoginProvider] ASC, [ProviderKey] ASC),
CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE );
GO
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]([UserId] ASC);