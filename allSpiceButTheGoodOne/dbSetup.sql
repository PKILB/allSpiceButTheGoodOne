CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS recipes(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  creatorId VARCHAR(255) NOT NULL,
  title VARCHAR(100) NOT NULL,
  instructions VARCHAR(500) NOT NULL,
  img VARCHAR(500) NOT NULL,
  category VARCHAR(30) NOT NULL,

  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS ingredients(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(50) NOT NULL,
  quantity VARCHAR(100) NOT NULL,
  recipeId INT NOT NULL,

  FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

DROP TABLE ingredients;

CREATE TABLE IF NOT EXISTS favorites(
id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
recipeId INT NOT NULL,
accountId VARCHAR(255) NOT NULL,

  FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE,
  FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

DROP TABLE favorites;
