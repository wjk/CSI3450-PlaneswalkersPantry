# How to run Planeswalker's Pantry

1. Install MySQL Community Server. This must be installed on the same host as the web application will be running from.
   Also install MySQL Workbench.
2. Open MySQL Workbench and connect as the root user. Copy and paste the contents of the following file into the script window:
   [`src/PlaneswalkersPantry/SqlScripts/CreateDatabase.sql`](src/PlaneswalkersPantry/SqlScripts/CreateDatabase.sql).
   Run the entire script.
3. In MySQL Workbench, connect as the PlaneswalkersPantry user. (The password is `PlaneswalkersPantry123`.) Copy and paste
   the contents of the following file into the script window: [`src/PlaneswalkersPantry/SqlScripts/SharedCards.sql`](src/PlaneswalkersPantry/SqlScripts/SharedCards.sql). Run the entire script.
4. While still connected as the PlaneswalkersPantry user, copy and paste the contents of the following file into the script
   window: [`src/PlaneswalkersPantry/SqlScripts/DomainDMU.sql`](src/PlaneswalkersPantry/SqlScripts/DomainDMU.sql). Run the entire script.
5. While still connected as the PlaneswalkersPantry user, copy and paste the contents of the following file into the script
   window: [`src/PlaneswalkersPantry/SqlScripts/sol4r1s deck.sql`](src/PlaneswalkersPantry/SqlScripts/sol4r1s deck.sql). Run the entire script.
6. Install .NET 6. Go to [Microsoft's website](https://dotnet.microsoft.com/en-us/download) and download the .NET 6.0 SDK (not the .NET 7
   SDK, and not the hosting bundle or shared runtime).
7. Open a terminal and `cd` into the `src/PlaneswalkersPantry` subdirectory. Execute `dotnet run`. A Web browser window should
   appear containing the home page of the web application.
