CREATE TABLE [Categories] (
          [Id] int NOT NULL IDENTITY,
          [Name] nvarchar(max) NOT NULL,
          [DisplayOrder] nvarchar(max) NOT NULL,
          [CreatedDateTime] datetime2 NOT NULL,
          CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
      );