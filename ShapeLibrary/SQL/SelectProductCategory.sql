DROP TABLE IF EXISTS [Product];
DROP TABLE IF EXISTS [Category];
DROP TABLE IF EXISTS [KEYS_Product_Category];

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
);

CREATE TABLE [KEYS_Product_Category]
(
	[ProductId] int,
	[CategoryId] int, 
	FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id])
	ON DELETE CASCADE
	ON UPDATE CASCADE,
	FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id])
	ON DELETE CASCADE
	ON UPDATE CASCADE
);

-- Заполняем данными

INSERT INTO [Category] ([Name]) VALUES ('Фрукты');
INSERT INTO [Category] ([Name]) VALUES ('Сладости');
INSERT INTO [Category] ([Name]) VALUES ('Выпечка');
INSERT INTO [Category] ([Name]) VALUES ('Жидкости');


INSERT INTO [Product] ([Name]) VALUES ('Яблоко');
INSERT INTO [Product] ([Name]) VALUES ('Груша');
INSERT INTO [Product] ([Name]) VALUES ('Шоколад');
INSERT INTO [Product] ([Name]) VALUES ('Конфеты');
INSERT INTO [Product] ([Name]) VALUES ('Кирпич');
INSERT INTO [Product] ([Name]) VALUES ('Финики');
INSERT INTO [Product] ([Name]) VALUES ('Яблоко в шоколаде');
INSERT INTO [Product] ([Name]) VALUES ('Пирожок с мясом');
INSERT INTO [Product] ([Name]) VALUES ('Пирожок с малиной');

INSERT INTO [KEYS_Product_Category] ([ProductId], [CategoryId]) VALUES (1, 1);
INSERT INTO [KEYS_Product_Category] ([ProductId], [CategoryId]) VALUES (2, 1);
INSERT INTO [KEYS_Product_Category] ([ProductId], [CategoryId]) VALUES (3, 2);
INSERT INTO [KEYS_Product_Category] ([ProductId], [CategoryId]) VALUES (4, 2);
INSERT INTO [KEYS_Product_Category] ([ProductId], [CategoryId]) VALUES (6, 1);
INSERT INTO [KEYS_Product_Category] ([ProductId], [CategoryId]) VALUES (6, 2);
INSERT INTO [KEYS_Product_Category] ([ProductId], [CategoryId]) VALUES (7, 1);
INSERT INTO [KEYS_Product_Category] ([ProductId], [CategoryId]) VALUES (7, 2);
INSERT INTO [KEYS_Product_Category] ([ProductId], [CategoryId]) VALUES (8, 3);
INSERT INTO [KEYS_Product_Category] ([ProductId], [CategoryId]) VALUES (9, 2);
INSERT INTO [KEYS_Product_Category] ([ProductId], [CategoryId]) VALUES (9, 3);

-- Собственно, выводим сам запрос

SELECT [Product].[Name] AS 'Имя продукта', [Category].[Name] AS 'Имя категории' 
	FROM [Product] 
	LEFT JOIN [KEYS_Product_Category] ON [KEYS_Product_Category].[ProductId] = [Product].[Id]
	LEFT JOIN [Category] ON [KEYS_Product_Category].[CategoryId] = [Category].[Id]