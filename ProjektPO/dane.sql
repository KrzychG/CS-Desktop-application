CREATE TABLE IF NOT EXISTS employee (
    id SERIAL PRIMARY KEY,
    firstname VARCHAR(100) NOT NULL,
    lastname VARCHAR(100) NOT NULL,
    department VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS device (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    serialnumber VARCHAR(100) NOT NULL,
    purchasedate DATE NOT NULL,
    employeeid INT,
    CONSTRAINT fk_employee FOREIGN KEY (employeeid) REFERENCES employee(id) ON DELETE SET NULL
);
