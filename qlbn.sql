BEGIN TRANSACTION;

CREATE TABLE Publisher (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL
);

INSERT INTO Publisher (Name) VALUES ('Department of Orthopedics');
INSERT INTO Publisher (Name) VALUES ('Emergency Department');
INSERT INTO Publisher (Name) VALUES ('Department of ENT');
INSERT INTO Publisher (Name) VALUES ('Pediatrics');
INSERT INTO Publisher (Name) VALUES ('(ICU) Department of Intensive Care and Anti-Poison');

CREATE TABLE Patient (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Year INT NOT NULL,
    Height FLOAT NOT NULL,
    Blood_Type NVARCHAR(10) NOT NULL,  -- Sửa lại tên cột ở đây
    Gender INT NOT NULL,
    Status INT NOT NULL,
    ImportDate DATETIME NOT NULL,
    ExportDate DATETIME NULL,
    PublisherId INT NOT NULL,
    CONSTRAINT FK_Patient_Publisher_PublisherId FOREIGN KEY (PublisherId) REFERENCES Publisher(Id) ON DELETE CASCADE
);

INSERT INTO Patient (Name, Year, Height, Blood_Type, Gender, Status, ImportDate, ExportDate, PublisherId) VALUES
('Nguyễn Thanh Vân', 2005, 1.68, 'A', 0, 1, '2023-12-27 00:00:00', '2023-12-27 00:00:00', 2);

CREATE INDEX IX_Patient_PublisherId ON Patient (PublisherId);

COMMIT;