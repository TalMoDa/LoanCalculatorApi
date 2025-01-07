
CREATE DATABASE  Finance;


CREATE TABLE  Clients (
                         Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
                         FullName NVARCHAR(100) NOT NULL,
                         Age INT NOT NULL,
                         CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE LoanPeriodExtraMonthInterests (
                                 Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
                                 ExtraMonths INT NOT NULL, -- Number of months after the minimum period
                                 ExtraMonthInterestRate DECIMAL(5, 4) NOT NULL, -- Extra interest rate for each additional month
                                 CreatedAt DATETIME DEFAULT GETDATE()
);


CREATE TABLE LoanAgeCalculations (
                                      Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
                                      MinAge INT NOT NULL,
                                      MaxAge INT NOT NULL,
                                      LoanMinAmount DECIMAL(18, 2) NOT NULL,
                                      LoanMaxAmount DECIMAL(18, 2) NULL,
                                      InterestRate DECIMAL(5, 2) NOT NULL, -- Base interest rate in %
                                      IsWithPrimeInterest BIT NOT NULL, -- 1 = Adds Prime Interest, 0 = Fixed Interest
                                      LoanPeriodExtraMonthInterestId int NULL, -- FK to LoanPeriodExtraMonthRules if null so no extra interest
                                      CreatedAt DATETIME DEFAULT GETDATE(),
                                      FOREIGN KEY (LoanPeriodExtraMonthInterestId) REFERENCES LoanPeriodExtraMonthInterests(Id)
);

CREATE TABLE PrimeInterest (
                               Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
                               InterestRate DECIMAL(5, 2) NOT NULL, -- Prime interest rate in %
                               EffectiveDate DATETIME DEFAULT GETDATE(),
                               IsActive BIT NOT NULL -- 1 = Active, 0 = Inactive
);


INSERT INTO LoanPeriodExtraMonthInterests (ExtraMonths, ExtraMonthInterestRate)
VALUES (12, 0.15);


INSERT INTO Clients (FullName, Age)
VALUES
    ('John Doe', 15),
        ('John Doe', 25),
       ('Jane Doe', 35),
       ('Alice Doe', 45),
       ('Bob Doe', 55),
       ('Charlie Doe', 65);

INSERT Into PrimeInterest (InterestRate, IsActive)
VALUES (1.5, 1);


INSERT INTO LoanAgeCalculations (MinAge, MaxAge, LoanMinAmount, LoanMaxAmount, InterestRate, IsWithPrimeInterest, LoanPeriodExtraMonthInterestId)
VALUES 
    -- Below 20 years: Interest = 2% + prime interest
    (0, 19, 0, NULL, 2, 1, 1),

    -- Age 20-35:
    -- Loan ≤ 5,000: 2% fixed
    (20, 35, 0, 5000, 2, 0, 1),

    -- Loan > 5,000 and ≤ 30,000: 1.5% + prime
    (20, 35, 5001, 30000, 1.5, 1, 1),

    -- Loan > 30,000: 1% + prime
    (20, 35, 30001, NULL, 1, 1, 1),

    -- Above 35:
    -- Loan ≤ 15,000: 1.5% + prime
    (36, 150, 0, 15000, 1.5, 1, 1),

    -- Loan > 15,000 and ≤ 30,000: 3% + prime
    (36, 150, 15001, 30000, 3, 1, 1),

    -- Loan > 30,000: 1% fixed
    (36, 150, 30001, NULL, 1, 0, 1);