-- Запрос по заданию №2 в конце документа

DROP TABLE IF EXISTS [Product];
DROP TABLE IF EXISTS [Category];

-- Создаем таблицы

CREATE TABLE [Category]
(
	[Id] int IDENTITY(1,1) PRIMARY KEY,
	[Name] nvarchar(50),
);

CREATE TABLE [Product]  
(  
	[Id] int IDENTITY(1,1) PRIMARY KEY,  
	[Name] nvarchar (50),
	[CategoryId] int, 
	FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id])
	ON DELETE CASCADE
	ON UPDATE CASCADE
);

-- Заполняем данными

INSERT INTO [Category] ([Name]) VALUES ('Овощи');
INSERT INTO [Category] ([Name]) VALUES ('Фрукты');
INSERT INTO [Category] ([Name]) VALUES ('Сладости');


INSERT INTO [Product] ([Name], [CategoryId]) VALUES ('Огурец', 1);
INSERT INTO [Product] ([Name], [CategoryId]) VALUES ('Помидор', 1);
INSERT INTO [Product] ([Name], [CategoryId]) VALUES ('Яблоко', 2);
INSERT INTO [Product] ([Name], [CategoryId]) VALUES ('Груша', 2);
INSERT INTO [Product] ([Name], [CategoryId]) VALUES ('Шоколад', 3);
INSERT INTO [Product] ([Name], [CategoryId]) VALUES ('Конфеты', 3);
INSERT INTO [Product] ([Name]) VALUES ('Кирпич');

-- Собственно, выводим сам запрос

SELECT [Product].[Name] AS 'Имя продукта', [Category].[Name] AS 'Имя категории' 
	FROM [Product] LEFT JOIN [Category] ON [Product].[CategoryId] = [Category].[Id]