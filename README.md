# Change Management Inventory
This project was made with the purpose of learning .Net MVC Framework, Entity Framework and Razor

## Entity Framework CLI commands

To create Migration file use:
```PS
add-migration <MigrationName>
```

To update database with current migration file use:

```PS
update-database
```

## Troubleshooting

### Cannot find path of ..\rosly\csc.exe 

Run

```
Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
```
