USE clinica;

-- Query 6. Mostrare per ogni reparto il tasso di occupazione attuale.
SELECT 
    r.nome AS Reparto,
    r.numero_posti AS Capacità_Totale,
    COUNT(ric.id_ricovero) AS Pazienti_Attuali,
    ROUND((COUNT(ric.id_ricovero) * 100.0 / r.numero_posti), 2) AS Percentuale_Occupazione
FROM 
    Reparto AS r
LEFT JOIN 
    Ricovero as ric ON r.id_reparto = ric.id_reparto 
    AND ric.data_dimissione IS NULL 
GROUP BY 
    r.id_reparto, r.nome, r.numero_posti;
    
-- 7. Mostrare i medici che non hanno avuto appuntamenti negli ultimi 30 giorni.
SELECT 
    m.nome AS Nome, 
    m.cognome AS Cognome
FROM Medico AS m
WHERE NOT EXISTS (
    SELECT 1 
    FROM Appuntamento AS a 
    WHERE a.id_medico = m.id_medico 
    AND a.data_appuntamento >= DATE_SUB(CURDATE(), INTERVAL 30 DAY)
);

-- 8. Mostrare la specializzazione che ha generato più incasso totale.
SELECT 
    s.nome AS Nome, 
    SUM(p.importo) AS Incasso_Totale
FROM Specializzazione s
JOIN Medico m ON s.id_specializzazione = m.id_specializzazione
JOIN Appuntamento a ON m.id_medico = a.id_medico
JOIN Pagamento p ON a.id_appuntamento = p.id_appuntamento
GROUP BY s.id_specializzazione, s.nome
ORDER BY Incasso_Totale DESC
LIMIT 1;

-- 9. Mostrare per ogni mese l’incasso totale e la variazione percentuale rispetto al mese precedente.
WITH IncassiMensili AS (
    SELECT 
        DATE_FORMAT(data_pagamento, '%Y-%m') AS Mese,
        SUM(importo) AS Incasso_Attuale
    FROM Pagamento
    GROUP BY Mese
)
SELECT 
    Mese,
    Incasso_Attuale,
    LAG(Incasso_Attuale) OVER (ORDER BY Mese) AS Incasso_Precedente,
    ROUND(
        ((Incasso_Attuale - LAG(Incasso_Attuale) OVER (ORDER BY Mese)) / 
        NULLIF(LAG(Incasso_Attuale) OVER (ORDER BY Mese), 0)) * 100, 2
    ) AS Variazione_Percentuale
FROM IncassiMensili;

-- 10. Mostrare i pazienti che: hanno avuto almeno 2 ricoveri; e hanno effettuato almeno 5 appuntamenti; e hanno speso sopra la media dei pazienti
SELECT p.id_paziente, p.nome, p.cognome
FROM Paziente AS p
WHERE 
    -- 1. Almeno 2 ricoveri
    (SELECT COUNT(*) FROM Ricovero AS r WHERE r.id_paziente = p.id_paziente) >= 2
    AND 
    -- 2. Almeno 5 appuntamenti
    (SELECT COUNT(*) FROM Appuntamento AS a WHERE a.id_paziente = p.id_paziente) >= 5
    AND      
    -- 3. Spesa totale sopra la media dei pazienti
    (SELECT SUM(pag.importo) FROM Pagamento AS pag 
     JOIN Appuntamento AS app ON pag.id_appuntamento = app.id_appuntamento
     WHERE app.id_paziente = p.id_paziente) 
     > 
    (SELECT AVG(totale_paziente) FROM (
        SELECT SUM(pag2.importo) as totale_paziente 
        FROM Pagamento AS pag2
        JOIN Appuntamento AS app2 ON pag2.id_appuntamento = app2.id_appuntamento
        GROUP BY app2.id_paziente
    ) AS MediaGenerale);