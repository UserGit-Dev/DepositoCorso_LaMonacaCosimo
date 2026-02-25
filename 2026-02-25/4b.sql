-- ==========================================================
-- 1. TABELLE DI BASE (NESSUNA DIPENDENZA)
-- ==========================================================

INSERT INTO Specializzazione (nome) VALUES 
('Cardiologia'), ('Ortopedia'), ('Dermatologia'), ('Neurologia'), ('Pediatria');

INSERT INTO Reparto (nome, numero_posti) VALUES 
('Terapia Intensiva', 5), ('Chirurgia', 20), ('Riabilitazione', 10);

-- Inseriamo pazienti specifici per soddisfare la Query 10 (almeno 2 ricoveri, 5 appuntamenti)
INSERT INTO Paziente (nome, cognome, data_nascita, codice_fiscale, telefono) VALUES 
('Mario', 'Rossi', '1980-05-15', 'RSSMRA80E15H501U', '3331112222'), -- Il "Paziente VIP"
('Laura', 'Bianchi', '1992-09-20', 'BNCLRA92P60L219X', '3405556666'),
('Luca', 'Verdi', '1970-01-01', 'VRDLCA70A01F205Z', '3470001111');

-- ==========================================================
-- 2. MEDICI (Uno sarà inattivo per soddisfare la Query 7)
-- ==========================================================

INSERT INTO Medico (nome, cognome, id_specializzazione, stipendio, data_assunzione) VALUES 
('Stefano', 'Martini', 1, 5000.00, '2010-01-01'), -- Molto attivo
('Elena', 'Fabbri', 2, 4500.00, '2015-05-10'),   -- Attiva
('Marco', 'Pigro', 3, 3000.00, '2023-01-01');    -- INATTIVO (nessun appuntamento recente)

-- ==========================================================
-- 3. RICOVERI (Per Query 6 e Query 10)
-- ==========================================================

INSERT INTO Ricovero (id_paziente, id_reparto, data_ingresso, data_dimissione) VALUES 
(1, 1, '2024-01-01', '2024-01-10'), -- Primo ricovero Rossi
(1, 1, '2024-02-01', NULL),         -- Secondo ricovero Rossi (ATTUALE per occupazione letti)
(2, 1, '2024-02-15', NULL),         -- Ricovero Bianchi (ATTUALE)
(3, 2, '2024-01-20', '2024-01-25');

-- ==========================================================
-- 4. APPUNTAMENTI (Per Query 8 e 10 - Rossi ne ha 5)
-- ==========================================================

-- Rossi: 5 appuntamenti per soddisfare la Query 10
INSERT INTO Appuntamento (id_paziente, id_medico, data_appuntamento, stato, costo) VALUES 
(1, 1, '2024-01-05 10:00:00', 'completato', 200.00),
(1, 1, '2024-01-20 10:00:00', 'completato', 200.00),
(1, 1, '2024-02-05 10:00:00', 'completato', 200.00),
(1, 2, '2024-02-15 10:00:00', 'completato', 150.00),
(1, 2, '2024-02-20 10:00:00', 'completato', 150.00),
-- Bianchi: solo 1 appuntamento
(2, 1, '2024-02-10 11:00:00', 'completato', 200.00);

-- ==========================================================
-- 5. PAGAMENTI (Per Query 9 - divisi su mesi diversi)
-- ==========================================================

INSERT INTO Pagamento (id_appuntamento, importo, metodo_pagamento, data_pagamento) VALUES 
(1, 200.00, 'Carta', '2024-01-05 11:00:00'),
(2, 200.00, 'Carta', '2024-01-20 11:00:00'), -- Tot Gennaio: 400
(3, 200.00, 'Contanti', '2024-02-05 11:00:00'),
(4, 150.00, 'Carta', '2024-02-15 11:00:00'),
(5, 150.00, 'Carta', '2024-02-20 11:00:00'),
(6, 200.00, 'Bancomat', '2024-02-10 12:00:00'); -- Tot Febbraio: 700