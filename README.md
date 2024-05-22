
---

# Setting Up Tournament App Database Connection

To connect your Tournament App to the database, follow these instructions to set the appropriate environment variable. This is necessary for the app to establish a connection to the database.

### Windows:

Open Command Prompt and run the following command to set the environment variable:

```bash
setx TournamentAppDBCon "Server=your_server_name;Database=TournamentManagement;User Id=your_username;Password=your_password;TrustServerCertificate=true;"
```

### Mac (bash shell):

Open Terminal and run the following command to set the environment variable. Replace `<connection_string>` with the equivalent connection string for your environment:

```bash
export TournamentAppDBCon="<connection_string>"
```

For example:

```bash
export TournamentAppDBCon="Server=your_server_name;Database=TournamentManagement;User Id=your_username;Password=your_password;"
```

### Linux (bash shell):

Open Terminal and run the following command to set the environment variable. Replace `<connection_string>` with the equivalent connection string for your environment:

```bash
export TournamentAppDBCon="<connection_string>"
```

For example:

```bash
export TournamentAppDBCon="Server=your_server_name;Database=TournamentManagement;User Id=your_username;Password=your_password;"
```

### Notes:

- **Server**: Replace `your_server_name` with your SQL Server instance name or IP address.
- **Database**: Ensure `TournamentManagement` matches your actual database name.
- **User Id** and **Password**: Replace `your_username` and `your_password` with your SQL Server credentials.
- **TrustServerCertificate**: Set to `true` if you want to trust the server certificate (optional).

Ensure the environment variable is set correctly before running the Tournament App to establish a successful database connection.

---

This readme provides platform-specific instructions for setting the `TournamentAppDBCon` environment variable on Windows, Mac (using bash shell), and Linux (using bash shell). Users can replace placeholders with their own database connection details according to their setup. 
