USE master;
GO

-- Drop existing database if it exists
IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'TournamentManagement')
    DROP DATABASE TournamentManagement;
GO

-- Create new database
CREATE DATABASE TournamentManagement;
GO

USE TournamentManagement;
GO

--ALTER TABLE

ALTER TABLE  Teams DROP CONSTRAINT FK_Teams_Tournaments;
ALTER TABLE Tournaments DROP CONSTRAINT FK_Tournaments_Users;
ALTER TABLE Tournaments DROP CONSTRAINT FK_Tournaments_Disciplines;
ALTER TABLE Tournaments DROP CONSTRAINT FK_Tournaments_TournamentTypes;
ALTER TABLE Tournaments DROP CONSTRAINT FK_Tournaments_Teams;
GO


-- Drop existing tables if they exist
IF OBJECT_ID('dbo.BracketMatches', 'U') IS NOT NULL
    DROP TABLE dbo.BracketMatches;
GO

IF OBJECT_ID('dbo.RoundRobinMatches', 'U') IS NOT NULL
    DROP TABLE dbo.RoundRobinMatches;
GO

IF OBJECT_ID('dbo.Players', 'U') IS NOT NULL
    DROP TABLE dbo.Players;
GO

IF OBJECT_ID('dbo.Teams', 'U') IS NOT NULL
    DROP TABLE dbo.Teams;
GO

IF OBJECT_ID('dbo.Tournaments', 'U') IS NOT NULL
    DROP TABLE dbo.Tournaments;
GO

IF OBJECT_ID('dbo.TournamentTypes', 'U') IS NOT NULL
    DROP TABLE dbo.TournamentTypes;
GO

IF OBJECT_ID('dbo.Disciplines', 'U') IS NOT NULL
    DROP TABLE dbo.Disciplines;
GO

IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
    DROP TABLE dbo.Users;
GO


CREATE TABLE Users (
    UserID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE Disciplines (
    DisciplineID INT PRIMARY KEY IDENTITY,
    DisciplineName NVARCHAR(50) NOT NULL,
    Description NVARCHAR(255),
    PlayersPerTeam INT NOT NULL
);
GO

CREATE TABLE TournamentTypes (
    TournamentTypeID INT PRIMARY KEY IDENTITY,
    TournamentTypeName NVARCHAR(50) NOT NULL,
    Description NVARCHAR(255)
);
GO

CREATE TABLE Teams (
    TeamID INT PRIMARY KEY IDENTITY,
    TournamentID INT NOT NULL,
    TeamName NVARCHAR(100) NOT NULL,
    MatchesPlayed INT DEFAULT 0,
   
);
GO

CREATE TABLE Tournaments (
    TournamentID INT PRIMARY KEY IDENTITY,
    UserID UNIQUEIDENTIFIER NOT NULL,
    TournamentName NVARCHAR(100) NOT NULL,
    DisciplineID INT NOT NULL,
    TournamentTypeID INT NOT NULL,
    NumberOfTeams INT NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME,
    WinnerTeamID INT,
    CreatedAt DATETIME DEFAULT GETDATE(),
);
GO

ALTER TABLE Teams
ADD CONSTRAINT FK_Teams_Tournaments
FOREIGN KEY (TournamentID) REFERENCES Tournaments(TournamentID);

--FOREING KEY TOURNAMENT
ALTER TABLE Tournaments
ADD CONSTRAINT FK_Tournaments_Users
FOREIGN KEY (UserID) REFERENCES Users(UserID);
GO

ALTER TABLE Tournaments
ADD CONSTRAINT FK_Tournaments_Disciplines
FOREIGN KEY (DisciplineID) REFERENCES Disciplines(DisciplineID);
GO


ALTER TABLE Tournaments
ADD CONSTRAINT FK_Tournaments_TournamentTypes
FOREIGN KEY (TournamentTypeID) REFERENCES TournamentTypes(TournamentTypeID);

GO

ALTER TABLE Tournaments
ADD CONSTRAINT FK_Tournaments_Teams
FOREIGN KEY (WinnerTeamID) REFERENCES Teams(TeamID);
go





CREATE TABLE Players (
    PlayerID INT PRIMARY KEY IDENTITY,
    TeamID INT NOT NULL,
    PlayerName NVARCHAR(100) NOT NULL,
    FOREIGN KEY (TeamID) REFERENCES Teams(TeamID)
);
GO

CREATE TABLE BracketMatches (
    MatchID INT PRIMARY KEY IDENTITY,
    TournamentID INT NOT NULL,
    Round INT NOT NULL,
    Team1ID INT NOT NULL,
    Team2ID INT NOT NULL,
    WinnerTeamID INT,
    MatchDate DATETIME,
    FOREIGN KEY (TournamentID) REFERENCES Tournaments(TournamentID),
    FOREIGN KEY (Team1ID) REFERENCES Teams(TeamID),
    FOREIGN KEY (Team2ID) REFERENCES Teams(TeamID),
    FOREIGN KEY (WinnerTeamID) REFERENCES Teams(TeamID)
);
GO

CREATE TABLE RoundRobinMatches (
    MatchID INT PRIMARY KEY IDENTITY,
    TournamentID INT NOT NULL,
    Team1ID INT NOT NULL,
    Team2ID INT NOT NULL,
    Team1Score INT,
    Team2Score INT,
    MatchDate DATETIME,
    FOREIGN KEY (TournamentID) REFERENCES Tournaments(TournamentID),
    FOREIGN KEY (Team1ID) REFERENCES Teams(TeamID),
    FOREIGN KEY (Team2ID) REFERENCES Teams(TeamID)
);
GO


SELECT * FROM Tournaments;

DELETE  FROM USERS WHERE UserName = 'joki_004'


-- Sample data for Disciplines table
INSERT INTO Disciplines (DisciplineName, Description, PlayersPerTeam)
VALUES ('Football', 'Description for Football', 11),
       ('Basketball', 'Description for Basketball', 5),
       ('Tennis', 'Description for Tennis', 1);


INSERT INTO TournamentTypes (TournamentTypeName, Description)
VALUES ('Single Elimination', 'Description for Single Elimination'),
       ('Round Robin', 'Description for Round Robin');


INSERT INTO Teams (TournamentID, TeamName, MatchesPlayed)
VALUES (2, 'Team A', 0),
       (2, 'Team B', 0),
       (3, 'Team C', 0);

	   INSERT INTO Tournaments (UserID, TournamentName, DisciplineID, TournamentTypeID, NumberOfTeams, StartDate, EndDate, WinnerTeamID, CreatedAt )
VALUES ('2E110C63-4713-452C-9841-6DB141C038DA', 'Football Tournament', 1, 1, 2, '2024-06-01', NULL, NULL,GETDATE()),
       ('2E110C63-4713-452C-9841-6DB141C038DA', 'Basketball Tournament', 2, 2, 1, '2024-06-01', NULL, NULL,GETDATE());


	   --2E110C63-4713-452C-9841-6DB141C038DA