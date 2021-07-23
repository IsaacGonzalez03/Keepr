CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS keeps(
  id INT AUTO_INCREMENT NOT NULL PRIMARY KEY COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'update time',
  creatorId VARCHAR(255) NOT NULL COMMENT 'FK: user account',
  name VARCHAR(255) NOT NULL COMMENT 'user name',
  description VARCHAR(255) NOT NULL COMMENT 'keep description',
  img VARCHAR(255) NOT NULL COMMENT 'img url',
  views INT NOT NULL DEFAULT 0 COMMENT 'view count',
  shares INT NOT NULL DEFAULT 0 COMMENT 'share count',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS vaults(
  id INT AUTO_INCREMENT NOT NULL PRIMARY KEY COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'update time',
  creatorId VARCHAR(255) NOT NULL COMMENT 'FK: user account',
  name VARCHAR(255) NOT NULL COMMENT 'user name',
  description VARCHAR(255) NOT NULL COMMENT 'vault description',
  isPrivate TINYINT NOT NULL COMMENT 'Private or Public',
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS vault_keeps(
  id INT AUTO_INCREMENT NOT NULL PRIMARY KEY COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'update time',
  creatorId VARCHAR(255) NOT NULL COMMENT 'FK: user account',
  vaultId INT NOT NULL COMMENT 'FK: vault id',
  keepId INT NOT NULL COMMENT ' FK: keep id',
  FOREIGN KEY (creatorId) REFERENCES accounts(id),
  FOREIGN KEY (vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
  FOREIGN KEY (keepId) REFERENCES keeps(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';