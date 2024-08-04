--Create table Pokemon(
--Id int identity(1,1),
--name varchar(255),
--type varchar(255),
--level int CHECK(level <=100),
--region varchar(255)
--);

--CREATE PROCEDURE CreatePokemon
--    @Name NVARCHAR(50),
--    @Type NVARCHAR(50),
--    @Level INT,
--    @Region NVARCHAR(50)
--AS
--BEGIN
--    INSERT INTO Pokemon (Name, Type, Level, Region)
--    VALUES (@Name, @Type, @Level, @Region);
--END

--CREATE PROCEDURE GetAllPokemon
--AS
--BEGIN
--    SELECT * FROM Pokemon;
--END

--CREATE PROCEDURE GetPokemonById
--    @Id INT
--AS
--BEGIN
--    SELECT * FROM Pokemon WHERE Id = @Id;
--END

--CREATE PROCEDURE UpdatePokemon
--    @Id INT,
--    @Name NVARCHAR(50),
--    @Type NVARCHAR(50),
--    @Level INT,
--    @Region NVARCHAR(50)
--AS
--BEGIN
--    UPDATE Pokemon
--    SET Name = @Name, Type = @Type, Level = @Level, Region = @Region
--    WHERE Id = @Id;
--END
--CREATE PROCEDURE DeletePokemon
--    @Id INT
--AS
--BEGIN
--    DELETE FROM Pokemon WHERE Id = @Id;
--END


