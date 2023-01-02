CREATE TABLE `Marca` (
	`MarcaId` CHAR(36),
	`Nome` VARCHAR(100),
	`DataAlteracao` DATETIME(20),
	`DataCadastro` DATETIME(20),
	`Excluido` BOOLEAN(20),
	UNIQUE KEY `iMarca` () USING BTREE,
	PRIMARY KEY (`MarcaId`)
) ENGINE=InnoDB;