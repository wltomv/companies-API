-- CREATE DATABASE Companies

CREATE TABLE Company
(
    id SERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL
);

CREATE TABLE Employee
(
    id SERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    lastname VARCHAR(50) NOT NULL,
    companyId INT NOT NULL REFERENCES Company(Id)
);

CREATE TABLE Position
(
    id SERIAL PRIMARY KEY,
    positionName VARCHAR(50) NOT NULL
);

CREATE TABLE PositionEmployee
(
    id SERIAL PRIMARY KEY,
    employeeId INT NOT NULL REFERENCES Employee(id),
    positionId INT NOT NULL REFERENCES Position(id)
);