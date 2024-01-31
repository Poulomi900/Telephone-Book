CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL , 
    [First] VARCHAR(50) NULL, 
    [Lat] VARCHAR(50) NULL, 
    [Mobile] VARCHAR(50) NOT NULL, 
    [Email] VARCHAR(50) NULL, 
    [Category] VARCHAR(50) NULL, 
    PRIMARY KEY ([Mobile])
)
