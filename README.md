# Luke-n-Phil-Dog-Show

Setup:
  In Package Manager:
    Install the following packages:
      Microsoft.AspNetCore.Identity
      Microsoft.AspNetCore.Identity.EntityFrameworkCore
      Microsoft.EntityFrameworkCore
      Microsoft.EntityFrameworkCore.Design
      Microsoft.EntityFrameworkCore.SqlServer
      Microsoft.VisualStudio.Web.CodeGeneration.Design
      FluentEmail.Mailgun
  In SQL Server Object Explorer:
    Create database 'dogshow'
    Open properties panel and copy database connection string
  In appsettings.json:
    Paste connection string in the value quotes for "Default Connection"
  In Package Manager Console:
    Run 'dotnet-ef database update'
  Note: Your email needs to be configured in Mailgun in order to receive emails sent by the program.
