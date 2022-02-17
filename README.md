# About system
Basic task management system. Features :
1. Create organisation with default admin user from register
2. Edit organisation deatails
3. Add new users to organisation.
4. New users can login with given credentials
5. View user's profile
6. View organisation's ticket board
7. Create/Edit/New organisation's tickets
8. Assign ticket to organisation member
9. Notify member about assignment with email

# Technical Stack
- ASP.NET Core 5.0 (with .NET Core 5.0)
- ASP.NET Identity Core
- Entity Framework Core
- .NET Core Native DI
- FluentValidator
- PostgreSQL
- MimeKit
- MailKit
- Newtonsoft.Json 

# Design Patterns
- Unit Of Work
- Repository & Generic Repository
- ORM
- Inversion of Control / Dependency injection

# Sotware architecture
- N-tier architecture

# Prerequirements
- Visual Studio 2019+
- .NET Core 5
- EF Core
- Docker
- Docker-compose

# How To Run
- Clone repository and open `kanban` folder
- Run docker : `docker-compose -f _development/docker-compose.yml up --build -d`
- Application will be started on : `http://localhost:5000/`
- I added additional container (`portrainer`) to manage dockers so you can check it :  `http://localhost:9000/`  

# How To Restore default db
- `cd _development/backups`
- Run command : `cat dumb_data_only.sql | docker exec -i postgre-db psql -U kanban-user kanban-db`

# Additional notes:
- If you want to add your smtp email credentials you can do this by changing env file in `_development/envs/web.env`


