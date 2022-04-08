CREATE TABLE [tasks] (
    [task_id] int NOT NULL IDENTITY,
    [description] varchar(max) NOT NULL,
    [date] datetime NOT NULL DEFAULT (getdate()),
    [concluided] bit NOT NULL DEFAULT CAST(0 AS bit),
    CONSTRAINT [PK_tasks] PRIMARY KEY ([task_id])
);
GO


