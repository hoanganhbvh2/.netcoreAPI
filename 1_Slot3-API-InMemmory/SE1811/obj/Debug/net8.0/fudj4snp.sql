IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Book] (
    [BookID] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Author] nvarchar(max) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [AverageRating] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY ([BookID])
);
GO

CREATE TABLE [Categories] (
    [CategoryID] int NOT NULL IDENTITY,
    [CategoryName] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryID])
);
GO

CREATE TABLE [Products] (
    [ProductID] int NOT NULL IDENTITY,
    [NameProduct] nvarchar(max) NOT NULL,
    [DescriptionProduct] nvarchar(max) NOT NULL,
    [Price] int NOT NULL,
    [CategoryID] int NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([ProductID]),
    CONSTRAINT [FK_Products_Categories_CategoryID] FOREIGN KEY ([CategoryID]) REFERENCES [Categories] ([CategoryID]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'BookID', N'Author', N'AverageRating', N'Price', N'Title') AND [object_id] = OBJECT_ID(N'[Book]'))
    SET IDENTITY_INSERT [Book] ON;
INSERT INTO [Book] ([BookID], [Author], [AverageRating], [Price], [Title])
VALUES (1, N'J.R.R. Tolkien', 4.8, 15.99, N'The Hobbit'),
(2, N'J.K. Rowling', 4.9, 20.5, N'Harry Potter and the Philosopher''s Stone'),
(3, N'F. Scott Fitzgerald', 4.3, 12.99, N'The Great Gatsby'),
(4, N'Arthur Conan Doyle', 4.6, 18.75, N'Adventure of Sherlock Holmes'),
(5, N'Jane Austen', 4.7, 10.0, N'Pride and Prejudice'),
(6, N'J.R.R. Tolkien', 4.9, 25.0, N'The Lord of the Rings'),
(7, N'George Orwell', 4.5, 14.99, N'1984'),
(8, N'Harper Lee', 4.8, 13.5, N'To Kill a Mockingbird'),
(9, N'J.D. Salinger', 4.2, 11.99, N'The Catcher in the Rye'),
(10, N'Paulo Coelho', 4.4, 16.5, N'The Alchemist'),
(11, N'Dan Brown', 4.1, 19.99, N'The Da Vinci Code'),
(12, N'Stephen King', 4.6, 17.75, N'The Shining'),
(13, N'Frank Herbert', 4.7, 22.5, N'Dune'),
(14, N'Patrick Rothfuss', 4.8, 21.0, N'The Name of the Wind'),
(15, N'C.S. Lewis', 4.6, 15.0, N'The Chronicles of Narnia'),
(16, N'John Green', 4.3, 12.5, N'The Fault in Our Stars'),
(17, N'Lois Lowry', 4.4, 11.0, N'The Giver'),
(18, N'S.E. Hinton', 4.2, 10.5, N'The Outsiders'),
(19, N'Suzanne Collins', 4.5, 14.99, N'The Hunger Games'),
(20, N'Markus Zusak', 4.7, 13.99, N'The Book Thief');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'BookID', N'Author', N'AverageRating', N'Price', N'Title') AND [object_id] = OBJECT_ID(N'[Book]'))
    SET IDENTITY_INSERT [Book] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryID', N'CategoryName', N'Description') AND [object_id] = OBJECT_ID(N'[Categories]'))
    SET IDENTITY_INSERT [Categories] ON;
INSERT INTO [Categories] ([CategoryID], [CategoryName], [Description])
VALUES (1, N'Instruments', N'Musical instruments category'),
(2, N'Electronics', N'Electronic devices category'),
(3, N'Books', N'All kinds of books');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryID', N'CategoryName', N'Description') AND [object_id] = OBJECT_ID(N'[Categories]'))
    SET IDENTITY_INSERT [Categories] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductID', N'CategoryID', N'DescriptionProduct', N'NameProduct', N'Price') AND [object_id] = OBJECT_ID(N'[Products]'))
    SET IDENTITY_INSERT [Products] ON;
INSERT INTO [Products] ([ProductID], [CategoryID], [DescriptionProduct], [NameProduct], [Price])
VALUES (1, 1, N'Classic acoustic guitar', N'Guitar', 0),
(2, 1, N'88-key digital piano', N'Piano', 0),
(3, 1, N'Standard 5-piece drum set', N'Drum Set', 0),
(4, 1, N'Full size violin', N'Violin', 0),
(5, 1, N'Silver concert flute', N'Flute', 0),
(6, 2, N'DSLR professional', N'Canon Camera', 0),
(7, 2, N'Mobile phone', N'Samsung Galaxy', 0),
(8, 2, N'Apple laptop', N'MacBook Air', 0),
(9, 2, N'Wireless', N'Logitech Mouse', 0),
(10, 2, N'24-inch screen', N'HP Monitor', 0),
(11, 3, N'Beginner to Advanced', N'C# Programming', 0),
(12, 3, N'A Handbook of Agile Software Craftsmanship', N'Clean Code', 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProductID', N'CategoryID', N'DescriptionProduct', N'NameProduct', N'Price') AND [object_id] = OBJECT_ID(N'[Products]'))
    SET IDENTITY_INSERT [Products] OFF;
GO

CREATE INDEX [IX_Products_CategoryID] ON [Products] ([CategoryID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250605100237_vo', N'8.0.16');
GO

COMMIT;
GO

