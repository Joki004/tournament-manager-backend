--Create Database
USE master;
DROP DATABASE IF EXISTS TournamentManagement;
CREATE DATABASE TournamentManagement;
USE TournamentManagement;

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY,
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
    PlayersPerTeam INT
);
GO

CREATE TABLE TournamentTypes (
    TournamentTypeID INT PRIMARY KEY IDENTITY,
    TournamentTypeName NVARCHAR(50) NOT NULL,
    Description NVARCHAR(255)
);
GO

CREATE TABLE Tournaments (
    TournamentID INT PRIMARY KEY IDENTITY,
    UserID INT NOT NULL,
    TournamentName NVARCHAR(100) NOT NULL,
    DisciplineID INT NOT NULL,
    TournamentTypeID INT NOT NULL,
    NumberOfTeams INT NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME,
    WinnerTeamID INT,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (DisciplineID) REFERENCES Disciplines(DisciplineID),
    FOREIGN KEY (TournamentTypeID) REFERENCES TournamentTypes(TournamentTypeID),
    FOREIGN KEY (WinnerTeamID) REFERENCES Teams(TeamID)
);
GO

CREATE TABLE Teams (
    TeamID INT PRIMARY KEY IDENTITY,
    TournamentID INT NOT NULL,
    TeamName NVARCHAR(100) NOT NULL,
    MatchesPlayed INT DEFAULT 0,
    FOREIGN KEY (TournamentID) REFERENCES Tournaments(TournamentID)
);
GO

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



