# bugnet-mvc
This is a MVC based version of the BugNET Issue Tracker using ASP.NET 5 / MVC 6

## Regenerate EF Models
To regenerate the EF models you can use the following from the command line:

```
dnx ef dbcontext scaffold "Server=(localdb)\\mssqllocaldb;Database=BugNET.Database;Trusted_Connection=True;MultipleActiveResultSets=true"  EntityFramework.MicrosoftSqlServer -o Models
```
Some massaging after needs to be done to delete the AspNet* models and remove pluralization and BugNet_ prefix.
