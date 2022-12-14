-- Active: 1661190855344@@SG-num3-6592-mysql-master.servers.mongodirector.com@3306

CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS keeps(
        id INT NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name VARCHAR(225) COMMENT 'Keep Name',
        description TEXT COMMENT 'Keep Description',
        img TEXT COMMENT 'Keep Image',
        views int Comment 'Keep number of views',
        kept int COMMENT 'Keep number of kepts',
        creatorId VARCHAR(225) NOT NULL,
        FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS vaults(
        id INT NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name VARCHAR(225) COMMENT 'Vault Name',
        description TEXT COMMENT 'Vault Description',
        img TEXT COMMENT 'Vault Image',
        isPrivate TINYINT COMMENT 'True if Vault is privated',
        creatorId VARCHAR(225) NOT NULL,
        FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS vaultKeeps(
        id INT NOT NULL primary key AUTO_INCREMENT COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        keepId Int NOT NULL COMMENT 'Id of associated Keep',
        vaultId INT NOT NULL COMMENT 'Id of assciated Vault',
        creatorId VARCHAR(225) NOT NULL COMMENT 'Id of assciated creator',
        FOREIGN KEY(vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
        FOREIGN KEY(keepId) REFERENCES keeps(id) ON DELETE CASCADE,
        FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

DELETE FROM vaultKeeps;

DELETE FROM vaults;

DELETE FROM keeps;

DROP TABLE vaultKeeps;

DROP TABLE keeps;

DROP TABLE vaults;