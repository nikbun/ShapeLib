-- ������ �� ������� �2 � ����� ���������

DROP TABLE IF EXISTS [Product];
DROP TABLE IF EXISTS [Category];

-- ������� �������

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

-- ��������� �������

INSERT INTO [Category] ([Name]) VALUES ('�����');
INSERT INTO [Category] ([Name]) VALUES ('������');
INSERT INTO [Category] ([Name]) VALUES ('��������');


INSERT INTO [Product] ([Name], [CategoryId]) VALUES ('������', 1);
INSERT INTO [Product] ([Name], [CategoryId]) VALUES ('�������', 1);
INSERT INTO [Product] ([Name], [CategoryId]) VALUES ('������', 2);
INSERT INTO [Product] ([Name], [CategoryId]) VALUES ('�����', 2);
INSERT INTO [Product] ([Name], [CategoryId]) VALUES ('�������', 3);
INSERT INTO [Product] ([Name], [CategoryId]) VALUES ('�������', 3);
INSERT INTO [Product] ([Name]) VALUES ('������');

-- ����������, ������� ��� ������

SELECT [Product].[Name] AS '��� ��������', [Category].[Name] AS '��� ���������' 
	FROM [Product] LEFT JOIN [Category] ON [Product].[CategoryId] = [Category].[Id]