CREATE DATABASE IF NOT EXISTS clinica;
USE clinica;

-- 1. Specializzazione (Tabella Indipendente)
CREATE TABLE Specializzazione (
    id_specializzazione INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) UNIQUE NOT NULL
);

-- 2. Reparto (Tabella Indipendente)
CREATE TABLE Reparto (
    id_reparto INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL,
    numero_posti INT NOT NULL CHECK (numero_posti > 0) 
);

-- 3. Paziente (Tabella Indipendente)
CREATE TABLE Paziente (
    id_paziente INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL, 
    cognome VARCHAR(100) NOT NULL, 
    data_nascita DATE NOT NULL,
    codice_fiscale CHAR(16) UNIQUE NOT NULL,
    telefono VARCHAR(20),
    email VARCHAR(100), 
    data_registrazione DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- 4. Medico (Dipende da Specializzazione)
CREATE TABLE Medico (
    id_medico INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL,
    cognome VARCHAR(100) NOT NULL,
    id_specializzazione INT, 
    stipendio DECIMAL(10,2) CHECK (stipendio > 0),
    data_assunzione DATE NOT NULL, 
    FOREIGN KEY (id_specializzazione) REFERENCES Specializzazione(id_specializzazione) ON DELETE SET NULL
);

-- 5. Appuntamento (Dipende da Paziente e Medico)
CREATE TABLE Appuntamento (
    id_appuntamento INT PRIMARY KEY AUTO_INCREMENT, 
    id_paziente INT, 
    id_medico INT, 
    data_appuntamento DATETIME NOT NULL, 
    stato ENUM('prenotato', 'completato', 'annullato') DEFAULT 'prenotato', 
    costo DECIMAL(10,2) DEFAULT 0 CHECK (costo >= 0), 
    FOREIGN KEY (id_paziente) REFERENCES Paziente(id_paziente) ON DELETE CASCADE,
    FOREIGN KEY (id_medico) REFERENCES Medico(id_medico) ON DELETE CASCADE
);
-- 6. Ricovero (Dipende da Paziente e Reparto)
CREATE TABLE Ricovero (
    id_ricovero INT PRIMARY KEY AUTO_INCREMENT,
    id_paziente INT, 
    id_reparto INT, 
    data_ingresso DATE NOT NULL,
    data_dimissione DATE NULL, 
    CONSTRAINT chk_date CHECK (data_dimissione IS NULL OR data_dimissione >= data_ingresso), 
    FOREIGN KEY (id_paziente) REFERENCES Paziente(id_paziente) ON DELETE CASCADE, 
    FOREIGN KEY (id_reparto) REFERENCES Reparto(id_reparto) ON DELETE CASCADE 
);

-- 7. Prescrizione (Dipende da Appuntamento)
CREATE TABLE Prescrizione (
    id_prescrizione INT PRIMARY KEY AUTO_INCREMENT, 
    id_appuntamento INT,
    descrizione TEXT NOT NULL, 
    data_prescrizione DATE NOT NULL,
    FOREIGN KEY (id_appuntamento) REFERENCES Appuntamento(id_appuntamento) ON DELETE CASCADE
);

-- 8. Pagamento (Dipende da Appuntamento)
CREATE TABLE Pagamento (
    id_pagamento INT PRIMARY KEY AUTO_INCREMENT, 
    id_appuntamento INT, 
    importo DECIMAL(10,2) NOT NULL,
    metodo_pagamento VARCHAR(50),
    data_pagamento DATETIME DEFAULT CURRENT_TIMESTAMP, 
    FOREIGN KEY (id_appuntamento) REFERENCES Appuntamento(id_appuntamento) ON DELETE CASCADE 
);