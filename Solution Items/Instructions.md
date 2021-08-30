Set connection string in LinksoftStudy.Web in appsettings.json.
Database is created automatically based on settings in LinksoftStudy.Web in appsettings.json.

Manually updating database using Package manager console:
1. Select LinksoftStudy.Data project
2. Update-Database

Manually adding migration using Package manager console:
1. Create Entity
2. add DbSet in Context
3. Create migration using Package manager console
	3.1 Select LinksoftStudy.Data project
	3.1 Add-Migration $"{yyyyMMdd}_{migration-name}"