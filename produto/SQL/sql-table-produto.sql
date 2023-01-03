CREATE TABLE `Produto` (
	`ProdutoId` CHAR(36),
	`Nome` VARCHAR(90),
	`Descricao` VARCHAR(180),
	`CEST` VARCHAR(30),
	`NCM` VARCHAR(30),
	`QtdItensContidos` DECIMAL,
	`CodigoBarras` VARCHAR(30),
	`Tipo` TINYINT,
	`DataAlteracao` DATETIME,
	`DataCadastro` DATETIME,
	`Excluido` BOOLEAN,
	`MarcaId` CHAR(36),
	`UnidadeMedida` TINYINT,
	UNIQUE KEY `iProduto` (`ProdutoId`) USING BTREE,
	PRIMARY KEY (`ProdutoId`)
) ENGINE=InnoDB;