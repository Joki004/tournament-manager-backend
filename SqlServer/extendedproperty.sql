--Users Table
EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Table storing user information.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'Users';

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'The primary key of the Users table.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'Users', 
    @level2type=N'COLUMN', @level2name=N'UserID';

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'User''s username.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'Users', 
    @level2type=N'COLUMN', @level2name=N'UserName';

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'User''s email address.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'Users', 
    @level2type=N'COLUMN', @level2name=N'Email';

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Hashed password of the user.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'Users', 
    @level2type=N'COLUMN', @level2name=N'PasswordHash';

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'The date and time when the user was created.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'Users', 
    @level2type=N'COLUMN', @level2name=N'CreatedAt';



--Disciplines Table
EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Table storing different sports disciplines.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'Disciplines';

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'The primary key of the Disciplines table.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'Disciplines', 
    @level2type=N'COLUMN', @level2name=N'DisciplineID';

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'The name of the discipline.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'Disciplines', 
    @level2type=N'COLUMN', @level2name=N'DisciplineName';

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Description of the discipline.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'Disciplines', 
    @level2type=N'COLUMN', @level2name=N'Description';

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'The number of players per team in the discipline.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'Disciplines', 
    @level2type=N'COLUMN', @level2name=N'PlayersPerTeam';


--TournamentTypes Table
EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Table storing different types of tournaments.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'TournamentTypes';

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'The primary key of the TournamentTypes table.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'TournamentTypes', 
    @level2type=N'COLUMN', @level2name=N'TournamentTypeID';

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'The name of the tournament type.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'TournamentTypes', 
    @level2type=N'COLUMN', @level2name=N'TournamentTypeName';

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Description of the tournament type.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'TournamentTypes', 
    @level2type=N'COLUMN', @level2name=N'Description';



--Tournaments Table
EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'Table storing information about tournaments.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'Tournaments';

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'The primary key of the Tournaments table.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'Tournaments', 
    @level2type=N'COLUMN', @level2name=N'TournamentID';

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'The user who created the tournament.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'Tournaments', 
    @level2type=N'COLUMN', @level2name=N'UserID';

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'The name of the tournament.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'Tournaments', 
    @level2type=N'COLUMN', @level2name=N'TournamentName';

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'The discipline of the tournament.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'Tournaments', 
    @level2type=N'COLUMN', @level2name=N'DisciplineID';

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'The type of the tournament.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'Tournaments', 
    @level2type=N'COLUMN', @level2name=N'TournamentTypeID';

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'The number of teams in the tournament.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'Tournaments', 
    @level2type=N'COLUMN', @level2name=N'NumberOfTeams';

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'The start date of the tournament.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'Tournaments', 
    @level2type=N'COLUMN', @level2name=N'StartDate';

EXEC sys.sp_addextendedproperty 
    @name=N'MS_Description', 
    @value=N'The end date of the tournament.', 
    @level0type=N'SCHEMA', @level0name=N'dbo', 
    @level1type=N'TABLE', @level1name=N'Tournaments', 
    @level
