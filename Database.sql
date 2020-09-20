USE BlogSimples
go
CREATE TABLE dbo.[autor] ( 
	id int IDENTITY NOT NULL, 
	nome varchar(150) NOT NULL, 
	email varchar(150) NOT NULL, 
	senha varchar(50) NOT NULL, 
	administrador bit DEFAULT(0) NOT NULL, 
	data_cadastro datetime DEFAULT(GETDATE()) NOT NULL,
	CONSTRAINT PK_autor PRIMARY KEY (id), 
	CONSTRAINT UQ_email_autor UNIQUE (email), 
) 
GO
CREATE TABLE dbo.[categoria_artigo] ( 
	id int IDENTITY NOT NULL, 
	nome varchar(150) NOT NULL, 
	descricao varchar(300) NULL, 
	CONSTRAINT PK_categoria_artigo PRIMARY KEY (id), 
	CONSTRAINT UQ_nome_categoria_artigo UNIQUE (nome), 
) 
GO
CREATE TABLE dbo.[artigo] ( 
	id int IDENTITY NOT NULL, 
	titulo varchar(300) NOT NULL, 
	conteudo varchar(MAX) NOT NULL, 
	data_publicacao datetime NOT NULL,
	categoria_artigo_id int NOT NULL, 
	autor_id int NOT NULL, 
	removido bit DEFAULT(0) NOT NULL, 
	CONSTRAINT PK_artigo PRIMARY KEY (id), 
	CONSTRAINT FK_artigo_categoria_artigo_id 
		FOREIGN KEY (categoria_artigo_id) REFERENCES dbo.[categoria_artigo] (id), 
	CONSTRAINT FK_artigo_autor_id 
		FOREIGN KEY (autor_id) REFERENCES dbo.[autor] (id) 
)
GO 


insert into [categoria_artigo] (nome, descricao)
values ('Tecnologia', 'Descrição de qualquer tipo de tecnologia')

select * from [categoria_artigo]