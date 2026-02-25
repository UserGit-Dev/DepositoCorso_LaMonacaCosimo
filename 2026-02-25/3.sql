USE WORLD;

-- 1.
SELECT 
	c.Name as nome, 
	CASE 
		WHEN c.SurfaceArea > 100000 THEN "Si"
		ELSE "No"
	END AS superefice_maggiore100k,
    CASE 
		WHEN c.IndepYear IS NOT NULL THEN c.IndepYear
		ELSE "NULL"
	END AS superefice_maggiore100k
FROM country AS c;

-- 2.
SELECT 
    c.Name AS nome, 
    c.CountryCode AS codice, 
    n.Name AS nazione
FROM city AS c
INNER JOIN country AS n ON c.CountryCode = n.Code
WHERE n.Population > 1000000
ORDER BY c.Name ASC;

-- 3.
CREATE OR REPLACE VIEW view_nomi AS
SELECT c.Name, c.Population 
FROM city AS c
INNER JOIN country AS n ON c.CountryCode = n.Code
WHERE LOWER(c.CountryCode) = 'ita';

SELECT * FROM view_nomi;

-- 4.
SELECT * FROM view_nomi 
WHERE Population < 100000;

