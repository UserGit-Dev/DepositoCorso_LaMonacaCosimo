USE world;

-- 1.
SELECT 
    n.Name AS nazione, 
    c.Name AS citta,
    l.Language AS lingua
FROM country AS n
INNER JOIN city AS c ON c.CountryCode = n.Code
INNER JOIN countrylanguage AS l ON l.CountryCode = n.Code;

-- 2.
SELECT 
	n.Name AS nazione, 
    COUNT(c.Name) AS numero_citta 
FROM city AS c
INNER JOIN country as n ON n.Code = c.CountryCode
GROUP BY n.Name
ORDER BY numero_citta DESC;

-- 3.
SELECT 
	n.Name AS paese, 
    n.LifeExpectancy AS aspettativa_vita, 
    l.Language,
    n.GovernmentForm
FROM country AS n
INNER JOIN countrylanguage AS l ON l.CountryCode = n.Code
WHERE LOWER(n.GovernmentForm) LIKE 'republic%'
AND n.LifeExpectancy > 70;

-- 4.
SELECT 
    n.Name AS Nazione, 
    l.Language AS Lingua, 
    l.Percentage AS Percentuale
FROM country AS n
INNER JOIN countrylanguage AS l ON n.Code = l.CountryCode
ORDER BY n.Name ASC, l.Percentage DESC;

-- 5.
SELECT 
    n.Name AS Nazione, 
    l.Language AS LinguaPrincipale, 
    l.Percentage AS Percentuale
FROM country AS n
INNER JOIN countrylanguage AS l ON n.Code = l.CountryCode
WHERE l.Percentage = (
    SELECT MAX(l2.Percentage)
    FROM countrylanguage AS l2
    WHERE l2.CountryCode = l.CountryCode
)
ORDER BY n.Name ASC;

-- 6.
SELECT 
    n.Name AS Nazione, 
    l.Language AS lingua_principale, 
    l.Percentage AS percentuale,
    (SELECT COUNT(*) FROM city AS c WHERE c.CountryCode = n.Code) AS numero_citta
FROM country AS n
INNER JOIN countrylanguage AS l ON n.Code = l.CountryCode
WHERE l.Percentage = (
    SELECT MAX(l2.Percentage)
    FROM countrylanguage AS l2
    WHERE l2.CountryCode = l.CountryCode
)
ORDER BY n.Name ASC;

-- 7.
/*
SELECT 
	subQ1.Continent AS continente, 
    subQ1.Language as lingua
    subQ1.Percentuale 
FROM (
	country AS c
	INNER JOIN countrylanguage AS l ON c.Code = l.CountryCode;
);
*/

-- Test
SELECT Continent, Language, TotalSpeakers
FROM (
    SELECT 
        c.Continent, 
        cl.Language, 
        ROUND(SUM(c.Population * cl.Percentage / 100)) AS TotalSpeakers,
        ROW_NUMBER() OVER (
            PARTITION BY c.Continent 
            ORDER BY SUM(c.Population * cl.Percentage / 100) DESC
        ) AS LanguageRank
    FROM country c
    JOIN countrylanguage cl ON c.Code = cl.CountryCode
    GROUP BY c.Continent, cl.Language
) AS RankedLanguages
WHERE LanguageRank <= 3
ORDER BY Continent ASC, TotalSpeakers DESC;