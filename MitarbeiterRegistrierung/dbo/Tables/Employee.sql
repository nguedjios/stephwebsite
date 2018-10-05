CREATE TABLE [dbo].[Employee] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [Vorname]     NVARCHAR (MAX) NULL,
    [Jobtitel]    NVARCHAR (MAX)  NULL, 
    [Abteilung]   NVARCHAR (MAX)  NULL,
    [Foto]        BINARY (MAX)  NULL, 
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([Id] ASC)
);
