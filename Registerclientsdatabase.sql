/*Creating table*/
use clients;
CREATE TABLE clients (
    id INT NOT NULL PRIMARY KEY IDENTITY,
    name VARCHAR (100) NOT NULL,
    email VARCHAR (150) NOT NULL UNIQUE,
    phone VARCHAR(20) NULL,
    address VARCHAR(100) NULL,
    created_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);

/*Showing tables*/
select * from clients;

/*Adding Data*/
INSERT INTO clients (name, email, phone, address)
VALUES
('Ambar Caraballo', 'ambarc.r@microsoft.com', '+18092575938', 'Santo Domingo, Dominican Republic');

INSERT INTO clients (name, email, phone, address)
VALUES
('Adreina Luna', 'aluna@gmail.com', '+18092575938', 'Oaxaca, Mexico');

INSERT INTO clients (name, email, phone, address)
VALUES
('Julia Acosta', 'Jacosta@yahoo.com', '+1454421878', 'Chile Peru');

INSERT INTO clients (name, email, phone, address)
VALUES
('Andres Guzman', 'Aguzman@hotmail.com', '+1789654125', 'San Juan, Puerto Rico');

INSERT INTO clients (name, email, phone, address)
VALUES
('Joel Smith', 'jsmith@hotmail.com', '+1789655555', 'Ottawa, Canada');