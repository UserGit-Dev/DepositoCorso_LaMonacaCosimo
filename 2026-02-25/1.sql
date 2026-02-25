USE libreria;

CREATE TABLE libri (
id INT,
titolo VARCHAR(100),
autore VARCHAR(100),
genere VARCHAR(50),
anno_pubblicazione INT,
prezzo DECIMAL(10,2),
PRIMARY KEY(id)
);

CREATE TABLE vendite (
	id INT,
    id_libro INT,
    data_vendita DATE,
    quantita INT,
    negozio VARCHAR(100),    
    PRIMARY KEY(id)
);

INSERT INTO libri (id, titolo, autore, genere, anno_pubblicazione, prezzo) VALUES
(1, 'It', 'Stephen King', 'Horror', 1986, 22.00),
(2, 'Shining', 'Stephen King', 'Horror', 1977, 14.50),
(3, 'Misery', 'Stephen King', 'Thriller Psicologico', 1987, 13.00),
(4, '22/11/''63', 'Stephen King', 'Fantascienza', 2011, 25.00),
(5, 'Il Signore degli Anelli', 'J.R.R. Tolkien', 'Fantasy', 1954, 30.00),
(6, '1984', 'George Orwell', 'Distopia', 1949, 12.50),
(7, 'Il Nome della Rosa', 'Umberto Eco', 'Giallo Storico', 1980, 16.00),
(8, 'Harry Potter e la Pietra Filosofale', 'J.K. Rowling', 'Fantasy', 1997, 15.00),
(9, 'Sapiens: Da animali a dèi', 'Yuval Noah Harari', 'Saggistica', 2011, 21.00),
(10, 'Il Piccolo Principe', 'Antoine de Saint-Exupéry', 'Favola', 1943, 8.00);

INSERT INTO vendite (id, id_libro, data_vendita, quantita, negozio) VALUES
(1, 1, '2024-01-10', 5, 'Amazon'),
(2, 2, '2024-01-11', 2, 'Libreria Centrale'),
(3, 5, '2024-01-12', 1, 'Feltrinelli'),
(4, 3, '2024-01-12', 3, 'Mondadori Store'),
(5, 8, '2024-01-13', 10, 'Amazon'),
(6, 4, '2024-01-14', 2, 'Libreria del Porto'),
(7, 1, '2024-01-15', 1, 'Feltrinelli'),
(8, 7, '2024-01-16', 4, 'Mondadori Store'),
(9, 6, '2024-01-17', 2, 'Libreria Centrale'),
(10, 10, '2024-01-18', 6, 'Amazon');

-- 1.
SELECT l.titolo, v.negozio, SUM(v.quantita * l.prezzo) as prezzo_totale FROM libri AS l
INNER JOIN vendite AS v ON l.id = v.id_libro
WHERE LOWER(v.negozio) IN ('libreria centrale','bookcity milano','cartoleria roma')
GROUP BY l.titolo, v.negozio;

-- 2.
SELECT l.titolo, v.data_vendita, l.prezzo, v.quantita FROM libri AS l
INNER JOIN vendite AS V ON v.id_libro = l.id
WHERE LOWER(v.negozio) LIKE '%book%' 
AND v.data_vendita BETWEEN '2020-01-01' AND '2022-12-31';

-- 3.
SELECT l.titolo, l.autore, l.prezzo, v.data_vendita FROM libri AS l
INNER JOIN vendite AS v ON v.id_libro = l.id
WHERE l.genere IN ('Fantasy', 'Horror', 'Giallo') 
AND LOWER(v.negozio) LIKE '%store%'
AND l.anno_pubblicazione > 2015
ORDER BY l.anno_pubblicazione DESC;
-- ==================================================