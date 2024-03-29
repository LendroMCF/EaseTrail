CREATE DATABASE EaseT_db
USE EaseT_db

CREATE TABLE Plans (
    Id CHAR(36) PRIMARY KEY,
    Name VARCHAR(250),
    Value DECIMAL(10, 2),
    Description VARCHAR(500),
    UserLimit INT,
    TeamLimit INT,
    ViewDashboard BIT,
    SupportLevel INT
);

CREATE TABLE Functions (
    Id CHAR(36) PRIMARY KEY,
    Name VARCHAR(250),
    Description VARCHAR(500)
);

CREATE TABLE PlanFunctions (
    Id CHAR(36) PRIMARY KEY,
    FunctionId CHAR(36),
    PlanId CHAR(36),
    FOREIGN KEY (FunctionId) REFERENCES Functions(Id),
    FOREIGN KEY (PlanId) REFERENCES Plans(Id)
);

CREATE TABLE Account (
    Id CHAR(36) PRIMARY KEY,
    Email VARCHAR(500),
    Phone VARCHAR(500),
    Code VARCHAR(500),
    Token VARCHAR(500),
    Status INT
);

CREATE TABLE AccountDetails (
    Id CHAR(36) PRIMARY KEY,
    AccountId CHAR(36),
    Name VARCHAR(250),
    Picture VARBINARY(MAX),
    FOREIGN KEY (AccountId) REFERENCES Account(Id)
);

CREATE TABLE AccountPlan (
    Id CHAR(36) PRIMARY KEY,
    AccountId CHAR(36),
    PlanId CHAR(36),
    PaymentStatus INT,
    Discount DECIMAL(10, 2),
    FOREIGN KEY (AccountId) REFERENCES Account(Id),
    FOREIGN KEY (PlanId) REFERENCES Plans(Id)
);

CREATE TABLE OriginStatus (
    Id CHAR(36) PRIMARY KEY,
    AccountId CHAR(36),
    Name VARCHAR(250),
    OriginStatus INT,
    FOREIGN KEY (AccountId) REFERENCES Account(Id)
);

CREATE TABLE Users (
    Id CHAR(36) PRIMARY KEY,
    AccountId CHAR(36),
    OriginStatusId CHAR(36),
    OriginId VARCHAR(500),
    Name VARCHAR(250),
    OriginPaymentStatus INT,
    FOREIGN KEY (AccountId) REFERENCES Account(Id),
    FOREIGN KEY (OriginStatusId) REFERENCES OriginStatus(Id)
);

CREATE TABLE Teams (
    Id CHAR(36) PRIMARY KEY,
    AccountId CHAR(36),
    Name VARCHAR(250),
    Description VARCHAR(500),
    TeammateCount INT,
    TeamType INT,
    TeamStatus INT,
    FOREIGN KEY (AccountId) REFERENCES Account(Id)
);

CREATE TABLE TeamAccounts (
    Id CHAR(36) PRIMARY KEY,
    AccountId CHAR(36),
    TeamId CHAR(36),
    MemberType INT,
    FOREIGN KEY (AccountId) REFERENCES Account(Id),
    FOREIGN KEY (TeamId) REFERENCES Teams(Id)
);

CREATE TABLE Transactions (
    Id CHAR(36) PRIMARY KEY,
    SenderId CHAR(36),
    ReceiverId CHAR(36),
    Value DECIMAL(10, 2),
    Description VARCHAR(500),
    FOREIGN KEY (SenderId) REFERENCES Account(Id),
    FOREIGN KEY (ReceiverId) REFERENCES Account(Id)
);

CREATE TABLE SystemTransactions (
    Id CHAR(36) PRIMARY KEY,
    SenderId CHAR(36),
    Value DECIMAL(10, 2),
    Description VARCHAR(500),
    FOREIGN KEY (SenderId) REFERENCES Account(Id)
);

CREATE TABLE Collaborators (
    Id CHAR(36) PRIMARY KEY,
    AccountId CHAR(36),
    Name VARCHAR(250),
    Link1 VARCHAR(500),
    Link2 VARCHAR(500),
    Link3 VARCHAR(500),
    Available INT,
    ValuePerHour DECIMAL(10, 2),
    FOREIGN KEY (AccountId) REFERENCES Account(Id)
);

CREATE TABLE Abilities (
    Id CHAR(36) PRIMARY KEY,
    Name VARCHAR(250),
    CreationType INT
);

CREATE TABLE CollaboratorAbilities (
    Id CHAR(36) PRIMARY KEY,
    CollaboratorId CHAR(36),
    AbilityId CHAR(36),
    FOREIGN KEY (CollaboratorId) REFERENCES Collaborators(Id),
    FOREIGN KEY (AbilityId) REFERENCES Abilities(Id)
);
